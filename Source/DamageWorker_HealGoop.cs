using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace MoreEccentricMissiles
{
    /// <summary>
    /// Settings for the heal-goop damage type, set on the DamageDef in XML.
    /// </summary>
    public class DamageExtension_HealGoop : DefModExtension
    {
        public FloatRange tendQualityRange = new FloatRange(0.4f, 0.8f);

        public HediffDef hediff;

        public ThoughtDef thought;

        /// <summary>Memories removed before the thought is given, e.g. a lingering follow-up thought.</summary>
        public List<ThoughtDef> removeThoughts;
    }

    /// <summary>
    /// Deals no damage. Tends every wound on non-mechanoid pawns (like Coagulate),
    /// then applies the heal-goop hediff and mood thought.
    /// </summary>
    public class DamageWorker_HealGoop : DamageWorker
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            DamageResult result = new DamageResult();
            if (!(victim is Pawn pawn) || pawn.Dead || pawn.RaceProps.IsMechanoid)
            {
                return result;
            }
            DamageExtension_HealGoop props = def.GetModExtension<DamageExtension_HealGoop>() ?? new DamageExtension_HealGoop();

            int tended = 0;
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs;
            for (int i = hediffs.Count - 1; i >= 0; i--)
            {
                if ((hediffs[i] is Hediff_Injury || hediffs[i] is Hediff_MissingPart) && hediffs[i].TendableNow())
                {
                    hediffs[i].Tended(props.tendQualityRange.RandomInRange, props.tendQualityRange.TrueMax, 1);
                    tended++;
                }
            }

            if (props.hediff != null)
            {
                Hediff existing = pawn.health.hediffSet.GetFirstHediffOfDef(props.hediff);
                if (existing != null)
                {
                    existing.TryGetComp<HediffComp_Disappears>()?.ResetElapsedTicks();
                }
                else
                {
                    pawn.health.AddHediff(props.hediff);
                }
            }

            MemoryThoughtHandler memories = pawn.needs?.mood?.thoughts?.memories;
            if (memories != null)
            {
                if (props.removeThoughts != null)
                {
                    foreach (ThoughtDef removed in props.removeThoughts)
                    {
                        memories.RemoveMemoriesOfDef(removed);
                    }
                }
                if (props.thought != null)
                {
                    memories.TryGainMemory(props.thought);
                }
            }

            if (pawn.Spawned)
            {
                if (tended > 0)
                {
                    MoteMaker.ThrowText(pawn.DrawPos, pawn.Map, "NumWoundsTended".Translate(tended), 3.65f);
                }
                FleckMaker.AttachedOverlay(pawn, FleckDefOf.FlashHollow, Vector3.zero, 1.5f);
            }
            return result;
        }
    }
}

using System.Collections.Generic;
using EccentricProjectiles;
using RimWorld;
using Verse;

namespace MoreEccentricMissiles
{
    /// <summary>
    /// Damage dealt to pawns standing in the impact cell, before the projectile explodes.
    /// </summary>
    public class ProjectileExtension_ImpactDamage : DefModExtension
    {
        public DamageDef damageDef;

        public int amount;

        public float armorPenetration;
    }

    /// <summary>
    /// Eccentric staged missile that hits pawns in the impact cell with a direct impact
    /// (see ProjectileExtension_ImpactDamage) before exploding normally. The impact is applied
    /// first so the heal-goop explosion tends the resulting wound as well.
    /// </summary>
    public class Projectile_HealGoopMissile : Projectile_ExplosiveStagedWithEffects
    {
        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            if (!blockedByShield)
            {
                ApplyImpactDamage(hitThing);
            }
            base.Impact(hitThing, blockedByShield);
        }

        private void ApplyImpactDamage(Thing hitThing)
        {
            ProjectileExtension_ImpactDamage props = def.GetModExtension<ProjectileExtension_ImpactDamage>();
            if (props?.damageDef == null || props.amount <= 0 || base.Map == null)
            {
                return;
            }
            List<Pawn> victims = new List<Pawn>();
            if (hitThing is Pawn hitPawn)
            {
                victims.Add(hitPawn);
            }
            foreach (Thing thing in base.Map.thingGrid.ThingsListAt(base.Position))
            {
                if (thing is Pawn pawn && !victims.Contains(pawn))
                {
                    victims.Add(pawn);
                }
            }
            float angle = origin.AngleToFlat(destination);
            foreach (Pawn victim in victims)
            {
                if (victim.Destroyed || victim.Dead)
                {
                    continue;
                }
                DamageInfo dinfo = new DamageInfo(props.damageDef, props.amount, props.armorPenetration, angle, launcher, null, equipmentDef, DamageInfo.SourceCategory.ThingOrUnknown, intendedTarget.Thing);
                victim.TakeDamage(dinfo);
            }
        }
    }
}

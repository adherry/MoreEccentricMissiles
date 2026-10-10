# More eccentric Missiles

This mod adds currently 3 additional missile types for the Eccentric tech defense grid mod. All of them are crafted at the fabrication bench (or the Eccentric nanoassembler) once you have researched the defense grid artillery, and fired from your vertical missile launchers like any other PGM.

## M71 PGM (Smoke)

This missile creates a large smoke screen at the destination. Good to approach or cover from static defences

- Effect radius: 9.9 tiles
- Cost: 50 steel, 35 chemfuel, 2 components
- Requires: Smokepop belt research

## M72 PGM (Flare) req. Eccentric Extras: Flare

This missile creates a flare at the destination. Good if you either do not believe in Flare guns, do not want to bother with Mortars or resource efficiency in general. 

- Effect radius: 2.9 tiles
- Cost: 50 steel, 40 chemfuel, 2 components
- Requires: Eccentric Extras - Flares to be active

## M73 PGM (Heal)

This missile bursts into a cloud of light blue heal-goop at the destination, tending all wounds of every non-mechanoid pawn caught in it (kind of like a Coagulate). This missile needs Glitter meds to create and people absolutely hate to be tended to by Missile, due to the deployment speed of the Mechanite solution. And its Sticky, very sticky.

- Effect radius: 1.9 tiles
- Tends all wounds of every pawn in the blast, except mechanoids
- A direct hit still deals 5 blunt damage, which the goop then tends as well
- Patients get "heal-goop numbing" (-10% pain) for 6 hours, and "disgusting heal-goop" (-10 mood) for 1 day, which then turns into "I still feel sticky" (-5 mood) for another day
- Leaves sticky light blue goop on the ground
- Can target pawns or locations, and tracks moving targets like the M48 PGM (HEAT)
- Healing is not considered an attack, so it can be used on visitors and allies without goodwill loss (a direct hit still counts as one)
- Cost: 50 steel, 20 silver, 35 chemfuel, 4 glitterworld medicine
- Requires: Medicine production research

# Requirements

- [Eccentric Tech - Defense Grid](https://steamcommunity.com/sharedfiles/filedetails/?id=3066838686) (and its own requirements)
- Optional: [Eccentric Extras - Flares](https://steamcommunity.com/sharedfiles/filedetails/?id=2552628275) for the M72

# Building

The M73 needs a small C# assembly. Build it with the .NET SDK:

```
dotnet build Source -c Release
```

This writes `1.6/Assemblies/MoreEccentricMissiles.dll`. The game and Workshop paths in `Source/MoreEccentricMissiles.csproj` default to a Linux Steam library; override them with `-p:RimWorldManaged=<.../Managed>` and `-p:WorkshopDir=<.../workshop/content/294100>`.

# Acknowledgements

- A big thank you to Aelanna, the author of the original Eccentric Tech series, without whom none of this would exist
- Missiles were created and kindly provided by Aelanna
- Implementation was greatly helped by Aelanna as she taught me the way of the missile

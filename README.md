# More eccentric Missiles

This mod adds currently 2 additional missile types for the Eccentric tech defense grid mod:

## M71 PGM (Smoke)

This missile creates a large smoke screen at the destination. Good to approach or cover from static defences

## M72 PGM (Flare) req. Eccentric Extras: Flare

This missile creates a flare at the destination. Good if you either do not believe in Flare guns, do not want to bother with Mortars or resource efficiency in general. 

## M73 PGM (Heal)

This missile bursts into a 1.9 tile cloud of light blue heal-goop at the destination, tending all wounds of every non-mechanoid pawn caught in it (kind of like a Coagulate). A direct hit still deals 5 blunt damage, which the goop then tends as well. This missile needs Glitter meds to create and people absolutely hate to be tended to by Missile, due to the deployment speed of the Mechanite solution: patients get "disgusting heal-goop" (-10 mood) and "heal-goop numbing" (-10% pain) for 6 hours. And its Sticky, very sticky.

It can target locations or pawns and tracks moving targets like the M48 PGM (HEAT).

# Building

The M73 needs a small C# assembly. Build it with the .NET SDK:

```
dotnet build Source -c Release
```

This writes `1.6/Assemblies/MoreEccentricMissiles.dll`. The game and Workshop paths in `Source/MoreEccentricMissiles.csproj` default to a Linux Steam library; override them with `-p:RimWorldManaged=<.../Managed>` and `-p:WorkshopDir=<.../workshop/content/294100>`.

# Acknowledgements

- Missiles were created and kindly provided by Aelanna
- Implementation was greatly helped by Aelanna as she taught me the way of the missile
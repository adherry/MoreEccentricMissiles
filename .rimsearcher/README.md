# RimSearcher Project Environment

- Status: Complete

## Tool Versions

- Project CLI: 3.2.0 (Linux x64 build, `.rimsearcher/rimsearcher`)
- Database Version: DataMod export 3.2.0 (SQLite user_version 30200; CLI supports 3.1.5–3.2.0)

## Game Locations

- Game Root: /mnt/games/SteamLibrary/steamapps/common/RimWorld (1.6.4871 rev598, Linux)
- Game DLL Directory: /mnt/games/SteamLibrary/steamapps/common/RimWorld/RimWorldLinux_Data/Managed
- Core Assembly Assembly-CSharp.dll: /mnt/games/SteamLibrary/steamapps/common/RimWorld/RimWorldLinux_Data/Managed/Assembly-CSharp.dll
- DataMod Installation Directory: /home/sven/Nextcloud/RimworldMods/RimSearcher_DataMod (`<GameRoot>/Mods` symlinks to /home/sven/Nextcloud/RimworldMods; installed from bundled DataMod zip, plugin 3.2.0)

## Dependent Mods

- Mod Directories (Steam Workshop, read-only):
  - Harmony (brrainz.harmony): /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2009463077
  - Eccentric Tech - Defense Grid (Aelanna.EccentricTech.DefenseGrid): /mnt/games/SteamLibrary/steamapps/workshop/content/294100/3066838686
  - Eccentric Tech - Core (Aelanna.EccentricTech.Core, transitive via Defense Grid): /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2552623545
  - Eccentric Extras - Flares (Aelanna.EccentricTech.Flares2, optional): /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2552628275
- Relevant Assembly DLLs:
  - /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2009463077/Current/Assemblies/0Harmony.dll
  - /mnt/games/SteamLibrary/steamapps/workshop/content/294100/3066838686/1.6/Assemblies/EccentricDefenseGrid.dll
  - /mnt/games/SteamLibrary/steamapps/workshop/content/294100/3066838686/1.6/Assemblies/0EccentricProjectiles.dll
  - /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2552628275/1.6/Assemblies/EccentricFlares.dll
  - /mnt/games/SteamLibrary/steamapps/workshop/content/294100/2552623545/1.6/Assemblies/EccentricTools.dll

## Def Snapshot

- Project Database: defs.db beside this README
- Export Source Path: /mnt/games/SteamLibrary/steamapps/common/RimWorld/Mods/RimSearcher_DataMod/defs.db
- Export Timestamp: 2026-10-10 19:27 (file mtime)
- Game Version, DLCs, Active Mods & Load Order: RimWorld 1.6.4871; Core, Royalty, Ideology, Biotech, Anomaly, Odyssey; Harmony, Eccentric Tech - Core, Eccentric Tech - Defense Grid, Eccentric Extras - Flares, More Eccentric Missiles (installed copy from ~/Nextcloud/RimworldMods, 6 defs), RimSearcherDataMod. Exact load order not recorded in the snapshot.

## Notes

- The bundled `rimsearcher.exe` is Windows-only; this project uses the Linux build from `~/.local/share/rimsearcher/rimsearcher`.
- The installed copy of this mod lives at /home/sven/Nextcloud/RimworldMods/MoreEccentricMissiles (separate from this clone).
- DecompilerServer MCP: v1.4.0 at ~/.local/share/decompiler-server/DecompilerServer, registered user-scope as `decompiler`. Verified 2026-10-10: loaded Assembly-CSharp.dll and decompiled `Verse.Pawn.get_IsColonist`.
  - Load game with `load_assembly(assemblyPath=<Core Assembly path above>, contextAlias="rw16")`. On Linux, use the explicit path: the gameDir auto-detection may expect `RimWorldWin64_Data`.
  - For mod DLLs, pass `additionalSearchDirs` = game Managed dir + Eccentric Tech Core / Defense Grid / Harmony Assemblies dirs. Aliases used: `etdg` (EccentricDefenseGrid), `etproj` (0EccentricProjectiles), `ettools` (EccentricTools), `etflares` (EccentricFlares).
  - The server keeps at most 4 contexts resident by default (`DECOMPILER_MAX_LOADED_CONTEXTS`); loading a 5th evicts the oldest, so re-load as needed.

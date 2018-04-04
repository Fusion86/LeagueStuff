# LeagueStuff

Just for fun.


## Image

![Katarina](https://raw.githubusercontent.com/Fusion86/LeagueStuff/master/Docs/Katarina.png)


## Projects

### Katarina

DLL. Mostly used for research.

### KatarinaInjector

Simple commandline DLL injector.  
Usage: `KatarinaInjector.exe ProcessName DllFile.dll`

### KatarinaInjectorGUI

Simple DLL injector with GUI. Loads DLLs from `./Inject`.  
Only supports injecting DLLs into LeagueClient or LeagueClientUx.

### KatarinaMini

DLL. Used by Hextech. Displays password and port when injected into LeagueClientUx.

### Spellthief

Tries to give files dumped with LeagueClient's `libzstd-ZSTD_decompress-dump` a sensible name.


## References

- https://nickcano.com/reversing-league-of-legends-client/
- https://medium.com/@behrmann/league-client-update-extra-insights-f9f05c427657
- https://github.com/msgpack/msgpack/blob/master/spec.md


## F.A.Q

**Q:** Can Riot detect this?  
**A:** 100% yes


## Riot's Stance on Third Party Applications

*No software should interfere directly with the in-game player experience, from when you press “Play” to the end-of-game screen* - [Riot](https://support.riotgames.com/hc/en-us/articles/225266848-Third-Party-Applications)

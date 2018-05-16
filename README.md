# LeagueStuff

Just for fun.


## Image

![Katarina](https://raw.githubusercontent.com/Fusion86/LeagueStuff/master/Docs/Katarina.png)


## Projects

### Hextech.LeagueClient

Communicate with the LeagueClient API.

### Katarina

DLL. Mostly used for research. Use Xenos Injector (or any other) to inject into LeagueClient or LeagueClientUx.

### PassportPls

GUI tool to grab the password and port for the LeagueClient API.

### Spellthief

Tries to give files dumped with LeagueClient's `libzstd-ZSTD_decompress-dump` a sensible name.


## References

- https://nickcano.com/reversing-league-of-legends-client/
- https://medium.com/@behrmann/league-client-update-extra-insights-f9f05c427657
- https://github.com/msgpack/msgpack/blob/master/spec.md


## F.A.Q

**Q:** Can Riot detect this?  
**A:** They could detect Katarina and mistake it for a cheating application. Hextech.LeagueClient should be fine since it uses the LeagueClient API directly and doesn't inject DLL's or hook methods.


## Riot's Stance on Third Party Applications

*No software should interfere directly with the in-game player experience, from when you press “Play” to the end-of-game screen* - [Riot](https://support.riotgames.com/hc/en-us/articles/225266848-Third-Party-Applications)

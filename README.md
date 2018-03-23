# LeagueStuff

Just for fun.


## Image

![Katarina](https://raw.githubusercontent.com/Fusion86/LeagueStuff/master/Docs/Katarina.png)


## Projects

## Ahri

.NET Core 2 library to talk with the LeagueClientApi. It's going to be a pita to get it to work so I'll probably just make a (Node.Js) JavaScript library (because there we don't need types).

### Katarina

The DLL that you inject into either LeagueClient or LeagueClientUx.

### Spellthief

Tries to give files dumped with LeagueClient's `libzstd-ZSTD_decompress-dump` a sensible name.

### Xayah

Downloads the API documentation (which btw is also accessible with Swagger UI afaik). Get password and port with LeagueClientUx's `libcef-cef_parse_url-print`.  
It's probably better to just download `https://127.0.0.1:{port}/v3/openapi.json`.


## References

- https://nickcano.com/reversing-league-of-legends-client/
- https://medium.com/@behrmann/league-client-update-extra-insights-f9f05c427657
- https://github.com/msgpack/msgpack/blob/master/spec.md


## F.A.Q

**Q:** Can Riot detect this?  
**A:** 100% yes


## Riot's Stance on Third Party Applications

*No software should interfere directly with the in-game player experience, from when you press “Play” to the end-of-game screen* - [Riot](https://support.riotgames.com/hc/en-us/articles/225266848-Third-Party-Applications)

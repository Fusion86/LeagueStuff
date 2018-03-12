var katarinaThread;

function KatarinaMain()
{
    if (processName != "LeagueClient.exe")
    {
        return 1;
    }

    while (katarinaThread)
    {

    }
}

function dllmain(reason)
{
    switch (reason)
    {
        case "ATTACH":
            katarinaThread = CreateThread(KatarinaMain);
    }
}
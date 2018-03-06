#include "stdafx.h"

#include "LuxApp.h"
#include "LeagueClient.h"

HMODULE library;
HANDLE modThread;

DWORD WINAPI LuxMain(LPVOID pThreadParameter)
{
	WCHAR szExePath[MAX_PATH + 1]; // +1 for zero terminated string
	DWORD len = GetModuleFileNameW(NULL, szExePath, MAX_PATH);

	if (len == 0)
	{
		printf("[LuxMain] Couldn't get main process name!\n");
		return 1;
	}

	LPWSTR exeName = PathFindFileName(szExePath);

	printf("[LuxMain] Main path: %ls\n", szExePath);
	printf("[LuxMain] Main process: %ls\n", exeName);

	Lux::LuxApp *app = nullptr;

	if (_wcsicmp(exeName, L"LeagueClient.exe") == 0)
	{
		printf("[LuxMain] Loading LeagueClient LuxApp\n");
		app = new Lux::LeagueClient();
	}
	else if (_wcsicmp(exeName, L"LeagueClientUx.exe") == 0)
	{
		printf("[LuxMain] Loading LeagueClientUx LuxApp\n");
		//app = new Lux::LeagueClientUx();
	}
	else
	{
		printf("[LuxMain] We can't do anything with this process!\n");
		return 1;
	}

	if (app != nullptr)
	{
		int res = app->Initialize(szExePath);

		if (res != 0)
		{
			printf("[LuxMain] LuxApp initialization failed!\n");
		}
		else
		{
			app->PrintKeybinds();

			while (!GetAsyncKeyState(VK_F5) && modThread)
			{
				res = app->Render();

				if (res != 0)
				{
					printf("[LuxMain] Render() returned error code %i!\n", res);
					break;
				}
				else
				{
					Sleep(10);
				}
			}
		}

		app->Uninitialize();
		delete app;
	}

	return 0;
}

void SetupConsole()
{
	AllocConsole();
	freopen("CONOUT$", "wb", stdout);
	freopen("CONOUT$", "wb", stderr);
	//freopen("CONIN$", "rb", stdin);
	SetConsoleTitle(L"Lux");
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		library = hModule;
		SetupConsole();
		modThread = CreateThread(0, 0, LuxMain, 0, 0, NULL);
		printf("[DllMain] Lux says hello!\n");
		break;
	case DLL_PROCESS_DETACH:
		if (modThread)
			CloseHandle(modThread);
		break;
	}

	return true;
}

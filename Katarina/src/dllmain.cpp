#include "stdafx.h"

#include "Katarina/LeagueBase.h"
#include "Katarina/LeagueClient.h"

HMODULE library;

BOOL WINAPI ConsoleHandlerRoutine(DWORD dwCtrlType)
{
	if (dwCtrlType == CTRL_CLOSE_EVENT)
	{
		return true;
	}

	return false;
}

void Run()
{
	AllocConsole();
	/*HWND hWnd =*/ GetConsoleWindow();
	freopen("CONOUT$", "w", stdout);
	freopen("CONOUT$", "wb", stderr);

	SetConsoleTitle(L"Katarina");
	SetConsoleCtrlHandler(ConsoleHandlerRoutine, true);

	auto logger = spdlog::stdout_color_mt("Katarina");

#ifdef _DEBUG
	spdlog::set_level(spdlog::level::debug);
#endif


	logger->info("Start");

	WCHAR szFilePath[MAX_PATH + 1];
	GetModuleFileName(NULL, szFilePath, MAX_PATH + 1);

	fs::path filePath(szFilePath);
	std::string fileName = filePath.stem().string();

	logger->info("Executable: {}", fileName);

	Katarina::LeagueBase* app = nullptr;

	if (fileName == "LeagueClient") app = new Katarina::LeagueClient();

	int res = 0;
	if (app == nullptr)
	{
		logger->error("I don't know what to do with this executable.");
	}
	else
	{
		res = app->Initialize();

		if (res == 0)
		{
			app->Run(); // This will block untill we app->Shutdown();

			res = app->Uninitialize();
		}
	}

	logger->info("Exit");

	FreeConsole();
	FreeLibraryAndExitThread(library, res);
}

bool APIENTRY DllMain(HMODULE hModule, DWORD  dwReason, LPVOID lpReserved)
{
	if (dwReason == DLL_PROCESS_ATTACH)
	{
		library = hModule;
		CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)Run, NULL, NULL, NULL);
	}

	return true;
}

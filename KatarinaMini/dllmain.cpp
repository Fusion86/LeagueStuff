#include "stdafx.h"

HMODULE library;
std::atomic<bool> wantExit;
fs::path appPath;
fs::path quietPath;
bool quiet;

decltype(&cef_parse_url) orig_cef_parse_url;

int hk_cef_parse_url(const cef_string_t* url, cef_urlparts_t* parts)
{
	wchar_t* ptr = wcsstr(url->str, L"riot:");
	if (ptr != NULL && !wantExit)
	{
		std::wstring full(url->str);

		size_t passStart = full.find(L"riot:") + 5; // 5 = strlen of `riot:`
		size_t passEnd = full.find(L"@127.0.0.1:");
		size_t portStart = passEnd + wcslen(L"@127.0.0.1:");

		std::wstring password = full.substr(passStart, passEnd - passStart);
		std::wstring port = full.substr(portStart, 5); // lets just assume that the portnumber is exactly 5 digits

		if (quiet)
		{
			fs::path outPath(appPath);
			outPath /= "auth";

			std::wofstream out(outPath);
			out << password << L"," << port << std::endl;
			out.close();
		}
		else
		{
			if (OpenClipboard(NULL))
			{
				EmptyClipboard();
				size_t size = (password.size() + 1) * sizeof(WCHAR);
				HGLOBAL hClipboardData = GlobalAlloc(NULL, size);
				if (hClipboardData)
				{
					WCHAR* pchData = (WCHAR*)GlobalLock(hClipboardData);
					if (pchData)
					{
						memcpy(pchData, password.c_str(), size);
						GlobalUnlock(hClipboardData);
						SetClipboardData(CF_UNICODETEXT, hClipboardData);
					}
				}
				CloseClipboard();
			}
			else
			{
				MessageBoxW(NULL, L"Couldn't open clipboard!", L"KatarinaMini Error", NULL);
			}

			std::wstring msg = L"Password: " + password + L"\nPort: " + port + L"\n\nPassword is also copied into the clipboard.";

			MessageBoxW(NULL, msg.c_str(), L"", NULL);
		}

		wantExit = true;


		//std::wregex re(L"riot:(.*)@127.0.0.1:(\d+)\/");
		//std::wsmatch matches;

		//if (std::regex_search(full, matches, re))
		//{
		//	std::wstring password = matches[1].str();
		//	std::wstring port = matches[2].str();

		//	std::wstring msg = L"Password: " + password + L"\nPort: " + port;
		//	MessageBoxW(NULL, msg.c_str(), L"KatarinaMini", NULL);
		//}
	}

	return orig_cef_parse_url(url, parts);
}

void Run()
{
	const char* appdata = getenv("APPDATA");
	appPath.assign(appdata);
	appPath /= "Katarina";
	appPath /= "KatarinaMini";

	fs::create_directories(appPath);

	quietPath.assign(appPath);
	quietPath /= "quiet";

	quiet = fs::exists(quietPath);

	if (MH_Initialize() != MH_OK)
	{
		MessageBoxW(NULL, L"Couldn't initialize MinHook!", L"KatarinaMini Error", NULL);
		goto exit;
	}

	if (MH_CreateHookApi(L"libcef", "cef_parse_url", &hk_cef_parse_url, (LPVOID*)&orig_cef_parse_url) != MH_OK)
	{
		MessageBoxW(NULL, L"Couldn't create cef_parse_url ApiHook!", L"KatarinaMini Error", NULL);
		goto exit;
	}

	if (MH_EnableHook(MH_ALL_HOOKS) != MH_OK)
	{
		MessageBoxW(NULL, L"Couldn't enable all hooks!", L"KatarinaMini Error", NULL);
		goto exit;
	}

	while (!wantExit)
	{
		// If we started in quiet modus, but the quiet lockfile has been remove since, then exit
		// This happens if a program requested the auth data but exited before getting them
		if (quiet)
			if (!fs::exists(quietPath))
				wantExit = true;

		Sleep(2000);
	}

exit:
	MH_Uninitialize();

	// Make 100% sure that the file is deleted (the program that created it should remove it, but we are just making sure that it really is removed)
	if (quiet)
	{
		_wremove(quietPath.c_str());
	}

	FreeLibraryAndExitThread(library, 0);
}

bool APIENTRY DllMain(HMODULE hModule, DWORD  dwReason, LPVOID lpReserved)
{
	if (dwReason == DLL_PROCESS_ATTACH)
	{
		library = hModule;
		CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)Run, NULL, NULL, NULL);
	}
	else if (dwReason == DLL_PROCESS_DETACH)
	{
		MH_Uninitialize(); // Probably not needed, but might fix a few crashes?
	}

	return true;
}

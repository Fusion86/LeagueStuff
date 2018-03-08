#include "stdafx.h"

#include "LeagueClient.h"

#include "typedef/openssl.h"
#include "typedef/curl.h"

extern "C"
{
#pragma region OpenSSL

	decltype(&SSL_use_PrivateKey) orig_SSL_use_PrivateKey = NULL;

	int hk_SSL_use_PrivateKey(SSL* ssl, EVP_PKEY* pkey)
	{
		printf("[LeagueClient SSL_use_PrivateKey]\n");
		return orig_SSL_use_PrivateKey(ssl, pkey);
	}

#pragma endregion

#pragma region CURL

	decltype(&curl_easy_setopt) orig_curl_easy_setopt = NULL;

	CURLcode hk_curl_easy_setopt(CURL *curl, CURLoption option, void* data)
	{
		printf("[LeagueClient curl_easy_setopt] option: %i ", option);

		if (_curl_is_string_option(option))
		{
			printf("set: %s", data);
		}
		else
		{
			printf("set: %i", data);
		}

		printf("\n");

		return orig_curl_easy_setopt(curl, option, data);
	}

#pragma endregion

#pragma region Windows

	decltype(&BringWindowToTop) orig_BringWindowToTop = NULL;
	decltype(&SetWindowPos) orig_SetWindowPos = NULL;
	decltype(&SetForegroundWindow) orig_SetForegroundWindow = NULL;

	bool WINAPI hk_BringWindowToTop(_In_ HWND hWnd)
	{
		printf("[LeagueClient BringWindowToTop] Blocked call!\n");
		return true;
	}

	BOOL WINAPI hk_SetWindowPos(
		_In_ HWND hWnd,
		_In_opt_ HWND hWndInsertAfter,
		_In_ int  X,
		_In_ int  Y,
		_In_ int  cx,
		_In_ int  cy,
		_In_ UINT uFlags)
	{
		printf("[LeagueClient SetWindowPos] ");

		if (hWndInsertAfter == HWND_TOP)
		{
			printf("hWndInsertAfter = HWND_TOP ");
			hWndInsertAfter = HWND_NOTOPMOST;
		}

		printf("\n");

		return orig_SetWindowPos(hWnd, hWndInsertAfter, X, Y, cx, cy, uFlags);
	}

	BOOL WINAPI hk_SetForegroundWindow(_In_ HWND hWnd)
	{
		printf("[LeagueClient SetForegroundWindow] Blocked call!\n");
		return true;
	}

#pragma endregion
}

namespace Lux
{
	LeagueClient::LeagueClient()
	{
	}

	LeagueClient::~LeagueClient()
	{
	}

	HRESULT LeagueClient::Initialize(LPCWSTR szExePath)
	{
		int res = LuxApp::Initialize(szExePath);
		if (res != 0) return res;

		return 0;
	}

	HRESULT LeagueClient::Uninitialize()
	{
		int res = LuxApp::Uninitialize();
		if (res != 0) return res;

		return 0;
	}

	HRESULT LeagueClient::Render()
	{
		return 0;
	}

	void LeagueClient::RegisterKeybinds()
	{
		LuxApp::RegisterKeybinds();
	}

	void LeagueClient::RegisterHooks()
	{
		LUX_ADDHOOK("libssl-1_1", SSL_use_PrivateKey);

		LUX_ADDHOOK("libcurl", curl_easy_setopt);

		// TODO: This needs to be in 
		//LUX_ADDHOOK("User32", BringWindowToTop); // Useless
		//LUX_ADDHOOK("User32", SetWindowPos);
		//LUX_ADDHOOK("User32", SetForegroundWindow);
	}
}

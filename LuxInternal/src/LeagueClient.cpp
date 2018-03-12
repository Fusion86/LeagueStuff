#include "stdafx.h"

#include "LeagueClient.h"

#include <iostream>

#include "typedef/openssl.h"
#include "typedef/cef.h"
#include "typedef/curl.h"
#include "typedef/zstd.h"

#include "memdmp.h"

extern "C"
{

	fs::path g_dmpPath;

#pragma region OpenSSL

	decltype(&SSL_use_PrivateKey) orig_SSL_use_PrivateKey = NULL;
	decltype(&SSL_connect) orig_SSL_connect = NULL;

	int hk_SSL_use_PrivateKey(SSL* ssl, EVP_PKEY* pkey)
	{
		printf("[LeagueClient SSL_use_PrivateKey]\n");
		return orig_SSL_use_PrivateKey(ssl, pkey);
	}

	int hk_SSL_connect(SSL *ssl)
	{
		int res = orig_SSL_connect(ssl);
		printf("[LeagueClient SSL_connect] result: %i\n", res);
		return res;
	}

#pragma endregion

#pragma region CEF

	decltype(&cef_parse_url) orig_cef_parse_url;

	int hk_cef_parse_url(const cef_string_t* url, struct _cef_urlparts_t* parts)
	{
		printf("[LeagueClient cef_parse_url] Port: %ls\n", parts->port.str);
		return orig_cef_parse_url(url, parts);
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

#pragma region ZSTD

	decltype(&ZSTD_decompress) orig_ZSTD_decompress;

	ZSTDLIB_API size_t hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);

		SYSTEMTIME st;
		GetLocalTime(&st);

		std::stringstream ss;
		ss << "luxdmp--" << st.wYear << "-" << st.wMonth << "-" << st.wDay 
			<< "--" << st.wHour << "-" << st.wMinute << "-" << st.wSecond << "-" << st.wMilliseconds << ".bin";

		fs::path path(g_dmpPath);
		path /= ss.str();

		memdmp(path.string().c_str(), dst, dstCapacity);
		std::cout << "[LeagueClient ZSTD_decompress] Dumped to '" << path << "'" << std::endl;

		return res;
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

		g_dmpPath = dumpPath;

		return 0;
	}

	//HRESULT LeagueClient::Uninitialize()
	//{
	//	int res = LuxApp::Uninitialize();
	//	if (res != 0) return res;

	//	return 0;
	//}

	//HRESULT LeagueClient::Render()
	//{
	//	return 0;
	//}

	//void LeagueClient::RegisterKeybinds()
	//{
	//	LuxApp::RegisterKeybinds();
	//}

	void LeagueClient::RegisterHooks()
	{
		LUX_ADDHOOK("libssl-1_1", SSL_use_PrivateKey);
		LUX_ADDHOOK("libssl-1_1", SSL_connect);

		LUX_ADDHOOK("libcef", cef_parse_url);

		LUX_ADDHOOK("libcurl", curl_easy_setopt);

		LUX_ADDHOOK("libzstd", ZSTD_decompress);

		// TODO: This needs to be in LeagueClientUx (NOT _Render)
		//LUX_ADDHOOK("User32", BringWindowToTop); // Useless
		//LUX_ADDHOOK("User32", SetWindowPos);
		//LUX_ADDHOOK("User32", SetForegroundWindow);
	}
}

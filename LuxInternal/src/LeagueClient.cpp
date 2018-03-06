#include "stdafx.h"

#include "LeagueClient.h"

#include "typedef/openssl.h"

extern "C"
{
	decltype(&SSL_use_PrivateKey) orig_SSL_use_PrivateKey = NULL;

	int hk_SSL_use_PrivateKey(SSL* ssl, EVP_PKEY* pkey)
	{
		printf("[LeagueClient SSL_use_PrivateKey]\n");
		return orig_SSL_use_PrivateKey(ssl, pkey);
	}
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
		LuxApp::AddHook(L"libssl-1_1", "SSL_use_PrivateKey", &hk_SSL_use_PrivateKey, (LPVOID*)&orig_SSL_use_PrivateKey);
	}
}

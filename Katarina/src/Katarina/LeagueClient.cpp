#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hooks/LeagueClient.h>
#include <Katarina/Hooks/Shared.h>

namespace Katarina
{
	namespace LeagueClient
	{
		HRESULT LeagueClient::Initialize()
		{
			int res = LeagueBase::Initialize();
			if (res != 0) return res;

			// Set global vars used by the FeatureHooks
			Hooks::dumpPath = m_dumpPath;

			return 0;
		}

		HRESULT LeagueClient::Uninitialize()
		{
			int res = LeagueBase::Uninitialize();
			if (res != 0) return res;

			return 0;
		}

		void LeagueClient::Update(int delta)
		{
			LeagueBase::Update(delta);
		}

		void LeagueClient::RegisterHooks()
		{
			KAT_RegisterApiHook("libcurl", curl_easy_setopt);
			KAT_RegisterFeatureHook(curl_easy_setopt, print, HookOrder::AfterOriginal);

			KAT_RegisterApiHook("libcurl", curl_multi_perform);
			KAT_RegisterFeatureHook(curl_multi_perform, print, HookOrder::AfterOriginal);

			KAT_RegisterApiHook("libzstd", ZSTD_decompress);
			KAT_RegisterFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);
			KAT_RegisterFeatureHook(ZSTD_decompress, hello, HookOrder::AfterOriginal);

			KAT_RegisterApiHook("Ws2_32", bind);
			KAT_RegisterFeatureHook(bind, print, HookOrder::AfterOriginal);

			KAT_RegisterApiHook("Ws2_32", recv);
			KAT_RegisterFeatureHook(recv, print, HookOrder::AfterOriginal);

			KAT_RegisterSharedApiHook("libssl-1_1", SSL_read);
			KAT_RegisterSharedFeatureHook(SSL_read, print, HookOrder::AfterOriginal);

			KAT_RegisterSharedApiHook("libssl-1_1", SSL_write);
			KAT_RegisterSharedFeatureHook(SSL_write, print, HookOrder::AfterOriginal);
			KAT_RegisterSharedFeatureHook(SSL_write, print_api_events, HookOrder::AfterOriginal);

			KAT_RegisterSharedApiHook("libssl-1_1", SSL_CTX_ctrl);
			KAT_RegisterSharedFeatureHook(SSL_CTX_ctrl, print, HookOrder::AfterOriginal);

			KAT_RegisterSharedApiHook("libssl-1_1", SSL_get_error);
			KAT_RegisterSharedFeatureHook(SSL_get_error, print, HookOrder::AfterOriginal);
		}

		void LeagueClient::RegisterKeybindings()
		{
			LeagueBase::RegisterKeybindings();
		}
	}
}

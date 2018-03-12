#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hooks/LeagueClient.h>

using namespace Katarina::Hooks::LeagueClient;

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{

		int res = LeagueBase::Initialize();
		if (res != 0) return res;

		for (auto const& hook : m_config.Hooks)
		{
			if (hook.Enabled)
			{
				logger->info("We want to enable {}", hook.Identifier);
			}
		}

		return 0;
	}

	HRESULT LeagueClient::Uninitialize()
	{
		int res = LeagueBase::Uninitialize();
		if (res != 0) return res;

		return 0;
	}

	void LeagueClient::RegisterHooks()
	{
		//KAT_AddApiHook("libzstd", ZSTD_decompress);

		//KAT_AddFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);

		LeagueBase::AddApiHook("libzstd", "ZSTD_decompress", &hk_ZSTD_decompress, (LPVOID*)&orig_ZSTD_decompress);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
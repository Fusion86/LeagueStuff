#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hooks/LeagueClient.h>

namespace Katarina
{
	namespace LeagueClient
	{
		HRESULT LeagueClient::Initialize()
		{
			int res = LeagueBase::Initialize();
			if (res != 0) return res;

			m_dumpPath = m_appPath;
			m_dumpPath /= "Dump";
			fs::create_directories(m_dumpPath);

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

		void LeagueClient::RegisterHooks()
		{
			KAT_RegisterApiHook("libzstd", ZSTD_decompress);
			KAT_RegisterFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);
			KAT_RegisterFeatureHook(ZSTD_decompress, hello, HookOrder::AfterOriginal);
		}

		void LeagueClient::RegisterKeybindings()
		{
			LeagueBase::RegisterKeybindings();
		}
	}
}

#include "stdafx.h"

#include <Katarina/LeagueClientUx.h>
#include <Katarina/Hooks/LeagueClientUx.h>

namespace Katarina
{
	namespace LeagueClientUx
	{
		HRESULT LeagueClientUx::Initialize()
		{
			int res = LeagueBase::Initialize();
			if (res != 0) return res;

			return 0;
		}

		HRESULT LeagueClientUx::Uninitialize()
		{
			int res = LeagueBase::Uninitialize();
			if (res != 0) return res;

			return 0;
		}

		void LeagueClientUx::RegisterHooks()
		{
			KAT_RegisterApiHook("libcef", cef_parse_url);
			KAT_RegisterFeatureHook(cef_parse_url, log, HookOrder::AfterOriginal);
		}

		void LeagueClientUx::RegisterKeybindings()
		{
			LeagueBase::RegisterKeybindings();
		}
	}
}

#include "stdafx.h"

#include <Katarina/LeagueClientUx.h>
#include <Katarina/Hooks/LeagueClientUx.h>
#include <Katarina/Hooks/Shared.h>

namespace Katarina
{
	namespace LeagueClientUx
	{
		HRESULT LeagueClientUx::Initialize()
		{
			int res = LeagueBase::Initialize();
			if (res != 0) return res;

			// Set global vars used by the FeatureHooks
			Hooks::dumpPath = m_dumpPath;
			Hooks::ns_cef_parse_url::cef_parse_urls = &cef_parse_urls;

			return 0;
		}

		HRESULT LeagueClientUx::Uninitialize()
		{
			int res = LeagueBase::Uninitialize();
			if (res != 0) return res;

			return 0;
		}

		void LeagueClientUx::Update(int delta)
		{
			LeagueBase::Update(delta);

			if (GetAsyncKeyState(VK_F4))
			{
				fs::path path = m_dumpPath;
				path /= "cef_parse_url--" + Utils::GetDateTimeString() + ".txt";

				logger->info("Writing {} collected urls (from cef_parse_urls) to ''", cef_parse_urls.size(), path);

				std::wofstream ofs(path);
				for (const auto& url : cef_parse_urls)
					ofs << url << '\n';

				cef_parse_urls.clear();
			}
		}

		void LeagueClientUx::RegisterHooks()
		{
			KAT_RegisterApiHook("libcef", cef_parse_url);
			KAT_RegisterFeatureHook(cef_parse_url, print, HookOrder::AfterOriginal);
			KAT_RegisterFeatureHook(cef_parse_url, save_to_file, HookOrder::AfterOriginal);
		}

		void LeagueClientUx::RegisterKeybindings()
		{
			LeagueBase::RegisterKeybindings();
		}
	}
}

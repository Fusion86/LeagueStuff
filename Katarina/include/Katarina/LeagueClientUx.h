#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>

namespace Katarina
{
	namespace LeagueClientUx
	{
		class LeagueClientUx : public LeagueBase
		{
		public:
			const char* GetName() { return "LeagueClientUx"; }

		private:
			std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt(GetName());

			std::set<std::wstring> cef_parse_urls;

		public:
			HRESULT Initialize() override;
			HRESULT Uninitialize() override;

		protected:
			void Update(int delta) override;
			void RegisterHooks();
			void RegisterKeybindings() override;
		};
	}
}

#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>

namespace Katarina
{
	namespace LeagueClient
	{
		class LeagueClient : public LeagueBase
		{
		public:
			const char* GetName() { return "LeagueClient"; }

		private:
			fs::path m_dumpPath;
			std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt(GetName());

		public:
			HRESULT Initialize() override;
			HRESULT Uninitialize() override;

		protected:
			void RegisterHooks();
			void RegisterKeybindings() override;
		};
	}
}

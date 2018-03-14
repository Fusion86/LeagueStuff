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
			std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt(GetName());

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

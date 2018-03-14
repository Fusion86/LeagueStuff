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

		public:
			HRESULT Initialize() override;
			HRESULT Uninitialize() override;

		protected:
			void RegisterHooks();
			void RegisterKeybindings() override;
		};
	}
}

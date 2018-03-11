#pragma once

#include "stdafx.h"

#include <Katarina/LeagueBase.h>

namespace Katarina
{
	class LeagueClient : public LeagueBase
	{
	public:
		const char* GetExecutableName() { return "LeagueClient"; }

	private:
		std::shared_ptr<spdlog::logger> logger = spdlog::stdout_color_mt("LeagueClient");
		
	public:
		HRESULT Initialize() override;
		HRESULT Uninitialize() override;

	protected:
		void RegisterHooks();
		void RegisterKeybindings() override;
	};
}
#pragma once

#include "stdafx.h"

#include "LuxApp.h"

namespace Lux
{
	class LeagueClient : public LuxApp
	{
	public:
		LeagueClient();
		~LeagueClient();

		HRESULT Initialize(LPCWSTR szExePath) override;
		HRESULT Uninitialize() override;
		HRESULT Render() override;
		void RegisterKeybinds() override;
		void RegisterHooks() override;
	};
}
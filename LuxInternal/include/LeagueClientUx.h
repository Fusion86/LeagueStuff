#pragma once

#include "stdafx.h"

#include "LuxApp.h"

namespace Lux
{
	class LeagueClientUx : public LuxApp
	{
	public:
		LeagueClientUx();
		~LeagueClientUx();

		//HRESULT Initialize(LPCWSTR szExePath) override;
		//HRESULT Uninitialize() override;
		//HRESULT Render() override;
		//void RegisterKeybinds() override;
		void RegisterHooks() override;
	};
}
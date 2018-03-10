#include "stdafx.h"

#include <Katarina/LeagueClient.h>

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{
		int res = LeagueBase::Initialize();
		if (res != 0) return res;
		
		logger->info("Hi");

		return 0;
	}

	HRESULT LeagueClient::Uninitialize()
	{
		int res = LeagueBase::Uninitialize();
		if (res != 0) return res;

		logger->info("Bye");

		return 0;
	}

	void LeagueClient::RegisterApiHooks()
	{

	}

	void LeagueClient::RegisterFeatureHooks()
	{

	}
}
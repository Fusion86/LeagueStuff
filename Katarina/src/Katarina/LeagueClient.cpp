#include "stdafx.h"

#include <Katarina/LeagueClient.h>

#include <External/zstd.h>

extern "C"
{
	decltype(&ZSTD_decompress) orig_ZSTD_decompress;

	ZSTDLIB_API size_t hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);
		std::cout << "[LeagueClient ZSTD_decompress] Dumped" << std::endl;
		return res;
	}
}

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

	void LeagueClient::RegisterHooks()
	{
		KAT_AddApiHook("libzstd", ZSTD_decompress);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
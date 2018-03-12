#include "stdafx.h"

#include <Katarina/LeagueClient.h>

#include <External/zstd.h>

extern "C"
{
	std::shared_ptr<spdlog::logger> g_logger;

	//KAT_PrepareHook(ZSTD_decompress);

	ZSTDLIB_API size_t hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		//for (auto const& hook : fhk_ZSTD_decompress[Katarina::HookOrder::BeforeOriginal])
		//	if (hook == NULL) g_logger->error("Hook is NULL!"); else hook(dst, dstCapacity, src, compressedSize);

		//int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);

		//for (auto const& hook : fhk_ZSTD_decompress[Katarina::HookOrder::AfterOriginal])
		//	if (hook == NULL) g_logger->error("Hook is NULL!"); else hook(dst, dstCapacity, src, compressedSize);

		//return res;
		return 0;
	}

	void ZSTD_decompress___dump(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		g_logger->info("It works!");
	}
}

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{
		g_logger = logger;

		int res = LeagueBase::Initialize();
		if (res != 0) return res;

		for (auto const& hook : m_config.Hooks)
		{
			if (hook.Enabled)
			{
				logger->info("We want to enable {}", hook.Identifier);
			}
		}

		return 0;
	}

	HRESULT LeagueClient::Uninitialize()
	{
		int res = LeagueBase::Uninitialize();
		if (res != 0) return res;

		return 0;
	}

	void LeagueClient::RegisterHooks()
	{
		//KAT_AddApiHook("libzstd", ZSTD_decompress);

		//KAT_AddFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
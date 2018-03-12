#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hooks/LeagueClient.h>

//extern "C"
//{
//	std::shared_ptr<spdlog::logger> g_logger;
//	std::map<LPCVOID, std::map<Katarina::HookOrder, std::vector<LPCVOID>>>* g_featureHooks = nullptr;
//
//	decltype(&ZSTD_decompress) orig_ZSTD_decompress;
//
//	ZSTDLIB_API size_t hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
//	{
//		//KAT_UseFeatureHooks(ZSTD_decompress);
//		//KAT_ExecuteFeatureHooks(beforeHooks, dst, dstCapacity, src, compressedSize);
//
//		int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);
//
//		std::cout << "Hi" << std::endl;
//
//		//KAT_ExecuteFeatureHooks(afterHooks, dst, dstCapacity, src, compressedSize);
//
//		return res;
//	}
//
//	void ZSTD_decompress___dump(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
//	{
//		g_logger->info("It works!");
//	}
//}

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{
		//g_logger = logger;
		//g_featureHooks = &m_featureHooks;

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
		//KAT_AddApiHook("libzstd", ZSTD_decompress);

		//KAT_AddFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
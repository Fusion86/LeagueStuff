#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hook.h>

#include <External/zstd.h>

extern "C"
{
	std::shared_ptr<Katarina::ApiHook> apiHook_ZSTD_decompress;

	int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		for (const auto& hook : apiHook_ZSTD_decompress->FeatureHooks[Katarina::HookOrder::BeforeOriginal])
			(decltype(&ZSTD_decompress)(hook.Target))(dst, dstCapacity, src, compressedSize);

		int res = (decltype(&ZSTD_decompress)(apiHook_ZSTD_decompress->Original))(dst, dstCapacity, src, compressedSize);

		for (const auto& hook : apiHook_ZSTD_decompress->FeatureHooks[Katarina::HookOrder::AfterOriginal])
			res = (decltype(&ZSTD_decompress)(hook.Target))(dst, dstCapacity, src, compressedSize);

		return res;
	}
}

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{
		int res = LeagueBase::Initialize();
		if (res != 0) return res;

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
		apiHook_ZSTD_decompress = KAT_AddApiHook("libzstd", ZSTD_decompress);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
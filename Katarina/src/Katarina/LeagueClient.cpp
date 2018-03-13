#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hook.h>

#include <External/zstd.h>

// TODO: Pass return value as pointer in AfterOriginal so that we can edit it when needed (or ignore it)

extern "C"
{
	std::shared_ptr<Katarina::ApiHook> apiHook_ZSTD_decompress;

	int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		for (const auto& hook : apiHook_ZSTD_decompress->FeatureHooks[Katarina::HookOrder::BeforeOriginal])
			(decltype(&ZSTD_decompress)(hook.Target))(dst, dstCapacity, src, compressedSize);

		int res = (decltype(&ZSTD_decompress)(apiHook_ZSTD_decompress->Original))(dst, dstCapacity, src, compressedSize);

		for (const auto& hook : apiHook_ZSTD_decompress->FeatureHooks[Katarina::HookOrder::AfterOriginal])
			(decltype(&ZSTD_decompress)(hook.Target))(dst, dstCapacity, src, compressedSize);

		return res;
	}

	void hk_ZSTD_decompress$dump(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
	{
		std::cout << "Hi" << std::endl;
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
		KAT_AddApiHook("libzstd", ZSTD_decompress);

		//KAT_AddFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);

		FeatureHook fhk;
		fhk.IsEnabled = false;
		fhk.Name = "dump";
		fhk.Target = hk_ZSTD_decompress$dump;

		apiHook_ZSTD_decompress->AddFeatureHook(fhk, HookOrder::AfterOriginal);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
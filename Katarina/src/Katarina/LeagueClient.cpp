#include "stdafx.h"

#include <Katarina/LeagueClient.h>
#include <Katarina/Hook.h>

#include <External/zstd.h>

#include <memdmp.h>

// TODO: Pass return value as pointer in AfterOriginal so that we can edit it when needed (or ignore it)

extern "C"
{
	std::shared_ptr<spdlog::logger> g_logger;
	fs::path g_dumpPath;

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
		SYSTEMTIME st;
		GetLocalTime(&st);

		std::stringstream ss;
		ss << "luxdmp--" << st.wYear << "-" << st.wMonth << "-" << st.wDay
			<< "--" << st.wHour << "-" << st.wMinute << "-" << st.wSecond << "-" << st.wMilliseconds << ".bin";

		fs::path path = g_dumpPath;
		path /= ss.str();

		memdmp(path.string().c_str(), dst, dstCapacity);

		g_logger->info("Dumped to '{}'", path);
	}
}

namespace Katarina
{
	HRESULT LeagueClient::Initialize()
	{
		int res = LeagueBase::Initialize();
		if (res != 0) return res;

		m_dumpPath = m_appPath;
		m_dumpPath /= "Dump";
		fs::create_directories(m_dumpPath);

		// Set global vars used by the FeatureHooks
		g_logger = this->logger;
		g_dumpPath = m_dumpPath;

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
		KAT_AddFeatureHook(ZSTD_decompress, dump, HookOrder::AfterOriginal);
	}

	void LeagueClient::RegisterKeybindings()
	{
		LeagueBase::RegisterKeybindings();
	}
}
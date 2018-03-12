#pragma once

#include "stdafx.h"

#include <Katarina/LeagueClient.h>

#include <External/zstd.h>

//#define KAT_Hook(name, ...) \
//	decltype(&##name) orig_##name; \
//\
//	extern "C" int hk_##name(__VA_ARGS__)

#define KAT_RegisterHook(name) \
	decltype(&##name) orig_##name; \

//#define KAT_HookBody(name, ...) \
//	int res = orig_##name(__VA_ARGS__); \
//	return res;

//extern "C"
//{
//	std::shared_ptr<spdlog::logger> logger;
//
//KAT_RegisterHook(ZSTD_decompress);
//
//	inline int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
//	{
//		int res = orig_ZSTD_decompress(dst, dstCapacity, src, compressedSize);
//
//		std::cout << "fadfsdaf" << std::endl;
//
//		return res;
//	}
//}

//decltype(&ZSTD_decompress) hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize)
//{
//	return 0;
//}

extern "C"
{
	//KAT_RegisterHook(ZSTD_decompress);
	decltype(&ZSTD_decompress) orig_ZSTD_decompress;

	int hk_ZSTD_decompress(void* dst, size_t dstCapacity, const void* src, size_t compressedSize);
}

#pragma once

#include "stdafx.h"

// I just added the inline keyword here to fix compilation errors
// FIXME: Fix the problem instead of just doing ^
inline void memdmp(const char* fileName, void* data, size_t size)
{
	std::fstream fs(fileName, std::ios::out | std::ios::binary);
	fs.write((char*)data, size);
	fs.close();
}

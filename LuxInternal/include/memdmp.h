#pragma once

#include <fstream>

void memdmp(const char* fileName, void* data, size_t size)
{
	std::fstream fs(fileName, std::ios::out | std::ios::binary);
	fs.write((char*)data, size);
	fs.close();
}
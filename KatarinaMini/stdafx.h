#pragma once

#define _CRT_SECURE_NO_WARNINGS
#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <stdlib.h>
#include <string>
#include <filesystem>
#include <iostream>
#include <fstream>
#include <atomic>

namespace fs = std::experimental::filesystem;

#include "../Katarina/include/MinHook.h"

typedef struct _cef_string_wide_t {
	wchar_t* str;
	size_t length;
	void(*dtor)(wchar_t* str);
} cef_string_wide_t;

typedef _cef_string_wide_t cef_string_t;

typedef struct _cef_urlparts_t {
	cef_string_t spec;
	cef_string_t scheme;
	cef_string_t username;
	cef_string_t password;
	cef_string_t host;
	cef_string_t port;
	cef_string_t origin;
	cef_string_t path;
	cef_string_t query;
} cef_urlparts_t;

int cef_parse_url(const cef_string_t* url, cef_urlparts_t* parts);

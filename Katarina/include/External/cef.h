#pragma once

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

typedef wchar_t char16;

typedef struct _cef_string_utf16_t {
	char16* str;
	size_t length;
	void(*dtor)(char16* str);
} cef_string_utf16_t;

int cef_parse_url(const cef_string_t* url, cef_urlparts_t* parts);
int cef_string_utf16_set(const char16* src, size_t src_len, cef_string_utf16_t* output, int copy);

//typedef int(*func_cef_parse_url)(const cef_string_t* url, cef_urlparts_t* parts);
//typedef int(*func_cef_string_utf16_set)(const char16* src, size_t src_len, cef_string_utf16_t* output, int copy);

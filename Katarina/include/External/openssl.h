#pragma once

#include <External/openssl/ssl.h>

inline const char* sslerr_to_str(int ret)
{
	switch (ret)
	{
	case SSL_ERROR_NONE: return "SSL_ERROR_NONE";
	case SSL_ERROR_SSL: return "SSL_ERROR_SSL";
	case SSL_ERROR_WANT_READ: return "SSL_ERROR_WANT_READ";
	case SSL_ERROR_WANT_WRITE: return "SSL_ERROR_WANT_WRITE";
	case SSL_ERROR_WANT_X509_LOOKUP: return "SSL_ERROR_WANT_X509_LOOKUP";
	case SSL_ERROR_SYSCALL: return "SSL_ERROR_SYSCALL";
	case SSL_ERROR_ZERO_RETURN: return "SSL_ERROR_ZERO_RETURN";
	case SSL_ERROR_WANT_CONNECT: return "SSL_ERROR_WANT_CONNECT";
	case SSL_ERROR_WANT_ACCEPT: return "SSL_ERROR_WANT_ACCEPT";
	case SSL_ERROR_WANT_ASYNC: return "SSL_ERROR_WANT_ASYNC";
	case SSL_ERROR_WANT_ASYNC_JOB: return "SSL_ERROR_WANT_ASYNC_JOB";
	default:
		return nullptr;
	}
}
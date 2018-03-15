#pragma once

#define CURL_STRICTER
#include "curl/curl.h"

#define _curl_is_string_option(option)                                        \
  ((option) == CURLOPT_ABSTRACT_UNIX_SOCKET ||                                \
   (option) == CURLOPT_ACCEPT_ENCODING ||                                     \
   (option) == CURLOPT_CAINFO ||                                              \
   (option) == CURLOPT_CAPATH ||                                              \
   (option) == CURLOPT_COOKIE ||                                              \
   (option) == CURLOPT_COOKIEFILE ||                                          \
   (option) == CURLOPT_COOKIEJAR ||                                           \
   (option) == CURLOPT_COOKIELIST ||                                          \
   (option) == CURLOPT_CRLFILE ||                                             \
   (option) == CURLOPT_CUSTOMREQUEST ||                                       \
   (option) == CURLOPT_DEFAULT_PROTOCOL ||                                    \
   (option) == CURLOPT_DNS_INTERFACE ||                                       \
   (option) == CURLOPT_DNS_LOCAL_IP4 ||                                       \
   (option) == CURLOPT_DNS_LOCAL_IP6 ||                                       \
   (option) == CURLOPT_DNS_SERVERS ||                                         \
   (option) == CURLOPT_EGDSOCKET ||                                           \
   (option) == CURLOPT_FTPPORT ||                                             \
   (option) == CURLOPT_FTP_ACCOUNT ||                                         \
   (option) == CURLOPT_FTP_ALTERNATIVE_TO_USER ||                             \
   (option) == CURLOPT_INTERFACE ||                                           \
   (option) == CURLOPT_ISSUERCERT ||                                          \
   (option) == CURLOPT_KEYPASSWD ||                                           \
   (option) == CURLOPT_KRBLEVEL ||                                            \
   (option) == CURLOPT_LOGIN_OPTIONS ||                                       \
   (option) == CURLOPT_MAIL_AUTH ||                                           \
   (option) == CURLOPT_MAIL_FROM ||                                           \
   (option) == CURLOPT_NETRC_FILE ||                                          \
   (option) == CURLOPT_NOPROXY ||                                             \
   (option) == CURLOPT_PASSWORD ||                                            \
   (option) == CURLOPT_PINNEDPUBLICKEY ||                                     \
   (option) == CURLOPT_PRE_PROXY ||                                           \
   (option) == CURLOPT_PROXY ||                                               \
   (option) == CURLOPT_PROXYPASSWORD ||                                       \
   (option) == CURLOPT_PROXYUSERNAME ||                                       \
   (option) == CURLOPT_PROXYUSERPWD ||                                        \
   (option) == CURLOPT_PROXY_CAINFO ||                                        \
   (option) == CURLOPT_PROXY_CAPATH ||                                        \
   (option) == CURLOPT_PROXY_CRLFILE ||                                       \
   (option) == CURLOPT_PROXY_KEYPASSWD ||                                     \
   (option) == CURLOPT_PROXY_PINNEDPUBLICKEY ||                               \
   (option) == CURLOPT_PROXY_SERVICE_NAME ||                                  \
   (option) == CURLOPT_PROXY_SSLCERT ||                                       \
   (option) == CURLOPT_PROXY_SSLCERTTYPE ||                                   \
   (option) == CURLOPT_PROXY_SSLKEY ||                                        \
   (option) == CURLOPT_PROXY_SSLKEYTYPE ||                                    \
   (option) == CURLOPT_PROXY_SSL_CIPHER_LIST ||                               \
   (option) == CURLOPT_PROXY_TLSAUTH_PASSWORD ||                              \
   (option) == CURLOPT_PROXY_TLSAUTH_USERNAME ||                              \
   (option) == CURLOPT_PROXY_TLSAUTH_TYPE ||                                  \
   (option) == CURLOPT_RANDOM_FILE ||                                         \
   (option) == CURLOPT_RANGE ||                                               \
   (option) == CURLOPT_REFERER ||                                             \
   (option) == CURLOPT_RTSP_SESSION_ID ||                                     \
   (option) == CURLOPT_RTSP_STREAM_URI ||                                     \
   (option) == CURLOPT_RTSP_TRANSPORT ||                                      \
   (option) == CURLOPT_SERVICE_NAME ||                                        \
   (option) == CURLOPT_SOCKS5_GSSAPI_SERVICE ||                               \
   (option) == CURLOPT_SSH_HOST_PUBLIC_KEY_MD5 ||                             \
   (option) == CURLOPT_SSH_KNOWNHOSTS ||                                      \
   (option) == CURLOPT_SSH_PRIVATE_KEYFILE ||                                 \
   (option) == CURLOPT_SSH_PUBLIC_KEYFILE ||                                  \
   (option) == CURLOPT_SSLCERT ||                                             \
   (option) == CURLOPT_SSLCERTTYPE ||                                         \
   (option) == CURLOPT_SSLENGINE ||                                           \
   (option) == CURLOPT_SSLKEY ||                                              \
   (option) == CURLOPT_SSLKEYTYPE ||                                          \
   (option) == CURLOPT_SSL_CIPHER_LIST ||                                     \
   (option) == CURLOPT_TLSAUTH_PASSWORD ||                                    \
   (option) == CURLOPT_TLSAUTH_TYPE ||                                        \
   (option) == CURLOPT_TLSAUTH_USERNAME ||                                    \
   (option) == CURLOPT_UNIX_SOCKET_PATH ||                                    \
   (option) == CURLOPT_URL ||                                                 \
   (option) == CURLOPT_USERAGENT ||                                           \
   (option) == CURLOPT_USERNAME ||                                            \
   (option) == CURLOPT_USERPWD ||                                             \
   (option) == CURLOPT_XOAUTH2_BEARER ||                                      \
   0)

// We can use JavaScript to generate the below cases (fill 'var string' with the CINIT() macro's, comments etc are ignored)
/*
var string = `CINIT(WRITEDATA, OBJECTPOINT, 1),
CINIT(URL, STRINGPOINT, 2),
...
...
CINIT(HAPPY_EYEBALLS_TIMEOUT, LONG, 271),`;

var cinit = "CINIT(";
var lines = string.split(',');
var code = [];

for (var i = 0; i < lines.length; i++)
{
var index = lines[i].indexOf(cinit);
if (index != -1)
{
var end = lines[i].indexOf(',');
var opt = lines[i].substr(index + cinit.length)
code.push("case CURLOPT_" + opt + ": return \"" + opt + "\";");
}
}

code.join("\n");
*/

inline const char* curlopt_to_str(CURLoption opt)
{
	switch (opt)
	{
	case CURLOPT_WRITEDATA: return "WRITEDATA";
	case CURLOPT_URL: return "URL";
	case CURLOPT_PORT: return "PORT";
	case CURLOPT_PROXY: return "PROXY";
	case CURLOPT_USERPWD: return "USERPWD";
	case CURLOPT_PROXYUSERPWD: return "PROXYUSERPWD";
	case CURLOPT_RANGE: return "RANGE";
	case CURLOPT_READDATA: return "READDATA";
	case CURLOPT_ERRORBUFFER: return "ERRORBUFFER";
	case CURLOPT_WRITEFUNCTION: return "WRITEFUNCTION";
	case CURLOPT_READFUNCTION: return "READFUNCTION";
	case CURLOPT_TIMEOUT: return "TIMEOUT";
	case CURLOPT_INFILESIZE: return "INFILESIZE";
	case CURLOPT_POSTFIELDS: return "POSTFIELDS";
	case CURLOPT_REFERER: return "REFERER";
	case CURLOPT_FTPPORT: return "FTPPORT";
	case CURLOPT_USERAGENT: return "USERAGENT";
	case CURLOPT_LOW_SPEED_LIMIT: return "LOW_SPEED_LIMIT";
	case CURLOPT_LOW_SPEED_TIME: return "LOW_SPEED_TIME";
	case CURLOPT_RESUME_FROM: return "RESUME_FROM";
	case CURLOPT_COOKIE: return "COOKIE";
	case CURLOPT_HTTPHEADER: return "HTTPHEADER";
	case CURLOPT_HTTPPOST: return "HTTPPOST";
	case CURLOPT_SSLCERT: return "SSLCERT";
	case CURLOPT_KEYPASSWD: return "KEYPASSWD";
	case CURLOPT_CRLF: return "CRLF";
	case CURLOPT_QUOTE: return "QUOTE";
	case CURLOPT_HEADERDATA: return "HEADERDATA";
	case CURLOPT_COOKIEFILE: return "COOKIEFILE";
	case CURLOPT_SSLVERSION: return "SSLVERSION";
	case CURLOPT_TIMECONDITION: return "TIMECONDITION";
	case CURLOPT_TIMEVALUE: return "TIMEVALUE";
	case CURLOPT_CUSTOMREQUEST: return "CUSTOMREQUEST";
	case CURLOPT_STDERR: return "STDERR";
	case CURLOPT_POSTQUOTE: return "POSTQUOTE";
	case CURLOPT_OBSOLETE40: return "OBSOLETE40";
	case CURLOPT_VERBOSE: return "VERBOSE";
	case CURLOPT_HEADER: return "HEADER";
	case CURLOPT_NOPROGRESS: return "NOPROGRESS";
	case CURLOPT_NOBODY: return "NOBODY";
	case CURLOPT_FAILONERROR: return "FAILONERROR";
	case CURLOPT_UPLOAD: return "UPLOAD";
	case CURLOPT_POST: return "POST";
	case CURLOPT_DIRLISTONLY: return "DIRLISTONLY";
	case CURLOPT_APPEND: return "APPEND";
	case CURLOPT_NETRC: return "NETRC";
	case CURLOPT_FOLLOWLOCATION: return "FOLLOWLOCATION";
	case CURLOPT_TRANSFERTEXT: return "TRANSFERTEXT";
	case CURLOPT_PUT: return "PUT";
	case CURLOPT_PROGRESSFUNCTION: return "PROGRESSFUNCTION";
	case CURLOPT_PROGRESSDATA: return "PROGRESSDATA";
	case CURLOPT_AUTOREFERER: return "AUTOREFERER";
	case CURLOPT_PROXYPORT: return "PROXYPORT";
	case CURLOPT_POSTFIELDSIZE: return "POSTFIELDSIZE";
	case CURLOPT_HTTPPROXYTUNNEL: return "HTTPPROXYTUNNEL";
	case CURLOPT_INTERFACE: return "INTERFACE";
	case CURLOPT_KRBLEVEL: return "KRBLEVEL";
	case CURLOPT_SSL_VERIFYPEER: return "SSL_VERIFYPEER";
	case CURLOPT_CAINFO: return "CAINFO";
	case CURLOPT_MAXREDIRS: return "MAXREDIRS";
	case CURLOPT_FILETIME: return "FILETIME";
	case CURLOPT_TELNETOPTIONS: return "TELNETOPTIONS";
	case CURLOPT_MAXCONNECTS: return "MAXCONNECTS";
	case CURLOPT_OBSOLETE72: return "OBSOLETE72";
	case CURLOPT_FRESH_CONNECT: return "FRESH_CONNECT";
	case CURLOPT_FORBID_REUSE: return "FORBID_REUSE";
	case CURLOPT_RANDOM_FILE: return "RANDOM_FILE";
	case CURLOPT_EGDSOCKET: return "EGDSOCKET";
	case CURLOPT_CONNECTTIMEOUT: return "CONNECTTIMEOUT";
	case CURLOPT_HEADERFUNCTION: return "HEADERFUNCTION";
	case CURLOPT_HTTPGET: return "HTTPGET";
	case CURLOPT_SSL_VERIFYHOST: return "SSL_VERIFYHOST";
	case CURLOPT_COOKIEJAR: return "COOKIEJAR";
	case CURLOPT_SSL_CIPHER_LIST: return "SSL_CIPHER_LIST";
	case CURLOPT_HTTP_VERSION: return "HTTP_VERSION";
	case CURLOPT_FTP_USE_EPSV: return "FTP_USE_EPSV";
	case CURLOPT_SSLCERTTYPE: return "SSLCERTTYPE";
	case CURLOPT_SSLKEY: return "SSLKEY";
	case CURLOPT_SSLKEYTYPE: return "SSLKEYTYPE";
	case CURLOPT_SSLENGINE: return "SSLENGINE";
	case CURLOPT_SSLENGINE_DEFAULT: return "SSLENGINE_DEFAULT";
	case CURLOPT_DNS_USE_GLOBAL_CACHE: return "DNS_USE_GLOBAL_CACHE";
	case CURLOPT_DNS_CACHE_TIMEOUT: return "DNS_CACHE_TIMEOUT";
	case CURLOPT_PREQUOTE: return "PREQUOTE";
	case CURLOPT_DEBUGFUNCTION: return "DEBUGFUNCTION";
	case CURLOPT_DEBUGDATA: return "DEBUGDATA";
	case CURLOPT_COOKIESESSION: return "COOKIESESSION";
	case CURLOPT_CAPATH: return "CAPATH";
	case CURLOPT_BUFFERSIZE: return "BUFFERSIZE";
	case CURLOPT_NOSIGNAL: return "NOSIGNAL";
	case CURLOPT_SHARE: return "SHARE";
	case CURLOPT_PROXYTYPE: return "PROXYTYPE";
	case CURLOPT_ACCEPT_ENCODING: return "ACCEPT_ENCODING";
	case CURLOPT_PRIVATE: return "PRIVATE";
	case CURLOPT_HTTP200ALIASES: return "HTTP200ALIASES";
	case CURLOPT_UNRESTRICTED_AUTH: return "UNRESTRICTED_AUTH";
	case CURLOPT_FTP_USE_EPRT: return "FTP_USE_EPRT";
	case CURLOPT_HTTPAUTH: return "HTTPAUTH";
	case CURLOPT_SSL_CTX_FUNCTION: return "SSL_CTX_FUNCTION";
	case CURLOPT_SSL_CTX_DATA: return "SSL_CTX_DATA";
	case CURLOPT_FTP_CREATE_MISSING_DIRS: return "FTP_CREATE_MISSING_DIRS";
	case CURLOPT_PROXYAUTH: return "PROXYAUTH";
	case CURLOPT_FTP_RESPONSE_TIMEOUT: return "FTP_RESPONSE_TIMEOUT";
	case CURLOPT_IPRESOLVE: return "IPRESOLVE";
	case CURLOPT_MAXFILESIZE: return "MAXFILESIZE";
	case CURLOPT_INFILESIZE_LARGE: return "INFILESIZE_LARGE";
	case CURLOPT_RESUME_FROM_LARGE: return "RESUME_FROM_LARGE";
	case CURLOPT_MAXFILESIZE_LARGE: return "MAXFILESIZE_LARGE";
	case CURLOPT_NETRC_FILE: return "NETRC_FILE";
	case CURLOPT_USE_SSL: return "USE_SSL";
	case CURLOPT_POSTFIELDSIZE_LARGE: return "POSTFIELDSIZE_LARGE";
	case CURLOPT_TCP_NODELAY: return "TCP_NODELAY";
	case CURLOPT_FTPSSLAUTH: return "FTPSSLAUTH";
	case CURLOPT_IOCTLFUNCTION: return "IOCTLFUNCTION";
	case CURLOPT_IOCTLDATA: return "IOCTLDATA";
	case CURLOPT_FTP_ACCOUNT: return "FTP_ACCOUNT";
	case CURLOPT_COOKIELIST: return "COOKIELIST";
	case CURLOPT_IGNORE_CONTENT_LENGTH: return "IGNORE_CONTENT_LENGTH";
	case CURLOPT_FTP_SKIP_PASV_IP: return "FTP_SKIP_PASV_IP";
	case CURLOPT_FTP_FILEMETHOD: return "FTP_FILEMETHOD";
	case CURLOPT_LOCALPORT: return "LOCALPORT";
	case CURLOPT_LOCALPORTRANGE: return "LOCALPORTRANGE";
	case CURLOPT_CONNECT_ONLY: return "CONNECT_ONLY";
	case CURLOPT_CONV_FROM_NETWORK_FUNCTION: return "CONV_FROM_NETWORK_FUNCTION";
	case CURLOPT_CONV_TO_NETWORK_FUNCTION: return "CONV_TO_NETWORK_FUNCTION";
	case CURLOPT_CONV_FROM_UTF8_FUNCTION: return "CONV_FROM_UTF8_FUNCTION";
	case CURLOPT_MAX_SEND_SPEED_LARGE: return "MAX_SEND_SPEED_LARGE";
	case CURLOPT_MAX_RECV_SPEED_LARGE: return "MAX_RECV_SPEED_LARGE";
	case CURLOPT_FTP_ALTERNATIVE_TO_USER: return "FTP_ALTERNATIVE_TO_USER";
	case CURLOPT_SOCKOPTFUNCTION: return "SOCKOPTFUNCTION";
	case CURLOPT_SOCKOPTDATA: return "SOCKOPTDATA";
	case CURLOPT_SSL_SESSIONID_CACHE: return "SSL_SESSIONID_CACHE";
	case CURLOPT_SSH_AUTH_TYPES: return "SSH_AUTH_TYPES";
	case CURLOPT_SSH_PUBLIC_KEYFILE: return "SSH_PUBLIC_KEYFILE";
	case CURLOPT_SSH_PRIVATE_KEYFILE: return "SSH_PRIVATE_KEYFILE";
	case CURLOPT_FTP_SSL_CCC: return "FTP_SSL_CCC";
	case CURLOPT_TIMEOUT_MS: return "TIMEOUT_MS";
	case CURLOPT_CONNECTTIMEOUT_MS: return "CONNECTTIMEOUT_MS";
	case CURLOPT_HTTP_TRANSFER_DECODING: return "HTTP_TRANSFER_DECODING";
	case CURLOPT_HTTP_CONTENT_DECODING: return "HTTP_CONTENT_DECODING";
	case CURLOPT_NEW_FILE_PERMS: return "NEW_FILE_PERMS";
	case CURLOPT_NEW_DIRECTORY_PERMS: return "NEW_DIRECTORY_PERMS";
	case CURLOPT_POSTREDIR: return "POSTREDIR";
	case CURLOPT_SSH_HOST_PUBLIC_KEY_MD5: return "SSH_HOST_PUBLIC_KEY_MD5";
	case CURLOPT_OPENSOCKETFUNCTION: return "OPENSOCKETFUNCTION";
	case CURLOPT_OPENSOCKETDATA: return "OPENSOCKETDATA";
	case CURLOPT_COPYPOSTFIELDS: return "COPYPOSTFIELDS";
	case CURLOPT_PROXY_TRANSFER_MODE: return "PROXY_TRANSFER_MODE";
	case CURLOPT_SEEKFUNCTION: return "SEEKFUNCTION";
	case CURLOPT_SEEKDATA: return "SEEKDATA";
	case CURLOPT_CRLFILE: return "CRLFILE";
	case CURLOPT_ISSUERCERT: return "ISSUERCERT";
	case CURLOPT_ADDRESS_SCOPE: return "ADDRESS_SCOPE";
	case CURLOPT_CERTINFO: return "CERTINFO";
	case CURLOPT_USERNAME: return "USERNAME";
	case CURLOPT_PASSWORD: return "PASSWORD";
	case CURLOPT_PROXYUSERNAME: return "PROXYUSERNAME";
	case CURLOPT_PROXYPASSWORD: return "PROXYPASSWORD";
	case CURLOPT_NOPROXY: return "NOPROXY";
	case CURLOPT_TFTP_BLKSIZE: return "TFTP_BLKSIZE";
	case CURLOPT_SOCKS5_GSSAPI_SERVICE: return "SOCKS5_GSSAPI_SERVICE";
	case CURLOPT_SOCKS5_GSSAPI_NEC: return "SOCKS5_GSSAPI_NEC";
	case CURLOPT_PROTOCOLS: return "PROTOCOLS";
	case CURLOPT_REDIR_PROTOCOLS: return "REDIR_PROTOCOLS";
	case CURLOPT_SSH_KNOWNHOSTS: return "SSH_KNOWNHOSTS";
	case CURLOPT_SSH_KEYFUNCTION: return "SSH_KEYFUNCTION";
	case CURLOPT_SSH_KEYDATA: return "SSH_KEYDATA";
	case CURLOPT_MAIL_FROM: return "MAIL_FROM";
	case CURLOPT_MAIL_RCPT: return "MAIL_RCPT";
	case CURLOPT_FTP_USE_PRET: return "FTP_USE_PRET";
	case CURLOPT_RTSP_REQUEST: return "RTSP_REQUEST";
	case CURLOPT_RTSP_SESSION_ID: return "RTSP_SESSION_ID";
	case CURLOPT_RTSP_STREAM_URI: return "RTSP_STREAM_URI";
	case CURLOPT_RTSP_TRANSPORT: return "RTSP_TRANSPORT";
	case CURLOPT_RTSP_CLIENT_CSEQ: return "RTSP_CLIENT_CSEQ";
	case CURLOPT_RTSP_SERVER_CSEQ: return "RTSP_SERVER_CSEQ";
	case CURLOPT_INTERLEAVEDATA: return "INTERLEAVEDATA";
	case CURLOPT_INTERLEAVEFUNCTION: return "INTERLEAVEFUNCTION";
	case CURLOPT_WILDCARDMATCH: return "WILDCARDMATCH";
	case CURLOPT_CHUNK_BGN_FUNCTION: return "CHUNK_BGN_FUNCTION";
	case CURLOPT_CHUNK_END_FUNCTION: return "CHUNK_END_FUNCTION";
	case CURLOPT_FNMATCH_FUNCTION: return "FNMATCH_FUNCTION";
	case CURLOPT_CHUNK_DATA: return "CHUNK_DATA";
	case CURLOPT_FNMATCH_DATA: return "FNMATCH_DATA";
	case CURLOPT_RESOLVE: return "RESOLVE";
	case CURLOPT_TLSAUTH_USERNAME: return "TLSAUTH_USERNAME";
	case CURLOPT_TLSAUTH_PASSWORD: return "TLSAUTH_PASSWORD";
	case CURLOPT_TLSAUTH_TYPE: return "TLSAUTH_TYPE";
	case CURLOPT_TRANSFER_ENCODING: return "TRANSFER_ENCODING";
	case CURLOPT_CLOSESOCKETFUNCTION: return "CLOSESOCKETFUNCTION";
	case CURLOPT_CLOSESOCKETDATA: return "CLOSESOCKETDATA";
	case CURLOPT_GSSAPI_DELEGATION: return "GSSAPI_DELEGATION";
	case CURLOPT_DNS_SERVERS: return "DNS_SERVERS";
	case CURLOPT_ACCEPTTIMEOUT_MS: return "ACCEPTTIMEOUT_MS";
	case CURLOPT_TCP_KEEPALIVE: return "TCP_KEEPALIVE";
	case CURLOPT_TCP_KEEPIDLE: return "TCP_KEEPIDLE";
	case CURLOPT_TCP_KEEPINTVL: return "TCP_KEEPINTVL";
	case CURLOPT_SSL_OPTIONS: return "SSL_OPTIONS";
	case CURLOPT_MAIL_AUTH: return "MAIL_AUTH";
	case CURLOPT_SASL_IR: return "SASL_IR";
	case CURLOPT_XFERINFOFUNCTION: return "XFERINFOFUNCTION";
	case CURLOPT_XOAUTH2_BEARER: return "XOAUTH2_BEARER";
	case CURLOPT_DNS_INTERFACE: return "DNS_INTERFACE";
	case CURLOPT_DNS_LOCAL_IP4: return "DNS_LOCAL_IP4";
	case CURLOPT_DNS_LOCAL_IP6: return "DNS_LOCAL_IP6";
	case CURLOPT_LOGIN_OPTIONS: return "LOGIN_OPTIONS";
	case CURLOPT_SSL_ENABLE_NPN: return "SSL_ENABLE_NPN";
	case CURLOPT_SSL_ENABLE_ALPN: return "SSL_ENABLE_ALPN";
	case CURLOPT_EXPECT_100_TIMEOUT_MS: return "EXPECT_100_TIMEOUT_MS";
	case CURLOPT_PROXYHEADER: return "PROXYHEADER";
	case CURLOPT_HEADEROPT: return "HEADEROPT";
	case CURLOPT_PINNEDPUBLICKEY: return "PINNEDPUBLICKEY";
	case CURLOPT_UNIX_SOCKET_PATH: return "UNIX_SOCKET_PATH";
	case CURLOPT_SSL_VERIFYSTATUS: return "SSL_VERIFYSTATUS";
	case CURLOPT_SSL_FALSESTART: return "SSL_FALSESTART";
	case CURLOPT_PATH_AS_IS: return "PATH_AS_IS";
	case CURLOPT_PROXY_SERVICE_NAME: return "PROXY_SERVICE_NAME";
	case CURLOPT_SERVICE_NAME: return "SERVICE_NAME";
	case CURLOPT_PIPEWAIT: return "PIPEWAIT";
	case CURLOPT_DEFAULT_PROTOCOL: return "DEFAULT_PROTOCOL";
	case CURLOPT_STREAM_WEIGHT: return "STREAM_WEIGHT";
	case CURLOPT_STREAM_DEPENDS: return "STREAM_DEPENDS";
	case CURLOPT_STREAM_DEPENDS_E: return "STREAM_DEPENDS_E";
	case CURLOPT_TFTP_NO_OPTIONS: return "TFTP_NO_OPTIONS";
	case CURLOPT_CONNECT_TO: return "CONNECT_TO";
	case CURLOPT_TCP_FASTOPEN: return "TCP_FASTOPEN";
	case CURLOPT_KEEP_SENDING_ON_ERROR: return "KEEP_SENDING_ON_ERROR";
	case CURLOPT_PROXY_CAINFO: return "PROXY_CAINFO";
	case CURLOPT_PROXY_CAPATH: return "PROXY_CAPATH";
	case CURLOPT_PROXY_SSL_VERIFYPEER: return "PROXY_SSL_VERIFYPEER";
	case CURLOPT_PROXY_SSL_VERIFYHOST: return "PROXY_SSL_VERIFYHOST";
	case CURLOPT_PROXY_SSLVERSION: return "PROXY_SSLVERSION";
	case CURLOPT_PROXY_TLSAUTH_USERNAME: return "PROXY_TLSAUTH_USERNAME";
	case CURLOPT_PROXY_TLSAUTH_PASSWORD: return "PROXY_TLSAUTH_PASSWORD";
	case CURLOPT_PROXY_TLSAUTH_TYPE: return "PROXY_TLSAUTH_TYPE";
	case CURLOPT_PROXY_SSLCERT: return "PROXY_SSLCERT";
	case CURLOPT_PROXY_SSLCERTTYPE: return "PROXY_SSLCERTTYPE";
	case CURLOPT_PROXY_SSLKEY: return "PROXY_SSLKEY";
	case CURLOPT_PROXY_SSLKEYTYPE: return "PROXY_SSLKEYTYPE";
	case CURLOPT_PROXY_KEYPASSWD: return "PROXY_KEYPASSWD";
	case CURLOPT_PROXY_SSL_CIPHER_LIST: return "PROXY_SSL_CIPHER_LIST";
	case CURLOPT_PROXY_CRLFILE: return "PROXY_CRLFILE";
	case CURLOPT_PROXY_SSL_OPTIONS: return "PROXY_SSL_OPTIONS";
	case CURLOPT_PRE_PROXY: return "PRE_PROXY";
	case CURLOPT_PROXY_PINNEDPUBLICKEY: return "PROXY_PINNEDPUBLICKEY";
	case CURLOPT_ABSTRACT_UNIX_SOCKET: return "ABSTRACT_UNIX_SOCKET";
	case CURLOPT_SUPPRESS_CONNECT_HEADERS: return "SUPPRESS_CONNECT_HEADERS";
	case CURLOPT_REQUEST_TARGET: return "REQUEST_TARGET";
	case CURLOPT_SOCKS5_AUTH: return "SOCKS5_AUTH";
	case CURLOPT_SSH_COMPRESSION: return "SSH_COMPRESSION";
	case CURLOPT_MIMEPOST: return "MIMEPOST";
	case CURLOPT_TIMEVALUE_LARGE: return "TIMEVALUE_LARGE";
	case CURLOPT_HAPPY_EYEBALLS_TIMEOUT: return "HAPPY_EYEBALLS_TIMEOUT";
	default:
		return nullptr;
	}
}

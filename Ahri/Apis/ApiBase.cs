using System;
using System.Collections.Generic;
using System.Text;

namespace Ahri.Apis
{
    public class ApiBase
    {
        protected readonly LeagueClientApi _api;

        public ApiBase(LeagueClientApi api)
        {
            _api = api;
        }
    }
}

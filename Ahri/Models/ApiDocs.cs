using System.Collections.Generic;

namespace Ahri.Models
{
    public class ApiDocs
    {
        public List<Api> Apis { get; set; }
        public Info Info { get; set; }
        public string SwaggerVersion { get; set; }
    }

    public class Api
    {
        public string Path { get; set; }
    }

    public class Info
    {
        public string Description { get; set; }
        public string Title { get; set; }
    }
}

using System;

namespace Tripod.Application.AdminApi
{
    public class AppOptions
    {
        public string ArchiveSrvHost { get; set; }

        public string SystemSrvHost { get; set; }

        public string Redis { get; set; }
    }
}
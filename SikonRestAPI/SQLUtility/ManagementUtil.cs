using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace SikonRestAPI.SQLUtility
{
    public class ManagementUtil
    {
        public static string ConnectionString;

        public const string LocalConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SikonDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public const string NicolaiConnString = @"Data Source=nicolaiserver.database.windows.net;Initial Catalog=NicolaiDataBase;User ID=NicolaiAdmin;Password=Seacret1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
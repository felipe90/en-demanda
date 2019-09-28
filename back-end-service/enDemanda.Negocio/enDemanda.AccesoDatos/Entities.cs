using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enDemanda.AccesoDatos
{
    public partial class Entities : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public Entities(String connectionString)
            : base(connectionString)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Retorna la Cadena de Conexion
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString(string sConnString)
        {
            string connectionstring = sConnString;
            EntityConnectionStringBuilder newconnstring = new EntityConnectionStringBuilder();
            newconnstring.Metadata = @"res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl";//@"res://*/";
            newconnstring.Provider = "System.Data.SqlClient";
            newconnstring.ProviderConnectionString = connectionstring;
            return newconnstring.ToString();
        }
    }
}

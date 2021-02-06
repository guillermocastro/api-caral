using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Caral.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class CurrencyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [CurrencyId],[Currency3N],[Decimal],[CurrencyName],[CurFormat],[LastValue],[TimeStamp],[IsDisabled] FROM [common].[Currency]";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}

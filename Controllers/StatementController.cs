using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Caral.Models;

namespace Caral.Controllers
{
    public class StatementController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [StatementId],[StatementName],[ParentId],[AccountList] FROM [Accounting].[Statement]";
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
        public string Post(Statement sta)
        {
            try
            {
                string query = @"INSERT INTO [Accounting].[Statement] VALUES (
                    '" + sta.StatementId + @"'
                    ,'" + sta.StatementName + @"'
                    ,'" + sta.ParentId + @"'
                    ,'" + sta.AccountList + @"'
                   )";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Put(Statement sta)
        {
            try
            {
                string query = @"UPDATE [Accounting].[Statement] SET 
                    [StatementId]='" + sta.StatementId + @"'
                    ,[StatementName]='" + sta.StatementName + @"'
                    ,[ParentId]='" + sta.ParentId + @"'
                    ,[AccountList]='" + sta.AccountList + @"'
                    WHERE StatementId='" + sta.StatementId + @"'";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Delete(string id)
        {
            try
            {
                string query = @"DELETE FROM [Accounting].[Statement] WHERE StatementId='" + id + @"'";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}

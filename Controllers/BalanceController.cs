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
    public class BalanceController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [BalanceId],[BalanceName],[ParentId],[AccountList] FROM [Accounting].[Balance]";
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
        public string Post(Balance bal)
        {
            try
            {
                string query = @"INSERT INTO [Accounting].[Balance] VALUES (
                    '" + bal.BalanceId + @"'
                    ,'" + bal.BalanceName + @"'
                    ,'" + bal.ParentId + @"'
                    ,'" + bal.AccountList + @"'
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
        public string Put(Balance bal)
        {
            try
            {
                string query = @"UPDATE [Accounting].[Balance] SET 
                    [BalanceId]='" + bal.BalanceId + @"'
                    ,[BalanceName]='" + bal.BalanceName + @"'
                    ,[ParentId]='" + bal.ParentId + @"'
                    ,[AccountList]='" + bal.AccountList + @"'
                    WHERE BalanceId='" + bal.BalanceId + @"'";
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
                string query = @"DELETE FROM [Accounting].[Balance] WHERE BalanceId='" + id + @"'";
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

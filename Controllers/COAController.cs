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
    public class COAController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [AccountId],[AccountName],[AccountType],[Description],[BalanceId],[StatementId],[IsDisabled] FROM [Accounting].[Account]";
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
        public string Post(Account coa)
        {
            try
            {
                string query = @"INSERT INTO dbo.Employee VALUES (
                    '" + coa.AccountId + @"'
                    ,'" + coa.AccountName + @"'
                    ,'" + coa.AccountType + @"'
                    ,'" + coa.Description + @"'
                    ,'" + coa.BalanceId + @"'
                    ,'" + coa.StatementId + @"'
                    ,'FALSE'
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
        public string Put(Account coa)
        {
            try
            {
                string query = @"UPDATE [Accounting].[Account] SET 
                    [AccountId]='" + coa.AccountId + @"'
                    ,[AccountName]='" + coa.AccountName + @"'
                    ,[AccountType]='" + coa.AccountType + @"'
                    ,[Description]='" + coa.Description + @"'
                    ,[BalanceId]='" + coa.BalanceId + @"'
                    ,[StatementId]='" + coa.StatementId + @"'
                    ,[IsDisabled]='" + coa.IsDisabled + @"'
                    WHERE AccountId=" + coa.AccountId + @"";
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
                string query = @"DELETE FROM [Accounting].[Account] WHERE AccountId=" + id + @"";
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

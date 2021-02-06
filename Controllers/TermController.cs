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
    public class TermController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [TermId],[TermName],[PaymenMethodId],[PaymentDayList],[PercentageList],[IsDisabled] FROM [crm].[Term] WHERE ISNULL([IsDisabled],'FALSE')='FALSE'";
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
        public string Post(Term ter)
        {
            try
            {
                string query = @"INSERT INTO [crm].[Term] VALUES (
                    '" + ter.TermName + @"'
                    ,'" + ter.Days + @"'
                    ,'" + ter.PaymentDays + @"'
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
        public string Put(Term ter)
        {
            try
            {
                string query = @"UPDATE [crm].[Term] SET 
                    [TermName]='" + ter.TermName + @"'
                    ,[Days]='" + ter.Days + @"'
                    ,[PaymentDay]='" + ter.PaymentDays+ @"'
                    ,[IsDisabled]='" + ter.IsDisabled + @"'
                    WHERE [TermId]=" + ter.TermId + @"";
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
                string query = @"DELETE FROM [crm].[Term] WHERE [TermId]=" + id + @"";
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

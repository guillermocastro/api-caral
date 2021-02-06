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
    public class PaymentMethodController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT [PaymenMethodId],[PaymenMethodName],[AccountId],[IsDisabled] FROM [Accounting].[PaymenMethod] WHERE ISNULL([IsDisabled],'FALSE')='FALSE'";
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
        public string Post(PaymenMethod pay)
        {
            try
            {
                string query = @"INSERT INTO [Accounting].[PaymentMethod] VALUES (
                    '" + pay.PaymentMethodName + @"'
                    ,'" + pay.AccountId + @"'
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
        public string Put(PaymenMethod pay)
        {
            try
            {
                string query = @"UPDATE [Accounting].[PaymentMethod] SET 
                    [PaymentMethodName]='" + pay.PaymentMethodName + @"'
                    ,[AccountId]='" + pay.AccountId + @"'
                    WHERE [PaymentMethodId]=" + pay.PaymentMethodId + @"";
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
                string query = @"DELETE FROM [Accounting].[PaymentMethod] WHERE [PaymentMethodId]=" + id + @"";
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

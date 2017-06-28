using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public class Session
    {
        public int ComputerId { get; set; }
        public object StartTime { get; set; }
        public object EndTime { get; set; }
        public object LoginTime { get; set; }
        public object LogOffTime { get; set; }
        public int Status { get; set; }
        public Boolean SessionClosed { get; set; }
        public Boolean IsActive { get; set; }
        public int CreatedBy { get; set; }
        public object InvoicedBy { get; set; }
        public Guid Id { get; set; }
        public string SessionCode { get; set; }
        public int PagesPrinted { get; set; }

        public int Hour { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }

        public static Session GetNonClosedSession(int Computerid , string Sessioncode)
        {
            try
            {
                Session ses = new Session();

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetNonClosedSession", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@computerid", Computerid);
                    command.Parameters.AddWithValue("@sessioncode", Sessioncode);

                    SqlDataReader dtreader = command.ExecuteReader();

                    if (dtreader.HasRows)
                    {
                        dtreader.Read();

                        if (dtreader.GetString(0).Equals("Error"))
                        {
                            dtreader.NextResult();
                            dtreader.Read();

                            throw new Exception(dtreader.GetString(0));
                        }

                        else
                        {
                            dtreader.NextResult();
                            dtreader.Read();

                            ses.Id = dtreader.GetGuid(0);
                            ses.SessionCode = dtreader.GetString(1);
                            ses.ComputerId = dtreader.GetInt32(2);
                            ses.StartTime = dtreader.GetValue(3);
                            ses.EndTime = dtreader.GetValue(4);
                            ses.LoginTime = dtreader.GetValue(5);
                            ses.LogOffTime = dtreader.GetValue(6);
                            ses.SessionClosed = dtreader.GetBoolean(7);
                            ses.IsActive = dtreader.GetBoolean(8);
                            ses.Status = dtreader.GetInt32(9);
                            ses.CreatedBy = dtreader.GetInt32(10);
                            ses.InvoicedBy = dtreader.GetValue(11);
                            ses.PagesPrinted = dtreader.GetInt32(12);
                            

                            dtreader.NextResult();
                            dtreader.Read();

                            ses.Hour = dtreader.GetInt32(0);
                            ses.Min = dtreader.GetInt32(1);
                            ses.Sec = dtreader.GetInt32(2);

                            return ses;

                        }
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    
        }

        public bool StartSession(object comment,object byemployeeid)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("StartSession", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sessionid", this.Id);
                    command.Parameters.AddWithValue("@comment", comment == null ? DBNull.Value : comment);
                    command.Parameters.AddWithValue("@byemployeeid", byemployeeid == null ? DBNull.Value : byemployeeid);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool StopSession(object comment, object byemployeeid)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("StopSession", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sessionid", this.Id);
                    command.Parameters.AddWithValue("@comment", comment == null ? DBNull.Value : comment);
                    command.Parameters.AddWithValue("@byemployeeid", byemployeeid == null ? DBNull.Value : byemployeeid);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool PauseSession(object comment, object byemployeeid)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("PauseSession", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sessionid", this.Id);
                    command.Parameters.AddWithValue("@comment", comment == null ? DBNull.Value : comment);
                    command.Parameters.AddWithValue("@byemployeeid", byemployeeid == null ? DBNull.Value : byemployeeid);

                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool PauseSession_CloseUnexpectedly(string sessionid, string datetime)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("PauseSession_CloseUnexpectedly", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sessionid", sessionid);
                    command.Parameters.AddWithValue("@time", Convert.ToDateTime(datetime));
                    command.Parameters.AddWithValue("@comment", "Session Paused Due To Network Disconnect.");
                    

                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DateTime GetLatestLoginTime(int computerid, Guid sessionid)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("GetLatestLoginTime", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@computerid", computerid);
                    command.Parameters.AddWithValue("@sessionid", sessionid);


                    return Convert.ToDateTime(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

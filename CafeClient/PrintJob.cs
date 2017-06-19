using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public class PrintJob
    {
        public int JobId { get; set; }

        public string Jobname { get; set; }

        public string Printername { get; set; }

        public string DocumentName { get; set; }

        public string StatusMask { get; set; }

        public string Status { get; set; }

        public int TotalPages { get; set; }

        public DateTime StartTime{ get; set; }

        public DateTime ElapsedTime { get; set; }

        public DateTime TimeSubmitted { get; set; }

        public string PaperSize { get; set; }

        public string PaperWidth { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Datatype { get; set; }

        public int PagesPrinted { get; set; }


        public static void DumpJobsToDatabase(Guid sessionid,int computerid)
        {

            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PrintJob");
                ManagementObjectCollection moc = mos.Get();

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();
                    SqlCommand command;

                    foreach (ManagementBaseObject Mo in moc)
                    {

                        command = new SqlCommand("InsertSessionPrint", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@sessionid", sessionid);
                        command.Parameters.AddWithValue("@computerid", computerid);
                        command.Parameters.AddWithValue("@jobid", Convert.ToInt32(Mo["JobId"].ToString()));
                        command.Parameters.AddWithValue("@jobname", Mo["Name"].ToString());
                        command.Parameters.AddWithValue("@printername", Mo["Name"].ToString().Split(',')[0]);
                        command.Parameters.AddWithValue("@documentname", Mo["Document"].ToString());
                        command.Parameters.AddWithValue("@statusmask", Mo["StatusMask"].ToString());
                        command.Parameters.AddWithValue("@status", Mo["Status"].ToString());
                        command.Parameters.AddWithValue("@totalpages", Convert.ToInt32(Mo["TotalPages"].ToString()));
                        command.Parameters.AddWithValue("@starttime", DBNull.Value);
                        command.Parameters.AddWithValue("@elapsedtime", DBNull.Value);
                        command.Parameters.AddWithValue("@submittedtime", MiscClass.WmiDatetimeConverter(Mo["TimeSubmitted"].ToString()));

                        command.Parameters.AddWithValue("@papersize", Mo["PaperSize"].ToString());
                        command.Parameters.AddWithValue("@paperwidth", Mo["PaperWidth"].ToString());
                        command.Parameters.AddWithValue("@description", Mo["Description"].ToString());
                        command.Parameters.AddWithValue("@color", Mo["Color"].ToString());
                        command.Parameters.AddWithValue("@datatype", Mo["DataType"].ToString());
                        command.Parameters.AddWithValue("@pagesprinted", Convert.ToInt32(Mo["PagesPrinted"].ToString()));

                        command.ExecuteNonQuery();

                        Mo.Dispose();
                        
                    }

                        moc.Dispose();
                        mos.Dispose();

                     

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void CancelPrintJobs()
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_PrintJob");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject Mo in moc)
                {
                    Mo.Delete();
                    Mo.Dispose();
                }

                moc.Dispose();
                mos.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

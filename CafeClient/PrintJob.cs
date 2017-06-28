using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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


        public static string DumpJobsToDatabase(Guid sessionid,int computerid,DataTable dt)
        {

            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();
                    SqlCommand command;


                    command = new SqlCommand("InsertSessionPrint", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@sessionid", sessionid);
                    command.Parameters.AddWithValue("@computerid", computerid);
                    command.Parameters.AddWithValue("@logtable", dt);

                    return Convert.ToInt32(command.ExecuteScalar()).ToString();
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

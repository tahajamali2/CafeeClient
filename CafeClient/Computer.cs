using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CafeClient
{
    public class Computer
    {
        public int Id { get; set; }
        public string PcName { get; set; }

        public string IPAddress { get; set; }

        public int FloorId { get; set; }

        public bool IsActive { get; set; }

        public bool IsBusy { get; set; }

        public int Status { get; set; }

        public int Port { get; set; }


        public static Computer GetComputerByIp(string ipaddress)
        {
            Computer returncom = new Computer();
            try
            {
                using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SelectComputerByIP", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ip",ipaddress);

                    SqlDataReader dtreader = command.ExecuteReader();

                    if(dtreader.HasRows) 
                    {
                        while(dtreader.Read())
                        {
                            returncom.Id = Convert.ToInt32(dtreader.GetValue(0));
                            returncom.PcName = dtreader.GetValue(1).ToString();
                            returncom.IPAddress = dtreader.GetValue(2).ToString();
                            returncom.FloorId = Convert.ToInt32(dtreader.GetValue(3));
                            returncom.IsActive = Convert.ToBoolean(dtreader.GetValue(4));
                            returncom.Status = Convert.ToInt32(dtreader.GetValue(6));
                            returncom.Port = Convert.ToInt32(dtreader.GetValue(5) == null ? 13000 : dtreader.GetValue(5));

                            break;
                        }

                        return returncom;
                    }

                    else {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

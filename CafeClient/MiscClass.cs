using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public class MiscClass
    {
        public static string GetMiscValue(string name)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString()))
                {

                    connection.Open();

                    SqlCommand command = new SqlCommand("GetMiscValue", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);

                    SqlDataReader dtreader = command.ExecuteReader();

                    if (dtreader.HasRows)
                    {
                        dtreader.Read();
                        return dtreader.GetValue(0).ToString();
                    }

                    else
                    {
                        throw new Exception("Misc name does'nt exist");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DateTime WmiDatetimeConverter(string datetime)
        {
            try
            {
                return new DateTime(Convert.ToInt32(datetime.Substring(0, 4)), Convert.ToInt32(datetime.Substring(4, 2)), Convert.ToInt32(datetime.Substring(6, 2)), Convert.ToInt32(datetime.Substring(8, 2)), Convert.ToInt32(datetime.Substring(10, 2)), Convert.ToInt32(datetime.Substring(12, 2)));
            }
            catch
            {
                return new DateTime();
            }
        }

        public static bool CheckNetworkAvailablity(string adapter, string ip)
        {
            bool adapteravailable = false;
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            string inner_ip;

            foreach (var adaptername in adapters)
            {
                if (adaptername.Name.Equals(adapter))
                {
                    adapteravailable = true;
                    if (adaptername.OperationalStatus == OperationalStatus.Down)
                    {
                        inner_ip = "0.0.0.0";
                    }

                    else
                    {
                        inner_ip = adaptername.GetIPProperties().UnicastAddresses.Where(x => x.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).Select(y => y.Address.ToString()).SingleOrDefault();

                    }

                    if (inner_ip.Equals("0.0.0.0"))
                    {
                        throw new Exception("[" + adapter + "] Network adapter is down.");
                    }

                    if (!ip.Equals(inner_ip))
                    {
                        throw new Exception("IP has been changed of [" + adapter + "] Network adapter");
                    }
                }
            }

            if (!adapteravailable)
            {
                throw new Exception("[" + adapter + "] Network adapter is not available");
            }

            return true;
        }

        public static string GetConfigValue(string key)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            return config.AppSettings.Settings[key] == null ? "" : config.AppSettings.Settings[key].Value;

        }

        public static void SetConfigValue(string key, string value)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, value);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }

        }

    }
}

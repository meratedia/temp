using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Helpdesk
{
    public class DbQueries
    {
        string dbConnectionString = "Server=localhost;Database=cases;User ID=root;Password=;";

        public List<casesList> getCase10()
        {
            List<casesList> cases = new List<casesList>();
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from `case` order by caseId desc Limit 10";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                casesList caseItem = new casesList
                                {
                                    caseID = reader.GetInt32("caseID"),
                                    username = reader.GetString("username"),
                                    date = reader.GetDateTime("date"),
                                    qry = reader.GetString("qry"),
                                    address = reader.GetString("address"),
                                    phone = reader.GetString("phone"),
                                    email = reader.GetString("email"),
                                    location = reader.GetString("location"),
                                    priority = reader.GetString("priority"),
                                    status = reader.GetString("status")
                                };

                                cases.Add(caseItem);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cases;
        }
        public  int GetTotalRowCount()
        {
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM `case`";
                MySqlCommand command = new MySqlCommand(query, conn);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public  int GetStatusCount(string status)
        {
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM `case` WHERE status = @status";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@status", status);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        public List<User> getClients()
        {
            List<User> cases = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "Select Distinct username from `case`";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User caseItem = new User
                                {
                                    Name = reader.GetString("username"),
                                    Country = "ZW"
                                };

                                cases.Add(caseItem);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cases;
        }
        public List<casesList> getCase()
        {
            List<casesList> cases = new List<casesList>();
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from `case` order by status desc";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                casesList caseItem = new casesList
                                {
                                    caseID = reader.GetInt32("caseID"),
                                    username = reader.GetString("username"),
                                    date = reader.GetDateTime("date"),
                                    qry = reader.GetString("qry"),
                                    address = reader.GetString("address"),
                                    phone = reader.GetString("phone"),
                                    email = reader.GetString("email"),
                                    location = reader.GetString("location"),
                                    priority = reader.GetString("priority"),
                                    status = reader.GetString("status")
                                };

                                cases.Add(caseItem);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cases;
        }
        public List<casesList> getOneCase(string caseid )
        {
            List<casesList> cases = new List<casesList>();
            using (MySqlConnection conn = new MySqlConnection(dbConnectionString))
            {
                try
                {
                    conn.Open();
                    string query = "Select * from `case` Where caseID='"+caseid+"'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                casesList caseItem = new casesList
                                {
                                    caseID = reader.GetInt32("caseID"),
                                    username = reader.GetString("username"),
                                    date = reader.GetDateTime("date"),
                                    qry = reader.GetString("qry"),
                                    address = reader.GetString("address"),
                                    phone = reader.GetString("phone"),
                                    email = reader.GetString("email"),
                                    location = reader.GetString("location"),
                                    priority = reader.GetString("priority"),
                                    status = reader.GetString("status")
                                };

                                cases.Add(caseItem);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return cases;
        }

        public string markDone(string caseID)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(dbConnectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Update `Case` set status='Done' where CaseId='"+caseID+"'", conn);
                var resp = cmd.ExecuteNonQuery();
                if (resp > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string addCase(casesList cases)
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(dbConnectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert Into `Case`(username, address, phone, email, location, priority, status,qry,date) Values(@name,@address,@phone,@email,@location," +
                    "@prio,@status,@qry,@dat) ", conn);
                cmd.Parameters.AddWithValue("name", cases.username);
                cmd.Parameters.AddWithValue("address", cases.address);
                cmd.Parameters.AddWithValue("email", cases.email);
                cmd.Parameters.AddWithValue("phone", cases.phone);
                cmd.Parameters.AddWithValue("qry", cases.qry);
                cmd.Parameters.AddWithValue("prio", cases.priority);
                cmd.Parameters.AddWithValue("status", "Pending");
                cmd.Parameters.AddWithValue("location", cases.location);
                cmd.Parameters.AddWithValue("dat", DateTime.Now);
                var resp = cmd.ExecuteNonQuery();
                if (resp > 0)
                {
                    return "success";
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<User> GetUsers()
        {
            return new List<User>
        {
             new User { Name = "Meratedia", Country = "ZW" },
            new User { Name = "Anna", Country = "ZW" },
             new User { Name = "Mike", Country = "ZW" },
            new User { Name = "Dylan", Country = "ZW" },
             new User { Name = "Chipo", Country = "ZW" },
            new User { Name = "Tanatswa", Country = "ZW" },
             new User { Name = "Rudo", Country = "ZW" },
            new User { Name = "Tendai", Country = "ZW" },
        };
        }

    }
    public class casesList
    {
        public int caseID { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }
        public string qry { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string priority { get; set; }
        public string status { get; set; }

    }
   
    public class User
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}


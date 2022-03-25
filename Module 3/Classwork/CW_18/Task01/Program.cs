using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            if (false)
                Example();
            if (true)
            {
                string connectionString = "Data Source=AdventureWorksLT.db";
                string CommandText = "SELECT * FROM Address";
                DataTable dt;
                //dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                //foreach(DataRow a in dt.Rows)
                //{
                //    foreach (var item in a.ItemArray)
                //    {
                //        Console.Write(item + " ");
                //    }
                //    Console.WriteLine();
                //}
                
                CommandText = "SELECT * FROM Product WHERE ListPrice >= 0 and ListPrice <= 1000";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                foreach (DataRow a in dt.Rows)
                {
                    Console.WriteLine(a["name"].ToString() + " --> " + a["ListPrice"].ToString());
                }
                Console.WriteLine();
                
                CommandText = "SELECT * FROM Product WHERE INSTR(name, 'ra')";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                foreach (DataRow a in dt.Rows)
                {
                    Console.WriteLine(a["name"].ToString());
                }
                Console.WriteLine();

                CommandText = "SELECT * FROM Product WHERE ProductID = 680";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                foreach (DataRow a in dt.Rows)
                {
                    Console.WriteLine(string.Join(" ", a.ItemArray));
                }

                CommandText = "UPDATE Product Set StandardCost=400, ListPrice=600 WHERE ProductID = 680";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                foreach (DataRow a in dt.Rows)
                {
                    Console.WriteLine(string.Join(" ", a.ItemArray));
                }

                CommandText = "INSERT INTO Product(Name, ProductNumber, StandardCost, ListPrice, ProductCategoryId, ProductModelId, SellStartDate, ThumbnailPhotoFileName, ModifiedDate, rowguid) VALUES ('deadbeef', 'beef', 100, 200, 10, 10, '', '', '', 'deadbeef')";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                
                CommandText = "SELECT * FROM Product WHERE name='deadbeef'";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
                
                foreach (DataRow a in dt.Rows)
                {
                    Console.WriteLine(string.Join(" ", a.ItemArray));
                }

                CommandText = "DELETE FROM Product WHERE ProductID=1003 or name='deadbeef'";
                dt = ExecuteSQL_DataTable(connectionString, CommandText, Array.Empty<Tuple<string, string>>());
            }
        }

        private static DataTable ExecuteSQL_DataTable(string connectionString, string SQL, params Tuple<string, string>[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqliteConnection con = new SqliteConnection(connectionString)) {
                using (SqliteCommand cmd = new SqliteCommand(SQL, con)) {
                    cmd.CommandType = CommandType.Text;
                    foreach (var tuple in parameters) {
                        cmd.Parameters.Add(new SqliteParameter(tuple.Item1, tuple.Item2));
                    }
                    con.Open();
                    SqliteDataReader reader = cmd.ExecuteReader();
                    for (int i = 0; i < reader.FieldCount; i++)
                        dt.Columns.Add(new DataColumn(reader.GetName(i)));
                    int rowIndex = 0;
                    while (reader.Read()) {
                        DataRow row = dt.NewRow();
                        dt.Rows.Add(row);
                        for (int i = 0; i < reader.FieldCount; i++)
                            dt.Rows[rowIndex][i] = (reader.GetValue(i));
                        rowIndex++;
                    }
                }
            }
            return dt;
        }

        static void Example()
        {
            string connectionString = "Data Source=MyDB4.db";
            SqliteConnection con = new SqliteConnection(connectionString);
            con.Open();



            SqliteCommand command = new SqliteCommand();
            command.Connection = con;
            command.CommandText = "CREATE TABLE User(id integer not null primary key autoincrement unique, name text not null)";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO User(name) VALUES ('Tom')";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO User(name) VALUES ('Alice')";
            command.ExecuteNonQuery();



            command.CommandText = "INSERT INTO User(name) VALUES ('Bob')";
            command.ExecuteNonQuery();



            command.CommandText = "DELETE FROM User WHERE name='Tom'";
            command.ExecuteNonQuery();



            command.CommandText = "UPDATE User SET name='BobUpdated' WHERE name='Bob'";
            command.ExecuteNonQuery();



            command.CommandText = "SELECT * FROM USER";
            SqliteDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1));
            }
        }
    }
}


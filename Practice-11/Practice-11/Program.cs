using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Practice_11
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);

            var con2 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"Database1.mdf;Integrated Security=True");
            con2.Open();
            var cmd = new SqlCommand("INSERT INTO [Table] (Id, Name, Amount) VALUES (1, 'Test', 1)", con2);
            cmd.ExecuteNonQuery();
            con2.Close();
           
            using (SqlConnection connection = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=DynamicsNAV100;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Table]", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetValue(1)}");

                }
                reader.Close();
                command = new SqlCommand("UPDATE [Table] SET Name = 'Test' where id = 3", connection);
                command.ExecuteNonQuery();
            
                var dataSet = new System.Data.DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Table]", connection);
                dataAdapter.Fill(dataSet);


                dataSet.Tables[0].Rows[0][2] = "Bla";




                dataAdapter.DeleteCommand = new SqlCommand("DELETE FROM [Table] WHERE [Id] = @id");
                dataAdapter.DeleteCommand.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int, 0, "Id"));

                dataAdapter.UpdateCommand = new SqlCommand("UPDATE [Table] SET [Name] = @name, [Amount] = @amount WHERE [Id] = @id");
                dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 10, "Name"));
                dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@amount", System.Data.SqlDbType.Decimal, 0, "Amount"));
                dataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int, 0, "Id"));

                dataAdapter.InsertCommand = new SqlCommand("INSERT INTO [Table] (Id, Name, Amount) VALUES (@id, @name, @amount)");
                dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.VarChar, 10, "Name"));
                dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@amount", System.Data.SqlDbType.Decimal, 0, "Amount"));
                dataAdapter.InsertCommand.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int, 0, "Id"));

                dataAdapter.Fill(dataSet);
                var table = dataSet.Tables[0];
                var newRow = table.NewRow();
                newRow[0] = 10;
                newRow[1] = "Naujas";
                newRow[2] = 10M;
                var rowToDelete = table.Rows[2];
                rowToDelete.Delete();
                var rowToUpdate = table.Rows[0];
                rowToUpdate[2] = 5M;
                rowToUpdate["Name"] = "Updated";


                dataAdapter.Update(dataSet);


            }
           

    


        }
    }
}

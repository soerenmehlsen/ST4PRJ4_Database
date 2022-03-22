using System;
using System.Data.SqlClient;

namespace ST4PRJ4_Database
{
    public class Database
    {
        public Database(){}

        private string _connectionString;
        private SqlConnection _cnn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string _sql, Output = "";
        private SqlDataAdapter _dataAdapter = new SqlDataAdapter();
        

        public void OpenConnection()
        {
            //Set connection string
            _connectionString =
                "Server=tcp:st4prj4.database.windows.net,1433;Initial Catalog=ST4PRJ4;Persist Security Info=False;User ID=azureuser;Password=Katrinebjerg123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            // Assign connection
            _cnn = new SqlConnection(_connectionString);

            // Open connection
            _cnn.Open();
        }

        public void Read()
        {
            _sql = "Select PersonID,FirstName,LastName from Test_table";

            command = new SqlCommand(_sql, _cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + "PersonID: " + dataReader.GetValue(0) + "\nFornavn: " + dataReader.GetValue(1) + "\nEfternavn: "+ dataReader.GetValue(2);
            }

            Console.WriteLine(Output);
            
            command.Dispose();
            _cnn.Close();     
        }

        public void Insert()
        {
            // Define the insert statement
              _sql = "INSERT INTO Test_table(PersonID, FirstName, LastName) VALUES(3, 'Lene', 'Madsen')";

              //Define the sqlcommand
              command = new SqlCommand(_sql, _cnn);

              // associate the insert command
              _dataAdapter.InsertCommand = new SqlCommand(_sql, _cnn);
              _dataAdapter.InsertCommand.ExecuteNonQuery();
              
              //Close object and connection
              command.Dispose();
              _cnn.Close();
        }
    }
}
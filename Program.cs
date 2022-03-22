using System;
using System.Data;
using System.Threading;

namespace ST4PRJ4_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            
            //Connect to database
            Console.WriteLine("Connecting to database");
            Thread.Sleep(1000);
            
            database.OpenConnection();
            Console.WriteLine("Successfully connected to database!");
            Thread.Sleep(1000);
            
            //Read from database
            Console.WriteLine("Reading from database");
            Thread.Sleep(1000);
            database.Read();
            
            //Insert to database
            // database.OpenConnection();
            Console.WriteLine("Insert to database");
            database.Insert();
            Thread.Sleep(1000);
            Console.WriteLine("Successful");
            
        }
    }
}

using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTest
{
    class Program
    {
        static string conStr = "Data Source=D:\\Temp\\test.db;Version=3;Compress=True;";
        static void Main(string[] args)
        {
            //GetData();
            //InsertData();
            //UpdateData();
        }
        static void GetData()
        {
            try
            {
                using (SqliteDataAccess da = new SqliteDataAccess(conStr))
                {
                    List<dynamic> result = da.GetDataList<dynamic, dynamic>("Select * From Person", null);
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void InsertData()
        {
            try
            {
                using (SqliteDataAccess da = new SqliteDataAccess(conStr))
                {

                    string sql = @"Insert into Person(Name,DOB,Salary,IsActive) 
                                    Values(@Name,@DOB,@Salary,@IsActive)";

                    //pass individual args
                    //string name = "Luke Smith";
                    //string dob = "1980-03-03";
                    //int salary = 50000;
                    //bool isActive = true;
                    //int result = da.SaveData(sql, new { @Name = name, @DOB = dob, @Salary = salary, @IsActive = isActive });

                    //pass model as arg
                    PersonModel p = new PersonModel();
                    p.Name = "Luke Smith";
                    p.DOB = DateTime.ParseExact("2015-03-03", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    p.Salary = 75000;
                    p.IsActive = true;
                    string errMsg = string.Empty;
                    int result = da.SaveData(sql, p, out errMsg);

                    Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void UpdateData()
        {
            try
            {
                using (SqliteDataAccess da = new SqliteDataAccess(conStr))
                {
                    string name = "Luke Smith";
                    double salary = 80000.50;

                    string sql = @"Update Person SET Salary=@Salary Where Name=@Name";
                    string errMsg = string.Empty;
                    int result = da.SaveData(sql, new {@Salary = salary, @Name = name},out errMsg);
                    
                    Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

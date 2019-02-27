using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace SchoolDataBase.Pages
{
    public class CreateModel : PageModel
    {
        public string Message { get; set; }
        public string textBoxEntry;
        public string[] newDataArray;
        String primaryKey;

        public void OnGet()
        {
            textBoxEntry = Request.QueryString.Value;
            MySqlConnection mySqlConnection = new MySqlConnection(@"Server=localhost;port=3306;Database=SchoolDB;Uid=root;Pwd=rootuser;");

            if (textBoxEntry == null)
            {
                Message = "Information NULL. NO ACTION TAKEN!";
            }
            else
            {
                Message = "Data created on SQL Server!";

                newDataArray = new string[9];
                newDataArray = textBoxEntry.Split("&");

                primaryKey = newDataArray[0].Split("=")[0];

                try
                {
                    mySqlConnection.Open();

                    MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                    mySqlCommand.CommandType = CommandType.Text;

                    switch (primaryKey)
                    {
                        case "?studentRollNumber":
                            mySqlCommand.CommandText = createStudent();
                            mySqlCommand.ExecuteNonQuery();
                            break;
                        case "?teacherID":
                            mySqlCommand.CommandText = createTeacher();
                            mySqlCommand.ExecuteNonQuery();
                            break;
                        case "?subjectCode":
                            mySqlCommand.CommandText = createSubject();
                            mySqlCommand.ExecuteNonQuery();
                            break;
                        case "?staffID":
                            mySqlCommand.CommandText = createStaff();
                            mySqlCommand.ExecuteNonQuery();
                            break;
                    }

                    mySqlConnection.Close();

                }
                catch(Exception ex)
                {

                }

            }
        }

        public String createStudent()
        {
            String command;
            string Data = "";
            foreach (string dat in newDataArray)
            {
                Data = Data + "," + dat.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "insert into Students values ('" + newDataArray[1] + "','" + newDataArray[2] + "','" + newDataArray[3] + "')";
            return command;
        }

        public String createTeacher()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "insert into Teachers values ('" + newDataArray[1] + "','" + newDataArray[2] + "','" + newDataArray[3] + "','" + newDataArray[4] + "')";
            return command;
        }

        public String createSubject()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "insert into Subjects values ('" + newDataArray[1] + "','" + newDataArray[2] + "')";
            return command;
        }

        public String createStaff()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "insert into NonTeachingStaff values ('" + newDataArray[1] + "','" + newDataArray[2] + "','" + newDataArray[3] + "','" + newDataArray[4] + "')";
            return command;
        }

    }
}

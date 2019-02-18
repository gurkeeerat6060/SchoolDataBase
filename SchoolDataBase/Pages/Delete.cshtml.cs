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
    public class DeleteModel : PageModel
    {
        public string Message { get; set; }
        public string textBoxEntry;
        public string[] newDataArray;
        String primaryKey;

        public void OnGet()
        {
            textBoxEntry = Request.QueryString.Value;
            MySqlConnection connection = new MySqlConnection(@"Server=localhost;port=3306;Database=SchoolDB;Uid=root;Pwd=rootuser;");

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

                connection.Open();

                MySqlCommand mySqlCommand = connection.CreateCommand();
                mySqlCommand.CommandType = CommandType.Text;

                switch (primaryKey)
                {
                    case "?studentRollNumber":
                        mySqlCommand.CommandText = deleteStudent();
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    case "?teacherID":
                        mySqlCommand.CommandText = deleteTeacher();
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    case "?subjectCode":
                        mySqlCommand.CommandText = deleteSubject();
                        mySqlCommand.ExecuteNonQuery();
                        break;
                    case "?staffID":
                        mySqlCommand.CommandText = deleteStaff();
                        mySqlCommand.ExecuteNonQuery();
                        break;
                }

                connection.Close();
            }
        }

        public String deleteStudent()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "delete from students where rollNo='" + newDataArray[1] +"';";
            return command;
        }

        public String deleteTeacher()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "delete from students where teacherID='" + newDataArray[1] + "';";
            return command;
        }

        public String deleteSubject()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "delete from students where subjectCode='" + newDataArray[1] + "';";
            return command;
        }

        public String deleteStaff()
        {
            String command;
            string Data = "";
            foreach (string item in newDataArray)
            {
                Data = Data + "," + item.Split("=")[1];
            }

            newDataArray = new string[10];
            newDataArray = Data.Split(",");
            command = "delete from students where staffID='" + newDataArray[1] + "';";
            return command;
        }

    }
}

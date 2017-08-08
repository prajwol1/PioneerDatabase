using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerEmployeeDatabase.DAL
{
    public class EmployeeDataAccessLayer
    {
        public int SaveEmployeeData(string FirstName, string LastName,string EmailId, long MobileNumber,long AlternateMobileNumber, string Address1, string Address2, string CurrentCountry, string HomeCountry,int ZipCode)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeDetail VALUES(" +
                            "'" + FirstName + "','" + LastName + "','" + EmailId + "'," +
                            MobileNumber + "," + AlternateMobileNumber + ",'" + Address1 + "','" + Address2 +
                            "','" + CurrentCountry + "','" + HomeCountry + "'," + ZipCode + ")", mysqlconnection);
            //Opening Sql Database Connection
            
            mysqlconnection.Open();


            //SqlDataReader Dr = cmd.ExecuteReader();
            result = cmd.ExecuteNonQuery();
            return result;
        }



        public int SaveProjectData(string ProjectName, string ClientName, string Location, string Roles, int EmployeeId)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO ProjectDetail VALUES(" +
                            "'" + ProjectName + "','" + ClientName + "','" + Location + "','" + Roles + "'," + EmployeeId + ")", mysqlconnection);
            //Opening Sql Database Connection

            mysqlconnection.Open();


            //SqlDataReader Dr = cmd.ExecuteReader();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int SaveCompanyData(string EmployerName, long EmployerContactNumber, string EmployerAddress, string Website, int EmployeeId)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";


            SqlCommand cmd = new SqlCommand("INSERT INTO CompanyDetail VALUES('" + EmployerName + "'," + EmployerContactNumber + ",'" + EmployerAddress + "','" + Website + "'," + EmployeeId + ")", mysqlconnection);
            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int SaveTechnicalData(string UI, string ProgrammingLanguage, string DatabaseName, int EmployeeId)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO TechnicalDetail VALUES('" + UI + "','" + ProgrammingLanguage + "','" + DatabaseName + "'," + EmployeeId + ")", mysqlconnection);
            
            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        

        public int SaveEducationData(string CourseType, int YearOfPass, string CourseSpecialization, int EmployeeId)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO EducationDetail VALUES('" + CourseType + "'," + YearOfPass + ",'" + CourseSpecialization + "'," + EmployeeId + ")", mysqlconnection);

            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }


    }


}

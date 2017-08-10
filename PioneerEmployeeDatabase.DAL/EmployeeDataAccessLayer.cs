using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pioneer.Database.Model;

namespace PioneerEmployeeDatabase.DAL
{
    public class EmployeeDataAccessLayer
    {
        public int SaveEmployeeData(EmployeeModel model)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO EmployeeDetail VALUES(" +
                            "'" + model.FirstName + "','" + model.LastName + "','" + model.EmailId + "'," +
                            model.MobileNumber + "," + model.AlternateMobileNumber + ",'" + model.Address1 + "','" + model.Address2 +
                            "','" + model.CurrentCountry + "','" + model.HomeCountry + "'," + model.ZipCode + ")", mysqlconnection);
            //Opening Sql Database Connection
            
            mysqlconnection.Open();


            //SqlDataReader Dr = cmd.ExecuteReader();
            result = cmd.ExecuteNonQuery();
            return result;
        }



        public int SaveProjectData(ProjectModel model)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO ProjectDetail VALUES(" +
                            "'" + model.ProjectName + "','" + model.ClientName + "','" + model.Place + "','" + model.Role + "'," + model.EmployeeId + ")", mysqlconnection);
            //Opening Sql Database Connection

            mysqlconnection.Open();


            //SqlDataReader Dr = cmd.ExecuteReader();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int SaveCompanyData(CompanyModel model)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";


            SqlCommand cmd = new SqlCommand("INSERT INTO CompanyDetail VALUES('" + model.EmployerName + "'," + model.EmployerContactNumber + ",'" + model.EmployerAddress + "','" + model.Website + "'," + model.EmployeeId + ")", mysqlconnection);
            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int SaveTechnicalData(TechnicalModel model)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO TechnicalDetail VALUES('" + model.UI + "','" + model.ProgrammingLanguage + "','" + model.DatabaseName + "'," + model.EmployeeId + ")", mysqlconnection);
            
            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }

        

        public int SaveEducationData(EducationModel model)
        {
            int result;
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("INSERT INTO EducationDetail VALUES('" + model.CourseType + "'," + model.YearOfPass + ",'" + model.CourseSpecialization + "'," + model.EmployeeId + ")", mysqlconnection);

            mysqlconnection.Open();
            result = cmd.ExecuteNonQuery();
            return result;
        }


        public void DashBoardDisplay()
        {


        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PioneerEmployeeDatabase.DAL;
using Pioneer.Database.Model;

namespace WindowsFormsApp3
{
    public partial class Employee_Form : Form
    {
        public Employee_Form()
        {
            InitializeComponent();
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("SELECT EmployeeId,FirstName  FROM EmployeeDetail", mysqlconnection);
            mysqlconnection.Open();
            SqlDataReader Dr = cmd.ExecuteReader();

            while (Dr.Read())
            {
                Employee_ProjectComboBox.Items.Add(Dr[0]);
                Employee_CompanyComboBox.Items.Add(Dr[0]);
                Employee_EducationComboBox.Items.Add(Dr[0]);
                Employee_TechnicalComboBox.Items.Add(Dr[0]);
                DashBoardComboBox.Items.Add(Dr[0]);

            }
            mysqlconnection.Close();
        }

       
        private void SaveButton_Click(object sender, EventArgs e)
        {
           try
           {
                EmployeeModel employeeModel = new EmployeeModel()
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    EmailId = EmailIdTextBox.Text,
                    MobileNumber = Convert.ToInt64(MobileNumberTextBox.Text),
                    AlternateMobileNumber = Convert.ToInt64(AlternateMobileNumberTextBox.Text),
                    Address1 = Address1TextBox.Text,
                    Address2 = Address2TextBox.Text,
                    CurrentCountry = CurrentCountryTextBox.Text,
                    HomeCountry = HomeCountryTextBox.Text,
                    ZipCode = Convert.ToInt32(ZipCodeTextBox.Text)

                };

                EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

                int NoOfRowsAffected = EmployeeDAL.SaveEmployeeData(employeeModel);
                if (NoOfRowsAffected > 0)
                    MessageBox.Show("Succesfully saved in Employee Detail");
                else
                    MessageBox.Show("Could Not Save");
            }
            catch (Exception exception)
            {
                MessageBox.Show("EXCEPTION OCCURED. PLEASE CONTACT ADMINISTRATOR",exception.Message);
            }
           
           
         }

       
        private void EmployeeDetailsClearButton_Click(object sender, EventArgs e)
        {
            ClearButton(EmployeeDetailTab.Controls);
        }

       
        private void ShowEmployeeDetailButton_Click(object sender, EventArgs e)
        {
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("SELECT * FROM EmployeeDetail", mysqlconnection);
            mysqlconnection.Open();
            SqlDataReader Dr = cmd.ExecuteReader();

            BindingSource source = new BindingSource();
            source.DataSource = Dr;

            
            mysqlconnection.Close();


        }

        private void ProjectDetailSaveButton_Click(object sender, EventArgs e)
        {
            ProjectModel projectModel = new ProjectModel()
            {
                ProjectName = ProjectNameTextBox.Text,
                ClientName = ClientNameTextBox.Text,
                Place = LocationTextBox.Text,
                Role = RolesTextBox.Text,
                EmployeeId = Convert.ToInt32(Employee_ProjectComboBox.Text)
            };

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveProjectData(projectModel);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved in Project Detail");
            else
                MessageBox.Show("Could Not Save");
            
        }

       

        private void ShowAllEmployeeButton_Click(object sender, EventArgs e)
        {
            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmdE = new SqlCommand("SELECT * FROM EmployeeDetail", mysqlconnection);
            SqlCommand cmdC = new SqlCommand("SELECT * FROM CompanyDetail ", mysqlconnection);
            SqlCommand cmdP = new SqlCommand("SELECT * FROM ProjectDetail ", mysqlconnection);
            mysqlconnection.Open();

            SqlDataReader DrE = cmdE.ExecuteReader();
            BindingSource sourceE = new BindingSource();
            sourceE.DataSource = DrE;
            DrE.Close();

            SqlDataReader DrC = cmdC.ExecuteReader();
            BindingSource sourceC = new BindingSource();
            sourceC.DataSource = DrC;
            DrC.Close();


            SqlDataReader DrP = cmdP.ExecuteReader();
            BindingSource sourceP = new BindingSource();
            sourceP.DataSource = DrP;
            DrP.Close();


            EmployeeDataGridView.DataSource = sourceE;
            CompanyDataGridView.DataSource = sourceC;
            ProjectDataGridView.DataSource = sourceP;

            mysqlconnection.Close();

        }

        private void ShowDetailsButton_Click(object sender, EventArgs e)
        {
            int EmployeeId = Convert.ToInt32(DashBoardComboBox.Text);

            SqlConnection mysqlconnection = new SqlConnection();
            mysqlconnection.ConnectionString = "Data Source = PRAJWOLPC;database = Pioneer_Employee_Database1;Integrated security = SSPI";

            SqlCommand cmdE = new SqlCommand("SELECT * FROM EmployeeDetail WHERE EmployeeId = " + EmployeeId, mysqlconnection);
            SqlCommand cmdC = new SqlCommand("SELECT * FROM CompanyDetail WHERE EmployeeId = " + EmployeeId, mysqlconnection);
            SqlCommand cmdP = new SqlCommand("SELECT * FROM ProjectDetail WHERE EmployeeId = " + EmployeeId, mysqlconnection);

            mysqlconnection.Open();
            SqlDataReader DrE = cmdE.ExecuteReader();

            if (DrE.HasRows == true)
            {
                BindingSource sourceE = new BindingSource();
                sourceE.DataSource = DrE;
                EmployeeDataGridView.DataSource = sourceE;
            }
            else
            {
                EmployeeDataGridView.DataSource = null;
                MessageBox.Show("No data to show for Employee");
               
            }
            DrE.Close();

                
              
           
                 SqlDataReader DrC = cmdC.ExecuteReader();
            if (DrC.HasRows == true)
            {

                BindingSource sourceC = new BindingSource();
                sourceC.DataSource = DrC;

                CompanyDataGridView.DataSource = sourceC;
            }
            else
            {
                CompanyDataGridView.DataSource = null;
                MessageBox.Show("No data to show for Company");
            }
                DrC.Close();


            
            SqlDataReader DrP = cmdP.ExecuteReader();

            if (DrP.HasRows == true)
            {

                BindingSource sourceP = new BindingSource();
                sourceP.DataSource = DrP;
                ProjectDataGridView.DataSource = sourceP;
            }
            else
            {
                ProjectDataGridView.DataSource = null;
                MessageBox.Show("No data to show for Project");

            }
            DrP.Close();

            mysqlconnection.Close();
            

        }

        private void DashBoardEmployeeIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompanyDetailsSaveButton_Click(object sender, EventArgs e)
        {
            
            CompanyModel companyModel = new CompanyModel()
            {
                EmployerName = EmployerNameTextBox.Text,
                EmployerContactNumber = Convert.ToInt64(EmployerContactNumberTextBox.Text),
                EmployerAddress = EmployerLocationTextBox.Text,
                Website = EmployerWebsiteTextBox.Text,
                EmployeeId = Convert.ToInt32(Employee_CompanyComboBox.Text)

            };

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveCompanyData(companyModel);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved Company Detail");
            else
                MessageBox.Show("Could Not Save");

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            TechnicalModel technicalModel = new TechnicalModel()
            {
                UI = UITextBox.Text,
                ProgrammingLanguage = ProgrammingLanguageTextBox.Text,
                DatabaseName = DatabaseTextBox.Text,
                EmployeeId = Convert.ToInt32(Employee_TechnicalComboBox.Text)

            };
            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveTechnicalData(technicalModel);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved to Technical Detail");
            else
                MessageBox.Show("Could Not Save");

        }

       
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

      
        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearButton(TechnicalDetailTab.Controls);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void EducationDetailSaveButton_Click(object sender, EventArgs e)
        {
            
            EducationModel educationModel = new EducationModel
            {
                CourseType = CourseTextBox.Text,
                YearOfPass = YearOfPassTextBox.Text,
                CourseSpecialization = CourseSpecializationTextBox.Text,
                EmployeeId = Convert.ToInt32(Employee_EducationComboBox.Text)

            };

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();
            int NoOfRowsAffected = EmployeeDAL.SaveEducationData(educationModel);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved to Education Detail");
            else
                MessageBox.Show("Could Not Save");
            
        }

        private void EmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
             
        private void ProjectDetailClearButton_Click(object sender, EventArgs e)
        {
            ClearButton(ProjectDetailTab.Controls);
        }

        public void ClearButton(Control.ControlCollection CurrentTab)
        {
            foreach (var EveryBox in CurrentTab)
            {
                if (EveryBox.GetType().Equals(typeof(TextBox)))
                {
                    TextBox TextBoxInTab = EveryBox as TextBox;
                    TextBoxInTab.Clear();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearButton(CompanyDetailTab.Controls);
        }

        private void EducationClearButton_Click(object sender, EventArgs e)
        {
            ClearButton(EducationDetailTab.Controls);
        }
    }
}

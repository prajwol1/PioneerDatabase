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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
           try
           {

                string FirstName = FirstNameTextBox.Text;
                string LastName = LastNameTextBox.Text;
                string EmailId = EmailIdTextBox.Text;
                long MobileNumber = Convert.ToInt64(MobileNumberTextBox.Text);
                long AlternateMobileNumber = Convert.ToInt64(AlternateMobileNumberTextBox.Text);
                string Address1 = Address1TextBox.Text;
                string Address2 = Address2TextBox.Text;
                string CurrentCountry = CurrentCountryTextBox.Text;
                string HomeCountry = HomeCountryTextBox.Text;
                int ZipCode = Convert.ToInt32(ZipCodeTextBox.Text);
                
                EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

                int NoOfRowsAffected = EmployeeDAL.SaveEmployeeData(FirstName, LastName, EmailId, MobileNumber, AlternateMobileNumber, Address1, Address2, CurrentCountry, HomeCountry, ZipCode);
                if (NoOfRowsAffected > 0)
                    MessageBox.Show("Succesfully saved");
                else
                    MessageBox.Show("Could Not Save");
            }
            catch (Exception exception)
            {
                MessageBox.Show("EXCEPTION OCCURED. PLEASE CONTACT ADMINISTRATOR",exception.Message);
            }
            finally
            {
               

            }
            
           
         }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeDetailsClearButton_Click(object sender, EventArgs e)
        {
            ClearButton(EmployeeDetailTab.Controls);
        }

        private void EmployeeDetailTab_Click(object sender, EventArgs e)
        {

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

            //dataGridView1.DataSource = source;
            mysqlconnection.Close();


        }

        private void ProjectDetailSaveButton_Click(object sender, EventArgs e)
        {
            
            string ProjectName = ProjectNameTextBox.Text;
            string ClientName = ClientNameTextBox.Text;
            string Location = LocationTextBox.Text;
            string Roles = RolesTextBox.Text;
            int EmployeeIdProject = Convert.ToInt32(Employee_ProjectComboBox.Text);

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveProjectData(ProjectName, ClientName, Location, Roles,EmployeeIdProject);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved");
            else
                MessageBox.Show("Could Not Save");



            MessageBox.Show("Your Datas has been saved into the Project database");
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                BindingSource sourceE = new BindingSource();
                sourceE.DataSource = DrE;
                EmployeeDataGridView.DataSource = sourceE;
                DrE.Close();

                
                

                //int check = cmdC.ExecuteNonQuery();
           
                 SqlDataReader DrC = cmdC.ExecuteReader();
                if (DrC.HasRows ==true)
                {
                    
                    BindingSource sourceC = new BindingSource();
                    sourceC.DataSource = DrC;
                    
                    CompanyDataGridView.DataSource = sourceC;
                }
                else
                    MessageBox.Show("No data to show for Company");
            DrC.Close();




            //int check2 = cmdC.ExecuteNonQuery();
            SqlDataReader DrP = cmdP.ExecuteReader();

                if (DrP.HasRows == true)
                {
                
                BindingSource sourceP = new BindingSource();
                    sourceP.DataSource = DrP;
                    ProjectDataGridView.DataSource = sourceP;
                }
                else
                    MessageBox.Show("No data to show for Project");
            DrP.Close();



            //ProjectDataGridView.DataSource = sourceP;

            mysqlconnection.Close();

           

        }

        private void DashBoardEmployeeIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompanyDetailsSaveButton_Click(object sender, EventArgs e)
        {
            string EmployerName = EmployerNameTextBox.Text;
            long EmployerContactNumber = Convert.ToInt64(EmployerContactNumberTextBox.Text);
            string EmployerAddress = EmployerLocationTextBox.Text;
            string Website = EmployerWebsiteTextBox.Text;
            int EmployeeId = Convert.ToInt32(Employee_CompanyComboBox.Text);

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveCompanyData(EmployerName, EmployerContactNumber, EmployerAddress, Website, EmployeeId);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved");
            else
                MessageBox.Show("Could Not Save");



            MessageBox.Show("Your Data has been saved into the Company Detail database");


        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string UI = UITextBox.Text;
            string ProgrammingLanguage = ProgrammingLanguageTextBox.Text;
            string DatabaseName = DatabaseTextBox.Text;
            int EmployeeId = Convert.ToInt32(Employee_TechnicalComboBox.Text);

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveTechnicalData(UI, ProgrammingLanguage, DatabaseName, EmployeeId);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved");
            else
                MessageBox.Show("Could Not Save");



            MessageBox.Show("Your Datas has been saved into the Technical Detail database");

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
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

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void EducationDetailSaveButton_Click(object sender, EventArgs e)
        {
            string CourseType = CourseTextBox.Text;
            int YearOfPass= Convert.ToInt32(YearOfPassTextBox.Text);
            string CourseSpecialization = CourseSpecializationTextBox.Text;

            int EmployeeId = Convert.ToInt32(Employee_EducationComboBox.Text);

            EmployeeDataAccessLayer EmployeeDAL = new EmployeeDataAccessLayer();

            int NoOfRowsAffected = EmployeeDAL.SaveEducationData(CourseType, YearOfPass, CourseSpecialization, EmployeeId);
            if (NoOfRowsAffected > 0)
                MessageBox.Show("Succesfully saved");
            else
                MessageBox.Show("Could Not Save");


            MessageBox.Show("Your Datas has been saved into the Technical Detail database");
        }

        private void EmployeeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void DropDownButton_Click(object sender, EventArgs e)
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

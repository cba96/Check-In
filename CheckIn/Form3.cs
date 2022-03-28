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

namespace CheckIn
{
    public partial class Form3 : Form
    {
        string cs = @"Data Source=hyzoon.com,8433;Initial Catalog=UserWorkDb;User ID=sa;Password=1q2w3e4r5t!";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;

        private void ClearControls()
        {
            dateTimePicker1.Text = "";
            txtName_TB.Text = "";
            numericUpDown1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            txtDelYesOrNo.Text = "";
            txtEditer.Text = "";
            txtEmployeeNumber2.Text = "";

        }

        public Form3()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy-MM-dd";
        }

        private void frmSearch_Load(object sender, EventArgs e)
        { //일단 dailyinfo 테이블을 끌어다옴, 출력은 아직
            con = new SqlConnection(cs);
            con.Open();
            adapt = new SqlDataAdapter("SELECT * FROM user_info, user_dailyinfo", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dgvInfo.DataSource = dt;
            con.Close();
        }

        private void btnSelectSearch_Click(object sender, EventArgs e)
        { //검색 버튼 누르면 그리드뷰에 뜸, 그리고 출력.
            con = new SqlConnection(cs);
            con.Open();
            //            adapt = new SqlDataAdapter("SELECT user_dailyinfo.Date_TB2,user_info.EmployeeNumber,user_dailyinfo.Temp,user_info.Name_TB, user_dailyinfo.GoToWork,user_dailyinfo.WorkFromHome,user_dailyinfo.Vacation, user_dailyinfo.Editer, user_dailyinfo.DelYesOrNo FROM user_info INNER JOIN user_dailyinfo ON user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2 WHERE Date_TB2 like '" + txtSearchDate.Text + "%'", con);
            //*****                       adapt = new SqlDataAdapter("SELECT user_dailyinfo.Date_TB2,user_info.EmployeeNumber,user_dailyinfo.Temp,user_info.Name_TB, user_dailyinfo.GoToWork,user_dailyinfo.WorkFromHome,user_dailyinfo.Vacation, user_dailyinfo.Editer, user_dailyinfo.DelYesOrNo FROM user_info INNER JOIN user_dailyinfo ON user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2 WHERE Date_TB2 like '" + dateTimePicker2.Text + "%'", con);
            //           adapt = new SqlDataAdapter("SELECT user_dailyinfot.Date_TB2,user_info.EmployeeNumber,user_dailyinfo.Temp,user_info.Name_TB, user_dailyinfo.GoToWork,user_dailyinfo.WorkFromHome,user_dailyinfo.Vacation, user_dailyinfo.Editer, user_dailyinfo.DelYesOrNo FROM user_info INNER JOIN user_dailyinfo ON user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2 WHERE Date_TB2"  + dateTimePicker2.Text + "%'" + "AND Name_TB='" + txtName_TB.Text +"'", con);
            //            adapt = new SqlDataAdapter("SELECT user_dailyinfo.Date_TB2,user_info.EmployeeNumber,user_dailyinfo.Temp,user_info.Name_TB, user_dailyinfo.GoToWork,user_dailyinfo.WorkFromHome,user_dailyinfo.Vacation, user_dailyinfo.Editer, user_dailyinfo.DelYesOrNo FROM user_info INNER JOIN user_dailyinfo ON user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2 WHERE Name_TB like '" + txtName_TB.Text + "%'" + "AND " + "Date_TB2 like '" + dateTimePicker2.Text + "%'", con);
            adapt = new SqlDataAdapter("SELECT user_dailyinfo.Date_TB2,user_info.EmployeeNumber,user_dailyinfo.Temp,user_info.Name_TB, user_dailyinfo.GoToWork,user_dailyinfo.WorkFromHome,user_dailyinfo.Vacation, user_dailyinfo.Editer, user_dailyinfo.DelYesOrNo FROM user_info INNER JOIN user_dailyinfo ON user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2 WHERE Name_TB like '" + txtName_TB.Text + "%'" + "AND " + "Date_TB2  BETWEEN '" + dateTimePicker2.Text +"'" + " AND " + "'" + dateTimePicker3.Text + "'", con);

            dt = new DataTable();
            adapt.Fill(dt);
            dgvInfo.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuPage f = new MenuPage();
            f.Show();
        }

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtEmployeeNumber2.Text = dgvInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Text = dgvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtName_TB.Text = dgvInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox1.Text = dgvInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox2.Text = dgvInfo.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox3.Text = dgvInfo.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtEditer.Text = dgvInfo.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDelYesOrNo.Text = dgvInfo.Rows[e.RowIndex].Cells[8].Value.ToString();

            if (e.ColumnIndex == 2)  // 3번째 칼럼이 선택되면....
            {
                MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text != "" && numericUpDown1.Text != "")
            {
                try
                {
                    


                    cmd = new SqlCommand("UPDATE user_dailyinfo SET Temp=@Temp,GoToWork=@GoToWork,WorkFromHome=@WorkFromHome,Vacation=@Vacation," +
                        "DelYesOrNo=@DelYesOrNo,Editer=@Editer,EditTime=@EditTime WHERE EmployeeNumber2=@EmployeeNumber2", con);
                    con.Open();
//                    cmd.Parameters.AddWithValue("@Date_TB2", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Temp", numericUpDown1.Text);
                    cmd.Parameters.AddWithValue("@GoToWork", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@WorkFromHome", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Vacation", comboBox3.Text);
                    //                cmd.Parameters.AddWithValue("@DelYesOrNo", DelYesOrNocomboBox1.Text);
                    cmd.Parameters.AddWithValue("@DelYesOrNo", 0);
                    cmd.Parameters.AddWithValue("@Editer", txtEditer.Text);
                    cmd.Parameters.AddWithValue("@EditTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@EmployeeNumber2", txtEmployeeNumber2.Text);
                    //                cmd.Parameters.AddWithValue("@RegTime", dateTimePicker2.Text);
                    //               cmd.Parameters.AddWithValue("@Editer", txtEditer.Text);
                    //                cmd.Parameters.AddWithValue("@EditTime", dateTimePicker3.Text);
                    //                cmd.Parameters.AddWithValue("@EmployeeNumber2", txtEmployeeNumber2.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ClearControls();
                    MessageBox.Show("수정을 성공적으로 수행했습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("다시 확인해 주세요");
                }

            }
            else
            {
                MessageBox.Show("필수 기재 사항을 다 적어주세요!");
            }
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = (decimal)0.1;

            if (this.numericUpDown1.Value >= 40)
            {
                this.numericUpDown1.Value = 40;
            }

            if (this.numericUpDown1.Value <= 34)
            {
                this.numericUpDown1.Value = 34;
            }
        }

        
    }
}

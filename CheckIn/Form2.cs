using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckIn
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=hyzoon.com,8433;Initial Catalog=UserWorkDb;User ID=sa;Password=1q2w3e4r5t!");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int num2 = 0;
        SqlDataReader dr;

        public Form2()
        {
            InitializeComponent();
            PopulateData();

            //this.numericUpDown1.Maximum = 26;
           // this.numericUpDown1.Minimum = -1;

            //NumericUpDown 컨트롤 값 변경 이벤트 선언
            this.numericUpDown1.ValueChanged += numericUpDown1_ValueChanged_1;
        

        string s1 = DateTime.Now.ToString("yyyy-MM-dd");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            dateTimePicker1.CustomFormat = s1;
//            dateTimePicker2.Format = DateTimePickerFormat.Custom;
//            dateTimePicker2.CustomFormat = s1;
//            dateTimePicker3.Format = DateTimePickerFormat.Custom;
//            dateTimePicker3.CustomFormat = "yyyy-MM-dd";
        }

        private void PopulateData()
        { //테이블에 있는 데이터들을 뽑아서(SELCECT) 그리드뷰에 뿌려준다.
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM user_dailyinfo", con);
            adapt.Fill(dt);
            dgvDailyinfo.DataSource = dt;
            con.Close();
        }

        private void ClearControls()
        {
            //            txtEmployeeNumber2.Text = ""; 
            comboBox1.Text = "";
            dateTimePicker1.Text = "";
 //           txtTemp.Text = "";
//            groupBox1.Text = "";
//            radioButton1.Text = "";
//            radioButton2.Text = "";
//            radioButton3.Text = "";
            txtRegistrant.Text = "";
            num2 = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {//insert 로직
            if (comboBox1.Text != "" && dateTimePicker1.Text != "" && numericUpDown1.Text != "" && (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked))
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO user_dailyinfo(EmployeeNumber2,Date_TB2,Temp,GoToWork,WorkFromHome,Vacation,DelYesOrNo,Registrant,RegTime) VALUES (@EmployeeNumber2,@Date_TB2,@Temp,@GoToWork,@WorkFromHome,@Vacation,@DelYesOrNo,@Registrant,@RegTime)", con);
                    con.Open();

                    if (radioButton1.Checked == true)
                    {
                        radioButton1.Text = "True";
                    }
                    if (radioButton1.Checked == false)
                    {
                        radioButton1.Text = "False";
                    }
                    if (radioButton2.Checked == true)
                    {
                        radioButton2.Text = "True";
                    }
                    if (radioButton2.Checked == false)
                    {
                        radioButton2.Text = "False";
                    }
                    if (radioButton3.Checked == true)
                    {
                        radioButton3.Text = "True";
                    }
                    if (radioButton3.Checked == false)
                    {
                        radioButton3.Text = "False";
                    }
                   

                    cmd.Parameters.AddWithValue("@EmployeeNumber2", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Date_TB2", dateTimePicker1.Text);
 //                   double a = double.Parse(txtTemp.Text);
                    
                    cmd.Parameters.AddWithValue("@Temp", numericUpDown1.Text);
                    
//                    cmd.Parameters.AddWithValue("@Temp", txtTemp.Text);
                    cmd.Parameters.AddWithValue("@GoToWork", radioButton1.Text);
                    cmd.Parameters.AddWithValue("@WorkFromHome", radioButton2.Text);
                    cmd.Parameters.AddWithValue("@Vacation", radioButton3.Text);
                    cmd.Parameters.AddWithValue("@DelYesOrNo", 0);
                    cmd.Parameters.AddWithValue("@Registrant", txtRegistrant.Text);
                    cmd.Parameters.AddWithValue("@RegTime", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("신규 등록을 성공적으로 수행했습니다.");
                    PopulateData();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오늘 이미 출근 등록을 했습니다!");
                }

                //
                MessageBox.Show("출근 정보를 기입을 완료하였으니, 메인페이지로 이동합니다. 오늘도 화이팅 하세요!");
                this.Hide();
                MainPage f = new MainPage();
                f.Show();
                //
            }

            else
            {
                MessageBox.Show("필수 기재 사항을 다 적어주세요!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {//update 로직
            if (comboBox1.Text != "" && dateTimePicker1.Text != "" && numericUpDown1.Text != "")
                {
                cmd = new SqlCommand("UPDATE user_dailyinfo SET Temp=@Temp,GoToWork=@GoToWork,WorkFromHome=@WorkFromHome,Vacation=@Vacation,DelYesOrNo=@DelYesOrNo,Registrant=@Registrant,RegTime=@RegTime,Editer=@Editer,EditTime=@EditTime where EmployeeNumber2=@EmployeeNumber2", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Date_TB2", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Temp", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@GoToWork", radioButton1.Checked);
                cmd.Parameters.AddWithValue("@WorkFromHome", radioButton2.Checked);
                cmd.Parameters.AddWithValue("@Vacation", radioButton3.Checked);
                cmd.Parameters.AddWithValue("@Registrant", txtRegistrant.Text);
                cmd.Parameters.AddWithValue("@EmployeeNumber2", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("수정을 성공적으로 수행했습니다.");
                PopulateData();
                ClearControls();
            }
            else
            {
                MessageBox.Show("필수 기재 사항을 다 적어주세요!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {//delete 로직
            if (num2 != 0)
            {
                cmd = new SqlCommand("DELETE user_dailyinfo WHERE EmployeeNumber2=@EmployeeNumber2", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmployeeNumber2", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("삭제를 성공적으로 수행했습니다.");
                PopulateData();
                ClearControls();
            }
            else
            {
                MessageBox.Show("삭제할 행을 선택해 주세요.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {//뒤로가기 (메뉴페이지)
            this.Hide();
            MenuPage f = new MenuPage();
            f.Show();
        }

        private void txtEmployeeNumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {   //앞애 있는 문자들 빼고 입력 x
                e.Handled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

   /*
        private void txtTemp_KeyPress(object sender, KeyPressEventArgs e)
        {   //체온 입력 범위 설정 (3x.x도~42도)
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == '.'))
            {
                e.Handled = true;
            }


            /*
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back) || e.KeyChar == 46))
            {   //숫자와 백스페이스, 마침표를 제외한 나머지를 바로 처리
                e.Handled = true;
            }

            // (유효성 체크)
            try
            {
                double dVal = Convert.ToDouble(txtTemp.Text.Trim().Insert(txtTemp.SelectionStart, ((char)e.KeyChar).ToString()));
                if (dVal <= 2 || dVal > 43)
                {
                    e.Handled = true;
                    return;
                }
            }
            catch
            {
                MessageBox.Show("체온을 다시 입력해주세요.");
                return;
            }

            
        }
    */
        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=hyzoon.com,8433;Initial Catalog=UserWorkDb;User ID=sa;Password=1q2w3e4r5t!");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM user_info";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["EmployeeNumber"]);
            }
            con.Close();
        }

        private void txtTemp_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            numericUpDown1.DecimalPlaces = 1;
            numericUpDown1.Increment = (decimal)0.1;

            if (this.numericUpDown1.Value >= 40)
            {
                this.numericUpDown1.Value = 40;
            }

            if (this.numericUpDown1.Value <=34)
            {
                this.numericUpDown1.Value = 34;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

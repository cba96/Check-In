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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=hyzoon.com,8433;Initial Catalog=UserWorkDb;User ID=sa;Password=1q2w3e4r5t!");
        SqlCommand cmd;
        SqlDataAdapter adapt;        
        int num = 0;

        public Form1()
        {
            InitializeComponent();
            PopulateData();

            string s1 = DateTime.Now.ToString("yyyy-MM-dd");

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void PopulateData()
        {//테이블에 저장되있는 데이터들을 그리드뷰에 뿌려주기
            con.Open();
            DataTable dt = new DataTable();
//            adapt = new SqlDataAdapter("SELECT * FROM user_info", con);
            adapt = new SqlDataAdapter("SELECT* FROM user_info where DelYesOrNo NOT IN(1)", con);
            adapt.Fill(dt);
            dgvInfo.DataSource = dt;
            con.Close();
        }

        //Clear the data   
        private void ClearControls()
        {
            txtEmployeeNumber.Text = "";
            txtName_TB.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = "";
            txtRegistrant.Text = "";
            num = 0;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {//user_info테이블에 값 insert하기
            txtEmployeeNumber.MaxLength = 10;
            txtName_TB.MaxLength = 10;
            txtRegistrant.MaxLength = 10;
            txtEditer.MaxLength = 10;
            
            if (txtEmployeeNumber.Text != "" && txtName_TB.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text!="")
            {
                try
                {
                                      cmd = new SqlCommand("INSERT INTO user_info(EmployeeNumber,Name_TB,Title,Gender,Birth,DelYesOrNo,Registrant,RegTime) VALUES(@EmployeeNumber,@Name_TB,@Title,@Gender,@Birth,@DelYesOrNo,@Registrant,@RegTime)", con);
/*                    cmd = new SqlCommand("IF EXISTS(SELECT Name_TB, Title, Gender, Birth, DelYesOrNo, Registrant, RegTime" +
                        "FROM user_info WHERE EmployeeNumber=@EmployeeNumber)" +
                        "BEGIN UPDATE user_info SET Name_TB=@Name_TB,Title=@Title,Gender=@Gender,Birth=@Birth,DelYesOrNo=@DelYesOrNo,Registrant=@Registrant,RegTime=@RegTime" +
                        "where EmployeeNumber=@EmployeeNumber " +
                        "END" +
                        "ELSE BEGIN INSERT INTO user_info(EmployeeNumber, Name_TB, Title, Gender, Birth, DelYesOrNo, Registrant, RegTime) VALUES(@EmployeeNumber, @Name_TB, @Title, @Gender, @Birth, @DelYesOrNo, @Registrant, @RegTime)" +
                        "END", con);*/
                    con.Open();
                    cmd.Parameters.AddWithValue("@EmployeeNumber", txtEmployeeNumber.Text);
                    cmd.Parameters.AddWithValue("@Name_TB", txtName_TB.Text);
                    cmd.Parameters.AddWithValue("@Title", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Birth", dateTimePicker1.Text);
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
                    MessageBox.Show("사번이 중복 되었습니다. 다시 입력하세요.");
                }
            }
            else
            {
                MessageBox.Show("필수 기재 사항을 다 적어주세요!");
            }
        }

        // Update values to database


        private void btnUpdate_Click(object sender, EventArgs e)
        {//user.info 테이블에 있는 값을 사원번호 기준으로 값 수정
            if (txtEmployeeNumber.Text != "" && txtName_TB.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
            {
                cmd = new SqlCommand("UPDATE user_info SET Name_TB=@Name_TB,Title=@Title,Gender=@Gender,Birth=@Birth,DelYesOrNo=@DelYesOrNo,Editer=@Editer,EditTime=@EditTime where EmployeeNumber=@EmployeeNumber", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmployeeNumber", txtEmployeeNumber.Text);
                cmd.Parameters.AddWithValue("@Name_TB", txtName_TB.Text);
                cmd.Parameters.AddWithValue("@Title", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Birth", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@DelYesOrNo", 0);
                cmd.Parameters.AddWithValue("@Editer", txtEditer.Text);
                cmd.Parameters.AddWithValue("@EditTime", DateTime.Now);
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
        {//user.info에 있는 값을을 사원번호를 기준으로 row삭제
            if (num != 0)
            {
                cmd = new SqlCommand("DELETE user_info WHERE EmployeeNumber=@EmployeeNumber", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmployeeNumber", txtEmployeeNumber.Text);
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
        {
            this.Hide();
            MenuPage f = new MenuPage();
            f.Show();
        }

        private void txtEmployeeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링 (유효성 체크)
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
/*
            //txtEmployeeNumber박스에(사번) 9자리로 넘어가면 메세지 박스 출력 (유효성 체크)
            try
            {
                double dVal = Convert.ToDouble(txtEmployeeNumber.Text.Trim().Insert(txtEmployeeNumber.SelectionStart, ((char)e.KeyChar).ToString()));
                if (dVal < 1 || dVal > 99999999)
                {
                    e.Handled = true;
                    return;
                }
            }
            catch
            {
                MessageBox.Show("사번을 다시 입력해주세요.");
                return;
            }
*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //user.info 테이블에 있는 값을 사원번호 기준으로 값 수정
            if (txtEmployeeNumber.Text != "" && txtName_TB.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
            {
                    //cmd = new SqlCommand("UPDATE user_info SET Name_TB=@Name_TB,Title=@Title,Gender=@Gender,Birth=@Birth,DelYesOrNo=@DelYesOrNo,Editer=@Editer,EditTime=@EditTime where EmployeeNumber=@EmployeeNumber", con);
                    cmd = new SqlCommand("IF EXISTS(SELECT Name_TB, Title, Gender, Birth, DelYesOrNo, Registrant, RegTime" +
                           " FROM user_info WHERE EmployeeNumber=@EmployeeNumber)" +
                           " BEGIN UPDATE user_info SET Name_TB=@Name_TB,Title=@Title,Gender=@Gender,Birth=@Birth,DelYesOrNo=@DelYesOrNo,Registrant=@Registrant,RegTime=@RegTime" +
                           " where EmployeeNumber=@EmployeeNumber " +
                           "END" +
                           " ELSE BEGIN INSERT INTO user_info(EmployeeNumber, Name_TB, Title, Gender, Birth, DelYesOrNo, Registrant, RegTime) VALUES(@EmployeeNumber, @Name_TB, @Title, @Gender, @Birth, @DelYesOrNo, @Registrant, @RegTime)" +
                           " END", con);
                    con.Open();


                    cmd.Parameters.AddWithValue("@EmployeeNumber", txtEmployeeNumber.Text);
                    cmd.Parameters.AddWithValue("@Name_TB", txtName_TB.Text);
                    cmd.Parameters.AddWithValue("@Title", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Birth", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@DelYesOrNo", 0);
                    cmd.Parameters.AddWithValue("@Registrant", txtRegistrant.Text);
                    cmd.Parameters.AddWithValue("@RegTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Editer", txtEditer.Text);
                    cmd.Parameters.AddWithValue("@EditTime", DateTime.Now);
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
        
        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                txtEmployeeNumber.Text = dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName_TB.Text = dgvInfo.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dgvInfo.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox2.Text = dgvInfo.Rows[e.RowIndex].Cells[3].Value.ToString();
                dateTimePicker1.Text = dgvInfo.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtRegistrant.Text = dgvInfo.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtEditer.Text = dgvInfo.Rows[e.RowIndex].Cells[6].Value.ToString();

                if (e.ColumnIndex == 2)  // 3번째 칼럼이 선택되면....
                {
                    MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
                }
        }

        private void txtEmployeeNumber_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtName_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)) && e.KeyChar != 8 && txtName_TB.Text == "")
            {
                e.Handled = true;
            }

        }
    }
}

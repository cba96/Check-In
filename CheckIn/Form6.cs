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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=hyzoon.com,8433;Initial Catalog=UserWorkDb;User ID=sa;Password=1q2w3e4r5t!");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        int num2 = 0;
        SqlDataReader dr;
        public Form6()
        {
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {//테이블에 저장되있는 데이터들을 그리드뷰에 뿌려주기
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("SELECT * FROM user_info,user_dailyinfo where user_info.DelYesOrNo NOT IN(1)AND user_dailyinfo.DelYesOrNo NOT IN(1) AND user_info.EmployeeNumber = user_dailyinfo.EmployeeNumber2", con);
            adapt.Fill(dt);
            dgvInfo.DataSource = dt;
            con.Close();
        }

        private void ClearControls()
        {

            comboBox1.Text = "";
            num2 = 0;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //user.info에 있는 값을을 사원번호를 기준으로 row삭제
            if (comboBox1.Text != "")
            {
                cmd = new SqlCommand("UPDATE user_info SET DelYesOrNo=@DelYesOrNo WHERE EmployeeNumber=@EmployeeNumber", con);
                con.Open();
                cmd.Parameters.AddWithValue("@EmployeeNumber", comboBox1.Text);
                cmd.Parameters.AddWithValue("@DelYesOrNo", 1);
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

        private void dgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dgvInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void txtEmployeeNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
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
    }
}

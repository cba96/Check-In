using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckIn
{
    public partial class MenuPage : Form
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//신규 사원 정보 입력 페이지 이동(info)
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {//출근 정보 입력 페이지 이동(dailyinfo)
            this.Hide();
            Form2 f = new Form2();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        { //메인페이지 이동
            this.Hide();
            MainPage f = new MainPage();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {//일자별 사용자 체온 조회 페이지로 이동
            this.Hide();
            Form3 f = new Form3();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
//            Form4 f = new Form4();
//            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
//            Form5 f = new Form5();
//            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f = new Form6();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

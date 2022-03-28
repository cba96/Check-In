namespace CheckIn
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectSearch = new System.Windows.Forms.Button();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableAdapterManager1 = new CheckIn.UserWorkDbDataSetTableAdapters.TableAdapterManager();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEditer = new System.Windows.Forms.TextBox();
            this.txtDelYesOrNo = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtName_TB = new System.Windows.Forms.TextBox();
            this.txtEmployeeNumber2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(179, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "*날짜(YYYY-MM-DD)";
            // 
            // btnSelectSearch
            // 
            this.btnSelectSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectSearch.Location = new System.Drawing.Point(947, 98);
            this.btnSelectSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelectSearch.Name = "btnSelectSearch";
            this.btnSelectSearch.Size = new System.Drawing.Size(81, 32);
            this.btnSelectSearch.TabIndex = 5;
            this.btnSelectSearch.Text = "검색";
            this.btnSelectSearch.UseVisualStyleBackColor = false;
            this.btnSelectSearch.Click += new System.EventHandler(this.btnSelectSearch_Click);
            // 
            // dgvInfo
            // 
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInfo.Location = new System.Drawing.Point(5, 135);
            this.dgvInfo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.RowHeadersWidth = 62;
            this.dgvInfo.Size = new System.Drawing.Size(1027, 188);
            this.dgvInfo.TabIndex = 27;
            this.dgvInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellClick);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(43, 41);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 37);
            this.button6.TabIndex = 28;
            this.button6.Text = "<- 뒤로가기";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(791, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 18);
            this.label13.TabIndex = 48;
            this.label13.Text = "* 은 필수기재 사항임!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("바탕체", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(430, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 32);
            this.label2.TabIndex = 49;
            this.label2.Text = "일자 별 조회";
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.tuser_dailyinfoTableAdapter = null;
            this.tableAdapterManager1.tuser_infoTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = CheckIn.UserWorkDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager1.user_dailyinfoTableAdapter = null;
            this.tableAdapterManager1.user_infoTableAdapter = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 18);
            this.label8.TabIndex = 54;
            this.label8.Text = "출근 날짜";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 56;
            this.label4.Text = "체온";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 524);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 18);
            this.label6.TabIndex = 59;
            this.label6.Text = "수정자";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(315, 414);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 63;
            this.label9.Text = "출근";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 564);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 18);
            this.label10.TabIndex = 65;
            this.label10.Text = "삭제여부(0,1)";
            // 
            // txtEditer
            // 
            this.txtEditer.Location = new System.Drawing.Point(409, 517);
            this.txtEditer.Name = "txtEditer";
            this.txtEditer.Size = new System.Drawing.Size(314, 28);
            this.txtEditer.TabIndex = 64;
            // 
            // txtDelYesOrNo
            // 
            this.txtDelYesOrNo.Location = new System.Drawing.Point(409, 560);
            this.txtDelYesOrNo.Name = "txtDelYesOrNo";
            this.txtDelYesOrNo.Size = new System.Drawing.Size(314, 28);
            this.txtDelYesOrNo.TabIndex = 66;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.Location = new System.Drawing.Point(554, 651);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(208, 32);
            this.btnDelete.TabIndex = 69;
            this.btnDelete.Text = "삭제 (Delete)";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUpdate.Location = new System.Drawing.Point(281, 651);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(208, 32);
            this.btnUpdate.TabIndex = 68;
            this.btnUpdate.Text = "수정 (Update)";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(409, 331);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(314, 28);
            this.dateTimePicker1.TabIndex = 70;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(375, 98);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(269, 28);
            this.dateTimePicker2.TabIndex = 71;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(1, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 18);
            this.label11.TabIndex = 67;
            this.label11.Text = "*이름";
            // 
            // txtName_TB
            // 
            this.txtName_TB.Location = new System.Drawing.Point(60, 98);
            this.txtName_TB.Name = "txtName_TB";
            this.txtName_TB.Size = new System.Drawing.Size(115, 28);
            this.txtName_TB.TabIndex = 53;
            // 
            // txtEmployeeNumber2
            // 
            this.txtEmployeeNumber2.Location = new System.Drawing.Point(409, 605);
            this.txtEmployeeNumber2.Name = "txtEmployeeNumber2";
            this.txtEmployeeNumber2.Size = new System.Drawing.Size(314, 28);
            this.txtEmployeeNumber2.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 72;
            this.label3.Text = "사원번호";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Location = new System.Drawing.Point(671, 98);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(268, 28);
            this.dateTimePicker3.TabIndex = 74;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(409, 370);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(314, 28);
            this.numericUpDown1.TabIndex = 76;
            this.numericUpDown1.Value = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 452);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 78;
            this.label7.Text = "제택";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 491);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 18);
            this.label12.TabIndex = 79;
            this.label12.Text = "휴가";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(647, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 18);
            this.label15.TabIndex = 81;
            this.label15.Text = "~";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox1.Location = new System.Drawing.Point(409, 410);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(314, 26);
            this.comboBox1.TabIndex = 82;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox2.Location = new System.Drawing.Point(409, 449);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(314, 26);
            this.comboBox2.TabIndex = 83;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "True",
            "False"});
            this.comboBox3.Location = new System.Drawing.Point(409, 486);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(314, 26);
            this.comboBox3.TabIndex = 84;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 873);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.txtEmployeeNumber2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDelYesOrNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEditer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtName_TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgvInfo);
            this.Controls.Add(this.btnSelectSearch);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectSearch;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private UserWorkDbDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEditer;
        private System.Windows.Forms.TextBox txtDelYesOrNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtName_TB;
        private System.Windows.Forms.TextBox txtEmployeeNumber2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}
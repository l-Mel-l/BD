namespace BD {
    partial class Form2 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            dataGridViewCRM = new DataGridView();
            label1 = new Label();
            dataGridViewSubscribers = new DataGridView();
            label2 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            groupBox1 = new GroupBox();
            btnAddCRM = new Button();
            cmbProblemType = new ComboBox();
            cmbStatus = new ComboBox();
            cmbService = new ComboBox();
            txtProblemDescription = new TextBox();
            txtPersonalAccount = new TextBox();
            txtLogin = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCRM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubscribers).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3_2;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(37, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 81);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // dataGridViewCRM
            // 
            dataGridViewCRM.AllowUserToAddRows = false;
            dataGridViewCRM.AllowUserToDeleteRows = false;
            dataGridViewCRM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCRM.Location = new Point(13, 91);
            dataGridViewCRM.Name = "dataGridViewCRM";
            dataGridViewCRM.ReadOnly = true;
            dataGridViewCRM.Size = new Size(219, 129);
            dataGridViewCRM.TabIndex = 1;
            dataGridViewCRM.CellClick += dataGridViewCRM_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F);
            label1.Location = new Point(244, 13);
            label1.Name = "label1";
            label1.Size = new Size(278, 72);
            label1.TabIndex = 2;
            label1.Text = "Абоненты";
            // 
            // dataGridViewSubscribers
            // 
            dataGridViewSubscribers.AllowUserToAddRows = false;
            dataGridViewSubscribers.AllowUserToDeleteRows = false;
            dataGridViewSubscribers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSubscribers.Location = new Point(246, 91);
            dataGridViewSubscribers.Name = "dataGridViewSubscribers";
            dataGridViewSubscribers.ReadOnly = true;
            dataGridViewSubscribers.Size = new Size(443, 347);
            dataGridViewSubscribers.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 17F);
            label2.Location = new Point(690, 45);
            label2.Name = "label2";
            label2.Size = new Size(104, 31);
            label2.TabIndex = 4;
            label2.Text = "События";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(0, 85);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 2);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaptionText;
            panel2.Location = new Point(238, -12);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(2, 476);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaptionText;
            panel3.Location = new Point(690, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(2, 476);
            panel3.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddCRM);
            groupBox1.Controls.Add(cmbProblemType);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(cmbService);
            groupBox1.Controls.Add(txtProblemDescription);
            groupBox1.Controls.Add(txtPersonalAccount);
            groupBox1.Controls.Add(txtLogin);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(13, 226);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 212);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            // 
            // btnAddCRM
            // 
            btnAddCRM.Location = new Point(66, 189);
            btnAddCRM.Name = "btnAddCRM";
            btnAddCRM.Size = new Size(75, 23);
            btnAddCRM.TabIndex = 14;
            btnAddCRM.Text = "Добавить";
            btnAddCRM.UseVisualStyleBackColor = true;
            btnAddCRM.Click += btnAddCRM_Click;
            // 
            // cmbProblemType
            // 
            cmbProblemType.FormattingEnabled = true;
            cmbProblemType.Location = new Point(124, 110);
            cmbProblemType.Name = "cmbProblemType";
            cmbProblemType.Size = new Size(95, 23);
            cmbProblemType.TabIndex = 12;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(124, 85);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(95, 23);
            cmbStatus.TabIndex = 11;
            // 
            // cmbService
            // 
            cmbService.FormattingEnabled = true;
            cmbService.Location = new Point(124, 60);
            cmbService.Name = "cmbService";
            cmbService.Size = new Size(95, 23);
            cmbService.TabIndex = 10;
            // 
            // txtProblemDescription
            // 
            txtProblemDescription.Location = new Point(124, 135);
            txtProblemDescription.Name = "txtProblemDescription";
            txtProblemDescription.Size = new Size(95, 23);
            txtProblemDescription.TabIndex = 9;
            // 
            // txtPersonalAccount
            // 
            txtPersonalAccount.Location = new Point(124, 35);
            txtPersonalAccount.Name = "txtPersonalAccount";
            txtPersonalAccount.Size = new Size(95, 23);
            txtPersonalAccount.TabIndex = 8;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(124, 10);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(95, 23);
            txtLogin.TabIndex = 7;
            txtLogin.TextChanged += textBox1_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 135);
            label8.Name = "label8";
            label8.Size = new Size(124, 15);
            label8.TabIndex = 5;
            label8.Text = "Описание проблемы";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 110);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 4;
            label7.Text = "Тип проблемы";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 85);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 3;
            label6.Text = "Статус";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 60);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 2;
            label5.Text = "Услуга";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 35);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 1;
            label4.Text = "Лицевой счёт";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 10);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 0;
            label3.Text = "Логин абонента";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(dataGridViewSubscribers);
            Controls.Add(label1);
            Controls.Add(dataGridViewCRM);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCRM).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSubscribers).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private DataGridView dataGridViewCRM;
        private Label label1;
        private DataGridView dataGridViewSubscribers;
        private DataGridViewTextBoxColumn fullName;
        private DataGridViewTextBoxColumn contractNumber;
        private DataGridViewTextBoxColumn personalAccount;
        private DataGridViewTextBoxColumn service;
        private Label label2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox txtLogin;
        private ComboBox cmbProblemType;
        private ComboBox cmbStatus;
        private ComboBox cmbService;
        private TextBox txtProblemDescription;
        private TextBox txtPersonalAccount;
        private Button btnAddCRM;
    }
}
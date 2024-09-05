namespace Dictionaries
{
    partial class Form_main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btn_loadData = new Button();
            btn_LoadMuch = new Button();
            textBox1 = new TextBox();
            btn_sirch = new Button();
            cb_typeOfSirch = new ComboBox();
            btn_add = new Button();
            col_nom = new DataGridViewTextBoxColumn();
            col_foto = new DataGridViewTextBoxColumn();
            col_LstName = new DataGridViewTextBoxColumn();
            col_FrstName = new DataGridViewTextBoxColumn();
            col_PtrName = new DataGridViewTextBoxColumn();
            col_DateOfB = new DataGridViewTextBoxColumn();
            col_company = new DataGridViewTextBoxColumn();
            col_rank = new DataGridViewTextBoxColumn();
            col_dateOfHire = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { col_nom, col_foto, col_LstName, col_FrstName, col_PtrName, col_DateOfB, col_company, col_rank, col_dateOfHire });
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1021, 493);
            dataGridView1.TabIndex = 0;
            // 
            // btn_loadData
            // 
            btn_loadData.Location = new Point(12, 12);
            btn_loadData.Name = "btn_loadData";
            btn_loadData.Size = new Size(120, 30);
            btn_loadData.TabIndex = 1;
            btn_loadData.Text = "Загрузить данные";
            btn_loadData.UseVisualStyleBackColor = true;
            // 
            // btn_LoadMuch
            // 
            btn_LoadMuch.Location = new Point(419, 12);
            btn_LoadMuch.Name = "btn_LoadMuch";
            btn_LoadMuch.Size = new Size(160, 30);
            btn_LoadMuch.TabIndex = 2;
            btn_LoadMuch.Text = "Стресс тест";
            btn_LoadMuch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F);
            textBox1.Location = new Point(585, 15);
            textBox1.Margin = new Padding(3, 3, 1, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 3;
            // 
            // btn_sirch
            // 
            btn_sirch.Location = new Point(787, 12);
            btn_sirch.Margin = new Padding(1, 3, 3, 3);
            btn_sirch.Name = "btn_sirch";
            btn_sirch.Size = new Size(90, 30);
            btn_sirch.TabIndex = 4;
            btn_sirch.Text = "Поиск";
            btn_sirch.UseVisualStyleBackColor = true;
            // 
            // cb_typeOfSirch
            // 
            cb_typeOfSirch.Font = new Font("Segoe UI", 9F);
            cb_typeOfSirch.FormattingEnabled = true;
            cb_typeOfSirch.Items.AddRange(new object[] { "по фамилии", "по имени", "по отчеству", "по организации", "по должности" });
            cb_typeOfSirch.Location = new Point(883, 17);
            cb_typeOfSirch.Name = "cb_typeOfSirch";
            cb_typeOfSirch.Size = new Size(150, 23);
            cb_typeOfSirch.TabIndex = 5;
            cb_typeOfSirch.Text = "по фамилии";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(147, 12);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(120, 30);
            btn_add.TabIndex = 6;
            btn_add.Text = "Добавить";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // col_nom
            // 
            col_nom.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_nom.HeaderText = "№";
            col_nom.MinimumWidth = 10;
            col_nom.Name = "col_nom";
            col_nom.ReadOnly = true;
            col_nom.Width = 45;
            // 
            // col_foto
            // 
            col_foto.HeaderText = "Фото";
            col_foto.Name = "col_foto";
            // 
            // col_LstName
            // 
            col_LstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_LstName.HeaderText = "Фамилия";
            col_LstName.MinimumWidth = 90;
            col_LstName.Name = "col_LstName";
            col_LstName.ReadOnly = true;
            col_LstName.Width = 90;
            // 
            // col_FrstName
            // 
            col_FrstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_FrstName.HeaderText = "Имя";
            col_FrstName.MinimumWidth = 90;
            col_FrstName.Name = "col_FrstName";
            col_FrstName.Width = 90;
            // 
            // col_PtrName
            // 
            col_PtrName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_PtrName.HeaderText = "Отчество";
            col_PtrName.MinimumWidth = 90;
            col_PtrName.Name = "col_PtrName";
            col_PtrName.ReadOnly = true;
            col_PtrName.Width = 90;
            // 
            // col_DateOfB
            // 
            col_DateOfB.HeaderText = "Дата рождения";
            col_DateOfB.Name = "col_DateOfB";
            col_DateOfB.ReadOnly = true;
            col_DateOfB.Width = 150;
            // 
            // col_company
            // 
            col_company.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_company.FillWeight = 50F;
            col_company.HeaderText = "Организация";
            col_company.Name = "col_company";
            // 
            // col_rank
            // 
            col_rank.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_rank.FillWeight = 50F;
            col_rank.HeaderText = "Должность";
            col_rank.Name = "col_rank";
            // 
            // col_dateOfHire
            // 
            col_dateOfHire.HeaderText = "Дата принятия на работу";
            col_dateOfHire.Name = "col_dateOfHire";
            col_dateOfHire.ReadOnly = true;
            col_dateOfHire.Width = 150;
            // 
            // Form_main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 553);
            Controls.Add(btn_add);
            Controls.Add(cb_typeOfSirch);
            Controls.Add(btn_sirch);
            Controls.Add(textBox1);
            Controls.Add(btn_LoadMuch);
            Controls.Add(btn_loadData);
            Controls.Add(dataGridView1);
            Name = "Form_main";
            Text = "Список";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btn_loadData;
        private Button btn_LoadMuch;
        private TextBox textBox1;
        private Button btn_sirch;
        private ComboBox cb_typeOfSirch;
        private Button btn_add;
        private DataGridViewTextBoxColumn col_nom;
        private DataGridViewTextBoxColumn col_foto;
        private DataGridViewTextBoxColumn col_LstName;
        private DataGridViewTextBoxColumn col_FrstName;
        private DataGridViewTextBoxColumn col_PtrName;
        private DataGridViewTextBoxColumn col_DateOfB;
        private DataGridViewTextBoxColumn col_company;
        private DataGridViewTextBoxColumn col_rank;
        private DataGridViewTextBoxColumn col_dateOfHire;
    }
}

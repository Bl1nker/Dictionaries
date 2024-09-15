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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            Table1 = new DataGridView();
            contextMenuForTable1 = new ContextMenuStrip(components);
            addItem = new ToolStripMenuItem();
            btn_loadData = new Button();
            btn_LoadMuch = new Button();
            textBox_Search = new TextBox();
            btn_search = new Button();
            cb_typeOfSearch = new ComboBox();
            btn_add = new Button();
            removeItem = new ToolStripMenuItem();
            removeAll = new ToolStripMenuItem();
            editItem = new ToolStripMenuItem();
            btn_saveData = new Button();
            col_id = new DataGridViewTextBoxColumn();
            col_photo = new DataGridViewImageColumn();
            col_LstName = new DataGridViewTextBoxColumn();
            col_FrstName = new DataGridViewTextBoxColumn();
            col_Surname = new DataGridViewTextBoxColumn();
            col_DateOfB = new DataGridViewTextBoxColumn();
            col_company = new DataGridViewTextBoxColumn();
            col_rank = new DataGridViewTextBoxColumn();
            col_dateOfHire = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Table1).BeginInit();
            contextMenuForTable1.SuspendLayout();
            SuspendLayout();
            // 
            // Table1
            // 
            Table1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Table1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Table1.Columns.AddRange(new DataGridViewColumn[] { col_id, col_photo, col_LstName, col_FrstName, col_Surname, col_DateOfB, col_company, col_rank, col_dateOfHire });
            Table1.ContextMenuStrip = contextMenuForTable1;
            Table1.Location = new Point(12, 48);
            Table1.Name = "Table1";
            Table1.RowHeadersVisible = false;
            Table1.Size = new Size(1021, 493);
            Table1.TabIndex = 0;
            // 
            // contextMenuForTable1
            // 
            contextMenuForTable1.Items.AddRange(new ToolStripItem[] { addItem });
            contextMenuForTable1.Name = "contextMenuforTable1";
            contextMenuForTable1.Size = new Size(167, 26);
            // 
            // addItem
            // 
            addItem.Name = "addItem";
            addItem.Size = new Size(166, 22);
            addItem.Text = "Добавить запись";
            addItem.Click += btn_add_Click;
            // 
            // btn_loadData
            // 
            btn_loadData.Location = new Point(12, 12);
            btn_loadData.Name = "btn_loadData";
            btn_loadData.Size = new Size(120, 30);
            btn_loadData.TabIndex = 1;
            btn_loadData.Text = "Загрузить реестр";
            btn_loadData.UseVisualStyleBackColor = true;
            btn_loadData.Click += btn_loadData_Click;
            // 
            // btn_LoadMuch
            // 
            btn_LoadMuch.Location = new Point(419, 12);
            btn_LoadMuch.Name = "btn_LoadMuch";
            btn_LoadMuch.Size = new Size(160, 30);
            btn_LoadMuch.TabIndex = 2;
            btn_LoadMuch.Text = "Стресс тест";
            btn_LoadMuch.UseVisualStyleBackColor = true;
            btn_LoadMuch.Click += btn_LoadMuch_Click;
            // 
            // textBox_Search
            // 
            textBox_Search.Font = new Font("Segoe UI", 9F);
            textBox_Search.Location = new Point(585, 15);
            textBox_Search.Margin = new Padding(3, 3, 1, 3);
            textBox_Search.Name = "textBox_Search";
            textBox_Search.Size = new Size(200, 23);
            textBox_Search.TabIndex = 3;
            // 
            // btn_search
            // 
            btn_search.Location = new Point(787, 12);
            btn_search.Margin = new Padding(1, 3, 3, 3);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(90, 30);
            btn_search.TabIndex = 4;
            btn_search.Text = "Поиск";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // cb_typeOfSearch
            // 
            cb_typeOfSearch.Font = new Font("Segoe UI", 9F);
            cb_typeOfSearch.FormattingEnabled = true;
            cb_typeOfSearch.Items.AddRange(new object[] { "по фамилии", "по имени", "по отчеству", "по организации", "по должности" });
            cb_typeOfSearch.Location = new Point(883, 17);
            cb_typeOfSearch.Name = "cb_typeOfSearch";
            cb_typeOfSearch.Size = new Size(150, 23);
            cb_typeOfSearch.TabIndex = 5;
            cb_typeOfSearch.Text = "по фамилии";
            // 
            // btn_add
            // 
            btn_add.Location = new Point(147, 12);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(120, 30);
            btn_add.TabIndex = 6;
            btn_add.Text = "Добавить запись";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // removeItem
            // 
            removeItem.Name = "removeItem";
            removeItem.Size = new Size(166, 22);
            removeItem.Text = "Удалить запись";
            removeItem.Click += RemoveItem_Click;
            // 
            // removeAll
            // 
            removeAll.Name = "removeAll";
            removeAll.Size = new Size(166, 22);
            removeAll.Text = "Очистить реестр";
            removeAll.Click += RemoveAllItem_Click;
            // 
            // editItem
            // 
            editItem.Name = "editItem";
            editItem.Size = new Size(166, 22);
            editItem.Text = "Изменить запись";
            // 
            // btn_saveData
            // 
            btn_saveData.Location = new Point(292, 12);
            btn_saveData.Name = "btn_saveData";
            btn_saveData.Size = new Size(75, 30);
            btn_saveData.TabIndex = 7;
            btn_saveData.Text = "Сохранить";
            btn_saveData.UseVisualStyleBackColor = true;
            btn_saveData.Click += btn_saveData_Click;
            // 
            // col_id
            // 
            col_id.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_id.HeaderText = "ID";
            col_id.MinimumWidth = 10;
            col_id.Name = "col_id";
            col_id.ReadOnly = true;
            col_id.Width = 43;
            // 
            // col_photo
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = resources.GetObject("dataGridViewCellStyle1.NullValue");
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            col_photo.DefaultCellStyle = dataGridViewCellStyle1;
            col_photo.HeaderText = "Фото";
            col_photo.Name = "col_photo";
            col_photo.ReadOnly = true;
            col_photo.Resizable = DataGridViewTriState.True;
            col_photo.SortMode = DataGridViewColumnSortMode.Automatic;
            col_photo.ImageLayout = DataGridViewImageCellLayout.Stretch;
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
            col_FrstName.ReadOnly = true;
            col_FrstName.Width = 90;
            // 
            // col_Surname
            // 
            col_Surname.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col_Surname.HeaderText = "Отчество";
            col_Surname.MinimumWidth = 90;
            col_Surname.Name = "col_Surname";
            col_Surname.ReadOnly = true;
            col_Surname.Width = 90;
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
            col_company.ReadOnly = true;
            // 
            // col_rank
            // 
            col_rank.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_rank.FillWeight = 50F;
            col_rank.HeaderText = "Должность";
            col_rank.Name = "col_rank";
            col_rank.ReadOnly = true;
            // 
            // col_dateOfHire
            // 
            col_dateOfHire.HeaderText = "Дата принятия на работу";
            col_dateOfHire.Name = "col_dateOfHire";
            col_dateOfHire.ReadOnly = true;
            col_dateOfHire.Width = 170;
            // 
            // Form_main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1045, 553);
            Controls.Add(btn_saveData);
            Controls.Add(btn_add);
            Controls.Add(cb_typeOfSearch);
            Controls.Add(btn_search);
            Controls.Add(textBox_Search);
            Controls.Add(btn_LoadMuch);
            Controls.Add(btn_loadData);
            Controls.Add(Table1);
            Name = "Form_main";
            Text = "Список";
            ((System.ComponentModel.ISupportInitialize)Table1).EndInit();
            contextMenuForTable1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void Form_main_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DataGridView Table1;
        private Button btn_loadData;
        private Button btn_LoadMuch;
        private TextBox textBox_Search;
        private Button btn_search;
        private ComboBox cb_typeOfSearch;
        private Button btn_add;
        private ContextMenuStrip contextMenuForTable1;
        private ToolStripMenuItem addItem;
        private ToolStripMenuItem removeItem;
        private ToolStripMenuItem removeAll;
        private ToolStripMenuItem editItem;
        private Button btn_saveData;
        private DataGridViewTextBoxColumn col_id;
        private DataGridViewImageColumn col_photo;
        private DataGridViewTextBoxColumn col_LstName;
        private DataGridViewTextBoxColumn col_FrstName;
        private DataGridViewTextBoxColumn col_Surname;
        private DataGridViewTextBoxColumn col_DateOfB;
        private DataGridViewTextBoxColumn col_company;
        private DataGridViewTextBoxColumn col_rank;
        private DataGridViewTextBoxColumn col_dateOfHire;
    }
}

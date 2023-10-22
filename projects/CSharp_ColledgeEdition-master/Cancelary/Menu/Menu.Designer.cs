namespace Menu
{
    partial class Menu
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
            DBRedescribeBTN = new Button();
            WriteBTN = new Button();
            Exit = new Button();
            dataGridView = new DataGridView();
            About = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // DBRedescribeBTN
            // 
            DBRedescribeBTN.Location = new Point(12, 23);
            DBRedescribeBTN.Name = "DBRedescribeBTN";
            DBRedescribeBTN.Size = new Size(217, 25);
            DBRedescribeBTN.TabIndex = 0;
            DBRedescribeBTN.Text = "Перезаписать данные из файлов";
            DBRedescribeBTN.UseVisualStyleBackColor = true;
            DBRedescribeBTN.Click += DBRedescribeBTN_Click;
            // 
            // WriteBTN
            // 
            WriteBTN.Location = new Point(12, 54);
            WriteBTN.Name = "WriteBTN";
            WriteBTN.Size = new Size(217, 25);
            WriteBTN.TabIndex = 1;
            WriteBTN.Text = "Вывести данные";
            WriteBTN.UseVisualStyleBackColor = true;
            WriteBTN.Click += WriteBTN_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(12, 243);
            Exit.Name = "Exit";
            Exit.Size = new Size(75, 25);
            Exit.TabIndex = 3;
            Exit.Text = "Выйти";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(248, 23);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(450, 244);
            dataGridView.TabIndex = 5;
            dataGridView.Visible = false;
            // 
            // About
            // 
            About.Location = new Point(102, 243);
            About.Name = "About";
            About.Size = new Size(105, 25);
            About.TabIndex = 6;
            About.Text = "О программе";
            About.UseVisualStyleBackColor = true;
            About.Click += About_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(237, 284);
            Controls.Add(About);
            Controls.Add(dataGridView);
            Controls.Add(Exit);
            Controls.Add(WriteBTN);
            Controls.Add(DBRedescribeBTN);
            Name = "Menu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button DBRedescribeBTN;
        private Button WriteBTN;
        private Button Exit;
        private DataGridView dataGridView;
        private Button About;
    }
}
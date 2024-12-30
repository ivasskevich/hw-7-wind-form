namespace hw_7_books_autors
{
    partial class Form1
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            addAuthorToolStripMenuItem = new ToolStripMenuItem();
            deleteAuthorToolStripMenuItem = new ToolStripMenuItem();
            editAuthorToolStripMenuItem = new ToolStripMenuItem();
            addABookToolStripMenuItem = new ToolStripMenuItem();
            deleteABookToolStripMenuItem = new ToolStripMenuItem();
            editBookToolStripMenuItem = new ToolStripMenuItem();
            comboBox1 = new ComboBox();
            listBox1 = new ListBox();
            checkBox1 = new CheckBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(424, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, signOutToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(180, 22);
            signOutToolStripMenuItem.Text = "Sign out";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addAuthorToolStripMenuItem, deleteAuthorToolStripMenuItem, editAuthorToolStripMenuItem, addABookToolStripMenuItem, deleteABookToolStripMenuItem, editBookToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // addAuthorToolStripMenuItem
            // 
            addAuthorToolStripMenuItem.Name = "addAuthorToolStripMenuItem";
            addAuthorToolStripMenuItem.Size = new Size(180, 22);
            addAuthorToolStripMenuItem.Text = "Add author";
            // 
            // deleteAuthorToolStripMenuItem
            // 
            deleteAuthorToolStripMenuItem.Name = "deleteAuthorToolStripMenuItem";
            deleteAuthorToolStripMenuItem.Size = new Size(180, 22);
            deleteAuthorToolStripMenuItem.Text = "Delete author";
            // 
            // editAuthorToolStripMenuItem
            // 
            editAuthorToolStripMenuItem.Name = "editAuthorToolStripMenuItem";
            editAuthorToolStripMenuItem.Size = new Size(180, 22);
            editAuthorToolStripMenuItem.Text = "Edit author";
            // 
            // addABookToolStripMenuItem
            // 
            addABookToolStripMenuItem.Name = "addABookToolStripMenuItem";
            addABookToolStripMenuItem.Size = new Size(180, 22);
            addABookToolStripMenuItem.Text = "Add a book";
            // 
            // deleteABookToolStripMenuItem
            // 
            deleteABookToolStripMenuItem.Name = "deleteABookToolStripMenuItem";
            deleteABookToolStripMenuItem.Size = new Size(180, 22);
            deleteABookToolStripMenuItem.Text = "Delete a book";
            // 
            // editBookToolStripMenuItem
            // 
            editBookToolStripMenuItem.Name = "editBookToolStripMenuItem";
            editBookToolStripMenuItem.Size = new Size(180, 22);
            editBookToolStripMenuItem.Text = "Edit book";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(400, 23);
            comboBox1.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 72);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(400, 229);
            listBox1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(187, 319);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(52, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Filter";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 353);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(comboBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Books & Authors";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem addAuthorToolStripMenuItem;
        private ToolStripMenuItem deleteAuthorToolStripMenuItem;
        private ToolStripMenuItem editAuthorToolStripMenuItem;
        private ToolStripMenuItem addABookToolStripMenuItem;
        private ToolStripMenuItem deleteABookToolStripMenuItem;
        private ToolStripMenuItem editBookToolStripMenuItem;
        private ComboBox comboBox1;
        private ListBox listBox1;
        private CheckBox checkBox1;
    }
}

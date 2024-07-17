namespace ShabatGuest.Forms
{
    partial class LogIn
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
            label2 = new Label();
            buttonAdd = new Button();
            label1 = new Label();
            textBoxName = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 187);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 9;
            label2.Text = "רשימת אורחים";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(331, 112);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "הוסף אותי";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(349, 56);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 7;
            label1.Text = "מה שמך";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(268, 79);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(224, 27);
            textBoxName.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(231, 230);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RightToLeft = RightToLeft.Yes;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 455);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(buttonAdd);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            Name = "LogIn";
            Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button buttonAdd;
        private Label label1;
        private TextBox textBoxName;
        private DataGridView dataGridView1;
    }
}
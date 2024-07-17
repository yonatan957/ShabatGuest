namespace ShabatGuest.Forms
{
    partial class HomePage
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
            button_prev = new Button();
            button_next = new Button();
            textBox_chois = new TextBox();
            button_add = new Button();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button_prev
            // 
            button_prev.Location = new Point(46, 580);
            button_prev.Name = "button_prev";
            button_prev.Size = new Size(94, 29);
            button_prev.TabIndex = 0;
            button_prev.Text = "<<<<";
            button_prev.UseVisualStyleBackColor = true;
            button_prev.Click += button_prev_Click;
            // 
            // button_next
            // 
            button_next.Location = new Point(662, 580);
            button_next.Name = "button_next";
            button_next.Size = new Size(94, 29);
            button_next.TabIndex = 1;
            button_next.Text = ">>>>";
            button_next.UseVisualStyleBackColor = true;
            button_next.Click += button_next_Click;
            // 
            // textBox_chois
            // 
            textBox_chois.Location = new Point(303, 262);
            textBox_chois.Name = "textBox_chois";
            textBox_chois.Size = new Size(210, 27);
            textBox_chois.TabIndex = 3;
            // 
            // button_add
            // 
            button_add.Location = new Point(359, 305);
            button_add.Name = "button_add";
            button_add.Size = new Size(94, 29);
            button_add.TabIndex = 0;
            button_add.Text = "הוספה";
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(302, 25);
            label1.Name = "label1";
            label1.Size = new Size(211, 81);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 354);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 6;
            label2.Text = "בחירות ישנות שלי";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(174, 101);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(468, 155);
            dataGridView1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(259, 389);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(300, 188);
            dataGridView2.TabIndex = 8;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 621);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_add);
            Controls.Add(textBox_chois);
            Controls.Add(button_next);
            Controls.Add(button_prev);
            Name = "HomePage";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_prev;
        private Button button_next;
        private TextBox textBox_chois;
        private Button button_add;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
    }
}

namespace Function_Hall_Reservation_System.Student
{
    partial class BorrowEquipment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearcheq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtEqname = new System.Windows.Forms.TextBox();
            this.txtAvailability = new System.Windows.Forms.TextBox();
            this.txtAvailqty = new System.Windows.Forms.TextBox();
            this.txtDefectqty = new System.Windows.Forms.TextBox();
            this.txtTotalqty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStoredFacility = new System.Windows.Forms.TextBox();
            this.txtBorrowedqty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 256);
            this.panel1.TabIndex = 0;
            // 
            // txtSearcheq
            // 
            this.txtSearcheq.Location = new System.Drawing.Point(122, 18);
            this.txtSearcheq.Multiline = true;
            this.txtSearcheq.Name = "txtSearcheq";
            this.txtSearcheq.Size = new System.Drawing.Size(131, 21);
            this.txtSearcheq.TabIndex = 1;
            this.txtSearcheq.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search Equipment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(633, 253);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // txtEqname
            // 
            this.txtEqname.Enabled = false;
            this.txtEqname.Location = new System.Drawing.Point(122, 55);
            this.txtEqname.Name = "txtEqname";
            this.txtEqname.Size = new System.Drawing.Size(100, 20);
            this.txtEqname.TabIndex = 3;
            // 
            // txtAvailability
            // 
            this.txtAvailability.Enabled = false;
            this.txtAvailability.Location = new System.Drawing.Point(122, 81);
            this.txtAvailability.Name = "txtAvailability";
            this.txtAvailability.Size = new System.Drawing.Size(100, 20);
            this.txtAvailability.TabIndex = 4;
            // 
            // txtAvailqty
            // 
            this.txtAvailqty.Enabled = false;
            this.txtAvailqty.Location = new System.Drawing.Point(122, 107);
            this.txtAvailqty.Name = "txtAvailqty";
            this.txtAvailqty.Size = new System.Drawing.Size(100, 20);
            this.txtAvailqty.TabIndex = 5;
            // 
            // txtDefectqty
            // 
            this.txtDefectqty.Enabled = false;
            this.txtDefectqty.Location = new System.Drawing.Point(122, 137);
            this.txtDefectqty.Name = "txtDefectqty";
            this.txtDefectqty.Size = new System.Drawing.Size(100, 20);
            this.txtDefectqty.TabIndex = 6;
            // 
            // txtTotalqty
            // 
            this.txtTotalqty.Enabled = false;
            this.txtTotalqty.Location = new System.Drawing.Point(342, 55);
            this.txtTotalqty.Name = "txtTotalqty";
            this.txtTotalqty.Size = new System.Drawing.Size(100, 20);
            this.txtTotalqty.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Equipment Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Availability";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Available Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Defective Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Stored Facility";
            // 
            // txtStoredFacility
            // 
            this.txtStoredFacility.Enabled = false;
            this.txtStoredFacility.Location = new System.Drawing.Point(342, 81);
            this.txtStoredFacility.Name = "txtStoredFacility";
            this.txtStoredFacility.Size = new System.Drawing.Size(100, 20);
            this.txtStoredFacility.TabIndex = 14;
            // 
            // txtBorrowedqty
            // 
            this.txtBorrowedqty.AccessibleName = "";
            this.txtBorrowedqty.Location = new System.Drawing.Point(342, 107);
            this.txtBorrowedqty.Name = "txtBorrowedqty";
            this.txtBorrowedqty.Size = new System.Drawing.Size(100, 20);
            this.txtBorrowedqty.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(228, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Borrowed Quantity";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 47);
            this.button1.TabIndex = 17;
            this.button1.Text = "Add to Reservation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(411, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 47);
            this.button2.TabIndex = 18;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txtSearcheq);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtEqname);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtAvailability);
            this.panel2.Controls.Add(this.txtBorrowedqty);
            this.panel2.Controls.Add(this.txtAvailqty);
            this.panel2.Controls.Add(this.txtStoredFacility);
            this.panel2.Controls.Add(this.txtDefectqty);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtTotalqty);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 207);
            this.panel2.TabIndex = 19;
            // 
            // BorrowEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BorrowEquipment";
            this.Text = "BorrowEquipment";
            this.Load += new System.EventHandler(this.BorrowEquipment_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearcheq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEqname;
        private System.Windows.Forms.TextBox txtAvailability;
        private System.Windows.Forms.TextBox txtAvailqty;
        private System.Windows.Forms.TextBox txtDefectqty;
        private System.Windows.Forms.TextBox txtTotalqty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtStoredFacility;
        private System.Windows.Forms.TextBox txtBorrowedqty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
    }
}
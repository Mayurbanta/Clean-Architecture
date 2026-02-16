
namespace WindowsFormsApp1
{
    partial class Employee
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
            this.txtEmplyeeNumber = new System.Windows.Forms.TextBox();
            this.btnCalculateSalary = new System.Windows.Forms.Button();
            this.lblSalary = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEmplyeeNumber
            // 
            this.txtEmplyeeNumber.Location = new System.Drawing.Point(256, 82);
            this.txtEmplyeeNumber.Name = "txtEmplyeeNumber";
            this.txtEmplyeeNumber.Size = new System.Drawing.Size(100, 20);
            this.txtEmplyeeNumber.TabIndex = 0;
            // 
            // btnCalculateSalary
            // 
            this.btnCalculateSalary.Location = new System.Drawing.Point(256, 128);
            this.btnCalculateSalary.Name = "btnCalculateSalary";
            this.btnCalculateSalary.Size = new System.Drawing.Size(121, 23);
            this.btnCalculateSalary.TabIndex = 1;
            this.btnCalculateSalary.Text = "Calculate Salary";
            this.btnCalculateSalary.UseVisualStyleBackColor = true;
            this.btnCalculateSalary.Click += new System.EventHandler(this.btnCalculateSalary_Click);
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(256, 182);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(35, 13);
            this.lblSalary.TabIndex = 2;
            this.lblSalary.Text = "label1";
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.btnCalculateSalary);
            this.Controls.Add(this.txtEmplyeeNumber);
            this.Name = "Employee";
            this.Text = "Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmplyeeNumber;
        private System.Windows.Forms.Button btnCalculateSalary;
        private System.Windows.Forms.Label lblSalary;
    }
}
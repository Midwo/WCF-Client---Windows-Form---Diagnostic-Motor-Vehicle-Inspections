namespace CheckVinClient
{
    partial class Repairs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repairs));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonVIN = new System.Windows.Forms.Button();
            this.textBoxVin = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelVIN = new System.Windows.Forms.Label();
            this.buttonReviewsHistory = new System.Windows.Forms.Button();
            this.buttonRepairsHistory = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonVIN);
            this.groupBox3.Controls.Add(this.textBoxVin);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox3.Location = new System.Drawing.Point(12, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 59);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VIN number:";
            // 
            // buttonVIN
            // 
            this.buttonVIN.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonVIN.Location = new System.Drawing.Point(368, 25);
            this.buttonVIN.Name = "buttonVIN";
            this.buttonVIN.Size = new System.Drawing.Size(75, 26);
            this.buttonVIN.TabIndex = 1;
            this.buttonVIN.Text = "Add";
            this.buttonVIN.UseVisualStyleBackColor = false;
            // 
            // textBoxVin
            // 
            this.textBoxVin.Location = new System.Drawing.Point(6, 25);
            this.textBoxVin.Name = "textBoxVin";
            this.textBoxVin.Size = new System.Drawing.Size(356, 26);
            this.textBoxVin.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonReviewsHistory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 211);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle History Report - Reviews";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Indigo;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(595, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonRepairsHistory);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(245, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(226, 211);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vehicle History Report - Repairs";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelVIN);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox4.Location = new System.Drawing.Point(12, 92);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(459, 52);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Selected VIN";
            // 
            // labelVIN
            // 
            this.labelVIN.AutoSize = true;
            this.labelVIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVIN.ForeColor = System.Drawing.Color.DarkRed;
            this.labelVIN.Location = new System.Drawing.Point(140, 22);
            this.labelVIN.Name = "labelVIN";
            this.labelVIN.Size = new System.Drawing.Size(147, 20);
            this.labelVIN.TabIndex = 0;
            this.labelVIN.Text = "Your number VIN";
            // 
            // buttonReviewsHistory
            // 
            this.buttonReviewsHistory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonReviewsHistory.BackgroundImage = global::CheckVinClient.Properties.Resources.iconmonstr_task_1_240;
            this.buttonReviewsHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReviewsHistory.Enabled = false;
            this.buttonReviewsHistory.Location = new System.Drawing.Point(23, 29);
            this.buttonReviewsHistory.Name = "buttonReviewsHistory";
            this.buttonReviewsHistory.Size = new System.Drawing.Size(180, 161);
            this.buttonReviewsHistory.TabIndex = 16;
            this.buttonReviewsHistory.UseVisualStyleBackColor = false;
            // 
            // buttonRepairsHistory
            // 
            this.buttonRepairsHistory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRepairsHistory.BackgroundImage = global::CheckVinClient.Properties.Resources.iconmonstr_wrench_24_240_1_;
            this.buttonRepairsHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRepairsHistory.Enabled = false;
            this.buttonRepairsHistory.Location = new System.Drawing.Point(23, 29);
            this.buttonRepairsHistory.Name = "buttonRepairsHistory";
            this.buttonRepairsHistory.Size = new System.Drawing.Size(180, 161);
            this.buttonRepairsHistory.TabIndex = 16;
            this.buttonRepairsHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonRepairsHistory.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 395);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(595, 23);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // Repairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(595, 418);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Repairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MD Check Vin Number";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonVIN;
        private System.Windows.Forms.TextBox textBoxVin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonReviewsHistory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRepairsHistory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelVIN;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
namespace BattleCity.NET
{
	partial class FMatchSettings
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
			this.tbBonusFreq = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.bOk = new System.Windows.Forms.Button();
			this.bCancel = new System.Windows.Forms.Button();
			this.tbAntibFreq = new System.Windows.Forms.TrackBar();
			this.tbShootingFreq = new System.Windows.Forms.TrackBar();
			this.tbHealth = new System.Windows.Forms.TrackBar();
			this.tbSpeed = new System.Windows.Forms.TrackBar();
			this.cbFieldSize = new System.Windows.Forms.ComboBox();
			this.lBonusFreq = new System.Windows.Forms.Label();
			this.lAntibFreq = new System.Windows.Forms.Label();
			this.lShootingFreq = new System.Windows.Forms.Label();
			this.lHealth = new System.Windows.Forms.Label();
			this.lSpeed = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tbBonusFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAntibFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbShootingFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHealth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
			this.SuspendLayout();
			// 
			// tbBonusFreq
			// 
			this.tbBonusFreq.LargeChange = 10;
			this.tbBonusFreq.Location = new System.Drawing.Point(248, 9);
			this.tbBonusFreq.Name = "tbBonusFreq";
			this.tbBonusFreq.Size = new System.Drawing.Size(137, 42);
			this.tbBonusFreq.TabIndex = 0;
			this.tbBonusFreq.Scroll += new System.EventHandler(this.tbBonusFreq_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Частота появления аптечек:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Частота появления антибонусов:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Частота стрельбы:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Здоровье танка:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(135, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Скорость передвижения:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 249);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(125, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Размер игрового поля:";
			// 
			// bOk
			// 
			this.bOk.Location = new System.Drawing.Point(310, 285);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 7;
			this.bOk.Text = "Ок";
			this.bOk.UseVisualStyleBackColor = true;
			this.bOk.Click += new System.EventHandler(this.bOk_Click);
			// 
			// bCancel
			// 
			this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bCancel.Location = new System.Drawing.Point(15, 286);
			this.bCancel.Name = "bCancel";
			this.bCancel.Size = new System.Drawing.Size(75, 23);
			this.bCancel.TabIndex = 6;
			this.bCancel.Text = "Отмена";
			this.bCancel.UseVisualStyleBackColor = true;
			this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
			// 
			// tbAntibFreq
			// 
			this.tbAntibFreq.LargeChange = 10;
			this.tbAntibFreq.Location = new System.Drawing.Point(248, 57);
			this.tbAntibFreq.Name = "tbAntibFreq";
			this.tbAntibFreq.Size = new System.Drawing.Size(137, 42);
			this.tbAntibFreq.TabIndex = 1;
			this.tbAntibFreq.Scroll += new System.EventHandler(this.tbAntibFreq_Scroll);
			// 
			// tbShootingFreq
			// 
			this.tbShootingFreq.LargeChange = 10;
			this.tbShootingFreq.Location = new System.Drawing.Point(248, 105);
			this.tbShootingFreq.Name = "tbShootingFreq";
			this.tbShootingFreq.Size = new System.Drawing.Size(137, 42);
			this.tbShootingFreq.TabIndex = 2;
			this.tbShootingFreq.Scroll += new System.EventHandler(this.tbShootingFreq_Scroll);
			// 
			// tbHealth
			// 
			this.tbHealth.LargeChange = 10;
			this.tbHealth.Location = new System.Drawing.Point(248, 153);
			this.tbHealth.Name = "tbHealth";
			this.tbHealth.Size = new System.Drawing.Size(137, 42);
			this.tbHealth.TabIndex = 3;
			this.tbHealth.Scroll += new System.EventHandler(this.tbHealth_Scroll);
			// 
			// tbSpeed
			// 
			this.tbSpeed.LargeChange = 10;
			this.tbSpeed.Location = new System.Drawing.Point(248, 201);
			this.tbSpeed.Name = "tbSpeed";
			this.tbSpeed.Size = new System.Drawing.Size(137, 42);
			this.tbSpeed.TabIndex = 4;
			this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
			// 
			// cbFieldSize
			// 
			this.cbFieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFieldSize.FormattingEnabled = true;
			this.cbFieldSize.Items.AddRange(new object[] {
            "Маленькое",
            "Стандартное",
            "Большое"});
			this.cbFieldSize.Location = new System.Drawing.Point(248, 249);
			this.cbFieldSize.Name = "cbFieldSize";
			this.cbFieldSize.Size = new System.Drawing.Size(137, 21);
			this.cbFieldSize.TabIndex = 5;
			// 
			// lBonusFreq
			// 
			this.lBonusFreq.AutoSize = true;
			this.lBonusFreq.Location = new System.Drawing.Point(211, 16);
			this.lBonusFreq.Name = "lBonusFreq";
			this.lBonusFreq.Size = new System.Drawing.Size(35, 13);
			this.lBonusFreq.TabIndex = 16;
			this.lBonusFreq.Text = "label7";
			this.lBonusFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lAntibFreq
			// 
			this.lAntibFreq.AutoSize = true;
			this.lAntibFreq.Location = new System.Drawing.Point(211, 64);
			this.lAntibFreq.Name = "lAntibFreq";
			this.lAntibFreq.Size = new System.Drawing.Size(35, 13);
			this.lAntibFreq.TabIndex = 17;
			this.lAntibFreq.Text = "label8";
			this.lAntibFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lShootingFreq
			// 
			this.lShootingFreq.AutoSize = true;
			this.lShootingFreq.Location = new System.Drawing.Point(211, 112);
			this.lShootingFreq.Name = "lShootingFreq";
			this.lShootingFreq.Size = new System.Drawing.Size(35, 13);
			this.lShootingFreq.TabIndex = 18;
			this.lShootingFreq.Text = "label9";
			this.lShootingFreq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lHealth
			// 
			this.lHealth.AutoSize = true;
			this.lHealth.Location = new System.Drawing.Point(211, 160);
			this.lHealth.Name = "lHealth";
			this.lHealth.Size = new System.Drawing.Size(29, 13);
			this.lHealth.TabIndex = 19;
			this.lHealth.Text = "label";
			this.lHealth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lSpeed
			// 
			this.lSpeed.AutoSize = true;
			this.lSpeed.Location = new System.Drawing.Point(211, 208);
			this.lSpeed.Name = "lSpeed";
			this.lSpeed.Size = new System.Drawing.Size(29, 13);
			this.lSpeed.TabIndex = 20;
			this.lSpeed.Text = "label";
			this.lSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FMatchSettings
			// 
			this.AcceptButton = this.bOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bCancel;
			this.ClientSize = new System.Drawing.Size(393, 320);
			this.Controls.Add(this.lSpeed);
			this.Controls.Add(this.lHealth);
			this.Controls.Add(this.lShootingFreq);
			this.Controls.Add(this.lAntibFreq);
			this.Controls.Add(this.lBonusFreq);
			this.Controls.Add(this.cbFieldSize);
			this.Controls.Add(this.tbSpeed);
			this.Controls.Add(this.tbHealth);
			this.Controls.Add(this.tbShootingFreq);
			this.Controls.Add(this.tbAntibFreq);
			this.Controls.Add(this.bCancel);
			this.Controls.Add(this.bOk);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbBonusFreq);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "FMatchSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Настройки матча";
			((System.ComponentModel.ISupportInitialize)(this.tbBonusFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAntibFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbShootingFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbHealth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar tbBonusFreq;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button bOk;
		private System.Windows.Forms.Button bCancel;
		private System.Windows.Forms.TrackBar tbAntibFreq;
		private System.Windows.Forms.TrackBar tbShootingFreq;
		private System.Windows.Forms.TrackBar tbHealth;
		private System.Windows.Forms.TrackBar tbSpeed;
		private System.Windows.Forms.ComboBox cbFieldSize;
		private System.Windows.Forms.Label lBonusFreq;
		private System.Windows.Forms.Label lAntibFreq;
		private System.Windows.Forms.Label lShootingFreq;
		private System.Windows.Forms.Label lHealth;
		private System.Windows.Forms.Label lSpeed;

	}
}
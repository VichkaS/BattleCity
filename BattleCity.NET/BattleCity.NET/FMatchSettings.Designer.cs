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
			this.tbReloadTime = new System.Windows.Forms.TrackBar();
			this.tbHealth = new System.Windows.Forms.TrackBar();
			this.tbSpeed = new System.Windows.Forms.TrackBar();
			this.cbFieldSize = new System.Windows.Forms.ComboBox();
			this.lBonusFreq = new System.Windows.Forms.Label();
			this.lAntibFreq = new System.Windows.Forms.Label();
			this.lReloadTime = new System.Windows.Forms.Label();
			this.lHealth = new System.Windows.Forms.Label();
			this.lSpeed = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tbBonusFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAntibFreq)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbReloadTime)).BeginInit();
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
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Health bonus spawn rate:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Slowness spawn rate:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Reload time:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Tank health:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Movement speed:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 249);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(81, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Game field size:";
			// 
			// bOk
			// 
			this.bOk.Location = new System.Drawing.Point(310, 285);
			this.bOk.Name = "bOk";
			this.bOk.Size = new System.Drawing.Size(75, 23);
			this.bOk.TabIndex = 7;
			this.bOk.Text = "Ok";
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
			this.bCancel.Text = "Cancel";
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
			// 
			// tbReloadTime
			// 
			this.tbReloadTime.LargeChange = 10;
			this.tbReloadTime.Location = new System.Drawing.Point(248, 105);
			this.tbReloadTime.Name = "tbReloadTime";
			this.tbReloadTime.Size = new System.Drawing.Size(137, 42);
			this.tbReloadTime.TabIndex = 2;
			// 
			// tbHealth
			// 
			this.tbHealth.LargeChange = 10;
			this.tbHealth.Location = new System.Drawing.Point(248, 153);
			this.tbHealth.Name = "tbHealth";
			this.tbHealth.Size = new System.Drawing.Size(137, 42);
			this.tbHealth.TabIndex = 3;
			// 
			// tbSpeed
			// 
			this.tbSpeed.LargeChange = 10;
			this.tbSpeed.Location = new System.Drawing.Point(248, 201);
			this.tbSpeed.Name = "tbSpeed";
			this.tbSpeed.Size = new System.Drawing.Size(137, 42);
			this.tbSpeed.TabIndex = 4;
			// 
			// cbFieldSize
			// 
			this.cbFieldSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFieldSize.FormattingEnabled = true;
			this.cbFieldSize.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
			this.cbFieldSize.Location = new System.Drawing.Point(248, 249);
			this.cbFieldSize.Name = "cbFieldSize";
			this.cbFieldSize.Size = new System.Drawing.Size(137, 21);
			this.cbFieldSize.TabIndex = 5;
			// 
			// lBonusFreq
			// 
			this.lBonusFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lBonusFreq.Location = new System.Drawing.Point(163, 16);
			this.lBonusFreq.Name = "lBonusFreq";
			this.lBonusFreq.Size = new System.Drawing.Size(79, 13);
			this.lBonusFreq.TabIndex = 16;
			this.lBonusFreq.Text = "label";
			this.lBonusFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lAntibFreq
			// 
			this.lAntibFreq.Location = new System.Drawing.Point(163, 64);
			this.lAntibFreq.Name = "lAntibFreq";
			this.lAntibFreq.Size = new System.Drawing.Size(79, 13);
			this.lAntibFreq.TabIndex = 17;
			this.lAntibFreq.Text = "label";
			this.lAntibFreq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lReloadTime
			// 
			this.lReloadTime.Location = new System.Drawing.Point(163, 112);
			this.lReloadTime.Name = "lReloadTime";
			this.lReloadTime.Size = new System.Drawing.Size(79, 13);
			this.lReloadTime.TabIndex = 18;
			this.lReloadTime.Text = "label";
			this.lReloadTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lHealth
			// 
			this.lHealth.Location = new System.Drawing.Point(163, 160);
			this.lHealth.Name = "lHealth";
			this.lHealth.Size = new System.Drawing.Size(79, 13);
			this.lHealth.TabIndex = 19;
			this.lHealth.Text = "label";
			this.lHealth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lSpeed
			// 
			this.lSpeed.Location = new System.Drawing.Point(163, 208);
			this.lSpeed.Name = "lSpeed";
			this.lSpeed.Size = new System.Drawing.Size(79, 13);
			this.lSpeed.TabIndex = 20;
			this.lSpeed.Text = "label";
			this.lSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.Controls.Add(this.lReloadTime);
			this.Controls.Add(this.lAntibFreq);
			this.Controls.Add(this.lBonusFreq);
			this.Controls.Add(this.cbFieldSize);
			this.Controls.Add(this.tbSpeed);
			this.Controls.Add(this.tbHealth);
			this.Controls.Add(this.tbReloadTime);
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
			this.Text = "Game options";
			((System.ComponentModel.ISupportInitialize)(this.tbBonusFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbAntibFreq)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbReloadTime)).EndInit();
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
		private System.Windows.Forms.TrackBar tbReloadTime;
		private System.Windows.Forms.TrackBar tbHealth;
		private System.Windows.Forms.TrackBar tbSpeed;
		private System.Windows.Forms.ComboBox cbFieldSize;
		private System.Windows.Forms.Label lBonusFreq;
		private System.Windows.Forms.Label lAntibFreq;
		private System.Windows.Forms.Label lReloadTime;
		private System.Windows.Forms.Label lHealth;
		private System.Windows.Forms.Label lSpeed;

	}
}
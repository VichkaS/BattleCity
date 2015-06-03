namespace BattleCity.NET
{
	partial class FResults
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FResults));
			this.lvResults = new System.Windows.Forms.ListView();
			this.chAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chShots = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHitAcc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chDestroyed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chBonuses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chAntibonuses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chHPLost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bExit = new System.Windows.Forms.Button();
			this.bRestart = new System.Windows.Forms.Button();
			this.pbFirst = new System.Windows.Forms.PictureBox();
			this.pbSecond = new System.Windows.Forms.PictureBox();
			this.pbThird = new System.Windows.Forms.PictureBox();
			this.lFirst = new System.Windows.Forms.Label();
			this.lSecond = new System.Windows.Forms.Label();
			this.lThird = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbFirst)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSecond)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbThird)).BeginInit();
			this.SuspendLayout();
			// 
			// lvResults
			// 
			this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAuthor,
            this.chShots,
            this.chHitAcc,
            this.chDestroyed,
            this.chBonuses,
            this.chAntibonuses,
            this.chHPLost,
            this.chDistance});
			this.lvResults.GridLines = true;
			this.lvResults.Location = new System.Drawing.Point(12, 252);
			this.lvResults.Name = "lvResults";
			this.lvResults.ShowGroups = false;
			this.lvResults.Size = new System.Drawing.Size(749, 180);
			this.lvResults.TabIndex = 0;
			this.lvResults.UseCompatibleStateImageBehavior = false;
			this.lvResults.View = System.Windows.Forms.View.Details;
			// 
			// chAuthor
			// 
			this.chAuthor.Text = "Author";
			this.chAuthor.Width = 112;
			// 
			// chShots
			// 
			this.chShots.Text = "Shots fired";
			this.chShots.Width = 63;
			// 
			// chHitAcc
			// 
			this.chHitAcc.Text = "Hit accuracy";
			this.chHitAcc.Width = 72;
			// 
			// chDestroyed
			// 
			this.chDestroyed.Text = "Tanks destroyed";
			this.chDestroyed.Width = 94;
			// 
			// chBonuses
			// 
			this.chBonuses.Text = "Bonuses collected";
			this.chBonuses.Width = 100;
			// 
			// chAntibonuses
			// 
			this.chAntibonuses.Text = "Antibonuses collected";
			this.chAntibonuses.Width = 116;
			// 
			// chHPLost
			// 
			this.chHPLost.Text = "Health points lost";
			this.chHPLost.Width = 93;
			// 
			// chDistance
			// 
			this.chDistance.Text = "Distance traveled";
			this.chDistance.Width = 95;
			// 
			// bExit
			// 
			this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bExit.Location = new System.Drawing.Point(686, 438);
			this.bExit.Name = "bExit";
			this.bExit.Size = new System.Drawing.Size(75, 23);
			this.bExit.TabIndex = 3;
			this.bExit.Text = "Exit";
			this.bExit.UseVisualStyleBackColor = true;
			this.bExit.Click += new System.EventHandler(this.bExit_Click);
			// 
			// bRestart
			// 
			this.bRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bRestart.Location = new System.Drawing.Point(605, 438);
			this.bRestart.Name = "bRestart";
			this.bRestart.Size = new System.Drawing.Size(75, 23);
			this.bRestart.TabIndex = 2;
			this.bRestart.Text = "New game";
			this.bRestart.UseVisualStyleBackColor = true;
			this.bRestart.Click += new System.EventHandler(this.bRestart_Click);
			// 
			// pbFirst
			// 
			this.pbFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pbFirst.BackColor = System.Drawing.SystemColors.Control;
			this.pbFirst.Image = ((System.Drawing.Image)(resources.GetObject("pbFirst.Image")));
			this.pbFirst.Location = new System.Drawing.Point(276, 3);
			this.pbFirst.Name = "pbFirst";
			this.pbFirst.Size = new System.Drawing.Size(205, 189);
			this.pbFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbFirst.TabIndex = 4;
			this.pbFirst.TabStop = false;
			// 
			// pbSecond
			// 
			this.pbSecond.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pbSecond.Image = ((System.Drawing.Image)(resources.GetObject("pbSecond.Image")));
			this.pbSecond.Location = new System.Drawing.Point(586, 50);
			this.pbSecond.Name = "pbSecond";
			this.pbSecond.Size = new System.Drawing.Size(132, 142);
			this.pbSecond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbSecond.TabIndex = 5;
			this.pbSecond.TabStop = false;
			this.pbSecond.Visible = false;
			// 
			// pbThird
			// 
			this.pbThird.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pbThird.Image = ((System.Drawing.Image)(resources.GetObject("pbThird.Image")));
			this.pbThird.Location = new System.Drawing.Point(60, 92);
			this.pbThird.Name = "pbThird";
			this.pbThird.Size = new System.Drawing.Size(111, 100);
			this.pbThird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbThird.TabIndex = 6;
			this.pbThird.TabStop = false;
			this.pbThird.Visible = false;
			// 
			// lFirst
			// 
			this.lFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lFirst.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lFirst.ForeColor = System.Drawing.Color.Maroon;
			this.lFirst.Location = new System.Drawing.Point(196, 188);
			this.lFirst.Name = "lFirst";
			this.lFirst.Size = new System.Drawing.Size(365, 61);
			this.lFirst.TabIndex = 7;
			this.lFirst.Text = "Иванов Сергей Иванович";
			this.lFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lSecond
			// 
			this.lSecond.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lSecond.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lSecond.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lSecond.Location = new System.Drawing.Point(556, 188);
			this.lSecond.Name = "lSecond";
			this.lSecond.Size = new System.Drawing.Size(193, 61);
			this.lSecond.TabIndex = 8;
			this.lSecond.Text = "Иванов Сергей Иванович";
			this.lSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lSecond.Visible = false;
			// 
			// lThird
			// 
			this.lThird.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lThird.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lThird.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lThird.Location = new System.Drawing.Point(32, 188);
			this.lThird.Name = "lThird";
			this.lThird.Size = new System.Drawing.Size(167, 61);
			this.lThird.TabIndex = 9;
			this.lThird.Text = "Иванов Сергей Иванович";
			this.lThird.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lThird.Visible = false;
			// 
			// FResults
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.bExit;
			this.ClientSize = new System.Drawing.Size(773, 473);
			this.Controls.Add(this.pbFirst);
			this.Controls.Add(this.bRestart);
			this.Controls.Add(this.bExit);
			this.Controls.Add(this.lvResults);
			this.Controls.Add(this.pbSecond);
			this.Controls.Add(this.pbThird);
			this.Controls.Add(this.lSecond);
			this.Controls.Add(this.lThird);
			this.Controls.Add(this.lFirst);
			this.MinimumSize = new System.Drawing.Size(700, 400);
			this.Name = "FResults";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game results";
			((System.ComponentModel.ISupportInitialize)(this.pbFirst)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbSecond)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbThird)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvResults;
		private System.Windows.Forms.ColumnHeader chAuthor;
		private System.Windows.Forms.ColumnHeader chShots;
		private System.Windows.Forms.ColumnHeader chHitAcc;
		private System.Windows.Forms.ColumnHeader chDestroyed;
		private System.Windows.Forms.ColumnHeader chBonuses;
		private System.Windows.Forms.ColumnHeader chAntibonuses;
		private System.Windows.Forms.ColumnHeader chHPLost;
		private System.Windows.Forms.ColumnHeader chDistance;
		private System.Windows.Forms.Button bExit;
		private System.Windows.Forms.Button bRestart;
		private System.Windows.Forms.PictureBox pbFirst;
		private System.Windows.Forms.PictureBox pbSecond;
		private System.Windows.Forms.PictureBox pbThird;
		private System.Windows.Forms.Label lFirst;
		private System.Windows.Forms.Label lSecond;
		private System.Windows.Forms.Label lThird;
	}
}
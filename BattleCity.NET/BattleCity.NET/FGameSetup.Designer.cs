namespace BattleCity.NET
{
    partial class FGameSetup
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
			this.bNext = new System.Windows.Forms.Button();
			this.cbDLLs = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bAdd = new System.Windows.Forms.Button();
			this.bSettings = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.lvTanks = new System.Windows.Forms.ListView();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.bChangeColor = new System.Windows.Forms.Button();
			this.bRemove = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bNext
			// 
			this.bNext.Location = new System.Drawing.Point(276, 314);
			this.bNext.Margin = new System.Windows.Forms.Padding(2);
			this.bNext.Name = "bNext";
			this.bNext.Size = new System.Drawing.Size(75, 23);
			this.bNext.TabIndex = 0;
			this.bNext.Text = "Next";
			this.bNext.UseVisualStyleBackColor = true;
			this.bNext.Click += new System.EventHandler(this.bNext_Click);
			// 
			// cbDLLs
			// 
			this.cbDLLs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDLLs.FormattingEnabled = true;
			this.cbDLLs.Location = new System.Drawing.Point(50, 23);
			this.cbDLLs.Margin = new System.Windows.Forms.Padding(2);
			this.cbDLLs.Name = "cbDLLs";
			this.cbDLLs.Size = new System.Drawing.Size(103, 21);
			this.cbDLLs.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(20, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "DLL";
			// 
			// bAdd
			// 
			this.bAdd.Location = new System.Drawing.Point(85, 54);
			this.bAdd.Margin = new System.Windows.Forms.Padding(2);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(56, 19);
			this.bAdd.TabIndex = 6;
			this.bAdd.Text = "Add";
			this.bAdd.UseVisualStyleBackColor = true;
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// bSettings
			// 
			this.bSettings.Location = new System.Drawing.Point(8, 314);
			this.bSettings.Name = "bSettings";
			this.bSettings.Size = new System.Drawing.Size(75, 23);
			this.bSettings.TabIndex = 10;
			this.bSettings.Text = "Options";
			this.bSettings.UseVisualStyleBackColor = true;
			this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(124, 314);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lvTanks
			// 
			this.lvTanks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvTanks.Location = new System.Drawing.Point(23, 81);
			this.lvTanks.Name = "lvTanks";
			this.lvTanks.Size = new System.Drawing.Size(249, 167);
			this.lvTanks.TabIndex = 12;
			this.lvTanks.UseCompatibleStateImageBehavior = false;
			// 
			// bChangeColor
			// 
			this.bChangeColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bChangeColor.Location = new System.Drawing.Point(157, 52);
			this.bChangeColor.Name = "bChangeColor";
			this.bChangeColor.Size = new System.Drawing.Size(115, 23);
			this.bChangeColor.TabIndex = 13;
			this.bChangeColor.Text = "Color";
			this.bChangeColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bChangeColor.UseVisualStyleBackColor = true;
			this.bChangeColor.Click += new System.EventHandler(this.bChangeColor_Click);
			// 
			// bRemove
			// 
			this.bRemove.Location = new System.Drawing.Point(23, 54);
			this.bRemove.Margin = new System.Windows.Forms.Padding(2);
			this.bRemove.Name = "bRemove";
			this.bRemove.Size = new System.Drawing.Size(56, 19);
			this.bRemove.TabIndex = 16;
			this.bRemove.Text = "Remove";
			this.bRemove.UseVisualStyleBackColor = true;
			this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 272);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(218, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "The game will be started in tournament mode";
			// 
			// FGameSetup
			// 
			this.AcceptButton = this.bNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 382);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.bRemove);
			this.Controls.Add(this.bChangeColor);
			this.Controls.Add(this.lvTanks);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.bSettings);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbDLLs);
			this.Controls.Add(this.bNext);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "FGameSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Setup";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.ComboBox cbDLLs;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Button bSettings;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView lvTanks;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Button bChangeColor;
		private System.Windows.Forms.Button bRemove;
		private System.Windows.Forms.Label label5;
    }
}


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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FGameSetup));
			this.bNext = new System.Windows.Forms.Button();
			this.bAdd = new System.Windows.Forms.Button();
			this.bSettings = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.lvTanks = new System.Windows.Forms.ListView();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.bChangeColor = new System.Windows.Forms.Button();
			this.bRemove = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// bNext
			// 
			this.bNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bNext.Location = new System.Drawing.Point(344, 196);
			this.bNext.Margin = new System.Windows.Forms.Padding(2);
			this.bNext.Name = "bNext";
			this.bNext.Size = new System.Drawing.Size(75, 23);
			this.bNext.TabIndex = 0;
			this.bNext.Text = "Start game";
			this.bNext.UseVisualStyleBackColor = true;
			this.bNext.Click += new System.EventHandler(this.bNext_Click);
			// 
			// bAdd
			// 
			this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bAdd.Image = ((System.Drawing.Image)(resources.GetObject("bAdd.Image")));
			this.bAdd.Location = new System.Drawing.Point(381, 12);
			this.bAdd.Margin = new System.Windows.Forms.Padding(2);
			this.bAdd.Name = "bAdd";
			this.bAdd.Size = new System.Drawing.Size(38, 38);
			this.bAdd.TabIndex = 6;
			this.toolTip.SetToolTip(this.bAdd, "Add participant");
			this.bAdd.UseVisualStyleBackColor = true;
			this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
			// 
			// bSettings
			// 
			this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bSettings.Location = new System.Drawing.Point(7, 196);
			this.bSettings.Name = "bSettings";
			this.bSettings.Size = new System.Drawing.Size(75, 23);
			this.bSettings.TabIndex = 10;
			this.bSettings.Text = "Options";
			this.bSettings.UseVisualStyleBackColor = true;
			this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(380, 155);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(38, 23);
			this.button1.TabIndex = 11;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lvTanks
			// 
			this.lvTanks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvTanks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvTanks.Location = new System.Drawing.Point(7, 12);
			this.lvTanks.Name = "lvTanks";
			this.lvTanks.Size = new System.Drawing.Size(364, 175);
			this.lvTanks.TabIndex = 12;
			this.lvTanks.UseCompatibleStateImageBehavior = false;
			// 
			// bChangeColor
			// 
			this.bChangeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bChangeColor.Image = ((System.Drawing.Image)(resources.GetObject("bChangeColor.Image")));
			this.bChangeColor.Location = new System.Drawing.Point(380, 97);
			this.bChangeColor.Name = "bChangeColor";
			this.bChangeColor.Size = new System.Drawing.Size(38, 38);
			this.bChangeColor.TabIndex = 13;
			this.toolTip.SetToolTip(this.bChangeColor, "Choose skin color");
			this.bChangeColor.UseVisualStyleBackColor = true;
			this.bChangeColor.Click += new System.EventHandler(this.bChangeColor_Click);
			// 
			// bRemove
			// 
			this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bRemove.Image = ((System.Drawing.Image)(resources.GetObject("bRemove.Image")));
			this.bRemove.Location = new System.Drawing.Point(381, 54);
			this.bRemove.Margin = new System.Windows.Forms.Padding(2);
			this.bRemove.Name = "bRemove";
			this.bRemove.Size = new System.Drawing.Size(38, 38);
			this.bRemove.TabIndex = 16;
			this.toolTip.SetToolTip(this.bRemove, "Remove participant");
			this.bRemove.UseVisualStyleBackColor = true;
			this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(88, 201);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(218, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "The game will be started in tournament mode";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Multiselect = true;
			// 
			// FGameSetup
			// 
			this.AcceptButton = this.bNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 227);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.bRemove);
			this.Controls.Add(this.bChangeColor);
			this.Controls.Add(this.lvTanks);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.bSettings);
			this.Controls.Add(this.bAdd);
			this.Controls.Add(this.bNext);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MinimumSize = new System.Drawing.Size(400, 200);
			this.Name = "FGameSetup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Setup";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button bNext;
		private System.Windows.Forms.Button bAdd;
		private System.Windows.Forms.Button bSettings;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListView lvTanks;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.Button bChangeColor;
		private System.Windows.Forms.Button bRemove;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}


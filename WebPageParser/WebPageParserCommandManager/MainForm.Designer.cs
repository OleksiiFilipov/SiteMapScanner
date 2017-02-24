namespace WebPageParserCommandManager
{
    partial class MainForm
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
            this.buttonParse = new System.Windows.Forms.Button();
            this.buttonBuildTree = new System.Windows.Forms.Button();
            this.textBoxUrlParse = new System.Windows.Forms.TextBox();
            this.textBoxUrlBuild = new System.Windows.Forms.TextBox();
            this.textBoxPathBuildTree = new System.Windows.Forms.TextBox();
            this.checkBoxUseExternalParse = new System.Windows.Forms.CheckBox();
            this.checkBoxUseExternalBuild = new System.Windows.Forms.CheckBox();
            this.numericUpDownDepthParse = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownThreadsCountParse = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepthParse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadsCountParse)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(12, 226);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 0;
            this.buttonParse.Text = "Parse";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParseOnClick);
            // 
            // buttonBuildTree
            // 
            this.buttonBuildTree.Location = new System.Drawing.Point(445, 226);
            this.buttonBuildTree.Name = "buttonBuildTree";
            this.buttonBuildTree.Size = new System.Drawing.Size(75, 23);
            this.buttonBuildTree.TabIndex = 1;
            this.buttonBuildTree.Text = "BuildTree";
            this.buttonBuildTree.UseVisualStyleBackColor = true;
            this.buttonBuildTree.Click += new System.EventHandler(this.buttonBuildTree_Click);
            // 
            // textBoxUrlParse
            // 
            this.textBoxUrlParse.Location = new System.Drawing.Point(13, 13);
            this.textBoxUrlParse.Name = "textBoxUrlParse";
            this.textBoxUrlParse.Size = new System.Drawing.Size(245, 22);
            this.textBoxUrlParse.TabIndex = 2;
            this.textBoxUrlParse.Text = "https://developer.microsoft.com";
            // 
            // textBoxUrlBuild
            // 
            this.textBoxUrlBuild.Location = new System.Drawing.Point(275, 13);
            this.textBoxUrlBuild.Name = "textBoxUrlBuild";
            this.textBoxUrlBuild.Size = new System.Drawing.Size(245, 22);
            this.textBoxUrlBuild.TabIndex = 3;
            this.textBoxUrlBuild.Text = "https://developer.microsoft.com";
            // 
            // textBoxPathBuildTree
            // 
            this.textBoxPathBuildTree.Location = new System.Drawing.Point(275, 55);
            this.textBoxPathBuildTree.Name = "textBoxPathBuildTree";
            this.textBoxPathBuildTree.Size = new System.Drawing.Size(245, 22);
            this.textBoxPathBuildTree.TabIndex = 4;
            this.textBoxPathBuildTree.Text = "1.txt";
            // 
            // checkBoxUseExternalParse
            // 
            this.checkBoxUseExternalParse.AutoSize = true;
            this.checkBoxUseExternalParse.Location = new System.Drawing.Point(13, 186);
            this.checkBoxUseExternalParse.Name = "checkBoxUseExternalParse";
            this.checkBoxUseExternalParse.Size = new System.Drawing.Size(101, 20);
            this.checkBoxUseExternalParse.TabIndex = 5;
            this.checkBoxUseExternalParse.Text = "WithExternal";
            this.checkBoxUseExternalParse.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseExternalBuild
            // 
            this.checkBoxUseExternalBuild.AutoSize = true;
            this.checkBoxUseExternalBuild.Location = new System.Drawing.Point(275, 186);
            this.checkBoxUseExternalBuild.Name = "checkBoxUseExternalBuild";
            this.checkBoxUseExternalBuild.Size = new System.Drawing.Size(101, 20);
            this.checkBoxUseExternalBuild.TabIndex = 6;
            this.checkBoxUseExternalBuild.Text = "WithExternal";
            this.checkBoxUseExternalBuild.UseVisualStyleBackColor = true;
            // 
            // numericUpDownDepthParse
            // 
            this.numericUpDownDepthParse.Location = new System.Drawing.Point(13, 54);
            this.numericUpDownDepthParse.Name = "numericUpDownDepthParse";
            this.numericUpDownDepthParse.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownDepthParse.TabIndex = 7;
            this.numericUpDownDepthParse.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownThreadsCountParse
            // 
            this.numericUpDownThreadsCountParse.Location = new System.Drawing.Point(12, 94);
            this.numericUpDownThreadsCountParse.Name = "numericUpDownThreadsCountParse";
            this.numericUpDownThreadsCountParse.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownThreadsCountParse.TabIndex = 8;
            this.numericUpDownThreadsCountParse.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 261);
            this.Controls.Add(this.numericUpDownThreadsCountParse);
            this.Controls.Add(this.numericUpDownDepthParse);
            this.Controls.Add(this.checkBoxUseExternalBuild);
            this.Controls.Add(this.checkBoxUseExternalParse);
            this.Controls.Add(this.textBoxPathBuildTree);
            this.Controls.Add(this.textBoxUrlBuild);
            this.Controls.Add(this.textBoxUrlParse);
            this.Controls.Add(this.buttonBuildTree);
            this.Controls.Add(this.buttonParse);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDepthParse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadsCountParse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.Button buttonBuildTree;
        private System.Windows.Forms.TextBox textBoxUrlParse;
        private System.Windows.Forms.TextBox textBoxUrlBuild;
        private System.Windows.Forms.TextBox textBoxPathBuildTree;
        private System.Windows.Forms.CheckBox checkBoxUseExternalParse;
        private System.Windows.Forms.CheckBox checkBoxUseExternalBuild;
        private System.Windows.Forms.NumericUpDown numericUpDownDepthParse;
        private System.Windows.Forms.NumericUpDown numericUpDownThreadsCountParse;
    }
}


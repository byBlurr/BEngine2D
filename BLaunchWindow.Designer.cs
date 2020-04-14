namespace BEngine2D
{
    partial class BLaunchWindow
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
            this.LaunchButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GameSettingsGroup = new System.Windows.Forms.GroupBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.FpsLabel = new System.Windows.Forms.Label();
            this.FpsBox = new System.Windows.Forms.TextBox();
            this.VsyncBox = new System.Windows.Forms.CheckBox();
            this.FullscreenBox = new System.Windows.Forms.CheckBox();
            this.LauncherSettingsGroup = new System.Windows.Forms.GroupBox();
            this.CloseBox = new System.Windows.Forms.CheckBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.GameSettingsGroup.SuspendLayout();
            this.LauncherSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(250, 146);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchButton.TabIndex = 0;
            this.LaunchButton.Text = "Launch";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchGame);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(169, 146);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveSettings);
            // 
            // GameSettingsGroup
            // 
            this.GameSettingsGroup.Controls.Add(this.HeightLabel);
            this.GameSettingsGroup.Controls.Add(this.HeightBox);
            this.GameSettingsGroup.Controls.Add(this.WidthLabel);
            this.GameSettingsGroup.Controls.Add(this.WidthBox);
            this.GameSettingsGroup.Controls.Add(this.FpsLabel);
            this.GameSettingsGroup.Controls.Add(this.FpsBox);
            this.GameSettingsGroup.Controls.Add(this.VsyncBox);
            this.GameSettingsGroup.Controls.Add(this.FullscreenBox);
            this.GameSettingsGroup.Location = new System.Drawing.Point(12, 65);
            this.GameSettingsGroup.Name = "GameSettingsGroup";
            this.GameSettingsGroup.Size = new System.Drawing.Size(313, 78);
            this.GameSettingsGroup.TabIndex = 2;
            this.GameSettingsGroup.TabStop = false;
            this.GameSettingsGroup.Text = "Game Settings";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(217, 45);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(80, 13);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Window Height";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(151, 42);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(60, 20);
            this.HeightBox.TabIndex = 6;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(74, 45);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(77, 13);
            this.WidthLabel.TabIndex = 5;
            this.WidthLabel.Text = "Window Width";
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(8, 42);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(60, 20);
            this.WidthBox.TabIndex = 4;
            // 
            // FpsLabel
            // 
            this.FpsLabel.AutoSize = true;
            this.FpsLabel.Location = new System.Drawing.Point(217, 20);
            this.FpsLabel.Name = "FpsLabel";
            this.FpsLabel.Size = new System.Drawing.Size(27, 13);
            this.FpsLabel.TabIndex = 3;
            this.FpsLabel.Text = "FPS";
            // 
            // FpsBox
            // 
            this.FpsBox.Location = new System.Drawing.Point(151, 16);
            this.FpsBox.Name = "FpsBox";
            this.FpsBox.Size = new System.Drawing.Size(60, 20);
            this.FpsBox.TabIndex = 2;
            // 
            // VsyncBox
            // 
            this.VsyncBox.AutoSize = true;
            this.VsyncBox.Location = new System.Drawing.Point(88, 19);
            this.VsyncBox.Name = "VsyncBox";
            this.VsyncBox.Size = new System.Drawing.Size(57, 17);
            this.VsyncBox.TabIndex = 1;
            this.VsyncBox.Text = "VSync";
            this.VsyncBox.UseVisualStyleBackColor = true;
            // 
            // FullscreenBox
            // 
            this.FullscreenBox.AutoSize = true;
            this.FullscreenBox.Location = new System.Drawing.Point(8, 19);
            this.FullscreenBox.Name = "FullscreenBox";
            this.FullscreenBox.Size = new System.Drawing.Size(74, 17);
            this.FullscreenBox.TabIndex = 0;
            this.FullscreenBox.Text = "Fullscreen";
            this.FullscreenBox.UseVisualStyleBackColor = true;
            this.FullscreenBox.CheckedChanged += new System.EventHandler(this.EnableVsync);
            // 
            // LauncherSettingsGroup
            // 
            this.LauncherSettingsGroup.Controls.Add(this.CloseBox);
            this.LauncherSettingsGroup.Location = new System.Drawing.Point(13, 13);
            this.LauncherSettingsGroup.Name = "LauncherSettingsGroup";
            this.LauncherSettingsGroup.Size = new System.Drawing.Size(312, 46);
            this.LauncherSettingsGroup.TabIndex = 3;
            this.LauncherSettingsGroup.TabStop = false;
            this.LauncherSettingsGroup.Text = "Launcher Settings";
            // 
            // CloseBox
            // 
            this.CloseBox.AutoSize = true;
            this.CloseBox.Location = new System.Drawing.Point(7, 20);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.Size = new System.Drawing.Size(102, 17);
            this.CloseBox.TabIndex = 0;
            this.CloseBox.Text = "Close on launch";
            this.CloseBox.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(13, 146);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplySettings);
            // 
            // BLaunchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 181);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.LauncherSettingsGroup);
            this.Controls.Add(this.GameSettingsGroup);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LaunchButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(353, 220);
            this.MinimumSize = new System.Drawing.Size(353, 220);
            this.Name = "BLaunchWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.GameSettingsGroup.ResumeLayout(false);
            this.GameSettingsGroup.PerformLayout();
            this.LauncherSettingsGroup.ResumeLayout(false);
            this.LauncherSettingsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox GameSettingsGroup;
        private System.Windows.Forms.GroupBox LauncherSettingsGroup;
        private System.Windows.Forms.CheckBox CloseBox;
        private System.Windows.Forms.CheckBox VsyncBox;
        private System.Windows.Forms.CheckBox FullscreenBox;
        private System.Windows.Forms.Label FpsLabel;
        private System.Windows.Forms.TextBox FpsBox;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Button ApplyButton;
    }
}
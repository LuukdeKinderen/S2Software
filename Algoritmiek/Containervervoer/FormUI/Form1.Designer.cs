namespace FormUI
{
    partial class Visualiser
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
            this.AddRandom = new System.Windows.Forms.Button();
            this.AddContianer = new System.Windows.Forms.Button();
            this.RandomInput = new System.Windows.Forms.TextBox();
            this.WeightText = new System.Windows.Forms.TextBox();
            this.ShipYLengthLabel = new System.Windows.Forms.Label();
            this.ShipYLength = new System.Windows.Forms.TextBox();
            this.SetShipFormat = new System.Windows.Forms.Button();
            this.Weight = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ShipXLength = new System.Windows.Forms.TextBox();
            this.ShipXLengthLabel = new System.Windows.Forms.Label();
            this.Valuable = new System.Windows.Forms.CheckBox();
            this.Cooled = new System.Windows.Forms.CheckBox();
            this.Containers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Sorted = new System.Windows.Forms.CheckBox();
            this.Clear = new System.Windows.Forms.Button();
            this.DistributeContainers = new System.Windows.Forms.Button();
            this.ContainersLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // AddRandom
            // 
            this.AddRandom.Location = new System.Drawing.Point(9, 367);
            this.AddRandom.Name = "AddRandom";
            this.AddRandom.Size = new System.Drawing.Size(59, 23);
            this.AddRandom.TabIndex = 4;
            this.AddRandom.Text = "Add";
            this.AddRandom.UseVisualStyleBackColor = true;
            this.AddRandom.Click += new System.EventHandler(this.AddRandom_Click);
            // 
            // AddContianer
            // 
            this.AddContianer.Location = new System.Drawing.Point(9, 251);
            this.AddContianer.Name = "AddContianer";
            this.AddContianer.Size = new System.Drawing.Size(59, 23);
            this.AddContianer.TabIndex = 10;
            this.AddContianer.Text = "Add";
            this.AddContianer.UseVisualStyleBackColor = true;
            this.AddContianer.Click += new System.EventHandler(this.AddContianer_Click);
            // 
            // RandomInput
            // 
            this.RandomInput.Location = new System.Drawing.Point(9, 328);
            this.RandomInput.Name = "RandomInput";
            this.RandomInput.Size = new System.Drawing.Size(100, 20);
            this.RandomInput.TabIndex = 3;
            this.RandomInput.Text = "500";
            // 
            // WeightText
            // 
            this.WeightText.Location = new System.Drawing.Point(9, 179);
            this.WeightText.Name = "WeightText";
            this.WeightText.Size = new System.Drawing.Size(100, 20);
            this.WeightText.TabIndex = 8;
            this.WeightText.Text = "4000";
            // 
            // ShipYLengthLabel
            // 
            this.ShipYLengthLabel.AutoSize = true;
            this.ShipYLengthLabel.Location = new System.Drawing.Point(9, 48);
            this.ShipYLengthLabel.Name = "ShipYLengthLabel";
            this.ShipYLengthLabel.Size = new System.Drawing.Size(64, 13);
            this.ShipYLengthLabel.TabIndex = 1;
            this.ShipYLengthLabel.Text = "Ship Length";
            // 
            // ShipYLength
            // 
            this.ShipYLength.Location = new System.Drawing.Point(9, 64);
            this.ShipYLength.Name = "ShipYLength";
            this.ShipYLength.Size = new System.Drawing.Size(100, 20);
            this.ShipYLength.TabIndex = 1;
            this.ShipYLength.Text = "0";
            // 
            // SetShipFormat
            // 
            this.SetShipFormat.Location = new System.Drawing.Point(9, 90);
            this.SetShipFormat.Name = "SetShipFormat";
            this.SetShipFormat.Size = new System.Drawing.Size(59, 23);
            this.SetShipFormat.TabIndex = 2;
            this.SetShipFormat.Text = "Set";
            this.SetShipFormat.UseVisualStyleBackColor = true;
            this.SetShipFormat.Click += new System.EventHandler(this.SetShipFormat_Click);
            // 
            // Weight
            // 
            this.Weight.AutoSize = true;
            this.Weight.Location = new System.Drawing.Point(6, 163);
            this.Weight.Name = "Weight";
            this.Weight.Size = new System.Drawing.Size(113, 13);
            this.Weight.TabIndex = 4;
            this.Weight.Text = "Weight (4000 - 30000)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Add";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 351);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Random Containers";
            // 
            // ShipXLength
            // 
            this.ShipXLength.Location = new System.Drawing.Point(9, 25);
            this.ShipXLength.Name = "ShipXLength";
            this.ShipXLength.Size = new System.Drawing.Size(100, 20);
            this.ShipXLength.TabIndex = 0;
            this.ShipXLength.Text = "0";
            // 
            // ShipXLengthLabel
            // 
            this.ShipXLengthLabel.AutoSize = true;
            this.ShipXLengthLabel.Location = new System.Drawing.Point(9, 9);
            this.ShipXLengthLabel.Name = "ShipXLengthLabel";
            this.ShipXLengthLabel.Size = new System.Drawing.Size(59, 13);
            this.ShipXLengthLabel.TabIndex = 8;
            this.ShipXLengthLabel.Text = "Ship Width";
            // 
            // Valuable
            // 
            this.Valuable.AutoSize = true;
            this.Valuable.Location = new System.Drawing.Point(9, 205);
            this.Valuable.Name = "Valuable";
            this.Valuable.Size = new System.Drawing.Size(67, 17);
            this.Valuable.TabIndex = 12;
            this.Valuable.Text = "Valuable";
            this.Valuable.UseVisualStyleBackColor = true;
            // 
            // Cooled
            // 
            this.Cooled.AutoSize = true;
            this.Cooled.Location = new System.Drawing.Point(9, 228);
            this.Cooled.Name = "Cooled";
            this.Cooled.Size = new System.Drawing.Size(59, 17);
            this.Cooled.TabIndex = 13;
            this.Cooled.Text = "Cooled";
            this.Cooled.UseVisualStyleBackColor = true;
            // 
            // Containers
            // 
            this.Containers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Containers.FormattingEnabled = true;
            this.Containers.Location = new System.Drawing.Point(184, 155);
            this.Containers.Name = "Containers";
            this.Containers.Size = new System.Drawing.Size(180, 446);
            this.Containers.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Containers";
            // 
            // Sorted
            // 
            this.Sorted.AutoSize = true;
            this.Sorted.Location = new System.Drawing.Point(184, 25);
            this.Sorted.Name = "Sorted";
            this.Sorted.Size = new System.Drawing.Size(57, 17);
            this.Sorted.TabIndex = 6;
            this.Sorted.Text = "Sorted";
            this.Sorted.UseVisualStyleBackColor = true;
            this.Sorted.CheckedChanged += new System.EventHandler(this.Sorted_CheckedChanged);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(184, 48);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 7;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // DistributeContainers
            // 
            this.DistributeContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DistributeContainers.Location = new System.Drawing.Point(9, 571);
            this.DistributeContainers.Name = "DistributeContainers";
            this.DistributeContainers.Size = new System.Drawing.Size(113, 23);
            this.DistributeContainers.TabIndex = 5;
            this.DistributeContainers.Text = "Distribute";
            this.DistributeContainers.UseVisualStyleBackColor = true;
            this.DistributeContainers.Click += new System.EventHandler(this.DistributeContainers_Click);
            // 
            // ContainersLabel
            // 
            this.ContainersLabel.AutoSize = true;
            this.ContainersLabel.Location = new System.Drawing.Point(184, 78);
            this.ContainersLabel.Name = "ContainersLabel";
            this.ContainersLabel.Size = new System.Drawing.Size(0, 13);
            this.ContainersLabel.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(370, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 592);
            this.tabControl1.TabIndex = 0;
            // 
            // Visualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 606);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ContainersLabel);
            this.Controls.Add(this.ShipYLengthLabel);
            this.Controls.Add(this.ShipYLength);
            this.Controls.Add(this.ShipXLengthLabel);
            this.Controls.Add(this.ShipXLength);
            this.Controls.Add(this.DistributeContainers);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Sorted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Containers);
            this.Controls.Add(this.AddRandom);
            this.Controls.Add(this.Cooled);
            this.Controls.Add(this.RandomInput);
            this.Controls.Add(this.Valuable);
            this.Controls.Add(this.AddContianer);
            this.Controls.Add(this.WeightText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Weight);
            this.Controls.Add(this.SetShipFormat);
            this.Name = "Visualiser";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddRandom;
        private System.Windows.Forms.Button AddContianer;
        private System.Windows.Forms.TextBox RandomInput;
        private System.Windows.Forms.TextBox WeightText;
        private System.Windows.Forms.Label ShipYLengthLabel;
        private System.Windows.Forms.TextBox ShipYLength;
        private System.Windows.Forms.Button SetShipFormat;
        private System.Windows.Forms.Label Weight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ShipXLength;
        private System.Windows.Forms.Label ShipXLengthLabel;
        private System.Windows.Forms.CheckBox Valuable;
        private System.Windows.Forms.CheckBox Cooled;
        private System.Windows.Forms.ListBox Containers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Sorted;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button DistributeContainers;
        private System.Windows.Forms.Label ContainersLabel;
        private System.Windows.Forms.TabControl tabControl1;
    }
}


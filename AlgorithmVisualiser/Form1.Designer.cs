
namespace AlgorithmVisualiser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Algorithm = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.VisualPanel = new System.Windows.Forms.Panel();
            this.Start = new System.Windows.Forms.Button();
            this.SelectedAlgorithm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Algorithm
            // 
            this.Algorithm.AutoSize = true;
            this.Algorithm.Location = new System.Drawing.Point(13, 13);
            this.Algorithm.Name = "Algorithm";
            this.Algorithm.Size = new System.Drawing.Size(61, 15);
            this.Algorithm.TabIndex = 0;
            this.Algorithm.Text = "Algorithm";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(209, 12);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // VisualPanel
            // 
            this.VisualPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.VisualPanel.Location = new System.Drawing.Point(13, 42);
            this.VisualPanel.Name = "VisualPanel";
            this.VisualPanel.Size = new System.Drawing.Size(775, 396);
            this.VisualPanel.TabIndex = 3;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(290, 12);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // SelectedAlgorithm
            // 
            this.SelectedAlgorithm.FormattingEnabled = true;
            this.SelectedAlgorithm.Items.AddRange(new object[] {
            "-Sort Algoritm-",
            "Insertion Sort",
            "Bubble Sort",
            "Merge Sort",
            "-Search Algorithms-",
            "Find Max"});
            this.SelectedAlgorithm.Location = new System.Drawing.Point(81, 13);
            this.SelectedAlgorithm.Name = "SelectedAlgorithm";
            this.SelectedAlgorithm.Size = new System.Drawing.Size(121, 23);
            this.SelectedAlgorithm.TabIndex = 1;
            this.SelectedAlgorithm.SelectedIndexChanged += new System.EventHandler(this.SelectedAlgorithm_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.VisualPanel);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.SelectedAlgorithm);
            this.Controls.Add(this.Algorithm);
            this.Name = "Form1";
            this.Text = "Algorithm Visualiser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Algorithm;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Panel VisualPanel;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ComboBox SelectedAlgorithm;
    }
}


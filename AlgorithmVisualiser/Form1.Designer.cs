
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
            this.VisualPanel = new System.Windows.Forms.Panel();
            this.lbl_ArraySize = new System.Windows.Forms.Label();
            this.Algorithm = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.SelectedAlgorithm = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.algorithmWorker = new System.ComponentModel.BackgroundWorker();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.VisualPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // VisualPanel
            // 
            this.VisualPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualPanel.AutoSize = true;
            this.VisualPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VisualPanel.Controls.Add(this.lbl_ArraySize);
            this.VisualPanel.Location = new System.Drawing.Point(13, 41);
            this.VisualPanel.Name = "VisualPanel";
            this.VisualPanel.Size = new System.Drawing.Size(775, 397);
            this.VisualPanel.TabIndex = 3;
            this.VisualPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.VisualPanel_Paint);
            // 
            // lbl_ArraySize
            // 
            this.lbl_ArraySize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ArraySize.AutoSize = true;
            this.lbl_ArraySize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ArraySize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ArraySize.ForeColor = System.Drawing.Color.GhostWhite;
            this.lbl_ArraySize.Location = new System.Drawing.Point(3, 0);
            this.lbl_ArraySize.Name = "lbl_ArraySize";
            this.lbl_ArraySize.Size = new System.Drawing.Size(75, 17);
            this.lbl_ArraySize.TabIndex = 0;
            this.lbl_ArraySize.Text = "ArraySize: 50";
            this.lbl_ArraySize.Click += new System.EventHandler(this.lbl_ArraySize_Click);
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
            this.Reset.Size = new System.Drawing.Size(125, 23);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Generate New Array";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // SelectedAlgorithm
            // 
            this.SelectedAlgorithm.FormattingEnabled = true;
            this.SelectedAlgorithm.Items.AddRange(new object[] {
            "-Sort Algoritm-",
            "Insertion Sort",
            "Bubble Sort",
            "Merge Sort",
            "Heap Sort",
            "-Search Algorithms-",
            "Find Max"});
            this.SelectedAlgorithm.Location = new System.Drawing.Point(81, 13);
            this.SelectedAlgorithm.Name = "SelectedAlgorithm";
            this.SelectedAlgorithm.Size = new System.Drawing.Size(121, 23);
            this.SelectedAlgorithm.TabIndex = 1;
            this.SelectedAlgorithm.SelectedIndexChanged += new System.EventHandler(this.SelectedAlgorithm_SelectedIndexChanged);
            // 
            // Start
            // 
            this.Start.Enabled = false;
            this.Start.Location = new System.Drawing.Point(340, 13);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // algorithmWorker
            // 
            this.algorithmWorker.WorkerReportsProgress = true;
            this.algorithmWorker.WorkerSupportsCancellation = true;
            this.algorithmWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.algorithmWorker_DoWork);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(421, 12);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(367, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.VisualPanel);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.SelectedAlgorithm);
            this.Controls.Add(this.Algorithm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(16, 39);
            this.Name = "Form1";
            this.Text = "Algorithm Visualiser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisualPanel.ResumeLayout(false);
            this.VisualPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Algorithm;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Panel VisualPanel;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ComboBox SelectedAlgorithm;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lbl_ArraySize;
    }
}


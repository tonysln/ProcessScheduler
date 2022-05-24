namespace ProcessScheduler
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.algoInput = new System.Windows.Forms.GroupBox();
            this.customAlgoTextbox = new System.Windows.Forms.TextBox();
            this.customAlgo = new System.Windows.Forms.RadioButton();
            this.sampleAlgo3 = new System.Windows.Forms.RadioButton();
            this.sampleAlgo2 = new System.Windows.Forms.RadioButton();
            this.sampleAlgo1 = new System.Windows.Forms.RadioButton();
            this.chosenAlgoLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.kryptonButton1 = new System.Windows.Forms.Button();
            this.kryptonButton2 = new System.Windows.Forms.Button();
            this.kryptonButton3 = new System.Windows.Forms.Button();
            this.kryptonButton4 = new System.Windows.Forms.Button();
            this.kryptonButton5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.averageTimeLabel = new System.Windows.Forms.Label();
            this.ganttField = new System.Windows.Forms.PictureBox();
            this.taskListGrid = new System.Windows.Forms.DataGridView();
            this.taskListPanel = new System.Windows.Forms.Panel();
            this.algoInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskListGrid)).BeginInit();
            this.taskListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // algoInput
            // 
            this.algoInput.Controls.Add(this.customAlgoTextbox);
            this.algoInput.Controls.Add(this.customAlgo);
            this.algoInput.Controls.Add(this.sampleAlgo3);
            this.algoInput.Controls.Add(this.sampleAlgo2);
            this.algoInput.Controls.Add(this.sampleAlgo1);
            this.algoInput.Location = new System.Drawing.Point(22, 14);
            this.algoInput.Name = "algoInput";
            this.algoInput.Size = new System.Drawing.Size(369, 186);
            this.algoInput.TabIndex = 1;
            this.algoInput.TabStop = false;
            this.algoInput.Text = "Vali või sisesta järjend (kujul 1,10;4,2;12,3;13,2)";
            // 
            // customAlgoTextbox
            // 
            this.customAlgoTextbox.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customAlgoTextbox.Location = new System.Drawing.Point(124, 136);
            this.customAlgoTextbox.Name = "customAlgoTextbox";
            this.customAlgoTextbox.Size = new System.Drawing.Size(209, 25);
            this.customAlgoTextbox.TabIndex = 4;
            this.customAlgoTextbox.TextChanged += new System.EventHandler(this.customAlgoTextbox_TextChanged);
            this.customAlgoTextbox.Enter += new System.EventHandler(this.customAlgoTextbox_Enter);
            // 
            // customAlgo
            // 
            this.customAlgo.AutoSize = true;
            this.customAlgo.Location = new System.Drawing.Point(21, 136);
            this.customAlgo.Name = "customAlgo";
            this.customAlgo.Size = new System.Drawing.Size(94, 24);
            this.customAlgo.TabIndex = 3;
            this.customAlgo.TabStop = true;
            this.customAlgo.Text = "Enda oma";
            this.customAlgo.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo3
            // 
            this.sampleAlgo3.AutoSize = true;
            this.sampleAlgo3.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo3.Location = new System.Drawing.Point(21, 105);
            this.sampleAlgo3.Name = "sampleAlgo3";
            this.sampleAlgo3.Size = new System.Drawing.Size(210, 22);
            this.sampleAlgo3.TabIndex = 2;
            this.sampleAlgo3.TabStop = true;
            this.sampleAlgo3.Text = "0,4;1,5;2,2;3,1;4,6;6,3";
            this.sampleAlgo3.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo2
            // 
            this.sampleAlgo2.AutoSize = true;
            this.sampleAlgo2.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo2.Location = new System.Drawing.Point(21, 74);
            this.sampleAlgo2.Name = "sampleAlgo2";
            this.sampleAlgo2.Size = new System.Drawing.Size(210, 22);
            this.sampleAlgo2.TabIndex = 1;
            this.sampleAlgo2.TabStop = true;
            this.sampleAlgo2.Text = "0,2;0,4;12,4;15,5;21,10";
            this.sampleAlgo2.UseVisualStyleBackColor = true;
            // 
            // sampleAlgo1
            // 
            this.sampleAlgo1.AutoSize = true;
            this.sampleAlgo1.Font = new System.Drawing.Font("Consolas", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sampleAlgo1.Location = new System.Drawing.Point(21, 43);
            this.sampleAlgo1.Name = "sampleAlgo1";
            this.sampleAlgo1.Size = new System.Drawing.Size(210, 22);
            this.sampleAlgo1.TabIndex = 0;
            this.sampleAlgo1.TabStop = true;
            this.sampleAlgo1.Text = "0,7;1,5;2,3;3,1;4,2;5,1";
            this.sampleAlgo1.UseVisualStyleBackColor = true;
            // 
            // chosenAlgoLabel
            // 
            this.chosenAlgoLabel.AutoSize = true;
            this.chosenAlgoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chosenAlgoLabel.Location = new System.Drawing.Point(18, 308);
            this.chosenAlgoLabel.Name = "chosenAlgoLabel";
            this.chosenAlgoLabel.Size = new System.Drawing.Size(27, 20);
            this.chosenAlgoLabel.TabIndex = 8;
            this.chosenAlgoLabel.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keskmine ooteaeg: ";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.kryptonButton1.Location = new System.Drawing.Point(22, 256);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(84, 32);
            this.kryptonButton1.TabIndex = 11;
            this.kryptonButton1.Text = "FCFS";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.kryptonButton2.Location = new System.Drawing.Point(112, 256);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(84, 32);
            this.kryptonButton2.TabIndex = 12;
            this.kryptonButton2.Text = "SRTF";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.kryptonButton3.Location = new System.Drawing.Point(202, 256);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(84, 32);
            this.kryptonButton3.TabIndex = 13;
            this.kryptonButton3.Text = "RR4";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.Enabled = false;
            this.kryptonButton4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.kryptonButton4.Location = new System.Drawing.Point(292, 256);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(84, 32);
            this.kryptonButton4.TabIndex = 14;
            this.kryptonButton4.Text = "2xFCFS";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // kryptonButton5
            // 
            this.kryptonButton5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.kryptonButton5.Location = new System.Drawing.Point(821, 256);
            this.kryptonButton5.Name = "kryptonButton5";
            this.kryptonButton5.Size = new System.Drawing.Size(84, 32);
            this.kryptonButton5.TabIndex = 15;
            this.kryptonButton5.Text = "Puhasta";
            this.kryptonButton5.Click += new System.EventHandler(this.kryptonButton5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Algoritmi käivitamiseks tee valik ja klõpsa nupule";
            // 
            // averageTimeLabel
            // 
            this.averageTimeLabel.AutoSize = true;
            this.averageTimeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.averageTimeLabel.Location = new System.Drawing.Point(153, 329);
            this.averageTimeLabel.Name = "averageTimeLabel";
            this.averageTimeLabel.Size = new System.Drawing.Size(29, 20);
            this.averageTimeLabel.TabIndex = 16;
            this.averageTimeLabel.Text = "0.0";
            // 
            // ganttField
            // 
            this.ganttField.BackColor = System.Drawing.Color.Transparent;
            this.ganttField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ganttField.Location = new System.Drawing.Point(22, 363);
            this.ganttField.Name = "ganttField";
            this.ganttField.Size = new System.Drawing.Size(883, 71);
            this.ganttField.TabIndex = 17;
            this.ganttField.TabStop = false;
            // 
            // taskListGrid
            // 
            this.taskListGrid.AllowUserToAddRows = false;
            this.taskListGrid.AllowUserToDeleteRows = false;
            this.taskListGrid.AllowUserToResizeColumns = false;
            this.taskListGrid.AllowUserToResizeRows = false;
            this.taskListGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.taskListGrid.BackgroundColor = System.Drawing.Color.White;
            this.taskListGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskListGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.taskListGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.taskListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.taskListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskListGrid.Location = new System.Drawing.Point(1, 1);
            this.taskListGrid.MultiSelect = false;
            this.taskListGrid.Name = "taskListGrid";
            this.taskListGrid.ReadOnly = true;
            this.taskListGrid.RowHeadersVisible = false;
            this.taskListGrid.RowHeadersWidth = 45;
            this.taskListGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.taskListGrid.ShowCellErrors = false;
            this.taskListGrid.ShowEditingIcon = false;
            this.taskListGrid.Size = new System.Drawing.Size(490, 215);
            this.taskListGrid.TabIndex = 18;
            // 
            // taskListPanel
            // 
            this.taskListPanel.BackColor = System.Drawing.Color.LightGray;
            this.taskListPanel.Controls.Add(this.taskListGrid);
            this.taskListPanel.Location = new System.Drawing.Point(413, 14);
            this.taskListPanel.Name = "taskListPanel";
            this.taskListPanel.Padding = new System.Windows.Forms.Padding(1);
            this.taskListPanel.Size = new System.Drawing.Size(492, 217);
            this.taskListPanel.TabIndex = 19;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(925, 461);
            this.Controls.Add(this.ganttField);
            this.Controls.Add(this.averageTimeLabel);
            this.Controls.Add(this.kryptonButton5);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chosenAlgoLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algoInput);
            this.Controls.Add(this.taskListPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protsessoriaja planeerimise algoritmide töö visualiseerimine";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.algoInput.ResumeLayout(false);
            this.algoInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ganttField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskListGrid)).EndInit();
            this.taskListPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox algoInput;
        private System.Windows.Forms.TextBox customAlgoTextbox;
        private System.Windows.Forms.RadioButton customAlgo;
        private System.Windows.Forms.RadioButton sampleAlgo3;
        private System.Windows.Forms.Label chosenAlgoLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button kryptonButton1;
        private System.Windows.Forms.Button kryptonButton2;
        private System.Windows.Forms.Button kryptonButton3;
        private System.Windows.Forms.Button kryptonButton4;
        private System.Windows.Forms.Button kryptonButton5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton sampleAlgo2;
        private System.Windows.Forms.Label averageTimeLabel;
        private System.Windows.Forms.RadioButton sampleAlgo1;
        private System.Windows.Forms.PictureBox ganttField;
        protected internal System.Windows.Forms.DataGridView taskListGrid;
        private System.Windows.Forms.Panel taskListPanel;
    }
}


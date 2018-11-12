namespace nudata.Forms
{
    partial class PositionYearRateHoursList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.yearsGridView = new System.Windows.Forms.DataGridView();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.ViewPanel = new System.Windows.Forms.Panel();
            this.hoursGridView = new System.Windows.Forms.DataGridView();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.remove = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.rate_hours = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearsGridView)).BeginInit();
            this.RightPanel.SuspendLayout();
            this.ViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursGridView)).BeginInit();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.yearsGridView);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(138, 736);
            this.LeftPanel.TabIndex = 0;
            // 
            // yearsGridView
            // 
            this.yearsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.yearsGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.yearsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearsGridView.Location = new System.Drawing.Point(0, 0);
            this.yearsGridView.Name = "yearsGridView";
            this.yearsGridView.ReadOnly = true;
            this.yearsGridView.RowHeadersVisible = false;
            this.yearsGridView.RowTemplate.Height = 35;
            this.yearsGridView.Size = new System.Drawing.Size(138, 736);
            this.yearsGridView.TabIndex = 0;
            this.yearsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.yearsGridView_CellClick);
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.ViewPanel);
            this.RightPanel.Controls.Add(this.ControlsPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(138, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(445, 736);
            this.RightPanel.TabIndex = 1;
            // 
            // ViewPanel
            // 
            this.ViewPanel.Controls.Add(this.hoursGridView);
            this.ViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewPanel.Location = new System.Drawing.Point(0, 160);
            this.ViewPanel.Name = "ViewPanel";
            this.ViewPanel.Size = new System.Drawing.Size(445, 576);
            this.ViewPanel.TabIndex = 1;
            // 
            // hoursGridView
            // 
            this.hoursGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hoursGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hoursGridView.Location = new System.Drawing.Point(0, 0);
            this.hoursGridView.Name = "hoursGridView";
            this.hoursGridView.ReadOnly = true;
            this.hoursGridView.RowHeadersVisible = false;
            this.hoursGridView.Size = new System.Drawing.Size(445, 576);
            this.hoursGridView.TabIndex = 0;
            this.hoursGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.hoursGridView_CellClick);
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.remove);
            this.ControlsPanel.Controls.Add(this.update);
            this.ControlsPanel.Controls.Add(this.add);
            this.ControlsPanel.Controls.Add(this.rate_hours);
            this.ControlsPanel.Controls.Add(this.label3);
            this.ControlsPanel.Controls.Add(this.position);
            this.ControlsPanel.Controls.Add(this.label2);
            this.ControlsPanel.Controls.Add(this.year);
            this.ControlsPanel.Controls.Add(this.label1);
            this.ControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(445, 160);
            this.ControlsPanel.TabIndex = 0;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(167, 100);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 8;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(167, 62);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 7;
            this.update.Text = "Изменить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(167, 22);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 6;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // rate_hours
            // 
            this.rate_hours.Location = new System.Drawing.Point(9, 103);
            this.rate_hours.Name = "rate_hours";
            this.rate_hours.Size = new System.Drawing.Size(145, 20);
            this.rate_hours.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество часов на ставку";
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(9, 64);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(145, 20);
            this.position.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Должность";
            // 
            // year
            // 
            this.year.Location = new System.Drawing.Point(9, 25);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(56, 20);
            this.year.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Год";
            // 
            // PositionYearRateHoursList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 736);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "PositionYearRateHoursList";
            this.Text = "Количество часов на ставку";
            this.Load += new System.EventHandler(this.PositionYearRateHoursList_Load);
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yearsGridView)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.ViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hoursGridView)).EndInit();
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel ViewPanel;
        private System.Windows.Forms.DataGridView hoursGridView;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.DataGridView yearsGridView;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox rate_hours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox year;
        private System.Windows.Forms.Label label1;
    }
}
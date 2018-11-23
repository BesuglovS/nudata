namespace nudata.Forms
{
    partial class MarkTypeList
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
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.LeftViewPanel = new System.Windows.Forms.Panel();
            this.LeftControlsPanel = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.RightViewPanel = new System.Windows.Forms.Panel();
            this.RightControlsPanel = new System.Windows.Forms.Panel();
            this.markTypeGrid = new System.Windows.Forms.DataGridView();
            this.markTypeOptionGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.markTypeText = new System.Windows.Forms.TextBox();
            this.addMT = new System.Windows.Forms.Button();
            this.updateMT = new System.Windows.Forms.Button();
            this.removeMT = new System.Windows.Forms.Button();
            this.markTypeOptionText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeMTO = new System.Windows.Forms.Button();
            this.updateMTO = new System.Windows.Forms.Button();
            this.addMTO = new System.Windows.Forms.Button();
            this.LeftPanel.SuspendLayout();
            this.LeftViewPanel.SuspendLayout();
            this.LeftControlsPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.RightViewPanel.SuspendLayout();
            this.RightControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markTypeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markTypeOptionGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.Controls.Add(this.LeftViewPanel);
            this.LeftPanel.Controls.Add(this.LeftControlsPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(384, 657);
            this.LeftPanel.TabIndex = 0;
            // 
            // LeftViewPanel
            // 
            this.LeftViewPanel.Controls.Add(this.markTypeGrid);
            this.LeftViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftViewPanel.Location = new System.Drawing.Point(0, 105);
            this.LeftViewPanel.Name = "LeftViewPanel";
            this.LeftViewPanel.Size = new System.Drawing.Size(384, 552);
            this.LeftViewPanel.TabIndex = 1;
            // 
            // LeftControlsPanel
            // 
            this.LeftControlsPanel.Controls.Add(this.removeMT);
            this.LeftControlsPanel.Controls.Add(this.updateMT);
            this.LeftControlsPanel.Controls.Add(this.addMT);
            this.LeftControlsPanel.Controls.Add(this.markTypeText);
            this.LeftControlsPanel.Controls.Add(this.label1);
            this.LeftControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LeftControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftControlsPanel.Name = "LeftControlsPanel";
            this.LeftControlsPanel.Size = new System.Drawing.Size(384, 105);
            this.LeftControlsPanel.TabIndex = 0;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.RightViewPanel);
            this.RightPanel.Controls.Add(this.RightControlsPanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(384, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(359, 657);
            this.RightPanel.TabIndex = 1;
            // 
            // RightViewPanel
            // 
            this.RightViewPanel.Controls.Add(this.markTypeOptionGrid);
            this.RightViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightViewPanel.Location = new System.Drawing.Point(0, 105);
            this.RightViewPanel.Name = "RightViewPanel";
            this.RightViewPanel.Size = new System.Drawing.Size(359, 552);
            this.RightViewPanel.TabIndex = 1;
            // 
            // RightControlsPanel
            // 
            this.RightControlsPanel.Controls.Add(this.removeMTO);
            this.RightControlsPanel.Controls.Add(this.updateMTO);
            this.RightControlsPanel.Controls.Add(this.addMTO);
            this.RightControlsPanel.Controls.Add(this.markTypeOptionText);
            this.RightControlsPanel.Controls.Add(this.label2);
            this.RightControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.RightControlsPanel.Name = "RightControlsPanel";
            this.RightControlsPanel.Size = new System.Drawing.Size(359, 105);
            this.RightControlsPanel.TabIndex = 0;
            // 
            // markTypeGrid
            // 
            this.markTypeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.markTypeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markTypeGrid.Location = new System.Drawing.Point(0, 0);
            this.markTypeGrid.Name = "markTypeGrid";
            this.markTypeGrid.ReadOnly = true;
            this.markTypeGrid.RowHeadersVisible = false;
            this.markTypeGrid.Size = new System.Drawing.Size(384, 552);
            this.markTypeGrid.TabIndex = 0;
            this.markTypeGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.markTypeGrid_CellClick);
            // 
            // markTypeOptionGrid
            // 
            this.markTypeOptionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.markTypeOptionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.markTypeOptionGrid.Location = new System.Drawing.Point(0, 0);
            this.markTypeOptionGrid.Name = "markTypeOptionGrid";
            this.markTypeOptionGrid.ReadOnly = true;
            this.markTypeOptionGrid.RowHeadersVisible = false;
            this.markTypeOptionGrid.Size = new System.Drawing.Size(359, 552);
            this.markTypeOptionGrid.TabIndex = 0;
            this.markTypeOptionGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.markTypeOptionGrid_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вид оценки";
            // 
            // markTypeText
            // 
            this.markTypeText.Location = new System.Drawing.Point(12, 25);
            this.markTypeText.Name = "markTypeText";
            this.markTypeText.Size = new System.Drawing.Size(340, 20);
            this.markTypeText.TabIndex = 1;
            // 
            // addMT
            // 
            this.addMT.Location = new System.Drawing.Point(12, 51);
            this.addMT.Name = "addMT";
            this.addMT.Size = new System.Drawing.Size(104, 23);
            this.addMT.TabIndex = 2;
            this.addMT.Text = "Добавить";
            this.addMT.UseVisualStyleBackColor = true;
            this.addMT.Click += new System.EventHandler(this.addMT_Click);
            // 
            // updateMT
            // 
            this.updateMT.Location = new System.Drawing.Point(129, 51);
            this.updateMT.Name = "updateMT";
            this.updateMT.Size = new System.Drawing.Size(104, 23);
            this.updateMT.TabIndex = 3;
            this.updateMT.Text = "Изменить";
            this.updateMT.UseVisualStyleBackColor = true;
            this.updateMT.Click += new System.EventHandler(this.updateMT_Click);
            // 
            // removeMT
            // 
            this.removeMT.Location = new System.Drawing.Point(248, 51);
            this.removeMT.Name = "removeMT";
            this.removeMT.Size = new System.Drawing.Size(104, 23);
            this.removeMT.TabIndex = 4;
            this.removeMT.Text = "Удалить";
            this.removeMT.UseVisualStyleBackColor = true;
            this.removeMT.Click += new System.EventHandler(this.removeMT_Click);
            // 
            // markTypeOptionText
            // 
            this.markTypeOptionText.Location = new System.Drawing.Point(9, 25);
            this.markTypeOptionText.Name = "markTypeOptionText";
            this.markTypeOptionText.Size = new System.Drawing.Size(340, 20);
            this.markTypeOptionText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Оценка";
            // 
            // removeMTO
            // 
            this.removeMTO.Location = new System.Drawing.Point(245, 51);
            this.removeMTO.Name = "removeMTO";
            this.removeMTO.Size = new System.Drawing.Size(104, 23);
            this.removeMTO.TabIndex = 7;
            this.removeMTO.Text = "Удалить";
            this.removeMTO.UseVisualStyleBackColor = true;
            this.removeMTO.Click += new System.EventHandler(this.removeMTO_Click);
            // 
            // updateMTO
            // 
            this.updateMTO.Location = new System.Drawing.Point(126, 51);
            this.updateMTO.Name = "updateMTO";
            this.updateMTO.Size = new System.Drawing.Size(104, 23);
            this.updateMTO.TabIndex = 6;
            this.updateMTO.Text = "Изменить";
            this.updateMTO.UseVisualStyleBackColor = true;
            this.updateMTO.Click += new System.EventHandler(this.updateMTO_Click);
            // 
            // addMTO
            // 
            this.addMTO.Location = new System.Drawing.Point(9, 51);
            this.addMTO.Name = "addMTO";
            this.addMTO.Size = new System.Drawing.Size(104, 23);
            this.addMTO.TabIndex = 5;
            this.addMTO.Text = "Добавить";
            this.addMTO.UseVisualStyleBackColor = true;
            this.addMTO.Click += new System.EventHandler(this.addMTO_Click);
            // 
            // MarkTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 657);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "MarkTypeList";
            this.Text = "Виды оценок";
            this.Load += new System.EventHandler(this.MarkTypeList_Load);
            this.LeftPanel.ResumeLayout(false);
            this.LeftViewPanel.ResumeLayout(false);
            this.LeftControlsPanel.ResumeLayout(false);
            this.LeftControlsPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightViewPanel.ResumeLayout(false);
            this.RightControlsPanel.ResumeLayout(false);
            this.RightControlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markTypeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markTypeOptionGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel LeftViewPanel;
        private System.Windows.Forms.Panel LeftControlsPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel RightViewPanel;
        private System.Windows.Forms.Panel RightControlsPanel;
        private System.Windows.Forms.DataGridView markTypeGrid;
        private System.Windows.Forms.DataGridView markTypeOptionGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button removeMT;
        private System.Windows.Forms.Button updateMT;
        private System.Windows.Forms.Button addMT;
        private System.Windows.Forms.TextBox markTypeText;
        private System.Windows.Forms.Button removeMTO;
        private System.Windows.Forms.Button updateMTO;
        private System.Windows.Forms.Button addMTO;
        private System.Windows.Forms.TextBox markTypeOptionText;
        private System.Windows.Forms.Label label2;
    }
}
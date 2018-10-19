namespace nudata.Forms
{
    partial class NoteList
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
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.NotesGridView = new System.Windows.Forms.DataGridView();
            this.NoteText = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.noteFilter = new System.Windows.Forms.TextBox();
            this.controlsPanel.SuspendLayout();
            this.viewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.noteFilter);
            this.controlsPanel.Controls.Add(this.label1);
            this.controlsPanel.Controls.Add(this.remove);
            this.controlsPanel.Controls.Add(this.update);
            this.controlsPanel.Controls.Add(this.add);
            this.controlsPanel.Controls.Add(this.NoteText);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(800, 82);
            this.controlsPanel.TabIndex = 0;
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.NotesGridView);
            this.viewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPanel.Location = new System.Drawing.Point(0, 82);
            this.viewPanel.Name = "viewPanel";
            this.viewPanel.Size = new System.Drawing.Size(800, 368);
            this.viewPanel.TabIndex = 1;
            // 
            // NotesGridView
            // 
            this.NotesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesGridView.Location = new System.Drawing.Point(0, 0);
            this.NotesGridView.Name = "NotesGridView";
            this.NotesGridView.ReadOnly = true;
            this.NotesGridView.RowHeadersVisible = false;
            this.NotesGridView.Size = new System.Drawing.Size(800, 368);
            this.NotesGridView.TabIndex = 0;
            this.NotesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NotesGridView_CellClick);
            // 
            // NoteText
            // 
            this.NoteText.Location = new System.Drawing.Point(12, 12);
            this.NoteText.Name = "NoteText";
            this.NoteText.Size = new System.Drawing.Size(776, 20);
            this.NoteText.TabIndex = 0;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(12, 38);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(93, 38);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "Изменить";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(174, 38);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(75, 23);
            this.remove.TabIndex = 3;
            this.remove.Text = "Удалить";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фильтр";
            // 
            // noteFilter
            // 
            this.noteFilter.Location = new System.Drawing.Point(336, 40);
            this.noteFilter.Name = "noteFilter";
            this.noteFilter.Size = new System.Drawing.Size(452, 20);
            this.noteFilter.TabIndex = 5;
            this.noteFilter.TextChanged += new System.EventHandler(this.noteFilter_TextChanged);
            // 
            // NoteList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewPanel);
            this.Controls.Add(this.controlsPanel);
            this.Name = "NoteList";
            this.Text = "Заметки";
            this.Load += new System.EventHandler(this.NoteList_Load);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.viewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NotesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Panel viewPanel;
        private System.Windows.Forms.TextBox noteFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox NoteText;
        private System.Windows.Forms.DataGridView NotesGridView;
    }
}
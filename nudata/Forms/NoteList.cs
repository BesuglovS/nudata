using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class NoteList : Form
    {
        private string ApiEndpoint;

        NoteRepo nRepo;
        List<Note> Notes;

        Timer textTimer;

        public NoteList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();
        }

        private void NoteList_Load(object sender, EventArgs e)
        {
            nRepo = new NoteRepo(ApiEndpoint);

            IntPtr pIcon = Resources.notes.GetHicon();
            Icon = Icon.FromHandle(pIcon);

            textTimer = new Timer();
            textTimer.Interval = 1000;
            textTimer.Tick += new EventHandler(textTimer_Tick);

            RefreshNotesList();                        
        }

        private void textTimer_Tick(object sender, EventArgs e)
        {
            if (noteFilter.Focused)
            {
                var items = Notes.Where(n => n.text.ToLower().Contains(noteFilter.Text.ToLower())).ToList();

                NotesGridView.DataSource = items;

                NotesGridView.Columns["id"].Visible = false;
                NotesGridView.Columns["text"].HeaderText = "Текст заметки";

                textTimer.Stop(); //No disposing required, just stop the timer.
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newNote = new Note()
            {
                text = NoteText.Text
            };
            nRepo.add(newNote);

            RefreshNotesList();
        }

        private void RefreshNotesList()
        {
            Notes = nRepo.all().OrderBy(n => n.text).ToList();

            NotesGridView.DataSource = Notes;

            NotesGridView.Columns["id"].Visible = false;
            NotesGridView.Columns["text"].HeaderText = "Текст заметки";
            NotesGridView.Columns["text"].Width = NotesGridView.Width - 10;

            if (noteFilter.Text.Trim() != "")
            {
                noteFilter_TextChanged(this, null);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (NotesGridView.SelectedCells.Count > 0)
            {
                var note = ((List<Note>)NotesGridView.DataSource)[NotesGridView.SelectedCells[0].RowIndex];

                note.text = NoteText.Text;

                nRepo.update(note, note.id);

                RefreshNotesList();
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (NotesGridView.SelectedCells.Count > 0)
            {
                var note = ((List<Note>)NotesGridView.DataSource)[NotesGridView.SelectedCells[0].RowIndex];

                nRepo.delete(note.id);

                RefreshNotesList();
            }
        }

        private void NotesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var note = ((List<Note>)NotesGridView.DataSource)[e.RowIndex];

            NoteText.Text = note.text;
        }

        private void noteFilter_TextChanged(object sender, EventArgs e)
        {
            textTimer.Start();
        }
    }
}

using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nudata.Forms
{
    public partial class MarkTypeList : Form
    {
        private string ApiEndpoint;

        MarkTypeRepo mtRepo;
        MarkTypeOptionRepo mtoRepo;

        public MarkTypeList(string apiEndpoint)
        {
            ApiEndpoint = apiEndpoint;
            InitializeComponent();

            mtRepo = new MarkTypeRepo(ApiEndpoint);
            mtoRepo = new MarkTypeOptionRepo(ApiEndpoint);
        }

        private void MarkTypeList_Load(object sender, EventArgs e)
        {
            IntPtr pIcon = Resources.Marks.GetHicon();
            Icon = Icon.FromHandle(pIcon);
            UpdateMarkTypes();
        }

        private void UpdateMarkTypes()
        {
            var markTypes = mtRepo.all();

            markTypeGrid.DataSource = markTypes;

            FormatMarkTypeGrid();
        }

        private void FormatMarkTypeGrid()
        {
            markTypeGrid.Columns["id"].Visible = false;            
            markTypeGrid.Columns["name"].HeaderText = "Вид оценки";
            markTypeGrid.Columns["name"].Width = markTypeGrid.Width - 10;
        }

        private void addMT_Click(object sender, EventArgs e)
        {
            var mt = new MarkType {
                name = markTypeText.Text
            };

            mtRepo.add(mt);

            UpdateMarkTypes();
        }

        private void updateMT_Click(object sender, EventArgs e)
        {
            if (markTypeGrid.SelectedCells.Count > 0)
            {
                var mt = ((List<MarkType>)markTypeGrid.DataSource)[markTypeGrid.SelectedCells[0].RowIndex];

                mt.name = markTypeText.Text;

                mtRepo.update(mt, mt.id);

                UpdateMarkTypes();
            }
        }

        private void removeMT_Click(object sender, EventArgs e)
        {
            if (markTypeGrid.SelectedCells.Count > 0)
            {
                var mt = ((List<MarkType>)markTypeGrid.DataSource)[markTypeGrid.SelectedCells[0].RowIndex];

                mtRepo.delete(mt.id);

                UpdateMarkTypes();
            }
        }

        private void markTypeGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var mt = ((List<MarkType>)markTypeGrid.DataSource)[e.RowIndex];

            markTypeText.Text = mt.name;

            UpdateMarkTypeOptions(mt.id);
        }

        private void UpdateMarkTypeOptions(int markTypeId)
        {
            var markTypeOptions = mtoRepo.markTypeAll(markTypeId);

            markTypeOptionGrid.DataSource = markTypeOptions;

            FormatMarkTypeOptionsGrid();
        }

        private void FormatMarkTypeOptionsGrid()
        {
            markTypeOptionGrid.Columns["id"].Visible = false;
            markTypeOptionGrid.Columns["mark_type_id"].Visible = false;
            markTypeOptionGrid.Columns["mark"].HeaderText = "Оценка";
            markTypeOptionGrid.Columns["mark"].Width = markTypeOptionGrid.Width - 10;
        }

        private void addMTO_Click(object sender, EventArgs e)
        {
            if (markTypeGrid.SelectedCells.Count > 0)
            {
                var mt = ((List<MarkType>)markTypeGrid.DataSource)[markTypeGrid.SelectedCells[0].RowIndex];
                var newMto = new MarkTypeOption
                {
                    mark_type_id = mt.id,
                    mark = markTypeOptionText.Text
                };

                mtoRepo.add(newMto);

                UpdateMarkTypeOptions(mt.id);
            }
        }

        private void updateMTO_Click(object sender, EventArgs e)
        {
            if (markTypeOptionGrid.SelectedCells.Count > 0)
            {
                var mto = ((List<MarkTypeOption>)markTypeOptionGrid.DataSource)[markTypeOptionGrid.SelectedCells[0].RowIndex];

                mto.mark = markTypeOptionText.Text;
                
                mtoRepo.update(mto, mto.id);

                UpdateMarkTypeOptions(mto.mark_type_id);
            }
        }

        private void removeMTO_Click(object sender, EventArgs e)
        {
            if (markTypeOptionGrid.SelectedCells.Count > 0)
            {
                var mto = ((List<MarkTypeOption>)markTypeOptionGrid.DataSource)[markTypeOptionGrid.SelectedCells[0].RowIndex];

                mtoRepo.delete(mto.id);

                UpdateMarkTypeOptions(mto.mark_type_id);
            }
        }

        private void markTypeOptionGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var mto = ((List<MarkTypeOption>)markTypeOptionGrid.DataSource)[e.RowIndex];

            markTypeOptionText.Text = mto.mark;
        }
    }
}

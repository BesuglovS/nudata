using nudata.Core;
using nudata.DomainClasses.Main;
using nudata.nubackRepos;
using nudata.Views;
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
    public partial class PositionYearRateHoursList : Form
    {
        private string ApiEndpoint;
        PositionYearRateHoursRepo pyrhRepo;

        List<int> currentYears = new List<int>();
        int currentYear = -1;


        public PositionYearRateHoursList(string apiEndpoint)
        {
            InitializeComponent();

            ApiEndpoint = apiEndpoint;

            pyrhRepo = new PositionYearRateHoursRepo(ApiEndpoint);
        }

        private void PositionYearRateHoursList_Load(object sender, EventArgs e)
        {
            ReloadYearsList();
        }

        private void ReloadYearsList()
        {
            currentYears = pyrhRepo.allYears();

            var yearViews = currentYears
                .OrderBy(y => y)
                .Select(year => new YearView { year = year })
                .ToList();

            yearsGridView.DataSource = yearViews;

            yearsGridView.Columns["year"].Visible = false;
            yearsGridView.Columns["yearString"].Width = yearsGridView.Width - 20;
            yearsGridView.Columns["yearString"].HeaderText = "Учебный год";
        }

        private void yearsGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentYear = ((List<YearView>)yearsGridView.DataSource)[e.RowIndex].year;
            ReloadYearHours(currentYear);
        }

        private void ReloadYearHours(int year)
        {
            var hours = pyrhRepo.year(year);

            hoursGridView.DataSource = hours.OrderBy(i => i.rate_hours).ToList();

            hoursGridView.Columns["id"].Visible = false;
            hoursGridView.Columns["year"].HeaderText = "Год";
            hoursGridView.Columns["position"].HeaderText = "Должность";
            hoursGridView.Columns["position"].Width = 200;
            hoursGridView.Columns["rate_hours"].HeaderText = "Часов на ставку";
        }

        private void add_Click(object sender, EventArgs e)
        {
            var newpyrh = new PositionYearRateHours {
                year = Utilities.ParseIntOrZero(year.Text),
                position = position.Text,
                rate_hours = Utilities.ParseIntOrZero(rate_hours.Text)
            };

            pyrhRepo.add(newpyrh);

            ReloadYearHours(currentYear);
            ReloadYearsList();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (hoursGridView.SelectedCells.Count > 0)
            {
                var pyrh = ((List<PositionYearRateHours>)hoursGridView.DataSource)[hoursGridView.SelectedCells[0].RowIndex];

                pyrh.year = Utilities.ParseIntOrZero(year.Text);
                pyrh.position = position.Text;
                pyrh.rate_hours = Utilities.ParseIntOrZero(rate_hours.Text);

                pyrhRepo.update(pyrh, pyrh.id);

                ReloadYearHours(currentYear);
                ReloadYearsList();
            }            
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (hoursGridView.SelectedCells.Count > 0)
            {
                var pyrh = ((List<PositionYearRateHours>)hoursGridView.DataSource)[hoursGridView.SelectedCells[0].RowIndex];

                pyrhRepo.delete(pyrh.id);

                ReloadYearHours(currentYear);
                ReloadYearsList();
            }
        }

        private void hoursGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var pyrh = ((List<PositionYearRateHours>)hoursGridView.DataSource)[e.RowIndex];

            year.Text = pyrh.year.ToString();
            position.Text = pyrh.position;
            rate_hours.Text = pyrh.rate_hours.ToString();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            cmbType.Items.Add("Доход");
            cmbType.Items.Add("Расход");
            cmbType.SelectedIndex = 0;

            dgvTransactions.ColumnCount = 4;
            dgvTransactions.Columns[0].Name = "Дата";
            dgvTransactions.Columns[1].Name = "Описание";
            dgvTransactions.Columns[2].Name = "Тип";
            dgvTransactions.Columns[3].Name = "Сумма";

            chart1.Series.Clear();
            Series series = new Series("Траты");
            series.ChartType = SeriesChartType.Pie;
            chart1.Series.Add(series);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string desc = txtDescription.Text;
            string type = cmbType.SelectedItem.ToString();
            double amount;

            if (double.TryParse(txtAmount.Text, out amount) && desc != "")
            {
                dgvTransactions.Rows.Add(DateTime.Now.ToShortDateString(), desc, type, amount);
                CalculateBalance();
                UpdateChart();
                txtDescription.Clear();
                txtAmount.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }

        private void CalculateBalance()
        {
            double total = 0;
            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    string type = row.Cells[2].Value.ToString();
                    double val = Convert.ToDouble(row.Cells[3].Value);

                    if (type == "Доход") total += val;
                    else total -= val;
                }
            }
            lblBalance.Text = "Баланс: " + total.ToString();
        }

        private void UpdateChart()
        {
            chart1.Series["Траты"].Points.Clear();
            foreach (DataGridViewRow row in dgvTransactions.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() == "Расход")
                {
                    string name = row.Cells[1].Value.ToString();
                    double val = Convert.ToDouble(row.Cells[3].Value);
                    chart1.Series["Траты"].Points.AddXY(name, val);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}
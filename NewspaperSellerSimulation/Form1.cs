using System;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        public static SimulationSystem simulationSystem = new SimulationSystem();

        public Form1()
        {
            InitializeComponent();

            simulationSystem = simulationSystem.BuildSimulationSystem();
            simulationSystem.BuildSimulationTable();

            dataGridView1.DataSource = simulationSystem.SimulationTable;
            SetLabels();

            string testingManager = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
            MessageBox.Show(testingManager);
        }

        private void SetLabels()
        {
            PerformanceMeasures performance = simulationSystem.PerformanceMeasures;

            totalSalesLabel.Text = performance.TotalSalesProfit.ToString();
            totalCostLabel.Text = performance.TotalCost.ToString();
            totalLostLabel.Text = performance.TotalLostProfit.ToString();
            totalScrapLabel.Text = performance.TotalScrapProfit.ToString();
            totalNetLabel.Text = performance.TotalNetProfit.ToString();

            lostDaysLabel.Text = performance.DaysWithMoreDemand.ToString();
            scrapDaysLabel.Text = performance.DaysWithUnsoldPapers.ToString();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
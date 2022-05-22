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
            string testingManager = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
            MessageBox.Show(testingManager);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
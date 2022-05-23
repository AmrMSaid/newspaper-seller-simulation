using System;
using System.Collections.Generic;
using System.IO;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public void BuildSimulationTable()
        {
            Random random = new Random();

            for (int i = 1; i <= NumOfRecords; i++)
            {
                SimulationCase simulationCase = new SimulationCase();

                //Day
                simulationCase.DayNo = i;

                //Random newsday
                simulationCase.RandomNewsDayType = random.Next(1, 101);

                //Newsday
                int randomDay = simulationCase.RandomNewsDayType;

                if (DayTypeDistributions[0].MinRange <= randomDay && randomDay <= DayTypeDistributions[0].MaxRange)
                    simulationCase.NewsDayType = Enums.DayType.Good;
                else if (DayTypeDistributions[1].MinRange <= randomDay && randomDay <= DayTypeDistributions[1].MaxRange)
                    simulationCase.NewsDayType = Enums.DayType.Fair;
                else
                    simulationCase.NewsDayType = Enums.DayType.Poor;

                //Random demand
                simulationCase.RandomDemand = random.Next(1, 101);

                //Demand
                for (int row = 0; row < 7; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        DayTypeDistribution dayTypeDistribution = DemandDistributions[row].DayTypeDistributions[col];
                        if (dayTypeDistribution.DayType == simulationCase.NewsDayType)
                        {
                            if (simulationCase.RandomDemand >= dayTypeDistribution.MinRange && simulationCase.RandomDemand <= dayTypeDistribution.MaxRange)
                            {
                                simulationCase.Demand = DemandDistributions[row].Demand;
                            }
                        }
                    }
                }
                //Revenue from sales
                simulationCase.SalesProfit = Math.Min(NumOfNewspapers, simulationCase.Demand) * SellingPrice;

                //Lost and scrap
                if (NumOfNewspapers == simulationCase.Demand)
                {
                    simulationCase.LostProfit = 0;
                    simulationCase.ScrapProfit = 0;
                }
                else if (NumOfNewspapers > simulationCase.Demand)
                {
                    simulationCase.LostProfit = 0;
                    simulationCase.ScrapProfit = (NumOfNewspapers - simulationCase.Demand) * ScrapPrice;
                    PerformanceMeasures.DaysWithUnsoldPapers++;
                }
                else if (NumOfNewspapers < simulationCase.Demand)
                {
                    simulationCase.LostProfit = (simulationCase.Demand - NumOfNewspapers) * (SellingPrice - PurchasePrice);
                    simulationCase.ScrapProfit = 0;
                    PerformanceMeasures.DaysWithMoreDemand++;
                }
                //Daily profit
                simulationCase.DailyCost = NumOfNewspapers * PurchasePrice;
                simulationCase.DailyNetProfit = simulationCase.SalesProfit - simulationCase.DailyCost - simulationCase.LostProfit + simulationCase.ScrapProfit;

                PerformanceMeasures.TotalSalesProfit += simulationCase.SalesProfit;
                PerformanceMeasures.TotalCost += simulationCase.DailyCost;
                PerformanceMeasures.TotalLostProfit += simulationCase.LostProfit;
                PerformanceMeasures.TotalScrapProfit += simulationCase.ScrapProfit;
                PerformanceMeasures.TotalNetProfit += simulationCase.DailyNetProfit;

                SimulationTable.Add(simulationCase);
            }
        }

        DayTypeDistribution SetDayTypeDistribution(int row, int col, DayTypeDistribution dayTypeDistribution)
        {
            if (row == 0)
                dayTypeDistribution.CummProbability = dayTypeDistribution.Probability;
            else
                dayTypeDistribution.CummProbability = dayTypeDistribution.Probability + DemandDistributions[row - 1].DayTypeDistributions[col - 1].CummProbability;

            if (row == 0)
                dayTypeDistribution.MinRange = 1;
            else
                dayTypeDistribution.MinRange = (int)(DemandDistributions[row - 1].DayTypeDistributions[col - 1].CummProbability * 100 + 1);

            if (dayTypeDistribution.CummProbability == 1)
                dayTypeDistribution.MaxRange = 100;
            else
                dayTypeDistribution.MaxRange = (int)(dayTypeDistribution.CummProbability * 100);

            return dayTypeDistribution;
        }

        public SimulationSystem BuildSimulationSystem()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            FileStream fs = new FileStream(projectPath + "/TestCases/TestCase1.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();
                if (line == "" || line == null)
                {
                    continue;
                }
                else if (line == "NumOfNewspapers")
                {
                    NumOfNewspapers = int.Parse(sr.ReadLine());
                }
                else if (line == "NumOfRecords")
                {
                    NumOfRecords = int.Parse(sr.ReadLine());
                }
                else if (line == "PurchasePrice")
                {
                    PurchasePrice = decimal.Parse(sr.ReadLine());
                }
                else if (line == "ScrapPrice")
                {
                    ScrapPrice = decimal.Parse(sr.ReadLine());
                }
                else if (line == "SellingPrice")
                {
                    SellingPrice = decimal.Parse(sr.ReadLine());
                }
                else if (line == "DayTypeDistributions")
                {
                    line = sr.ReadLine();
                    string[] arr = line.Split(',');

                    for (int i = 0; i < arr.Length; i++)
                    {
                        DayTypeDistribution dayType = new DayTypeDistribution();
                        dayType.Probability = decimal.Parse(arr[i]);

                        if (i == 0)
                            dayType.CummProbability = dayType.Probability;
                        else
                            dayType.CummProbability = dayType.Probability + DayTypeDistributions[i - 1].CummProbability;

                        if (i == 0)
                            dayType.MinRange = 1;
                        else
                            dayType.MinRange = (int)(DayTypeDistributions[i - 1].CummProbability * 100 + 1);

                        if (dayType.CummProbability == 1)
                            dayType.MaxRange = 100;
                        else
                            dayType.MaxRange = (int)(dayType.CummProbability * 100);

                        if (i == 0)
                            dayType.DayType = Enums.DayType.Good;
                        else if (i == 1)
                            dayType.DayType = Enums.DayType.Fair;
                        else
                            dayType.DayType = Enums.DayType.Poor;

                        DayTypeDistributions.Add(dayType);
                    }
                }
                else if (line == "DemandDistributions")
                {
                    for (int row = 0; row < 7; row++)
                    {
                        line = sr.ReadLine();

                        if (line == "" || line == null)
                        {
                            break;
                        }
                        string[] arr = line.Split(',');

                        DemandDistribution demandDistribution = new DemandDistribution();
                        demandDistribution.Demand = int.Parse(arr[0]);

                        DayTypeDistribution good = new DayTypeDistribution();
                        DayTypeDistribution fair = new DayTypeDistribution();
                        DayTypeDistribution poor = new DayTypeDistribution();

                        good.Probability = decimal.Parse(arr[1]);
                        fair.Probability = decimal.Parse(arr[2]);
                        poor.Probability = decimal.Parse(arr[3]);

                        for (int col = 0; col < arr.Length; col++)
                        {
                            if (col == 1)
                            {
                                good.DayType = Enums.DayType.Good;
                                good = SetDayTypeDistribution(row, col, good);
                                demandDistribution.DayTypeDistributions.Add(good);
                            }
                            else if (col == 2)
                            {
                                fair.DayType = Enums.DayType.Fair;
                                fair = SetDayTypeDistribution(row, col, fair);
                                demandDistribution.DayTypeDistributions.Add(fair);
                            }
                            else if (col == 3)
                            {
                                poor.DayType = Enums.DayType.Poor;
                                poor = SetDayTypeDistribution(row, col, poor);
                                demandDistribution.DayTypeDistributions.Add(poor);
                            }
                        }
                        DemandDistributions.Add(demandDistribution);
                    }
                }
            }
            fs.Close();
            return this;
        }
    }
}

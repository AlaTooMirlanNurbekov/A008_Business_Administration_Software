// P000 - CRM REVENUE FORECASTING TOOL (LEAKY FUNNEL MODEL)

using System;

namespace CRMForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            The idea: We want to simulate how leads move through a sales pipeline.
            A business needs to know how much money they will make based on the quality of their leads and the effficiency of their staff
            This tool helps managers see if they need more staff to handle the lead volume before they lose money.
            We use specific conversion rates from our A008 - Part 0002 slides:
            -30% of leads become real opportunities
            -20% of opportunities usually close
            -BUT if we have too many leads (>500), the team gets tired and the close rate drops to 10%
            */

            // Styling the header for a more professional look in the console
            Console.WriteLine("========================================");
            Console.WriteLine("   ALA-TOO CRM: REVENUE PREDICTOR       ");
            Console.WriteLine("========================================");

            //asking the user for the raw data
            Console.Write("Enter number of incoming leads: ");
            int leads = Convert.ToInt32(Console.ReadLine());

            // constants based on business logic
            const double CONVERSION_RATE = 0.30;  // 30% conversion to opportunities
            const double DEAL_VALUE = 2000.0;     // Each deal is worth 2k USD

            // Step 000: calculate opportunities
            // This is the number of people who actually want to buy something
            double opps = leads * CONVERSION_RATE;

            // Step 001:determine the close rate .If we have too many leads, the system "leaks" because we can't reply to everyone fast enough
            double closeRate;

            if (leads > 500)
            {
                closeRate = 0.10;
                Console.WriteLine("\n[SYSTEM ALERT]: High lead volume detected!");
                Console.WriteLine("[WARNING]: Efficiency dropping to 10% due to overload.");
            }
            else
            {
                closeRate = 0.20;
                Console.WriteLine("\n[STATUS]: Sales team operating at normal capacity.");
            }

            // Step 002: final calculations
            double closedDeals = opps * closeRate;
            double revenue = closedDeals * DEAL_VALUE;

            //final output formatting we format the money to look like actual currency
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("PIPELINE ANALYSIS:");
            Console.WriteLine(" > Qualified Opportunities: {0}", (int)opps);
            Console.WriteLine(" > Estimated Closed Deals:  {0}", (int)closedDeals);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("TOTAL FORECASTED REVENUE: ${0:N2}", revenue);
            Console.WriteLine("========================================");
            
            //for keeping the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}


// Made by JetiHub - J000
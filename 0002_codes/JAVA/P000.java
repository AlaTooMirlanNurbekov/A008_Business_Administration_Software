// P000 - CRM REVENUE FORECASTING TOOL (LEAKY FUNNEL MODEL)
import java.util.Scanner;

/*
The idea:
We want to simulate how leads move through a sales pipeline.A business needs to know how much money they will make based on 
the quality of their leads and the efficiency of their staff.This tool helps managers see if they need more staff to handle 
the lead volumne before they lose money

    We use specific conversion rates from our A008 - Part 0002 slides:
    -30% of leads become real opportunities
    -20% of opportunities usually close
    -BUT if we have too many leads (>500), the team gets tired and the close rate drops to 10%
*/

public class P000 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        // Styling the header for a more proffesional look in the console
        System.out.println("========================================");
        System.out.println("   ALA-TOO CRM: REVENUE PREDICTOR       ");
        System.out.println("========================================");

        // Asking the user for the raw data
        System.out.print("Enter number of incoming leads: ");
        int leads = input.nextInt();

        // Constants based on business logic
        double CONVERSION_RATE = 0.30; // 30% conversion to opportunities
        double DEAL_VALUE = 2000.0;    // Each deal is worth 2k USD
        
        // Step 000: Calculate Opportunities
        // This is the number of people who actually want to buy something
        double opps = leads * CONVERSION_RATE;

        // Step 001: determine the close rrate
        // If we have too many leads, the system "leaks" because we 
        // cant reply to everyone fast enough. 
        double closeRate;
        if (leads > 500) {
            closeRate = 0.10;
            System.out.println("\n[SYSTEM ALERT]: High lead volume detected!");
            System.out.println("[WARNING]: Efficiency dropping to 10% due to overload");
        } else {
            closeRate = 0.20;
            System.out.println("\n[STATUS]: Sales team operating at normal capacity");
        }

        // Step 002:final calculations
        double closedDeals = opps * closeRate;
        double revenue = closedDeals * DEAL_VALUE;

        //Final otput formating
        // We use printf to make the money look like actual currency
        System.out.println("----------------------------------------");
        System.out.println("PIPELINE ANALYSIS:");
        System.out.println(" > Qualified Opportunities: " + (int)opps);
        System.out.println(" > Estimated Closed Deals:  " + (int)closedDeals);
        System.out.println("----------------------------------------");
        System.out.printf("TOTAL FORECASTED REVENUE: $%.2f\n", revenue);
        System.out.println("========================================");
        
        input.close(); //good practice to close the scaner
    }
}

// Made by JetiHub - J000
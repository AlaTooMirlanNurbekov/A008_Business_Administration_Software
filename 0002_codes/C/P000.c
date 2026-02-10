// P000 - CRM REVENUE FORECASTING TOOL (LEAKY FUNNEL MODEL)

#include <stdio.h>

/*
The idea: We want to simulate how leads move through a sales pipeline.
A business needs to know how much money they will make based on the quality of their leads and the efficiency of their staff.

This tool helps managers see if they need more staff to handle
the lead volume before they lose money.
We use specific conversion rates from our A008 - Part 0002 slides:
-30% of leads become real opportunities
-20% of opportunities usually close
-BUT if we have too many leads (>500), the team gets tired and the close rate drops to 10%
*/
int main() {

    // Styling the header for a more professional look in the console
    printf("========================================\n");
    printf("   ALA-TOO CRM: REVENUE PREDICTOR       \n");
    printf("========================================\n");

    //asking the user for the raw data
    int leads;
    printf("Enter number of incoming leads: ");
    scanf("%d", &leads);
    // Constants based on business logic
    const double CONVERSION_RATE = 0.30;  // 30% conversion to opportunities
    const double DEAL_VALUE = 2000.0;     // Each deal is worth 2k USD

    // Step 000: Calculate opportunities
    // This is the number of people who actually want to buy something
    double opps = leads * CONVERSION_RATE;

    // Step 001:determine the close rate .If we have too many leads, the system "leaks" because we can't reply to everyone fast enough
    double closeRate;

    if (leads > 500) {
        closeRate = 0.10;
        printf("\n[SYSTEM ALERT]: High lead volume detected!\n");
        printf("[WARNING]: Efficiency dropping to 10%% due to overload.\n");
    } else {
        closeRate = 0.20;
        printf("\n[STATUS]: Sales team operating at normal capacity.\n");
    }

    // Step 002: final calculations
    double closedDeals = opps * closeRate;
    double revenue = closedDeals * DEAL_VALUE;

    //Final output formatting
    // We format the money to look like actual currency
    printf("----------------------------------------\n");
    printf("PIPELINE ANALYSIS:\n");
    printf(" > Qualified Opportunities: %d\n", (int)opps);
    printf(" > Estimated Closed Deals:  %d\n", (int)closedDeals);
    printf("----------------------------------------\n");
    printf("TOTAL FORECASTED REVENUE: $%.2f\n", revenue);
    printf("========================================\n");

    return 0;
}

// Made by JetiHub - J000

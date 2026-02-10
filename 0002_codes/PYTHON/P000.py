# P000 - CRM REVENUE FORECASTING TOOL (LEAKY FUNNEL MODEL)

"""
The idea: We want to simulate how leads move through a sales pipeline.
A business needs to know how much money they will make based on the quality of their leads and the efficiency of their staff
This tool helps managers see if they need more staff to handle
the lead volume before they lose money.

We use specific conversion rates from our A008 - Part 0002 slides:
- 30% of leads become real opportunities
- 20% of opportunities usually close
- BUT if we have too many leads (>500), the team gets tired and the close rate drops to 10%
"""

# Styling the header for a more professional look in the console
print("========================================")
print("   ALA-TOO CRM: REVENUE PREDICTOR       ")
print("========================================")

# Asking the user for the raw data
leads = int(input("Enter number of incoming leads: "))

# Constants based on business logic
CONVERSION_RATE = 0.30   # 30% conversion to opportunities
DEAL_VALUE = 2000.0      # Each deal is worth 2k $

# Step 000:calculate opportunities
# This is the number of people who actually want to buy something
opps = leads * CONVERSION_RATE

# Step 001: determine the close rate
# If we have too many leads, the system "leaks" because we cna not reply to everyone fast enough.
if leads > 500:
    close_rate = 0.10
    print("\n[SYSTEM ALERT]: High lead volume detected!")
    print("[WARNING]: Efficiency dropping to 10% due to overload.")
else:
    close_rate = 0.20
    print("\n[STATUS]: Sales team operating at normal capacity.")

# Step 002: final calculations
closed_deals = opps * close_rate
revenue = closed_deals * DEAL_VALUE

# Final output formatting
# We format the money to look like actual currency
print("----------------------------------------")
print("PIPELINE ANALYSIS:")
print(f" > Qualified Opportunities: {int(opps)}")
print(f" > Estimated Closed Deals:  {int(closed_deals)}")
print("----------------------------------------")
print(f"TOTAL FORECASTED REVENUE: ${revenue:,.2f}")
print("========================================")



# Made by JetiHub - J000

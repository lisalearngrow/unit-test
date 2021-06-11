using System;

class PracticeSolution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget)
    {

        double grantsCap = 0;
        //double previousCap = 0;
        bool foundCap = false;
        double adjustment = 0;

        while (!foundCap)
        {
            // Take # of grants and divide the new budget by that
            grantsCap = (double)newBudget / grantsArray.Length + adjustment;

            double sum = 0;

            // Add together the amount of grants if this was the cap
            for (int i = 0; i < grantsArray.Length; i++)
            {
                var cash = grantsArray[i];
                if (cash > grantsCap)
                    cash = grantsCap;

                sum += cash;
            }

            // If the sum is less than the new budget, then try again
            if ((newBudget - grantsArray.Length) < sum && sum < (newBudget + grantsArray.Length))
            {
                foundCap = true;
            }
            else
            {
                // How off were we?  Let's try to zero in.
                adjustment = (double)(newBudget - sum) / (double)grantsArray.Length;
            }
        }

        return grantsCap;
    }

    static void Main(string[] args)
    {

    }
}


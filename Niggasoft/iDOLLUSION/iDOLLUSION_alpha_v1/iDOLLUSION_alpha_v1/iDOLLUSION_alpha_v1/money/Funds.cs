using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1
	{
    static class Funds // the money the company has, not your personal wages
	{
	        private static int peronsalFunds = 0; //starting funds
            private static int companyFunds = 0;
	        public static void setFunds(int val, string accType) 
            {
                switch (accType)
                {
                    case "personal":
                        peronsalFunds = val;
                        break;

                    case "company":
                        companyFunds = val;
                        break;
                }
	        }
	
	        public static int getFunds(string accType) 
            {
                switch (accType)
                {
                    case "personal":
                        return peronsalFunds;

                    case "company":
                        return companyFunds;
                }
                return 1000000000;
	        }

            public static void addFunds(int val, string accType) 
            {
                switch (accType)
                {
                    case "personal":
                        peronsalFunds += val;
                        break;

                    case "company":
                        companyFunds += val;
                        break;
                }
	        }
        }
            public static string fundsToString(string accType)
            {
                switch(accType)
                    case "personal":
                        string funds = personalFunds.ToString();
                        break;
                    case "company":
                        string funds = companyFunds.ToString()
                        break;

                int length = funds.Length; 

                for(int i = 1, length/3>i, i++)
                {
                    funds.Insert(i*3+(i-1),",");
                }
                return funds;  

		}
	}

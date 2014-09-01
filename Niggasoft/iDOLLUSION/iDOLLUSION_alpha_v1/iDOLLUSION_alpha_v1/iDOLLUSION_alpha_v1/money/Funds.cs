using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1
	{
	static class Funds // the money the company has, not your personal wages
	{
			private static int personalFunds = 0; //starting funds
			private static int companyFunds = 0;
	    private static int error = -1;
			public static void setFunds(int val, string accType) 
			{
				switch (accType)
				{
					case "personal":
						personalFunds = val;
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
						return personalFunds;

					case "company":
						return companyFunds;
				}
				return error;
			}

			public static void addFunds(int val, string accType) 
			{
				switch (accType)
				{
					case "personal":
						personalFunds += val;
						break;

					case "company":
						companyFunds += val;
						break;
				}
			}

			public static string fundsToString(string accType)
			{
				string funds = null;
				switch(accType)
				{
					case "personal":
						funds = personalFunds.ToString();
						break;
					case "company":
						funds = companyFunds.ToString();
						break;
				}
				int length = funds.Length;

				for (int i = 1; length / 3 > i; i++)
				{
					funds.Insert(i * 3 + (i - 1), ",");
				}
				return funds;  

		}

		}
	}

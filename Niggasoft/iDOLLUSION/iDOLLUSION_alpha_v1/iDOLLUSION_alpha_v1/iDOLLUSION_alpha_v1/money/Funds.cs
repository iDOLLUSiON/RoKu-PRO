using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1
	{
   static class Funds // the money the company has, not your personal wages
		{
	private static long funds = 0; //starting funds
	
	public static void setFunds(long val) {
		funds = val;
	}
	
	public static long getFunds() {
		return funds;
	}
	
	public static void addFunds( int addFunds ) {
		funds += addFunds;
	}

		}
	}

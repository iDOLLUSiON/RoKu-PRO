using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1
	{
	static class Cash
		{

	private static long cash = 0; //starting value
	
	public static void setCash(long val) {
		cash = val;
	}
	
	public static long getCash() {
		return cash;
	}
	
	public static void addCash( int addcash ) {
		cash += addcash;
	}
		}
	}

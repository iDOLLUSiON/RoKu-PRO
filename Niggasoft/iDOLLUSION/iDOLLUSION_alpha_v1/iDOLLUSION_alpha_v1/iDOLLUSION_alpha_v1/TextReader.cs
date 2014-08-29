using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


public class TextReader
{
	public static void readText()
	{
//	    Content.RootDirectory = "Content";

		string path = @"C:\Users\CJ\Desktop\test.xml"; //..\..\Data\thenwhowasphone.txt
		using (StreamReader sr = File.OpenText(path))
		{
			string s = "";
			while ((s = sr.ReadLine()) != null)
			{
				Console.WriteLine(s);
			}
		}
	}
}

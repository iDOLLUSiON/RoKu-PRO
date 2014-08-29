using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;


public class TextReader
{
	public void readText()
	{
//	    Content.RootDirectory = "Content";

		string path = "data\test.txt"; //..\..\Data\thenwhowasphone.txt
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

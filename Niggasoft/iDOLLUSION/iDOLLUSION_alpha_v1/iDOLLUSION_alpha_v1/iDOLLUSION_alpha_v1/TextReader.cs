using System;
using System.Text;
using System.IO;
public class TextReader
{
	public void readText()
	{
        string path = @"C:\Users\Andrew\Downloads\idollusion\RoKu-PRO\Niggasoft\iDOLLUSION\iDOLLUSION_alpha_v1\iDOLLUSION_alpha_v1\Data\thenwhowasphone.txt"; //..\..\Data\thenwhowasphone.txt
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

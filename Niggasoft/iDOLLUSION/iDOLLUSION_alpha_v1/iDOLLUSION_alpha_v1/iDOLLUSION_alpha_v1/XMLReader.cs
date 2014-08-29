using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Xml;


public class XMLReader
{
    public static void readText()
    {
        string path = @"C:\Users\CJ\Desktop\test.xml";
        XmlDocument dialogue = new XmlDocument();
        dialogue.Load(path);
        XmlNodeList nodelist = dialogue.SelectNodes("/Greeting"); // get all <testcase> nodes

        foreach (XmlNode node in nodelist) // for each <testcase> node
        {
            try
            {
                string name = node.SelectSingleNode("ToProducer").InnerText;
                 Console.WriteLine(name);

            }
            catch (Exception e)
            {
                
            }

        }

    }
}
using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Xml;


public class XMLReader
{
      static  string path = @"C:\Users\CJ\Desktop\test.xml";
        static XmlDocument dialogue = new XmlDocument();
    public static void readText()
    {
        dialogue.Load(path);
        XmlNodeList nodelist = dialogue.SelectNodes("/Greeting"); 

        foreach (XmlNode node in nodelist) 
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
    public static void readText(string message)
    {
        dialogue.Load(path);
        XmlNodeList nodelist = dialogue.SelectNodes("/Greeting"); 

        foreach (XmlNode node in nodelist) 
        {
            try
            {
                string targetNode = "/" + message;
                string name2 = node.SelectSingleNode(targetNode).InnerText;
                 Console.WriteLine(name2);
                 Console.WriteLine(targetNode);


            }
            catch (Exception e)
            {
                
            }

        }

    }
}
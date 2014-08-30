using System;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Xml;


public class XMLReader
{
    static string path = (Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\test.xml");  //The file to be read from
        static XmlDocument dialogue = new XmlDocument(); //name of the file from here on out

    public static void readText() //This is not useful except for testing and will always return the same result  
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


    public static void readText(string message)   //This will return the text contained within the node indicated by message.  message must be a valid node name or an exception occurs
    {
        dialogue.Load(path);
        XmlNodeList nodelist = dialogue.SelectNodes("/Greeting"); 

        foreach (XmlNode node in nodelist) 
        {
            try
            {
               
               string name2 = node.SelectSingleNode(message).InnerText;
                Console.WriteLine(name2);
                 Console.WriteLine(message);


            }
            catch (Exception e)  //catch exception when message is not a valid node
            {
                
            }

        }

    }

    public static string retrieveMessage(string message) //I think this is just an improved version of readText.  readText(message) may be redundant, check in future
    {
        dialogue.Load(path);
        XmlNodeList nodelist = dialogue.SelectNodes("/Greeting");

        foreach (XmlNode node in nodelist)
        {
            try
            {

                string dialogueMessage = node.SelectSingleNode(message).InnerText;
                Console.WriteLine(message);
                Console.WriteLine(dialogueMessage);
                return dialogueMessage;

            }
            catch (Exception e)
            {
                return "something broke";
            }

        }
        return "something broke";
    }
}
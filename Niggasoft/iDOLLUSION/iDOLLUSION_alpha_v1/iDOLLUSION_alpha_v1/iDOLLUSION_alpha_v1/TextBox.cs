using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
{
    class TextBox
        {
//fields
         string speakerName; //Name of the character talking
         string message; //Message contained in text box
         Vector2 position = new Vector2(640, 600);
         Vector2 size = new Vector2(800, 300);
        public Boolean textBoxIsVisible = false;
        
//methods
        public void setSpeaker(string speaker)
        {
            speakerName = speaker;
            return;
        }

        public void setMessage(string setMessage)
        {
            message = setMessage;
            return;
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
            return;
        }
        public void setSize(Vector2 newSize)
        {
            size = newSize;
            return;
        }

        public void clearMessage()
        {
            message = null;
            return;
        }

        public bool isEmpty()
        {
            return (message == null);
        }

        public Vector2 getPosition()
        {
            return (position);
        }

        public Vector2 getSize()
        {
            return (size);
        }

        public bool textBoxVisible()
        {
            return (textBoxIsVisible);
        }

        public void upDate()
        {
            if (message == null)
            {
                textBoxIsVisible = false;
            }
            else
            {
                textBoxIsVisible = true;
            }
            return;
        }

//CONSTRUCTORS
        public TextBox()//for standard large box on bottom
        {
            
        }


        public TextBox(Vector2 position )  //probably useless
        {
            setPosition(position);
        }

        public TextBox(Vector2 position, Vector2 size) //use for non bottom-centered ones
        {
            setPosition(position);
            setSize(size);
        }
        public TextBox(Vector2 position, Vector2 size,string speaker, string message)  //use for popup
        {
            setPosition(position);
            setSize(size);
            setMessage(message);
            setSpeaker(speaker);
        }
    

        }
    }

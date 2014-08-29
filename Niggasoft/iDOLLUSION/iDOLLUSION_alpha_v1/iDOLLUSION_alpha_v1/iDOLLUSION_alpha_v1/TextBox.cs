using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace iDOLLUSION_alpha_v1
{
    class TextBox
        {
//fields
         string speakerName ;
         string message;
         Vector2 position = new Vector2(1, 1);
        public Boolean textBoxIsVisible = false;
        
//methods
        public void setSpeaker(string speaker)
        {
            speakerName = speaker;
        }

        public void setMessage(string setMessage)
        {
            message = setMessage;
        }

        public void clearMessage()
        {
            message = null;
        }

        public bool isEmpty()
        {
            return (message == null);
        }

        public Vector2 getPosition()
        {
            return (position);
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
        }



    

        }
    }

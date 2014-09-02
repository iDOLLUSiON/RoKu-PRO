using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using iDOLLUSION_alpha_v1.characters;

namespace iDOLLUSION_alpha_v1.scenes.email
  {
    class Messages
    {
        public static List<Messages> unassignedMessages = new List<Messages>(); 
        public string Sender;
        public MainCharacter Recipient;
        public string text;
        public Boolean isUnread = true;


        public void upDate()
        {
            foreach (Messages message in unassignedMessages)
            {
                foreach (Inbox inbox in Inbox.Inboxes)
                {
                    if (message.Recipient == inbox.Owner)
                    {
                        inbox.inboxMessages.Add(message);
                        unassignedMessages.Remove(message);
                    }
                }

            }
        }



    }
  }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iDOLLUSION_alpha_v1.characters;
using iDOLLUSION_alpha_v1.scenes.email;

namespace iDOLLUSION_alpha_v1.scenes
    {
    class Inbox
    {
        public MainCharacter Owner;

        public static  List<Inbox> Inboxes = new List<Inbox>();
        public List<Messages> inboxMessages = new List<Messages>();



    Inbox(Idol owner)
        {
            Owner = owner;
        }


    }
    }

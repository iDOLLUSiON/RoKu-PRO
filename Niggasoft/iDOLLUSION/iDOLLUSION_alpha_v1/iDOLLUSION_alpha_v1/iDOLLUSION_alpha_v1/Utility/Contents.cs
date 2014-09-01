using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iDOLLUSION_alpha_v1.Utility
    {
    class Contents
    {
        private enum Directory
        {
            Characters,
            MainMap,
            Schedule,
            Sprites,
            Sounds,
            fonts,
            data,

        }
        
        private string directory; //directory its located int

        private enum Type //types of content
        {
            Texture,
            Song,
            SoundEffect
        }


        public Contents()
        {
            
        }



    }
    }

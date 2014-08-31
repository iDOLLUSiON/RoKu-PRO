using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;


namespace iDOLLUSION_alpha_v1
    {
    class Music
        {


        public void play(SoundEffect soundEffect)
        {
            if (soundEffect.IsDisposed)
            {
                //insert code for loading soundEffect
                return;
            }
            soundEffect.Play();
            return;
        }


        public void play(Song song)
        {
            if (song.IsDisposed)
            {
                //insert code for loading song
                return;
            }
            MediaPlayer.Play(song);
            return;
        }

        public void stop(SoundEffect soundEffect)
        {
            if (!soundEffect.IsDisposed)
            {
                soundEffect.Dispose();
            }
            return;
        }

        public void stop(Song song)
        {
            if (!song.IsDisposed)
            {
                song.Dispose();
            }
            return;
        }

        }
    }

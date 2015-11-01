using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace CuocChienVuTru.BUS
{
    public class CBusiSoundManager
    {
        public SoundEffect explosion;
        public SoundEffect shot;
        public SoundEffect gameOver;
        public SoundEffect start;
        public SoundEffect pause;
        public SoundEffect hover;
        public SoundEffect clicked;
        public Song background;

        public void loadContent(ContentManager Content)
        {
            explosion = Content.Load<SoundEffect>("Sound/explode");
            shot = Content.Load<SoundEffect>("Sound/shoot");
            background = Content.Load<Song>("Sound/background1");
            hover = Content.Load<SoundEffect>("Sound/hover");
            clicked = Content.Load<SoundEffect>("Sound/clicked");
        }
    }
}


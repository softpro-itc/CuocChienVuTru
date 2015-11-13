using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.Global
{
    public class CGlobalDictionary
    {
        public Dictionary<string, SoundEffect> ListSoundEffect = new Dictionary<string, SoundEffect>();
        public Dictionary<string, Song> ListSoundBG = new Dictionary<string, Song>();

        public CGlobalDictionary(Game1 game)
        {
            ListSoundEffect.Add("clicked", game.Content.Load<SoundEffect>("Sound/clicked"));
            ListSoundEffect.Add("explode", game.Content.Load<SoundEffect>("Sound/explode"));
            ListSoundEffect.Add("hover", game.Content.Load<SoundEffect>("Sound/hover"));
            ListSoundEffect.Add("shoot", game.Content.Load<SoundEffect>("Sound/shoot"));
            ListSoundBG.Add("bg1", game.Content.Load<Song>("Sound/background1"));
        }

    }
}

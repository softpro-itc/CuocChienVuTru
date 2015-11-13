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
            ListSoundEffect.Add("clicked", game.Content.Load<SoundEffect>("Sound/Effect/clicked"));
            ListSoundEffect.Add("explode", game.Content.Load<SoundEffect>("Sound/Effect/explode"));
            ListSoundEffect.Add("hover", game.Content.Load<SoundEffect>("Sound/Effect/hover"));
            ListSoundEffect.Add("shoot", game.Content.Load<SoundEffect>("Sound/Effect/shoot"));
            ListSoundEffect.Add("item", game.Content.Load<SoundEffect>("Sound/Effect/item_1"));
            ListSoundEffect.Add("player_die", game.Content.Load<SoundEffect>("Sound/Effect/player_die"));
        }

    }
}

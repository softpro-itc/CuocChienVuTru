using CuocChienVuTru.BUS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.GUI
{
    public class CGuiLevel1 : CBusiLevelBase
    {
        public CGuiLevel1()
        {
            player = new CBusiPlayer(game, game.Content.Load<Texture2D>("Images/Player/player_3"), new Vector2(200, 400), 5, 2, 5, 100);
        }


    }
}

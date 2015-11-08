using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CuocChienVuTru.GUI
{
    class CGuiLevel2 : CBusiLevelBase
    {
        public CGuiLevel2(Game1 game)
            : base(game)
        {
            listButton.Add(new CBusiButton(game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50)));
            player = new CBusiPlayer(game, "player_2", new Vector2(400, 400), 5, 2, 5, 100);
            background = new CBusiBackground(game, "bg_level2_1", "bg_level2_2", 2);
            background.MaxItem = 10;
            pointDestination = 10;
        }
    }
}

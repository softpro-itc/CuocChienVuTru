using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.GUI
{
    class CGuiLevel2 : CBusiLevelBase
    {
        public CGuiLevel2(CInfoLevelBase dto)
            : base(dto)
        {
            Dto.ListButton.Add(new CBusiButton(new CInfoButton(dto.Game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50))));
            Dto.Player = new CBusiPlayer(new CInfoPlayer(dto.Game, "player_2", new Vector2(400, 400), 5, 2, 5, 100));
            Dto.Background = new CBusiBackground(new CInfoBackground(dto.Game, "bg_level2_1", "bg_level2_2", 2));
            Dto.PointDestination = 10;
        }
    }
}

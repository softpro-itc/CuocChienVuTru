using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DTO;
using Microsoft.Xna.Framework.Media;

namespace CuocChienVuTru.GUI
{
    public class CGuiLevel1 : CBusiLevelBase
    {
        public CGuiLevel1(CInfoLevelBase info) : base(info)
        {
            dto = info;
            dto.ListButton.Add(new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50))));
            dto.Player = new CBusiPlayer(new CInfoPlayer(info.Game, "player_1", new Vector2(400, 400), 5, 2, 5, 1));
            dto.Background = new CBusiBackground(new CInfoBackground(info.Game, "bg_level1_1", "bg_level1_2", 2));
            dto.PointDestination = 1;
            dto.Boss = new CBusiBoss(new CInfoBoss(info.Game, "boss_1", new Vector2(400, 0), 5, 100, 100));
            MediaPlayer.Play(dto.Game.Content.Load<Song>("Sound/Background/1"));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
        }
    }
}

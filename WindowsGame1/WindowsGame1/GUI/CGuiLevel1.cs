using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.GUI
{
    public class CGuiLevel1 : CBusiLevelBase
    {
        public CGuiLevel1(CInfoLevelBase info) : base(info)
        {
            dto = info;
            dto.ListButton.Add(new CBusiButton(new CInfoButton(info.Game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50))));
            dto.Player = new CBusiPlayer(new CInfoPlayer(info.Game, "player_1", new Vector2(400, 400), 5, 2, 5, 100));
            dto.Background = new CBusiBackground(new CInfoBackground(info.Game, "bg_level1_1", "bg_level1_2", 2));
            dto.PointDestination = 1;
            dto.Boss = new CBusiBoss(new CInfoBoss(info.Game, "boss_1", new Vector2(400, 0), 5, 100, 100));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Dto.Player.Dto.Score >= Dto.PointDestination)
            {
                //Dto.Boss.Position = new Vector2(dto.Player.PosCenter.X, 0);
                Dto.Boss.Dto.Visible = true;
                Dto.Boss.Update(gameTime);
                //game.gameSceneManager.ShowGameScene(new CGuiLevel2(game));
            }
        }
    }
}

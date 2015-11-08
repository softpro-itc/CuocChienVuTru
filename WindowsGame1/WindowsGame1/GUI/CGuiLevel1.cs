using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
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
        public CGuiLevel1(Game1 game) : base(game)
        {
            listButton.Add(new CBusiButton(game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50)));
            player = new CBusiPlayer(game, "player_1", new Vector2(400, 400), 5, 2, 5, 100);
            background = new CBusiBackground(game, "bg_level1_1", "bg_level1_2", 2);
            background.MaxItem = 10;
            pointDestination = 1;
            boss = new CBusiBoss(game, "boss_1", new Vector2(400, 0), 5, 100, 100);
            boss.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (player.Score >= pointDestination)
            {
                //boss.Position = new Vector2(player.PosCenter.X, 0);
                boss.Visible = true;
                boss.Update(gameTime);
                //game.gameSceneManager.ShowGameScene(new CGuiLevel2(game));
            }
        }
    }
}

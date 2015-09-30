using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace CuocChienVuTru.Scene
{
    public class HelpScene : GameScene
    {
        public HelpScene(CuocChienVuTru game, Texture2D background) : base(game, background)
        {

        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Escape))
                game.sceneManager.ShowScene(game.sceneManager.start);
            base.Update(gameTime);
        }
    }
}

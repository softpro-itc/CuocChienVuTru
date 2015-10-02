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
    public
        class PauseScene : GameScene
    {

        public GUI.Button _continue;
        public GUI.Button _menu;
        public CuocChienVuTru game;

        public PauseScene(CuocChienVuTru game, Texture2D background)
            : base(game, background)
        {
            this.game = game;
            listButton = new List<GUI.Button>();

            _continue = new GUI.Button(game, "Continue", new Vector2(350, 170), GUI.Button.Status.active);
            _menu = new GUI.Button(game, "Menu", new Vector2(350, 230), GUI.Button.Status.wait);

            listButton.Add(_continue);
            listButton.Add(_menu);

            menu = new GUI.Menu(game, listButton);
            components.Add(menu);
        }

        public override void Update(GameTime gameTime)
        {
            if (menu.curentIndex == 0 && input.Release(Keys.Enter))
                game.sceneManager.ShowScene(game.sceneManager.level1Scene);

            if (menu.curentIndex == 1 && input.Release(Keys.Enter))
            {
                game.sceneManager.ShowScene(game.sceneManager.start);
            }

            base.Update(gameTime);
        }

    }
}

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
        class StartScene  : GameScene
    {

        public GUI.Button _continue;
        public GUI.Button _new;
        public GUI.Button _option;
        public GUI.Button _help;
        public GUI.Button _exit;
        public CuocChienVuTru game;

        public StartScene(CuocChienVuTru game, Texture2D background)
            : base(game, background)
        {
            this.game = game;
            listButton = new List<GUI.Button>();

            _continue = new GUI.Button(game, "Continue", new Vector2(405, 207), GUI.Button.Status.active);
            _new = new GUI.Button(game, "New Game", new Vector2(400, 280), GUI.Button.Status.wait);
            _option = new GUI.Button(game, "Options", new Vector2(430, 340), GUI.Button.Status.wait);
            _help = new GUI.Button(game, "Help", new Vector2(440, 410), GUI.Button.Status.wait);
            _exit = new GUI.Button(game, "Quit", new Vector2(440, 480), GUI.Button.Status.wait);

            listButton.Add(_continue);
            listButton.Add(_new);
            listButton.Add(_option);
            listButton.Add(_help);
            listButton.Add(_exit);

            menu = new GUI.Menu(game, listButton);
            components.Add(menu);
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            //if (menu.curentIndex == 0 && keyboard.IsKeyDown(Keys.Enter))

            if (menu.curentIndex == 3 && keyboard.IsKeyDown(Keys.Enter))
            {
               game.sceneManager.ShowScene(game.sceneManager.help);
            }

            if (menu.curentIndex == 4 && keyboard.IsKeyDown(Keys.Enter))
                game.Exit();
            base.Update(gameTime);
        }

    }
}

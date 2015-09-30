using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CuocChienVuTru.GUI
{
    public class Menu : DrawableGameComponent
    {
        public List<Button> listButton;
        public int curentIndex = 0;

        KeyboardState keyboard;

        int delay = 50;
        int timeTmp = 0;
        bool keyPress = false;

        public Menu(CuocChienVuTru game, List<Button> listButton)
            : base(game)
        {
            this.listButton = listButton;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            listButton[curentIndex].status = Button.Status.active;
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            if (keyboard.GetPressedKeys().Length > 0)
                keyPress = true;
            if (keyPress) timeTmp += gameTime.ElapsedGameTime.Milliseconds;
            if (timeTmp >= delay)
            {
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    listButton[curentIndex].status = Button.Status.wait;
                    curentIndex = (curentIndex - 1 < 0) ? listButton.Count - 1 : curentIndex - 1;
                    listButton[curentIndex].status = Button.Status.active;
                }
                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    listButton[curentIndex].status = Button.Status.wait;
                    curentIndex = (curentIndex + 1 == listButton.Count) ? 0 : curentIndex + 1;
                    listButton[curentIndex].status = Button.Status.active;
                }
                timeTmp = 0;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (listButton.Count > 0)
            {
                foreach (GUI.Button b in listButton)
                    b.Draw(gameTime);
            }
            base.Draw(gameTime);
        }
    }
}

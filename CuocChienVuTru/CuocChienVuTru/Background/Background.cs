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


namespace CuocChienVuTru.Background
{

    public class Background : DrawableGameComponent
    {

        Texture2D background1;
        Vector2 position1;
        Texture2D background2;
        Vector2 position2;

        SpriteBatch spriteBatch;

        public Background(CuocChienVuTru game)
            : base(game)
        {
            background1 = game.Content.Load<Texture2D>(@"Images\background\1");
            position1 = Vector2.Zero;

            background2 = game.Content.Load<Texture2D>(@"Images\background\1");
            position2 = new Vector2(0, -300);

            spriteBatch = game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
        }


        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            position1.Y++;
            if (position1.Y >= 300)
                position1.Y = -300;

            position2.Y++;
            if (position2.Y >= 300)
                position2.Y = -300;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background1, position1, Color.White);
            spriteBatch.Draw(background2, position2, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

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
    public class Button : DrawableGameComponent
    {
        public string label;
        public Vector2 position;
        public Texture2D backgroundItem;
        public SpriteBatch spriteBatch;
        public SpriteFont font;

        public enum Status
        {
            active, wait
        }

        public Status status;

        public Button(CuocChienVuTru game, string label, Vector2 position, Status status)
            : base(game)
        {
            this.label = label;
            this.position = position;
            this.status = status;
            spriteBatch = (SpriteBatch)game.Services.GetService(typeof(SpriteBatch));
            font = game.Content.Load<SpriteFont>(@"font\SpriteFontMenu");
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, label, position, (status == Status.active) ? Color.Red : Color.Blue);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CuocChienVuTru.BUS
{
    public class CBusiItem : CBusiGameObject
    {
        CBusiAnimation animation;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="skin"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="damage"></param>
        public CBusiItem(Game1 game, Texture2D skin, Vector2 position, int speed, int damage)
            : base(game, skin, position, speed, damage)
        {
            animation = new CBusiAnimation(skin, position, 50, 50, 5, -1);
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += speed;
            bound.Y = (int)position.Y;

            animation.Update(gameTime);
            animation.Position = position;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(skin, bound, Color.White);
            animation.Draw(spriteBatch);
        }
    }
}

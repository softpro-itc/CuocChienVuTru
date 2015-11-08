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
        bool isAnimation = true;

        public bool IsAnimation
        {
            get { return isAnimation; }
            set { isAnimation = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="skin"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="damage"></param>
        public CBusiItem(Game1 game, string skinName, Vector2 position, int speed, int damage)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Item/";
            animation = new CBusiAnimation(game, FolderSkin + skinName, position, 80, 50, 50, 5, -1);
            LoadContent(skinName);
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += speed;
            bound.Y = (int)position.Y;

            if (isAnimation)
            {
                animation.Update(gameTime);
                animation.Position = position;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(!isAnimation)
                spriteBatch.Draw(skin, bound, Color.White);
            else
                animation.Draw(spriteBatch);
        }
    }
}

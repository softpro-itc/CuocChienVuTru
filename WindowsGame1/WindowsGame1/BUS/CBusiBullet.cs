using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CuocChienVuTru.BUS
{
    public class CBusiBullet : CBusiGameObject
    {
        public enum Owner
        {
            enemy,
            player
        };

        Owner owner;

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="game">đối tượng game chính</param>
        /// <param name="skin">skin</param>
        /// <param name="position">vị trí</param>
        /// <param name="speed">tốc độ di chuyển</param>
        /// <param name="damage">mức sát thương</param>
        /// <param name="owner">sở hữu(enemy, player)</param>
        public CBusiBullet(Game1 game, string skinName, Vector2 position, int speed, int damage, Owner owner)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Bullet/";
            LoadContent(skinName);
            this.owner = owner;
        }
        public override void Update(GameTime gameTime)
        {
            if (this.owner == Owner.enemy)
                position.Y += speed;
            else
                position.Y -= speed;

            bound.Y = (int)position.Y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skin, bound, Color.White);
        }

    }
}

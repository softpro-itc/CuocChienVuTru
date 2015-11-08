using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.BUS
{
    public class CBusiBoss : CBusiEnemy
    {
        CBusiAnimation animation;
        bool isMoveLeft = true;
        public CBusiBoss(Game1 game, string skinName, Vector2 position, int speed, int damage, int hp)
            : base(game, skinName, position, speed, damage)
        {
            animation = new CBusiAnimation(game, FolderSkin + skinName, position, 1000, 311, 320, 3, 1, true);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            animation.Update(gameTime);
            animation.Position = position;
            if (position.X <= 0)
                isMoveLeft = false;
            if(position.X >= 800)
                isMoveLeft = true;

            if (isMoveLeft)
                MoveLeft();
            else
                MoveRight();
        }

        public override void Move()
        {
            //position.X -= 2;
        }

        private void MoveLeft()
        {
            animation.CurrentFrame = 0;
            position.X -= 2f;
        }

        private void MoveRight()
        {
            animation.CurrentFrame = 2;
            position.X += 2f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (CBusiBullet b in listBullet)
                b.Draw(spriteBatch);
            animation.Draw(spriteBatch);
        }

    }
}

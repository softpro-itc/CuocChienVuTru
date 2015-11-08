using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.CGlobal;

namespace CuocChienVuTru.BUS
{
    public class CBusiEnemy : CBusiGameObjectAI
    {
        #region khai báo biến
        private int maxBullet = 3;
        #endregion


        #region constructor
        public CBusiEnemy(Game1 game, string skinName, Vector2 position, int speed, int damage)
            : base(game, skinName, position, speed, damage)
        {
            FolderSkin = "Images/Enemy/";
            LoadContent(skinName);
        }

        public CBusiEnemy(Game1 game, string skinName, Vector2 position, int speed, int damage, int hp)
            : base(game, skinName, position, speed, damage)
        {
            this.hp = hp;
            FolderSkin = "Images/Enemy/";
            LoadContent(skinName);
        }
        #endregion

        #region khai báo phương thức
        public override void Update(GameTime gameTime)
        {
            timerAddBullet += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);

            bound.Y = (int)position.Y;
            bound.X = (int)position.X;
        }

        public virtual void Move()
        {
            //if(cglobal.random.Next(0,1) == 1)
            //    position.X += speed;
            //else
            //    position.X -= speed;
            position.Y += speed;
        }

        public void Shot()
        {
            if (timerAddBullet >= IntevalAddBullet && listBullet.Count <= maxBullet)
            {
                timerAddBullet -= IntevalAddBullet;
                CBusiBullet b = new CBusiBullet(game, "bullet_2", new Vector2(position.X + 15, position.Y + 10), 2, 1, CBusiBullet.Owner.enemy);
                listBullet.Add(b);
            }
        }

        public void BulletManagement(GameTime gameTime)
        {
            //cập nhật đạn
            for (int i = 0; i < listBullet.Count; i++)
            {
                if (listBullet[i].Position.Y >= CGlobalVariable.WINDOW_HEIGHT)
                {
                    listBullet.RemoveAt(i);
                    i--;
                }
                else
                    listBullet[i].Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (CBusiBullet b in listBullet)
                b.Draw(spriteBatch);
            spriteBatch.Draw(skin, bound, Color.White);
        }

        #endregion
    }
}

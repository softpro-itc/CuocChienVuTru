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
    public class CBusiEnemy : CBusiGameObject
    {
        #region khai báo biến
        private int score;
        private List<CBusiBullet> listBullet = new List<CBusiBullet>();
        private CGloabalFunction input = new CGloabalFunction();
        private int timer = 0;
        private int inteval = 2000;
        private int maxBullet = 3;

        #endregion

        #region khai báo propeties
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public List<CBusiBullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }
        #endregion

        #region constructor
        public CBusiEnemy(Game1 game, Texture2D skin, Vector2 position, int speed, int damage)
            : base(game ,skin, position, speed, damage)
        {
        }

        public CBusiEnemy(Game1 game,Texture2D skin, Vector2 position, int speed, int damage, int hp)
            : base(game ,skin, position, speed, damage)
        {
            this.hp = hp;
        }
        #endregion

        #region khai báo phương thức
        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);

            bound.Y = (int)position.Y;
            //bound.X = (int)position.X;
        }

        private void Move()
        {
            //if(cglobal.random.Next(0,1) == 1)
            //    position.X += speed;
            //else
            //    position.X -= speed;
            position.Y += speed;
        }

        public void Shot()
        {
            if (timer >= inteval && listBullet.Count <= maxBullet)
            {
                timer -= inteval;
                Texture2D t = cglobal.Content.Load<Texture2D>(@"Images\Bullet\bullet_2");
                CBusiBullet b = new CBusiBullet(game, t, new Vector2(position.X + 15, position.Y + 10), 2, 1, CBusiBullet.Owner.enemy );
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

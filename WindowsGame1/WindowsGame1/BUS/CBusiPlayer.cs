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
    public class CBusiPlayer : CBusiGameObject
    {
        #region khai báo biến
        private int score;
        private int life;
        private List<CBusiBullet> listBullet =  new List<CBusiBullet>();
        private CGloabalFunction input = new CGloabalFunction();
        private int timer = 0;
        private int inteval = 100;
        private Texture2D skinHealthBar;
        private CBusiAnimation animation;

        public CBusiAnimation Animation
        {
            get { return animation; }
            set { animation = value; }
        }
        private Vector2 posCenter;

        public Vector2 PosCenter
        {
            get { return new Vector2(position.X - animation.Rectangle.Width/2, position.Y - animation.Rectangle.Height/2); }
            set { posCenter = value; }
        }
            
        #endregion

        #region khai báo propeties
        public int Life
        {
            get { return life; }
            set { if(value >=0) life = value; }
        }

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
        public CBusiPlayer(Game1 game, Texture2D skin, Vector2 position, int speed, int damage)
            : base(game, skin, position, speed, damage)
        {
            life = 5;
            score = 0;
            hp = 100;
            skinHealthBar = cglobal.Content.Load<Texture2D>("Images/Button/HealthBar");
            animation = new CBusiAnimation(skin, position, 64, 64, 3, 1, true);
            
        }

        public CBusiPlayer(Game1 game, Texture2D skin, Vector2 position, int speed, int damage, int life, int hp)
            : base(game, skin, position, speed, damage)
        {
            score = 0;
            this.life = life;
            this.hp = hp;
            skinHealthBar = cglobal.Content.Load<Texture2D>("Images/Button/HealthBar");
            animation = new CBusiAnimation(skin, position, 64, 64, 3, 1, true);
        }

        public CBusiPlayer(Game1 game, Texture2D skin, Vector2 position, int speed, int damage, int life, int hp, int score)
            : base(game, skin, position, speed, damage)
        {
            this.score = score;
            this.life = life;
            this.hp = hp;
            animation = new CBusiAnimation(skin, position, 64, 64, 3, 1, true);
        }
        #endregion

        #region khai báo phương thức
        public override void Update(GameTime gameTime)
        {
            bound.Width = animation.Rectangle.Width;

            input.Update();
            timer += gameTime.ElapsedGameTime.Milliseconds;

            //di chuyển
            Move();
            //bắn đạn
            Shot();
            //quản lý đạn
            BulletManagement(gameTime);

            bound.X = (int)position.X;
            bound.Y = (int)position.Y;
                                
            animation.Update(gameTime);
            animation.Position = position;
        }

        /// <summary>
        /// phương thức di chuyển nhân vật
        /// </summary>
        private void Move()
        {
            if (input.KeyboardPress(Keys.Up) && position.Y > 0)
                position.Y -= speed;
            if (input.KeyboardPress(Keys.Down) && position.Y < CGlobalVariable.WINDOW_HEIGHT - skin.Height)
                position.Y += speed;
            if (input.KeyboardPress(Keys.Left) && position.X > 0)
                position.X -= speed;
            if (input.KeyboardPress(Keys.Right) && position.X < CGlobalVariable.WINDOW_WIDTH - skin.Width / 2)
                position.X += speed;
        }

        /// <summary>
        /// phương thức bắn đạn
        /// </summary>
        public void Shot()
        {
            if (input.KeyboardPress(Keys.Space))
            {
                if (timer >= inteval)
                {
                    timer -= inteval;
                    Texture2D t = cglobal.Content.Load<Texture2D>(@"Images\Bullet\bullet_1");
                    CBusiBullet b = new CBusiBullet(game, t, new Vector2(position.X-animation.Rectangle.Width+skin.Width/2, position.Y), 10, 3, CBusiBullet.Owner.player);
                    listBullet.Add(b);
                    cglobal.sound.shot.Play();
                }
            }
        }

        /// <summary>
        /// Phương thức cập nhập đạn
        /// </summary>
        /// <param name="gameTime"></param>
        public void BulletManagement(GameTime gameTime)
        {
            //cập nhật đạn
            for(int i = 0; i < listBullet.Count; i++)
            {
                if (listBullet[i].Position.Y <= 0)
                {
                    listBullet.RemoveAt(i);
                    i--;
                }
                else
                    listBullet[i].Update(gameTime);
            }
        }

        public void DrawHeadBar(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(skinHealthBar, new Rectangle(800 / 2 - skinHealthBar.Width / 2, 30, skinHealthBar.Width, 20), new Rectangle(0, 45, skinHealthBar.Width, 44), Color.Gray);
            spriteBatch.Draw(skinHealthBar, new Rectangle(800 / 2 - skinHealthBar.Width / 2, 30, (int)(skinHealthBar.Width * ((double)hp / 100)), 20), new Rectangle(0, 45, skinHealthBar.Width, 44), Color.Red);
            spriteBatch.DrawString(cglobal.font, Hp + " / " + hp, new Vector2(800 / 2 - skinHealthBar.Width / 2, 28), Color.White);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            DrawHeadBar(spriteBatch);
            //spriteBatch.Draw(skin, bound, Color.White);
            animation.Draw(spriteBatch);

            if(visible)
                foreach (CBusiBullet b in listBullet)
                    b.Draw(spriteBatch);
        }

        #endregion
    }
}

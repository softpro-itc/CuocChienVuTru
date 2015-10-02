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


namespace CuocChienVuTru.Object
{

    public class Player : GameObject
    {
        private List<Bullet> listBullet = new List<Bullet>();
        private int timeAddBullet = 100;
        private int timeTmp = 0;
        private int speedBulet = 5;

        public List<Bullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }

        public Player(CuocChienVuTru game, Texture2D texture, Rectangle bound, Vector2 position, int speed)
            : base(game, texture, bound, position, speed)
        { }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            
            //kiem tra di chuyen
            if (keyboard.IsKeyDown(Keys.Up) && position.Y > 0)
                position.Y -= speed;
            if (keyboard.IsKeyDown(Keys.Down) && position.Y  < game.height - texture.Height)
                position.Y += speed;
            if (keyboard.IsKeyDown(Keys.Left) && position.X > - texture.Width/2)
                position.X -= speed;
            if (keyboard.IsKeyDown(Keys.Right) && position.X < game.width - texture.Width/2)
                position.X += speed;

            //kiem tra ban dan
            timeTmp += gameTime.ElapsedGameTime.Milliseconds;
            if(keyboard.IsKeyDown(Keys.Space))
            {
                if(timeTmp >= timeAddBullet)
                {
                    timeTmp = 0;
                    Texture2D t = game.Content.Load<Texture2D>(@"Images\Bullet\bullet");
                    Bullet b = new Bullet(game, t, new Rectangle((int)position.X + texture.Width/2, (int)position.Y - t.Height, t.Width, t.Height), position, speedBulet, Bullet.Owner.player);
                    Bullet c = new Bullet(game, t, new Rectangle((int)position.X + texture.Width, (int)position.Y - t.Height, t.Width, t.Height), position, speedBulet, Bullet.Owner.player);
                    Bullet d = new Bullet(game, t, new Rectangle((int)position.X, (int)position.Y - t.Height, t.Width, t.Height), position, speedBulet, Bullet.Owner.player);
                    listBullet.Add(b);
                    listBullet.Add(c);
                    listBullet.Add(d);
                }
            }
            //cap nhat vi tri nhan vat
            bound.X = (int)position.X;
            bound.Y = (int)position.Y;

            //cap nhat dan
            for (int i = 0; i < listBullet.Count; i++ )
            {
                if (listBullet[i].Enabled)
                    listBullet[i].Update(gameTime);
                else
                    listBullet.RemoveAt(i);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Bullet b in listBullet)
                b.Draw(gameTime);
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, "so dan: " + listBullet.Count.ToString(), Vector2.Zero, Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

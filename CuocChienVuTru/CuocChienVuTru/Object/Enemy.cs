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

    public class Enemy : GameObject
    {

        private List<Bullet> listBullet = new List<Bullet>();
        private int timeAddBullet = 100;
        private int timeTmp = 0;
        private int speedBulet = 1;
        private int speedDefault = 1;

        public List<Bullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }

        public Enemy(CuocChienVuTru game, Texture2D texture, Rectangle bound, Vector2 position, int speed)
            : base(game, texture, bound, position, speed)
        { }


        public override void Initialize()
        {
            base.Initialize();
        }

 
        public override void Update(GameTime gameTime)
        {
            if (position.Y >= game.height)
                this.Remove();
            if (this.Enabled)
                position.Y += speed;

            //them dan
            timeTmp += gameTime.ElapsedGameTime.Milliseconds;
            if (timeTmp >= timeAddBullet)
            {
                timeTmp = 0;
                Texture2D t = game.Content.Load<Texture2D>(@"Texture\Bullet\bullet");
                Bullet b = new Bullet(game, t, new Rectangle((int)position.X + 10, (int)position.Y - 70, t.Width, t.Height), position, speedBulet, Bullet.Owner.enemy);
                listBullet.Add(b);
            }

            //cap nhat dan
            for (int i = 0; i < listBullet.Count; i++)
            {
                if (listBullet[i].Enabled)
                    listBullet[i].Update(gameTime);
                else
                    listBullet.RemoveAt(i);
            }

            bound.Y = (int)position.Y;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Bullet b in listBullet)
                b.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}

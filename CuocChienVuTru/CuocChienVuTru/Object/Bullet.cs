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
using CuocChienVuTru.Object;


namespace CuocChienVuTru.Object
{

    public class Bullet : GameObject
    {
        public enum Owner
        {
            enemy = 0,
            player
        }

        private Owner owner;

        public Bullet(CuocChienVuTru game, Texture2D texture, Rectangle bound, Vector2 position, int speed, Owner owner)
            : base(game, texture, bound, position, speed)
        {
            this.owner = owner;
            
        }

        public override void Initialize()
        {
            
            base.Initialize();
        }


        public override void Update(GameTime gameTime)
        {
            if (position.Y >= game.height || position.Y <= 0)
                this.Remove();
            if(this.Enabled)
            {
                if (this.owner == Owner.enemy)
                {
                    position.Y += speed;
                }
                else
                {
                    position.Y -= speed;
                }
            }
            bound.Y = (int)position.Y;
            base.Update(gameTime);
        }
    }
}

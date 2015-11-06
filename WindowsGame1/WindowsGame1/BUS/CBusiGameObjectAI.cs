using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CuocChienVuTru.CGlobal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CuocChienVuTru.BUS
{
    public class CBusiGameObjectAI : CBusiGameObject
    {
        #region khai báo biến
        protected List<CBusiBullet> listBullet = new List<CBusiBullet>();
        protected int timerAddBullet = 0;
        private int intevalAddBullet = 2000;

        protected int IntevalAddBullet
        {
            get { return intevalAddBullet; }
            set { intevalAddBullet = value; }
        }
        #endregion

        #region khai báo propeties
        public List<CBusiBullet> ListBullet
        {
            get { return listBullet; }
            set { listBullet = value; }
        }
        #endregion

        public CBusiGameObjectAI(Game1 game, Texture2D skin, Vector2 position, int speed, int damage)
            : base(game, skin, position, speed, damage)
        {            
        }

        public CBusiGameObjectAI() { }


        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}

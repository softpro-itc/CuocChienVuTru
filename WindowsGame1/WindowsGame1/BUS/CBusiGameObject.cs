using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;

namespace CuocChienVuTru.BUS
{
    public abstract class CBusiGameObject
    {
        #region khai báo biến
        private string folderSkin;
        protected Texture2D skin;
        protected Vector2 position;
        protected Rectangle bound;
        protected int speed;
        protected int hp;
        protected int damage;
        protected bool visible;
        protected Game1 game;
        protected CGlobalVariable cglobalVar;
        protected SpriteFont font;
        #endregion

        #region khai báo propeties

        protected string FolderSkin
        {
            get { return folderSkin; }
            set { folderSkin = value; }
        }

        public Texture2D Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Bound
        {
            get { return bound; }
            set { bound = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int Hp
        {
            get { return hp; }
            set 
            { 
                hp = (value >= 0) ? value : 0; 
            }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        #endregion

        #region constructor
        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="game">đối tượng game chính</param>
        /// <param name="skin">hình ảnh</param>
        /// <param name="position">vị trí </param>
        /// <param name="speed">tốc độ di chuyển</param>
        /// <param name="damage">mức độ tấn công</param>
        public CBusiGameObject(Game1 game ,string skinName, Vector2 position, int speed, int damage)
        {
            this.visible = true;
            this.position = position;
            this.speed = speed;
            this.damage = damage;
            //this.bound = new Rectangle((int)position.X, (int)position.Y, skin.Width, skin.Height);
            this.game = game;
            font = game.Content.Load<SpriteFont>("Font/fontMain");
            cglobalVar = game.cglobalVar;
        }

        public void LoadContent(string skinName)
        {
            skin = game.Content.Load<Texture2D>(folderSkin + skinName);
            this.bound = new Rectangle((int)position.X, (int)position.Y, skin.Width, skin.Height);
        }

        public CBusiGameObject(){}
        #endregion

        #region khai báo phương thức
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}

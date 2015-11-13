using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoGameObject
    {
        #region khai báo biến
        protected Texture2D skin;
        protected Vector2 position;
        protected Rectangle bound;
        protected int speed;
        protected int hp;
        protected int damage;
        protected bool visible;
        protected Game1 game;
        protected CGlobalVariable cglobalVar;
        protected CGloabalFunction cglobalFunc;
        protected CGlobalDictionary cglobalDic;        
        protected SpriteFont font;
        protected string folderSkin;
        protected string skinName;
        #endregion

        #region khai báo propeties

        public CGloabalFunction CglobalFunc
        {
            get { return cglobalFunc; }
            set { cglobalFunc = value; }
        }

        public CGlobalDictionary CglobalDic
        {
            get { return cglobalDic; }
            set { cglobalDic = value; }
        }

        public CGlobalVariable CglobalVar
        {
            get { return cglobalVar; }
            set { cglobalVar = value; }
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

        public Game1 Game
        {
            get { return game; }
            set { game = value; }
        }


        public string SkinName
        {
            get { return skinName; }
            set { skinName = value; }
        }

        public string FolderSkin
        {
            get { return folderSkin; }
            set { folderSkin = value; }
        }

        #endregion

        #region constructor
        /// <summary>
        /// phương thức khởi tạo game
        /// </summary>
        /// <param name="skin">hình ảnh đối tượng</param>
        /// <param name="position">vị trí</param>
        /// <param name="bound">bao quanh đối tượng</param>
        /// <param name="speed">tốc độ</param>
        /// <param name="hp">máu của đối tượng</param>
        /// <param name="damage">mức sát thương</param>
        /// <param name="visible">thuộc tính ẩn hiện</param>
        /// <param name="game">đối tượng game</param>
        /// <param name="cglobal">đối tượng toàn cục</param>
        /// <param name="font">đối tượng chữ</param>
        public CInfoGameObject(Game1 game, Texture2D skin, Vector2 position, Rectangle bound, int speed, int hp, int damage, bool visible)
        {
            this.skin = skin;
            this.position = position;
            this.bound = bound;
            this.speed = speed;
            this.hp = hp;
            this.damage = damage;
            this.visible = visible;
            this.game = game;
            font = game.Content.Load<SpriteFont>("Font/fontMain");
            cglobalVar = game.cglobalVar;
            cglobalDic = game.cglobalDic;
            cglobalFunc = game.cglobalFunc;

        }

        public CInfoGameObject(Game1 game, string skinName, Vector2 position, int speed, int damage)
        {
            this.visible = true;
            this.position = position;
            this.speed = speed;
            this.damage = damage;
            this.skinName = skinName;
            //this.bound = new Rectangle((int)position.X, (int)position.Y, skin.Width, skin.Height);
            this.game = game;
            font = game.Content.Load<SpriteFont>("Font/fontMain");
            cglobalVar = game.cglobalVar;
            cglobalDic = game.cglobalDic;
            cglobalFunc = game.cglobalFunc;
        }

        public void LoadContent(string skinName)
        {
            skin = game.Content.Load<Texture2D>(folderSkin + skinName);
            this.bound = new Rectangle((int)position.X, (int)position.Y, skin.Width, skin.Height);
        }

        public CInfoGameObject() { }
        #endregion
    }
}

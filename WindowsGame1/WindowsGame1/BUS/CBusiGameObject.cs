using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public abstract class CBusiGameObject
    {

        //protected CInfoGameObject dto;
        protected bool isAnimation;


        public bool IsAnimation
        {
            get { return isAnimation; }
            set { isAnimation = value; }
        }

        //public CInfoGameObject Dto
        //{
        //    get { return dto; }
        //    set { dto = value; }
        //}

        #region constructor
        ///// <summary>
        ///// phương thức khởi tạo
        ///// </summary>
        ///// <param name="game">đối tượng game chính</param>
        ///// <param name="skin">hình ảnh</param>
        ///// <param name="position">vị trí </param>
        ///// <param name="speed">tốc độ di chuyển</param>
        ///// <param name="damage">mức độ tấn công</param>
        //public CBusiGameObject(CInfoGameObject dto)
        //{
        //    this.dto = dto;
        //}

        //public void LoadContent(string skinName)
        //{
        //    dto.Skin = dto.Game.Content.Load<Texture2D>(dto.FolderSkin + skinName);
        //    dto.Bound = new Rectangle((int)dto.Position.X, (int)dto.Position.Y, dto.Skin.Width, dto.Skin.Height);
        //}

        //public CBusiGameObject(CInfoGameObject info) { }

        public CBusiGameObject(){}
        #endregion

        #region khai báo phương thức
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        #endregion
    }
}

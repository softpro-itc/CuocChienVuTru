using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoGameSceneBase
    {
        protected List<CBusiButton> listButton;
        protected CBusiBackground background;
        protected CGlobalVariable cglobalVar;
        protected bool isVisible;
        protected Game1 game;
        protected CGloabalFunction cglobalFunc;
        protected CGlobalDictionary cglobalDic;

       
        #region khai báo propeties
        public List<CBusiButton> ListButton
        {
            get { return listButton; }
            set { listButton = value; }
        }
        public CBusiBackground Background
        {
            get { return background; }
            set { background = value; }
        }
        public CGlobalVariable CglobalVar
        {
            get { return cglobalVar; }
            set { cglobalVar = value; }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        public Game1 Game
        {
            get { return game; }
            set { game = value; }
        }
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

         #endregion

        #region khai báo constructer
        /// <summary>
        /// phương thức khởi tạo màn hình 
        /// </summary>
        /// <param name="listButton">danh sách button</param>
        /// <param name="background">đối tượng hình nền</param>
        /// <param name="cglobalVar">đối tượng biến toàn cục</param>
        /// <param name="isVisible">cho phép ẩn hiện</param>
        /// <param name="game">đối tượng game</param>
        /// <param name="cglobalFunc">đối tượng hàm toàn cục</param>
        /// <param name="cglobalDic">đối tượng dictionnary toàn cục</param>
        public CInfoGameSceneBase(List<CBusiButton> listButton, CBusiBackground background, CGlobalVariable cglobalVar, bool isVisible, Game1 game, CGloabalFunction cglobalFunc, CGlobalDictionary cglobalDic)
        {
            this.listButton = listButton;
            this.background = background;
            this.cglobalVar = cglobalVar;
            this.isVisible = isVisible;
            this.game = game;
            this.cglobalFunc = cglobalFunc;
            this.cglobalDic = cglobalDic;
        }
        public CInfoGameSceneBase(Game1 game, CBusiBackground background)
        {
            this.background = background;
            isVisible = false;
            listButton = new List<CBusiButton>();
            this.game = game;
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
        }

        public CInfoGameSceneBase(Game1 game)
        {
            this.game = game;
            listButton = new List<CBusiButton>();
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
        }

        public CInfoGameSceneBase()
        {
            cglobalVar = game.cglobalVar;
            cglobalFunc = game.cglobalFunc;
            cglobalDic = game.cglobalDic;
        }

        #endregion

    }
}

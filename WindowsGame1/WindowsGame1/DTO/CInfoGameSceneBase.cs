using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoGameSceneBase
    {
        private List<CBusiButton> listButton;
        private CBusiBackground background;
        private CGlobalVariable cglobalVar;
        private bool isVisible;
        private Game1 game;
        private CGloabalFunction cglobalFunc;
        private CGlobalDictionary cglobalDic;

       
        #region khai báo biến
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
        protected Game1 Game
        {
            get { return game; }
            set { game = value; }
        }
        protected CGloabalFunction CglobalFunc
        {
            get { return cglobalFunc; }
            set { cglobalFunc = value; }
        }
        protected CGlobalDictionary CglobalDic
        {
            get { return cglobalDic; }
            set { cglobalDic = value; }
        }

         #endregion
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
        public CInfoGameSceneBase(  List<CBusiButton> listButton,CBusiBackground background,CGlobalVariable cglobalVar,bool isVisible, Game1 game,CGloabalFunction cglobalFunc, CGlobalDictionary cglobalDic)
        {
            this.listButton = listButton;
            this.background = background;
            this.cglobalVar = cglobalVar;
            this.isVisible = isVisible;
            this.game = game;
            this.cglobalFunc = cglobalFunc;
            this.cglobalDic = cglobalDic;
        }

    }
}

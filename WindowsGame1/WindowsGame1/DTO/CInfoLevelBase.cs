using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoLevelBase:CInfoGameSceneBase
    {
        private List<CBusiEnemy> listEnemy = new List<CBusiEnemy>();
        private CBusiPlayer player;
        private int timeAddEnemy = 500;
        private int timerEnemy = 0;
        private int maxEnemy = 10;
        private List<CBusiItem> listItem = new List<CBusiItem>();
        private int timeAddItem = 500;      
        private int timerItem = 0;   
        private int maxItem = 3;

       
        protected List<CBusiEnemy> ListEnemy
        {
            get { return listEnemy; }
            set { listEnemy = value; }
        }
        protected CBusiPlayer Player
        {
            get { return player; }
            set { player = value; }
        }
        protected int TimeAddEnemy
        {
            get { return timeAddEnemy; }
            set { timeAddEnemy = value; }
        }
        protected int TimerEnemy
        {
            get { return timerEnemy; }
            set { timerEnemy = value; }
        }
        protected int MaxEnemy
        {
            get { return maxEnemy; }
            set { maxEnemy = value; }
        }
        protected List<CBusiItem> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }
        protected int TimeAddItem
        {
            get { return timeAddItem; }
            set { timeAddItem = value; }
        }
        protected int TimerItem
        {
            get { return timerItem; }
            set { timerItem = value; }
        }
        protected int MaxItem
        {
            get { return maxItem; }
            set { maxItem = value; }
        }
        /// <summary>
        /// phương thức khởi tạo màn chơi
        /// </summary>
        /// <param name="listEnemy">danh sách quái</param>
        /// <param name="player">đối tượng người chơi</param>
        /// <param name="timeAddEnemy"> time thêm quái</param>
        /// <param name="timerEnemy">biến đếm time thêm quái</param>
        /// <param name="maxEnemy">số quái tối đa</param>
        /// <param name="listItem">danh sách item</param>
        /// <param name="timeAddItem">thời gian thêm item</param>
        /// <param name="timerItem">biến đếm time thêm item</param>
        /// <param name="maxItem">số item tối đa</param>
        /// <param name="listButton">danh sách button</param>
        /// <param name="background"> đối tượng hình nền</param>
        /// <param name="cglobalVar"> đối tượng biến toàn cục</param>
        /// <param name="isVisible">cho phép ẩn hiện</param>
        /// <param name="game">đối tượng game</param>
        /// <param name="cglobalFunc">đối tượng hàm toàn cục</param>
        /// <param name="cglobalDic">đối tượng dictionnary toàn cục</param>
        public CInfoLevelBase(List<CBusiEnemy> listEnemy , CBusiPlayer player,int timeAddEnemy , int timerEnemy , int maxEnemy , List<CBusiItem> listItem, int timeAddItem,int timerItem , int maxItem , List<CBusiButton> listButton,CBusiBackground background,CGlobalVariable cglobalVar,bool isVisible, Game1 game,CGloabalFunction cglobalFunc, CGlobalDictionary cglobalDic)
            :base(  listButton, background, cglobalVar, isVisible,  game, cglobalFunc,  cglobalDic)
        {
            this.listEnemy = listEnemy;
            this.player = player;
            this.timeAddEnemy = timeAddEnemy;
            this.timerEnemy = timerEnemy;
            this.maxEnemy = maxEnemy;
            this.listItem = listItem;
            this.timeAddEnemy = timeAddEnemy;
            this.timerItem = timerItem;
            this.maxItem = maxItem;
        }
    }
}

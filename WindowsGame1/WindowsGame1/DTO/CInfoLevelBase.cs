using CuocChienVuTru.BUS;
using CuocChienVuTru.CGlobal;
using CuocChienVuTru.Global;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    public class CInfoLevelBase:CInfoGameSceneBase
    {
        protected List<CBusiEnemy> listEnemy = new List<CBusiEnemy>();
        protected CBusiPlayer player;
        protected int timeAddEnemy = 500;
        protected int timerEnemy = 0;
        protected int maxEnemy = 10;
        protected List<CBusiItem> listItem = new List<CBusiItem>();
        protected int timeAddItem = 500;      
        protected int timerItem = 0;   
        protected int maxItem = 3;
        protected int pointDestination;
        protected List<CBusiAnimation> listEffect = new List<CBusiAnimation>();
        protected bool isPLaying = true;
        protected CBusiBoss boss;

        public CBusiBoss Boss
        {
            get { return boss; }
            set { boss = value; }
        }

        public int PointDestination
        {
            get { return pointDestination; }
            set { pointDestination = value; }
        }

        public bool IsPLaying
        {
            get { return isPLaying; }
            set { isPLaying = value; }
        }

        public List<CBusiAnimation> ListEffect
        {
            get { return listEffect; }
            set { listEffect = value; }
        }

        public List<CBusiEnemy> ListEnemy
        {
            get { return listEnemy; }
            set { listEnemy = value; }
        }
        public CBusiPlayer Player
        {
            get { return player; }
            set { player = value; }
        }
        public int TimeAddEnemy
        {
            get { return timeAddEnemy; }
            set { timeAddEnemy = value; }
        }
        public int TimerEnemy
        {
            get { return timerEnemy; }
            set { timerEnemy = value; }
        }
        public int MaxEnemy
        {
            get { return maxEnemy; }
            set { maxEnemy = value; }
        }
        public List<CBusiItem> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }
        public int TimeAddItem
        {
            get { return timeAddItem; }
            set { timeAddItem = value; }
        }
        public int TimerItem
        {
            get { return timerItem; }
            set { timerItem = value; }
        }
        public int MaxItem
        {
            get { return maxItem; }
            set { maxItem = value; }
        }

        #region khai báo constructer
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
        public CInfoLevelBase(List<CBusiEnemy> listEnemy, CBusiPlayer player, int timeAddEnemy, int timerEnemy, int maxEnemy, List<CBusiItem> listItem, int timeAddItem, int timerItem, int maxItem, List<CBusiButton> listButton, CBusiBackground background, CGlobalVariable cglobalVar, bool isVisible, Game1 game, CGloabalFunction cglobalFunc, CGlobalDictionary cglobalDic)
            : base(listButton, background, cglobalVar, isVisible, game, cglobalFunc, cglobalDic)
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
        public CInfoLevelBase(Game1 game, CBusiBackground background, CBusiPlayer player)
            : base(game, background)
        {
            this.player = player;
            listButton.Add(new CBusiButton( new CInfoButton(game.Content.Load<Texture2D>("Images/Button/sound"), new Vector2(0, CGlobalVariable.WINDOW_HEIGHT - 50))));
            MediaPlayer.Play(cglobalDic.ListSoundBG["bg1"]);
        }

        public CInfoLevelBase(Game1 game) : base(game) { }

        public CInfoLevelBase() { }
        #endregion
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.DTO
{
    class CInfoAnimation
    {

        Texture2D texture;   //hình ảnh
        Rectangle rectangle; //khung bao quanh frame
        Vector2 position;    //vị trí
        int currentFrame = 0;//frame hiện tại
        int maxFrame = 0;    //tổng số frame
        int frameHeight;    //chiều cao frame
        int frameWidth;        //chiều rộng frame
        int life = 12;      //số lần thực hiện frame
        private bool isVisible = true;           //thuộc tính ẩn hiện
        private bool isAllowControl = false;    //cho phép điều khiển hay không
        float timer = 0;      //biến thời gian
        float interval = 80;    //thời gian thực hiện 1 frame


        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        public int MaxFrame
        {
            get { return maxFrame; }
            set { maxFrame = value; }
        }
        public int FrameHeight
        {
            get { return frameHeight; }
            set { frameHeight = value; }
        }
        public int FrameWidth
        {
            get { return frameWidth; }
            set { frameWidth = value; }
        }
        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        public bool IsAllowControl
        {
            get { return isAllowControl; }
            set { isAllowControl = value; }
        }    
        public float Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        public float Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="texture">hình ảnh</param>
        /// <param name="rectangle">khung bao quanh frame</param>
        /// <param name="position">vị trí</param>
        /// <param name="currentFrame">frame hiện tại</param>
        /// <param name="maxFrame">tổng số frame</param>
        /// <param name="frameHeight">chiều cao frame</param>
        /// <param name="frameWidth">chiều rộng frame</param>
        /// <param name="life">số lần thực hiện frame</param>
        /// <param name="isVisible">thuộc tính ẩn hiện</param>
        /// <param name="isAllowControl">cho phép điều khiển hay không</param>
        /// <param name="timer">biến thời gian</param>
        /// <param name="interval">thời gian thực hiện 1 frame</param>
        public CInfoAnimation( Texture2D texture,Rectangle rectangle,Vector2 position, int currentFrame, int maxFrame ,int frameHeight, int frameWidth,int life ,bool isVisible , bool isAllowControl ,float timer, float interval )
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.position = position;
            this.currentFrame = currentFrame;
            this.maxFrame = maxFrame;
            this.frameHeight = frameHeight;
            this.frameWidth = frameWidth;
            this.life = life;
            this.isVisible = isVisible;
            this.isAllowControl = isAllowControl;
            this.timer = timer;
            this.interval = interval;

        }
    }
}

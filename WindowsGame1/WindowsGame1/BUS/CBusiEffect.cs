using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuocChienVuTru.BUS
{
    public class CBusiEffect
    {
        Texture2D texture;
        Rectangle rectangle; 
        Vector2 position;

        int currentFrame = 0;
        int maxFrame = 6;
        int frameHeight;
        int frameWidth;
        int life = 12;

        public bool isVisible = true;

        float timer = 0;
        float interval = 80;

        public float Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// phương thức khởi tạo
        /// </summary>
        /// <param name="newTexture">hình ảnh animation</param>
        /// <param name="newPosition">vị trí của animation</param>
        /// <param name="NewFrameWidth">chiều rộng của 1 frame</param>
        /// <param name="newFrameHeight">chiều cao của 1 frame</param>
        /// <param name="newMaxFrame">số frame trong hình</param>
        /// <param name="count">số lân thực hiện animation</param>
        public CBusiEffect(Texture2D newTexture, Vector2 newPosition, int NewFrameWidth, int newFrameHeight, int newMaxFrame, int count)
        {
            texture = newTexture;
            position = newPosition;
            frameWidth = NewFrameWidth;
            frameHeight = newFrameHeight;
            maxFrame = newMaxFrame;
            life = count * maxFrame;
        }

        public void Update(GameTime gameTime)
        {
            if (life  == 0)
            {
                isVisible = false;
                return;
            }

            //chuyển frame
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if(timer >= interval)
            {
                currentFrame++;
                if (currentFrame > maxFrame-1)
                    currentFrame = 0;
                timer -= interval;
                life--;
            }

            rectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isVisible)
                spriteBatch.Draw(texture, position, rectangle, Color.White);
        }
    }
}

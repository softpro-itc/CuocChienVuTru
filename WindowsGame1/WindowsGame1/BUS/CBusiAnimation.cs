using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace CuocChienVuTru.BUS
{
    public class CBusiAnimation
    {
        Texture2D texture;
        Rectangle rectangle;

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        int currentFrame = 0;

        public int CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        int maxFrame = 0;
        int frameHeight;
        int frameWidth;
        int life = 12;

        public bool isVisible = true;
        private bool isAllowControl = false;

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
        public CBusiAnimation(Texture2D newTexture, Vector2 newPosition, int NewFrameWidth, int newFrameHeight, int newMaxFrame, int count)
        {
            texture = newTexture;
            position = newPosition;
            frameWidth = NewFrameWidth;
            frameHeight = newFrameHeight;
            maxFrame = newMaxFrame;
            life = count * maxFrame;
        }


        public CBusiAnimation(Texture2D newTexture, Vector2 newPosition, int NewFrameWidth, int newFrameHeight, int newMaxFrame, int currentFrame, bool isAllowControl)
        {
            texture = newTexture;
            position = newPosition;
            frameWidth = NewFrameWidth;
            frameHeight = newFrameHeight;
            maxFrame = newMaxFrame;
            this.currentFrame = currentFrame;
            this.isAllowControl = isAllowControl;
        }

        public void Update(GameTime gameTime)
        {
            if (isVisible)
            {
                if (!isAllowControl)
                {
                    if (life == 0)
                    {
                        isVisible = false;
                        return;
                    }
                }

                //chuyển frame
                timer += gameTime.ElapsedGameTime.Milliseconds;
                if (timer >= interval)
                {
                    if (!isAllowControl)
                    {
                        currentFrame++;
                        if (currentFrame > maxFrame - 1)
                            currentFrame = 0;
                    }
                    else
                    {
                        //cập nhật frame khi bấm phím
                        KeyboardState key = Keyboard.GetState();
                        if (key.IsKeyDown(Keys.Left))
                            currentFrame--;
                        else if (key.IsKeyDown(Keys.Right))
                            currentFrame++;
                        else
                            currentFrame = 1;

                        //giới hạn phạm vi của frame
                        if (currentFrame < 0)
                            currentFrame = 0;
                        if (currentFrame > maxFrame - 1)
                            currentFrame = maxFrame - 1;
                    }

                    timer -= interval;
                    if (life > 0)
                        life--;
                }

                rectangle = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(isVisible)
                spriteBatch.Draw(texture, position, rectangle, Color.White);
        }
    }
}

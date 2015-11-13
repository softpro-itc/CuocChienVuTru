using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using CuocChienVuTru.DTO;

namespace CuocChienVuTru.BUS
{
    public class CBusiAnimation
    {

        CInfoAnimation dto;

        public CInfoAnimation Dto
        {
            get { return dto; }
            set { dto = value; }
        }

        public CBusiAnimation(CInfoAnimation dto)
        {
            this.dto = dto;
        }


        public void Update(GameTime gameTime)
        {
            if (dto.IsVisible)
            {
                if (!dto.IsAllowControl)
                {
                    if (dto.Life == 0)
                    {
                        dto.IsVisible = false;
                        return;
                    }
                }

                //chuyển frame
                dto.Timer += gameTime.ElapsedGameTime.Milliseconds;
                if (dto.Timer >= dto.Interval)
                {
                    if (!dto.IsAllowControl)
                    {
                        dto.CurrentFrame++;
                        if (dto.CurrentFrame > dto.MaxFrame - 1)
                            dto.CurrentFrame = 0;
                    }
                    else
                    {
                        //cập nhật frame khi bấm phím
                        KeyboardState key = Keyboard.GetState();
                        if (key.IsKeyDown(Keys.Left))
                            dto.CurrentFrame--;
                        else if (key.IsKeyDown(Keys.Right))
                            dto.CurrentFrame++;
                        else
                            dto.CurrentFrame = 1;

                        //giới hạn phạm vi của frame
                        if (dto.CurrentFrame < 0)
                            dto.CurrentFrame = 0;
                        if (dto.CurrentFrame > dto.MaxFrame - 1)
                            dto.CurrentFrame = dto.MaxFrame - 1;
                    }

                    dto.Timer -= dto.Interval;
                    if (dto.Life > 0)
                        dto.Life--;
                }

                dto.Rectangle = new Rectangle(dto.CurrentFrame * dto.FrameWidth, 0, dto.FrameWidth, dto.FrameHeight);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(dto.IsVisible)
                spriteBatch.Draw(dto.Texture, dto.Position, dto.Rectangle, Color.White);
        }
    }
}

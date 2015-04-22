using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class GameLogoSprite : IAnimatedSprite
    {
        //Credit for fade-in code: http://xnadevelopment.com/tutorials/fadeinfadeout/FadeInFadeOut.shtml
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int UpdateSpeed { get; set; }

        int alphaValue = 1;
        int fadeIncrement = 3;
        double fadeDelay = .01;


        public GameLogoSprite(Texture2D texture)
        {
            Texture = texture;
            Rows = 1;
            Columns = 1;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            UpdateSpeed = ValueHolder.normalAnimationTimer;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void Update(GameTime gametime)
        {
            fadeDelay -= gametime.ElapsedGameTime.TotalSeconds;
            if (fadeDelay <= 0)
            {
                fadeDelay = .01;
                alphaValue += fadeIncrement;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, 
                new Color(255, 255, 255, (byte)MathHelper.Clamp(alphaValue, 0, 255)));
        }
    }
}

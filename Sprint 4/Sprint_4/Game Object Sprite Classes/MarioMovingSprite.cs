using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    class MarioMovingSprite : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        int animTimer;
        public int UpdateSpeed { get; set; }
        int speedClamp = 50;

        public MarioMovingSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
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
            if (UpdateSpeed < speedClamp)
            {
                UpdateSpeed = speedClamp;
            }
            animTimer += gametime.ElapsedGameTime.Milliseconds;
            if (animTimer > UpdateSpeed)
            {
                animTimer -= UpdateSpeed;

                currentFrame = (currentFrame + 1) % totalFrames;
                if (currentFrame == totalFrames)
                { currentFrame = 0; }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    class RightWalkingShellessKoopa : IAnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        int animTimer = 0;
        public int UpdateSpeed { get; set; }


        public RightWalkingShellessKoopa(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void Update(GameTime gameTime)
        {
            animTimer++;
            if (animTimer == 12)
            {
                animTimer = 0;
          
                currentFrame = (currentFrame + 1) % totalFrames;
                if (currentFrame == totalFrames)
                { currentFrame = 0; }
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

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}

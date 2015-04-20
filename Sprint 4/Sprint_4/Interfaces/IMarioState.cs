using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public interface IMarioState
    {
        IAnimatedSprite Sprite { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void TakeDamage();
        void Up();
        void Down();
        void GoLeft();
        void GoRight();
        void Idle();
        void Land();
        void MakeBigMario();
        void MakeSmallMario();
        void MakeFireMario();
        void MakeFireballMario();
        void MakeNinjaMario();
        void MakeDeadMario();
        void Flip();
        Rectangle GetBoundingBox(Vector2 location);
    }
}


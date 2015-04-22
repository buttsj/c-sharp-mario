using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class BackgroundHolder
    {
        ISpriteFactory factory;
        public IAnimatedSprite OverworldSprite { get; set; }
        public IAnimatedSprite OverworldHillsSprite { get; set; }
        public IAnimatedSprite UndergroundSprite { get; set; }
        public IAnimatedSprite CurrentSprite { get; set; }

        public BackgroundHolder()
        {
            factory = new SpriteFactory();
            OverworldSprite = factory.build(SpriteFactory.sprites.overworldBackground);
            UndergroundSprite = factory.build(SpriteFactory.sprites.undergroundBackground);
            OverworldHillsSprite = factory.build(SpriteFactory.sprites.overworldHillsBackground);

            // Set current background with this
            CurrentSprite = OverworldSprite;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentSprite.Draw(spriteBatch, new Vector2(0, 0), Color.White);
        }
    }
}

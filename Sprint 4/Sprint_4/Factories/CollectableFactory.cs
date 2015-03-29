using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class CollectableFactory
    {
        public enum CollectableType
        {
            coin, star, oneUp, fireFlower, superMushroom
        }
        SpriteFactory factory;
        Game1 game;
        ICollectable product;

        public CollectableFactory(Game1 game)
        {
            this.game = game;
        }
        
        public ICollectable build(CollectableType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == CollectableType.coin)
            {
                product = new Coin(game, location);
            }
            if (type == CollectableType.star)
            {
                product = new Star(game, location);
            }
            if (type == CollectableType.oneUp)
            {
                product = new OneUpMushroom(game, location);
            }
            if (type == CollectableType.fireFlower)
            {
                product = new FireFlower(game, location);
            }
            if (type == CollectableType.superMushroom)
            {
                product = new SuperMushroom(game, location);
            }
            return product;
        }
    }
}

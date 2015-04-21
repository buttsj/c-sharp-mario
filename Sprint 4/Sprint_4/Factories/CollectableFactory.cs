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
            coin, star, oneUp, fireFlower, superMushroom, ninja,
        }
        SpriteFactory factory;
        ICollectable product;

        public CollectableFactory()
        {
        }
        
        public ICollectable build(CollectableType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == CollectableType.coin)
            {
                product = new Coin(location);
            }
            if (type == CollectableType.star)
            {
                product = new Star(location);
            }
            if (type == CollectableType.oneUp)
            {
                product = new OneUpMushroom(location);
            }
            if (type == CollectableType.fireFlower)
            {
                product = new FireFlower(location);
            }
            if (type == CollectableType.superMushroom)
            {
                product = new SuperMushroom(location);
            }
            if (type == CollectableType.ninja)
            {
                product = new Ninja(location);
            }
            
            return product;
        }
    }
}

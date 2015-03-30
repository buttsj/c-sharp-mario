using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class EnemyFactory
    {
        public enum EnemyType { Dino, Koopa, Bill, SmashedDino}
        IEnemyState state;

        public EnemyFactory()
        {
        }
        
        public Enemy build(EnemyType type, Vector2 location)
        {
            if (type == EnemyFactory.EnemyType.Dino)
            {
                state = new LeftTallDinoState();
            }
            if (type == EnemyFactory.EnemyType.Koopa)
            {
                state = new LeftWalkingShellessKS();
            }
            if (type == EnemyFactory.EnemyType.SmashedDino)
            {
                state = new LeftSmashedDinoState();
            }
            if (type == EnemyFactory.EnemyType.Bill)
            {
                state = new BanzaiBillState();
            }
            Enemy product = new Enemy(location, state);
            return product;
        }
    }
}

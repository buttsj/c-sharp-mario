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
        Game1 game;
        IEnemyState state;

        public EnemyFactory(Game1 game)
        {
            this.game = game;
        }
        
        public BasicEnemy build(EnemyType type, Vector2 location)
        {
            if (type == EnemyFactory.EnemyType.Bill)
            {
                state = new BanzaiBillState(game);
            }
            if (type == EnemyFactory.EnemyType.Dino)
            {
                state = new LeftTallDinoState(game);
            }
            if (type == EnemyFactory.EnemyType.Koopa)
            {
                state = new LeftWalkingShellessKS(game);
            }
            if (type == EnemyFactory.EnemyType.SmashedDino)
            {
                state = new LeftSmashedDinoState(game);
            }
            BasicEnemy product = new BasicEnemy(game, location, state);
            return product;
        }
    }
}

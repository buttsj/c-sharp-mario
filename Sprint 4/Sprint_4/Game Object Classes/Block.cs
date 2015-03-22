using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Block
    {
        public IBlockState state;
        ISpriteFactory factory;
        public Item prize;
        bool prizeSpawned = false;
        public Vector2 position = new Vector2(0, 0);
        Game1 game;

        //split this off into a factory
        public enum BlockType { used, question, winged, exclamation, brick, pipe, ground, leftEdge, rightEdge, quesMush,
        quesCoin, ques1up, quesStar}

        public Block(Game1 game, Block.BlockType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == BlockType.used)
            {
                state = new UsedBlockState(game);
            }
            if (type == BlockType.question)
            {
                state = new QuestionBlockState(game);
            }
            if (type == BlockType.winged)
            {
                state = new WingedBlockState(game);
            }
            if (type == BlockType.exclamation)
            {
                state = new ExclamationBlockState(game);
            }
            if (type == BlockType.brick)
            {
                state = new BrickBlockState(game);
            }
            if (type == BlockType.pipe)
            {
                state = new PipeBlockState(game);
            }
            if (type == BlockType.ground)
            {
                state = new GroundBlockState(game);
            }
            if (type == BlockType.leftEdge)
            {
                state = new LeftEdgeBlockState(game);
            }
            if (type == BlockType.rightEdge)
            {
                state = new RightEdgeBlockState(game);
            }
            if (type == BlockType.quesMush)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.superMushroom));
                prize.position = location;
            }
            if (type == BlockType.quesStar)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.star));
                prize.position = location;
            }
            if (type == BlockType.ques1up)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.oneUpMushroom));
                prize.position = location;
            }
            if (type == BlockType.quesCoin)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.coin));
                prize.position = location;
                prize.isCoin = true;
            }
            position = location;
            this.game = game;
        }

        public void Update(GameTime gameTime)
        {
            state.Update(gameTime, this);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
        public void Reaction()
        {
            state.Reaction(this);
            if (prize != null && !prizeSpawned)
            {
                prize.Spawn();
                prizeSpawned = true;
            }
        }
        public Rectangle GetRectangle()
        {
            return state.GetRectangle(position);
        }
    }
}

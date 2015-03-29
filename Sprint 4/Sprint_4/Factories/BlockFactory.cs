using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint4
{
    public class BlockFactory
    {
        public enum BlockType
        {
            used, question, winged, exclamation, brick, pipe, ground, leftEdge, rightEdge, quesMush,
            quesCoin, ques1up, quesStar, quesFlower
        }
        SpriteFactory factory;
        Game1 game;
        IBlockState state;
        Item prize;

        public BlockFactory(Game1 game)
        {
            this.game = game;
        }
        
        public Block build(BlockType type, Vector2 location)
        {
            prize = null;
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
                prize = new Item(game, factory.build(SpriteFactory.sprites.superMushroom), location);
            }
            if (type == BlockType.quesStar)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.star), location);
            }
            if (type == BlockType.ques1up)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.oneUpMushroom), location);
            }
            if (type == BlockType.quesCoin)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.coin), location);
                prize.isCoin = true;
            }
            if (type == BlockType.quesFlower)
            {
                state = new QuestionBlockState(game);
                prize = new Item(game, factory.build(SpriteFactory.sprites.fireFlower), location);
            }
            Block product = new Block(game, location, prize, state);
            return product;
        }
    }
}

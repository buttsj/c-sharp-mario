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
        IBlockState state;
        ICollectable prize;

        public BlockFactory()
        {
        }
        
        public Block build(BlockType type, Vector2 location)
        {
            prize = null;
            factory = new SpriteFactory();
            if (type == BlockType.used)
            {
                state = new UsedBlockState();
            }
            if (type == BlockType.question)
            {
                state = new QuestionBlockState();
            }
            if (type == BlockType.winged)
            {
                state = new WingedBlockState();
            }
            if (type == BlockType.exclamation)
            {
                state = new ExclamationBlockState();
            }
            if (type == BlockType.brick)
            {
                state = new BrickBlockState();
            }
            if (type == BlockType.pipe)
            {
                state = new PipeBlockState();
            }
            if (type == BlockType.ground)
            {
                state = new GroundBlockState();
            }
            if (type == BlockType.leftEdge)
            {
                state = new LeftEdgeBlockState();
            }
            if (type == BlockType.rightEdge)
            {
                state = new RightEdgeBlockState();
            }
            if (type == BlockType.quesMush)
            {
                state = new QuestionBlockState();
                prize = new SuperMushroom(location);
            }
            if (type == BlockType.quesStar)
            {
                state = new QuestionBlockState();
                prize = new Star(location);
            }
            if (type == BlockType.ques1up)
            {
                state = new InvisibleBlockState();
                prize = new OneUpMushroom(location);
            }
            if (type == BlockType.quesCoin)
            {
                state = new QuestionBlockState();
                prize = new Coin(location);
            }
            if (type == BlockType.quesFlower)
            {
                state = new QuestionBlockState();
                prize = new FireFlower(location);
            }
            Block product = new Block(location, prize, state);
            return product;
        }
    }
}

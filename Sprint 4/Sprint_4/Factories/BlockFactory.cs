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
            quesCoin, ques1up, quesStar, quesFlower, undergroundRoof, undergroundFloor, undergroundLeftWall, undergroundRightWall,
            undergroundLeftTop, undergroundRightTop, undergroundRightBottom, undergroundLeftBottom, leftPipe, downPipe
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
                state = new GenericBlockState(SpriteFactory.sprites.usedBlock);
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
            if (type == BlockType.leftPipe)
            {
                state = new PipeBlockState();
            }
            if (type == BlockType.downPipe)
            {
                state = new PipeBlockState();
            }
            if (type == BlockType.ground)
            {
                state = new GenericBlockState(SpriteFactory.sprites.ground);
            }
            if (type == BlockType.leftEdge)
            {
                state = new GenericBlockState(SpriteFactory.sprites.leftEdge);
            }
            if (type == BlockType.rightEdge)
            {
                state = new GenericBlockState(SpriteFactory.sprites.rightEdge);
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
            if (type == BlockType.undergroundRoof)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRoof);
            }
            if (type == BlockType.undergroundFloor)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundFloor);
            }
            if (type == BlockType.undergroundRightTop)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRightTopCorner);
            }
            if (type == BlockType.undergroundLeftTop)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftTopCorner);
            }
            if (type == BlockType.undergroundRightBottom)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRightBottomCorner);
            }
            if (type == BlockType.undergroundLeftBottom)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftBottomCorner);
            }
            if (type == BlockType.undergroundLeftWall)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundLeftWall);
            }
            if (type == BlockType.undergroundRightWall)
            {
                state = new GenericBlockState(SpriteFactory.sprites.undergroundRightWall);
            }
            Block product = new Block(location, prize, state);
            return product;
        }
    }
}

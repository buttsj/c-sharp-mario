using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class SpriteFactory : ISpriteFactory
    {
        public enum sprites
        {
            // Enemies
            leftDeadDino, rightDeadDino, walkingLeftDino, walkingRightDino,
            walkingRightSquishedDino, walkingLeftSquishedDino, deadShellessKoopa, leftWalkShellessKoopa, rightWalkShellessKoopa,
            banzaiBill, deadBanzaiBill,
            // Items
            oneUpMushroom, fireFlower, superMushroom, coin, star, fireball,
            // Blocks
            questionBlock, brickBlock, usedBlock, wingedBlock, exclamationBlock, 
            // Background items
            bluePipe, bush1, bush2, bush3, launcherPiper, launcherPipeSupport, yellowPipe, whitePipe, leftPipe, downPipe, exitSign,
            ground, rightEdge, leftEdge, undergroundBackground, overworldBackground, overworldHillsBackground,undergroundFloor,
            undergroundLeftBottomCorner, undergroundRightBottomCorner, undergroundRightTopCorner, undergroundLeftTopCorner,
            undergroundRightWall, undergroundLeftWall, undergroundRoof, exit,
            // Mario big
            leftCrouchingMarioBig,  leftIdleMarioBig, leftJumpingMarioBig,  
            leftMovingMarioBig, leftQuickturnMarioBig, leftShellKickMarioBig, leftSlidingMarioBig, rightCrouchingMarioBig,
            rightIdleMarioBig, rightJumpingMarioBig,  rightMovingMarioBig, 
            rightQuickturnMarioBig, rightShellKickMarioBig, victoryMarioBig, leftSprintMarioBig, rightSprintMarioBig,
            // Mario fire
            leftCrouchingMarioFire, leftIdleMarioFire, leftJumpingMarioFire, leftQuickturnMarioFire, 
            leftFireballMarioFire, leftMovingMarioFire, rightMovingMarioFire, rightCrouchingMarioFire,
            rightJumpingMarioFire, rightQuickturnMarioFire, rightFireballMarioFire,
            rightIdleMarioFire, victoryMarioFire,
            // Mario small
            deadMario, leftCrouchingMarioSmall, leftIdleMarioSmall, leftJumpingMarioSmall, 
            leftMovingMarioSmall, rightCrouchingMarioSmall, rightIdleMarioSmall, rightJumpingMarioSmall, 
            rightMovingMarioSmall, leftSprintMarioSmall, rightSprintMarioSmall, victoryMarioSmall
        }

        public SpriteFactory()
        {
        }
        
        public IAnimatedSprite build(SpriteFactory.sprites sprite)
        {
            IAnimatedSprite product = null;

            //ENEMIES
            if (sprite == sprites.banzaiBill)
            {
                Texture2D banzaiBill = Game1.gameContent.Load<Texture2D>("Enemies/banzaiBill");
                return new StaticSprite(banzaiBill);
            }
            if (sprite == sprites.deadBanzaiBill)
            {
                Texture2D deadBanzaiBill = Game1.gameContent.Load<Texture2D>("Enemies/deadBanzaiBill");
                return new StaticSprite(deadBanzaiBill);
            }
            if (sprite == sprites.walkingLeftDino)
            {
                Texture2D leftTallDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/walkingLeftDino");
                return new LeftTallDino(leftTallDino, 1, 2);
            }
            if (sprite == sprites.leftDeadDino)
            {
                Texture2D leftDeadDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/leftDeadDino");
                return new StaticSprite(leftDeadDino);
            }
            if (sprite == sprites.walkingLeftSquishedDino)
            {
                Texture2D leftSquishedDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/walkingLeftSquishedDino");
                return new LeftSmashedDino(leftSquishedDino, 1, 2);
            }
            if (sprite == sprites.walkingRightDino)
            {
                Texture2D rightTallDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/walkingRightDino");
                return new RightTallDino(rightTallDino, 1, 2);
            }
            if (sprite == sprites.walkingRightSquishedDino)
            {
                Texture2D rightSquishedDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/walkingRightSquishedDino");
                return new RightSmashedDino(rightSquishedDino, 1, 2);
            }
            if (sprite == sprites.deadShellessKoopa)
            {
                Texture2D deadShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/deadShellessKoopa");
                return new StaticSprite(deadShellessKoopa);
            }
            if (sprite == sprites.leftWalkShellessKoopa)
            {
                Texture2D leftShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/leftWalkShellessKoopa");
                return new LeftWalkingShellessKoopa(leftShellessKoopa, 1, 2);
            }
            if (sprite == sprites.rightWalkShellessKoopa)
            {
                Texture2D rightShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/rightWalkShellessKoopa");
                return new RightWalkingShellessKoopa(rightShellessKoopa, 1, 2);
            }

            //ITEMS
            if (sprite == sprites.oneUpMushroom)
            {
                Texture2D oneUpMushroom = Game1.gameContent.Load<Texture2D>("Items/1upMushroom");
                return new StaticSprite(oneUpMushroom);
            }
            if (sprite == sprites.superMushroom)
            {
                Texture2D superMushroom = Game1.gameContent.Load<Texture2D>("Items/SuperMushroom");
                return new StaticSprite(superMushroom);
            }
            if (sprite == sprites.fireFlower)
            {
                Texture2D fireFlower = Game1.gameContent.Load<Texture2D>("Items/FireFlower");
                return new FireFlowerSprite(fireFlower, 1, 2);
            }
            if (sprite == sprites.coin)
            {
                Texture2D coin = Game1.gameContent.Load<Texture2D>("Items/spinningCoin");
                return new CoinSprite(coin, 1, 4);
            }
            if (sprite == sprites.bluePipe)
            {
                Texture2D bluePipe = Game1.gameContent.Load<Texture2D>("Items/bluePipe");
                return new StaticSprite(bluePipe);
            }
            if (sprite == sprites.leftPipe)
            {
                Texture2D leftPipe = Game1.gameContent.Load<Texture2D>("Items/leftFacingPipe");
                return new StaticSprite(leftPipe);
            }
            if (sprite == sprites.downPipe)
            {
                Texture2D downPipe = Game1.gameContent.Load<Texture2D>("Items/downFacingPipe");
                return new StaticSprite(downPipe);
            }
            if (sprite == sprites.yellowPipe)
            {
                Texture2D yellowPipe = Game1.gameContent.Load<Texture2D>("Items/yellowPipe");
                return new StaticSprite(yellowPipe);
            }
            if (sprite == sprites.whitePipe)
            {
                Texture2D whitePipe = Game1.gameContent.Load<Texture2D>("Items/whitePipe");
                return new StaticSprite(whitePipe);
            }
            if (sprite == sprites.exitSign)
            {
                Texture2D exitSign = Game1.gameContent.Load<Texture2D>("Items/exitarrow");
                return new StaticSprite(exitSign);
            }
            if (sprite == sprites.exit)
            {
                Texture2D exit = Game1.gameContent.Load<Texture2D>("Items/gate");
                return new StaticSprite(exit);
            }
            if (sprite == sprites.star)
            {
                Texture2D star = Game1.gameContent.Load<Texture2D>("Items/star");
                return new StaticSprite(star);
            }
            if (sprite == sprites.bush1)
            {
                Texture2D bush1 = Game1.gameContent.Load<Texture2D>("Items/bush1");
                return new StaticSprite(bush1);
            }
            if (sprite == sprites.bush2)
            {
                Texture2D bush2 = Game1.gameContent.Load<Texture2D>("Items/bush2");
                return new StaticSprite(bush2);
            }
            if (sprite == sprites.bush3)
            {
                Texture2D bush3 = Game1.gameContent.Load<Texture2D>("Items/bush3");
                return new StaticSprite(bush3);
            }
            if (sprite == sprites.undergroundBackground)
            {
                Texture2D undergroundBackground = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundBackground");
                return new UndergroundBackgroundSprite(undergroundBackground, 1, 3);
            }
            if (sprite == sprites.overworldBackground)
            {
                Texture2D overworldBackground = Game1.gameContent.Load<Texture2D>("Overworld Sprites/background");
                return new OverworldBackgroundSprite(overworldBackground, 1, 1);
            }
            if (sprite == sprites.overworldHillsBackground)
            {
                Texture2D overworldHillsBackground = Game1.gameContent.Load<Texture2D>("Overworld Sprites/background2");
                return new OverworldBGHillsSprite(overworldHillsBackground, 1, 1);
            }
            if (sprite == sprites.fireball)
            {
                Texture2D fireball = Game1.gameContent.Load<Texture2D>("Items/fireball1");
                return new FireballSprite(fireball, 1, 4);
            }

            //BLOCKS
            if (sprite == sprites.usedBlock)
            {
                Texture2D usedBlock = Game1.gameContent.Load<Texture2D>("Items/usedBlock");
                return new StaticSprite(usedBlock);
            }
            if (sprite == sprites.brickBlock)
            {
                Texture2D stoneBlock = Game1.gameContent.Load<Texture2D>("Items/stoneBlock");
                return new StaticSprite(stoneBlock);
            }
            if (sprite == sprites.wingedBlock)
            {
                Texture2D wingedBlock = Game1.gameContent.Load<Texture2D>("Items/wingedBlock");
                return new WingedBlockSprite(wingedBlock, 1, 2);
            }
            if (sprite == sprites.exclamationBlock)
            {
                Texture2D exclamationBlock = Game1.gameContent.Load<Texture2D>("Items/exclamationBlock");
                return new StaticSprite(exclamationBlock);
            }
            if (sprite == sprites.questionBlock)
            {
                Texture2D questionBlock = Game1.gameContent.Load<Texture2D>("Items/questionBlock");
                return new QuestionBlockSprite(questionBlock, 1, 4);
            }
            if (sprite == sprites.ground)
            {
                Texture2D ground = Game1.gameContent.Load<Texture2D>("ground tile");
                return new StaticSprite(ground);
            }
            if (sprite == sprites.leftEdge)
            {
                Texture2D leftEdge = Game1.gameContent.Load<Texture2D>("Items/leftGroundEdge");
                return new StaticSprite(leftEdge);
            }
            if (sprite == sprites.rightEdge)
            {
                Texture2D rightEdge = Game1.gameContent.Load<Texture2D>("Items/rightGroundEdge");
                return new StaticSprite(rightEdge);
            }
            if (sprite == sprites.undergroundFloor)
            {
                Texture2D undergroundFloor = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundFloor");
                return new StaticSprite(undergroundFloor);
            }
            if (sprite == sprites.undergroundLeftBottomCorner)
            {
                Texture2D undergroundLeftBottomCorner = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundLeftBottomCorner");
                return new StaticSprite(undergroundLeftBottomCorner);
            }
            if (sprite == sprites.undergroundRightBottomCorner)
            {
                Texture2D undergroundRightBottomCorner = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundRightBottomCorner");
                return new StaticSprite(undergroundRightBottomCorner);
            }
            if (sprite == sprites.undergroundLeftTopCorner)
            {
                Texture2D undergroundLeftTopCorner = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundLeftTopCorner");
                return new StaticSprite(undergroundLeftTopCorner);
            }
            if (sprite == sprites.undergroundRightTopCorner)
            {
                Texture2D undergroundRightTopCorner = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundRightTopCorner");
                return new StaticSprite(undergroundRightTopCorner);
            }
            if (sprite == sprites.undergroundRoof)
            {
                Texture2D undergroundRoof = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundRoof");
                return new StaticSprite(undergroundRoof);
            }
            if (sprite == sprites.undergroundLeftWall)
            {
                Texture2D undergroundLeftWall = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundLeftWall");
                return new StaticSprite(undergroundLeftWall);
            }
            if (sprite == sprites.undergroundRightWall)
            {
                Texture2D undergroundRightWall = Game1.gameContent.Load<Texture2D>("Underground Sprites/undergroundRightWall");
                return new StaticSprite(undergroundRightWall);
            }

            //SMALL MARIO
            if (sprite == sprites.deadMario)
            {
                Texture2D deadMario = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/deadMario");
                return new StaticSprite(deadMario);
            }
            if (sprite == sprites.leftCrouchingMarioSmall)
            {
                Texture2D leftCrouchingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftCrouchingMarioSmall");
                return new StaticSprite(leftCrouchingMarioSmall);
            }
            if (sprite == sprites.leftIdleMarioSmall)
            {
                Texture2D leftIdleMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftIdleMarioSmall");
                return new StaticSprite(leftIdleMarioSmall);
            }
            if (sprite == sprites.leftJumpingMarioSmall)
            {
                Texture2D leftJumpingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftJumpingMarioSmall");
                return new StaticSprite(leftJumpingMarioSmall);
            }
            if (sprite == sprites.leftMovingMarioSmall)
            {
                Texture2D leftMovingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftMovingMarioSmall");
                return new MarioMovingSprite(leftMovingMarioSmall, 1, 2);
            }
            if (sprite == sprites.rightCrouchingMarioSmall)
            {
                Texture2D rightCrouchingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightCrouchingMarioSmall");
                return new StaticSprite(rightCrouchingMarioSmall);
            }
            if (sprite == sprites.rightIdleMarioSmall)
            {
                Texture2D rightIdleMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightIdleMarioSmall");
                return new StaticSprite(rightIdleMarioSmall);
            }
            if (sprite == sprites.rightJumpingMarioSmall)
            {
                Texture2D rightJumpingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightJumpingMarioSmall");
                return new StaticSprite(rightJumpingMarioSmall);
            }
            if (sprite == sprites.rightMovingMarioSmall)
            {
                Texture2D rightMovingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightMovingMarioSmall");
                return new MarioMovingSprite(rightMovingMarioSmall, 1, 2);
            }
            if (sprite == sprites.rightSprintMarioSmall)
            {
                Texture2D rightSprintMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/smallMarioRightSprint");
                return new MarioMovingSprite(rightSprintMarioSmall, 1, 3);
            }
            if (sprite == sprites.leftSprintMarioSmall)
            {
                Texture2D leftSprintMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/smallMarioLeftSprint");
                return new MarioMovingSprite(leftSprintMarioSmall, 1, 3);
            }
            if (sprite == sprites.victoryMarioSmall)
            {
                Texture2D victoryMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/smallMarioVictory");
                return new StaticSprite(victoryMarioSmall);
            }

            //BIG MARIO
            if (sprite == sprites.leftCrouchingMarioBig)
            {
                Texture2D leftCrouchingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftCrouchingMarioBig");
                return new StaticSprite(leftCrouchingMarioBig);
            }
            if (sprite == sprites.leftIdleMarioBig)
            {
                Texture2D leftIdleMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftIdleMarioBig");
                return new StaticSprite(leftIdleMarioBig);
            }
            if (sprite == sprites.leftJumpingMarioBig)
            {
                Texture2D leftJumpingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftJumpingMarioBig");
                return new StaticSprite(leftJumpingMarioBig);
            }
            if (sprite == sprites.leftMovingMarioBig)
            {
                Texture2D leftMovingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftMovingMarioBig");
                return new MarioMovingSprite(leftMovingMarioBig, 1, 3);
            }
            if (sprite == sprites.rightCrouchingMarioBig)
            {
                Texture2D rightCrouchingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightCrouchingMarioBig");
                return new StaticSprite(rightCrouchingMarioBig);
            }
            if (sprite == sprites.rightIdleMarioBig)
            {
                Texture2D rightIdleMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightIdleMarioBig");
                return new StaticSprite(rightIdleMarioBig);
            }
            if (sprite == sprites.rightJumpingMarioBig)
            {
                Texture2D rightJumpingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightJumpingMarioBig");
                return new StaticSprite(rightJumpingMarioBig);
            }
            if (sprite == sprites.rightMovingMarioBig)
            {
                Texture2D rightMovingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightMovingMarioBig");
                return new MarioMovingSprite(rightMovingMarioBig, 1, 3);
            }
            if (sprite == sprites.rightSprintMarioBig)
            {
                Texture2D rightSprintMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/bigMarioRightSprint");
                return new MarioMovingSprite(rightSprintMarioBig, 1, 3);
            }
            if (sprite == sprites.leftSprintMarioBig)
            {
                Texture2D leftSprintMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/bigMarioLeftSprint");
                return new MarioMovingSprite(leftSprintMarioBig, 1, 3);
            }
            if (sprite == sprites.victoryMarioBig)
            {
                Texture2D victoryMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/victoryMarioBig");
                return new StaticSprite(victoryMarioBig);
            }


            //FIRE MARIO
            if (sprite == sprites.leftCrouchingMarioFire)
            {
                Texture2D leftCrouchingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingCrouchingMarioFire");
                return new StaticSprite(leftCrouchingMarioFire);
            }
            if (sprite == sprites.leftIdleMarioFire)
            {
                Texture2D leftIdleMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingIdleMarioFire");
                return new StaticSprite(leftIdleMarioFire);
            }
            if (sprite == sprites.leftJumpingMarioFire)
            {
                Texture2D leftJumpingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingJumpingMarioFire");
                return new StaticSprite(leftJumpingMarioFire);
            }
            if (sprite == sprites.leftMovingMarioFire)
            {
                Texture2D leftMovingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/movingLeftMarioFire");
                return new MarioMovingSprite(leftMovingMarioFire, 1, 3);
            }
            if (sprite == sprites.rightCrouchingMarioFire)
            {
                Texture2D rightCrouchingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFacingCrouchingMarioFire");
                return new StaticSprite(rightCrouchingMarioFire);
            }
            if (sprite == sprites.rightIdleMarioFire)
            {
                Texture2D rightIdleMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightidlemariofire");
                return new StaticSprite(rightIdleMarioFire);
            }
            if (sprite == sprites.rightJumpingMarioFire)
            {
                Texture2D rightJumpingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFacingJumpingMarioFire");
                return new StaticSprite(rightJumpingMarioFire);
            }
            if (sprite == sprites.rightMovingMarioFire)
            {
                Texture2D rightMovingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/movingRightMarioFire");
                return new MarioMovingSprite(rightMovingMarioFire, 1, 3);
            }
            if (sprite == sprites.victoryMarioFire)
            {
                Texture2D victoryMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/victoryMarioFire");
                return new StaticSprite(victoryMarioFire);
            }
            if (sprite == sprites.leftFireballMarioFire)
            {
                Texture2D leftFireballMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFireballMarioFire");
                return new StaticSprite(leftFireballMarioFire);
            }
            if (sprite == sprites.rightFireballMarioFire)
            {
                Texture2D rightFireballMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFireballMarioFire");
                return new StaticSprite(rightFireballMarioFire);
            }

            return product;
        }
    }
}

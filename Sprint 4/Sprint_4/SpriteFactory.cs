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
            //enemies
            leftDeadDino, rightDeadDino, walkingLeftDino, walkingRightDino,
            walkingRightSquishedDino, walkingLeftSquishedDino, deadShellessKoopa, leftWalkShellessKoopa, rightWalkShellessKoopa,
            banzaiBill, deadBanzaiBill, piranhaPlant, 
            //items
            oneUpMushroom, fireFlower, superMushroom, coin, redShell, star,
            //blocks
            questionBlock, brickBlock, usedBlock, wingedBlock, exclamationBlock, 
            //background
            bluePipe, bush1, bush2, bush3, launcherPiper, launcherPipeSupport, yellowPipe, whitePipe, exitSign,
            ground,
            //Mario big
            leftCrouchingMarioBig,  leftIdleMarioBig, leftJumpingMarioBig,  
            leftMovingMarioBig, leftQuickturnMarioBig, leftShellKickMarioBig, leftSlidingMarioBig, rightCrouchingMarioBig,
            rightIdleMarioBig, rightJumpingMarioBig,  rightMovingMarioBig, 
            rightQuickturnMarioBig, rightShellKickMarioBig, victoryMarioBig,
            //Mario fire
            leftCrouchingMarioFire, leftIdleMarioFire, leftJumpingMarioFire, leftQuickturnMarioFire, 
            leftFireballMarioFire, leftMovingMarioFire, rightMovingMarioFire, rightCrouchingMarioFire,
            rightJumpingMarioFire, rightQuickturnMarioFire, rightFireballMarioFire,
            rightIdleMarioFire, victoryMarioFire,
            //Mario small
            deadMario, leftCrouchingMarioSmall, leftIdleMarioSmall, leftJumpingMarioSmall, 
            leftMovingMarioSmall, rightCrouchingMarioSmall, rightIdleMarioSmall, rightJumpingMarioSmall, 
            rightMovingMarioSmall
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
                return new BanzaiBillSprite(banzaiBill, 1, 1);
            }
            if (sprite == sprites.walkingLeftDino)
            {
                Texture2D leftTallDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/walkingLeftDino");
                return new LeftTallDino(leftTallDino, 1, 2);
            }
            if (sprite == sprites.leftDeadDino)
            {
                Texture2D leftDeadDino = Game1.gameContent.Load<Texture2D>("Enemies/Dino/leftDeadDino");
                return new DeadDino(leftDeadDino, 1, 1);
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
            if (sprite == sprites.piranhaPlant)
            {
                Texture2D piranhaPlant = Game1.gameContent.Load<Texture2D>("Enemies/piranhaPlant");
                return new PiranhaPlant(piranhaPlant, 1, 4);
            }
            if (sprite == sprites.deadShellessKoopa)
            {
                Texture2D deadShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/deadShellessKoopa");
                return new DeadShellessKoopa(deadShellessKoopa, 1, 1);
            }
            if (sprite == sprites.leftWalkShellessKoopa)
            {
                Texture2D leftShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/leftWalkShellessKoopa");
                return new LeftWalkingShellessKoopa(leftShellessKoopa, 2, 1);
            }
            if (sprite == sprites.rightWalkShellessKoopa)
            {
                Texture2D rightShellessKoopa = Game1.gameContent.Load<Texture2D>("Enemies/Shell-Less Koopa/rightWalkShellessKoopa");
                return new RightWalkingShellessKoopa(rightShellessKoopa, 2, 1);
            }
            if (sprite == sprites.deadBanzaiBill)
            {
                Texture2D deadBanzaiBill = Game1.gameContent.Load<Texture2D>("Enemies/deadBanzaiBill");
                return new RightWalkingShellessKoopa(deadBanzaiBill, 1, 1);
            }

            //ITEMS
            if (sprite == sprites.oneUpMushroom)
            {
                Texture2D oneUpMushroom = Game1.gameContent.Load<Texture2D>("Items/1upMushroom");
                return new OneUpMushroomSprite(oneUpMushroom, 1, 1);
            }
            if (sprite == sprites.superMushroom)
            {
                Texture2D superMushroom = Game1.gameContent.Load<Texture2D>("Items/SuperMushroom");
                return new SuperMushroomSprite(superMushroom, 1, 1);
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
            if (sprite == sprites.redShell)
            {
                Texture2D redShell = Game1.gameContent.Load<Texture2D>("Items/ShellRed");
                return new RedShellSprite(redShell, 1, 1);
            }
            if (sprite == sprites.bluePipe)
            {
                Texture2D bluePipe = Game1.gameContent.Load<Texture2D>("Items/bluePipe");
                return new BluePipeSprite(bluePipe, 1, 1);
            }
            if (sprite == sprites.yellowPipe)
            {
                Texture2D yellowPipe = Game1.gameContent.Load<Texture2D>("Items/yellowPipe");
                return new YellowPipeSprite(yellowPipe, 1, 1);
            }
            if (sprite == sprites.whitePipe)
            {
                Texture2D whitePipe = Game1.gameContent.Load<Texture2D>("Items/whitePipe");
                return new WhitePipeSprite(whitePipe, 1, 1);
            }
            if (sprite == sprites.exitSign)
            {
                Texture2D exitSign = Game1.gameContent.Load<Texture2D>("Items/exitarrow");
                return new ExitSignSprite(exitSign, 1, 1);
            }
            if (sprite == sprites.star)
            {
                Texture2D star = Game1.gameContent.Load<Texture2D>("Items/star");
                return new StarSprite(star, 1, 1);
            }
            if (sprite == sprites.bush1)
            {
                Texture2D bush1 = Game1.gameContent.Load<Texture2D>("Items/bush1");
                return new Bush1Sprite(bush1, 1, 1);
            }
            if (sprite == sprites.bush2)
            {
                Texture2D bush2 = Game1.gameContent.Load<Texture2D>("Items/bush2");
                return new Bush2Sprite(bush2, 1, 1);
            }
            if (sprite == sprites.bush3)
            {
                Texture2D bush3 = Game1.gameContent.Load<Texture2D>("Items/bush3");
                return new Bush3Sprite(bush3, 1, 1);
            }

            //BLOCKS
            if (sprite == sprites.usedBlock)
            {
                Texture2D usedBlock = Game1.gameContent.Load<Texture2D>("Items/usedBlock");
                return new UsedBlockSprite(usedBlock, 1, 1);
            }
            if (sprite == sprites.brickBlock)
            {
                Texture2D stoneBlock = Game1.gameContent.Load<Texture2D>("Items/stoneBlock");
                return new StoneBlockSprite(stoneBlock, 1, 1);
            }
            if (sprite == sprites.wingedBlock)
            {
                Texture2D wingedBlock = Game1.gameContent.Load<Texture2D>("Items/wingedBlock");
                return new WingedBlockSprite(wingedBlock, 1, 2);
            }
            if (sprite == sprites.exclamationBlock)
            {
                Texture2D exclamationBlock = Game1.gameContent.Load<Texture2D>("Items/exclamationBlock");
                return new ExclamationBlockSprite(exclamationBlock, 1, 1);
            }
            if (sprite == sprites.questionBlock)
            {
                Texture2D questionBlock = Game1.gameContent.Load<Texture2D>("Items/questionBlock");
                return new QuestionBlockSprite(questionBlock, 1, 4);
            }
            if (sprite == sprites.ground)
            {
                Texture2D ground = Game1.gameContent.Load<Texture2D>("ground tile");
                return new GroundBlockSprite(ground, 1, 1);
            }


            //MARIOS
            //small
            if (sprite == sprites.deadMario)
            {
                Texture2D deadMario = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/deadMario");
                return new DeadMarioSprite(deadMario, 1, 1);
            }
            if (sprite == sprites.leftCrouchingMarioSmall)
            {
                Texture2D leftCrouchingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftCrouchingMarioSmall");
                return new LeftCrouchingMarioSmallSprite(leftCrouchingMarioSmall, 1, 1);
            }
            if (sprite == sprites.leftIdleMarioSmall)
            {
                Texture2D leftIdleMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftIdleMarioSmall");
                return new LeftIdleMarioSmallSprite(leftIdleMarioSmall, 1, 1);
            }
            if (sprite == sprites.leftJumpingMarioSmall)
            {
                Texture2D leftJumpingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftJumpingMarioSmall");
                return new LeftJumpingMarioSmallSprite(leftJumpingMarioSmall, 1, 1);
            }
            if (sprite == sprites.leftMovingMarioSmall)
            {
                Texture2D leftMovingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/leftMovingMarioSmall");
                return new LeftMovingMarioSmallSprite(leftMovingMarioSmall, 1, 2);
            }
            if (sprite == sprites.rightCrouchingMarioSmall)
            {
                Texture2D rightCrouchingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightCrouchingMarioSmall");
                return new RightCrouchingMarioSmallSprite(rightCrouchingMarioSmall, 1, 1);
            }
            if (sprite == sprites.rightIdleMarioSmall)
            {
                Texture2D rightIdleMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightIdleMarioSmall");
                return new RightIdleMarioSmallSprite(rightIdleMarioSmall, 1, 1);
            }
            if (sprite == sprites.rightJumpingMarioSmall)
            {
                Texture2D rightJumpingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightJumpingMarioSmall");
                return new RightJumpingMarioSmallSprite(rightJumpingMarioSmall, 1, 1);
            }
            if (sprite == sprites.rightMovingMarioSmall)
            {
                Texture2D rightMovingMarioSmall = Game1.gameContent.Load<Texture2D>("Mario Sprites/Small Mario/rightMovingMarioSmall");
                return new RightMovingMarioSmallSprite(rightMovingMarioSmall, 1, 2);
            }

            //BIG
            if (sprite == sprites.leftCrouchingMarioBig)
            {
                Texture2D leftCrouchingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftCrouchingMarioBig");
                return new LeftCrouchingMarioBigSprite(leftCrouchingMarioBig, 1, 1);
            }

            if (sprite == sprites.leftIdleMarioBig)
            {
                Texture2D leftIdleMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftIdleMarioBig");
                return new LeftIdleMarioBigSprite(leftIdleMarioBig, 1, 1);
            }
            if (sprite == sprites.leftJumpingMarioBig)
            {
                Texture2D leftJumpingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftJumpingMarioBig");
                return new LeftJumpingMarioBigSprite(leftJumpingMarioBig, 1, 1);
            }
            if (sprite == sprites.leftMovingMarioBig)
            {
                Texture2D leftMovingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/leftMovingMarioBig");
                return new LeftMovingMarioBigSprite(leftMovingMarioBig, 1, 3);
            }
            if (sprite == sprites.rightCrouchingMarioBig)
            {
                Texture2D rightCrouchingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightCrouchingMarioBig");
                return new RightCrouchingMarioBigSprite(rightCrouchingMarioBig, 1, 1);
            }
            if (sprite == sprites.rightIdleMarioBig)
            {
                Texture2D rightIdleMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightIdleMarioBig");
                return new RightIdleMarioBigSprite(rightIdleMarioBig, 1, 1);
            }
            if (sprite == sprites.rightJumpingMarioBig)
            {
                Texture2D rightJumpingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightJumpingMarioBig");
                return new RightJumpingMarioBigSprite(rightJumpingMarioBig, 1, 1);
            }
            if (sprite == sprites.rightMovingMarioBig)
            {
                Texture2D rightMovingMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/rightMovingMarioBig");
                return new RightMovingMarioBigSprite(rightMovingMarioBig, 1, 3);
            }
            if (sprite == sprites.victoryMarioBig)
            {
                Texture2D victoryMarioBig = Game1.gameContent.Load<Texture2D>("Mario Sprites/Big Mario/victoryMarioBig");
                return new VictoryMarioBigSprite(victoryMarioBig, 1, 1);
            }


            //FIRE
            if (sprite == sprites.leftCrouchingMarioFire)
            {
                Texture2D leftCrouchingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingCrouchingMarioFire");
                return new LeftCrouchingMarioFireSprite(leftCrouchingMarioFire, 1, 1);
            }
            if (sprite == sprites.leftIdleMarioFire)
            {
                Texture2D leftIdleMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingIdleMarioFire");
                return new LeftIdleMarioFireSprite(leftIdleMarioFire, 1, 1);
            }
            if (sprite == sprites.leftJumpingMarioFire)
            {
                Texture2D leftJumpingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFacingJumpingMarioFire");
                return new LeftJumpingMarioFireSprite(leftJumpingMarioFire, 1, 1);
            }
            if (sprite == sprites.leftMovingMarioFire)
            {
                Texture2D leftMovingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/movingLeftMarioFire");
                return new LeftMovingMarioFireSprite(leftMovingMarioFire, 1, 3);
            }
            if (sprite == sprites.rightCrouchingMarioFire)
            {
                Texture2D rightCrouchingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFacingCrouchingMarioFire");
                return new RightCrouchingMarioFireSprite(rightCrouchingMarioFire, 1, 1);
            }
            if (sprite == sprites.rightIdleMarioFire)
            {
                Texture2D rightIdleMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightidlemariofire");
                return new RightIdleMarioFireSprite(rightIdleMarioFire, 1, 1);
            }
            if (sprite == sprites.rightJumpingMarioFire)
            {
                Texture2D rightJumpingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFacingJumpingMarioFire");
                return new RightJumpingMarioFireSprite(rightJumpingMarioFire, 1, 1);
            }
            if (sprite == sprites.rightMovingMarioFire)
            {
                Texture2D rightMovingMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/movingRightMarioFire");    
                return new RightMovingMarioFireSprite(rightMovingMarioFire, 1, 3);
            }
            if (sprite == sprites.victoryMarioFire)
            {
                Texture2D victoryMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/victoryMarioFire");
                return new VictoryMarioFireSprite(victoryMarioFire, 1, 1);
            }
            if (sprite == sprites.leftFireballMarioFire)
            {
                Texture2D leftFireballMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/leftFireballMarioFire");
                return new LeftFireballMarioFireSprite(leftFireballMarioFire, 1, 1);
            }
            if (sprite == sprites.rightFireballMarioFire)
            {
                Texture2D rightFireballMarioFire = Game1.gameContent.Load<Texture2D>("Mario Sprites/Fire Mario/rightFireballMarioFire");
                return new RightFireballMarioFireSprite(rightFireballMarioFire, 1, 1);
            }

            return product;
        }
    }
}

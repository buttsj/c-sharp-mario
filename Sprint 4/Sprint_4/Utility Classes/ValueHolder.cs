using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ValueHolder
    {
        //points
        public static int coinCollectPoints = 200;
        public static int enemyHurtPoints = 100;
        public static int itemCollectPoints = 1000;
        public static int remainingTimePoints = 50;
        public static int brickBreakPoints = 50;

        public static int fallingMarioBoundary = 500;

        //items
        public static double itemSpawnRate = .3;
        public static int itemSpawnTimer = 50;

        //physics
        public static Vector2 leftMarioIdlingRange = new Vector2((float)-.2, (float)-.1);
        public static Vector2 rightMarioIdlingRange = new Vector2((float).2, (float).1);
        public static float jumpingVelocity = 2;
        public static float walkingVelocity = 1;
        public static int flipFallRate = 3;
        public static int maxCoins = 100;
        public static int maxInvinciblityTime = 100;
        public static int maxStarTime = 1000;
        public static int maxNinjaTime = 1500;
        public static int normalAnimationTimer = 90;
        public static int slowdownRate = 3;
        public static Vector2 textPosition = new Vector2(-40, 120);

        //HUD
        public static Rectangle coinSpritePos = new Rectangle(650, 30, 53, 25);
        public static Vector2 coinTextPos = new Vector2(750, 26);
        public static Rectangle livesSpritePos = new Rectangle(30, 30, 132, 29);
        public static Vector2 livesTextPos = new Vector2(60, 55);
        public static Rectangle timeSpritePos = new Rectangle(500, 30, 82, 25);
        public static Vector2 timeTextPos = new Vector2(530, 55);
        public static Vector2 scoreTextPos = new Vector2(650, 55);
        public static Color blackScreenText = Color.White;
        public static Color normalScreenText = Color.Black;
        public static int startingLives = 3;
        public static int startingTime = 300;
        public static int hurryTime = 100;
        public static int achTimer = 200;
        public static int achGained = 0;

        //projectiles
        public static int projectileXSpawn = 5;
        public static int projectileYSpawn = 3;
        public static int projectileDelay = 10;
        public static int maxFireballs = 3;
        public static int maxThrowingStars = 6;


        //camera
        public static int camClamp = -200;

        //BG
        public static Rectangle undergroundBGPos = new Rectangle(0, 0, 1000, 600);
    }
}

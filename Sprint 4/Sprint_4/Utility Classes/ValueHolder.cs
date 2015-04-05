using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class ValueHolder
    {
        public static int enemyHurtPoints = 100;
        public static int itemCollectPoints = 1000;
        public static int maxCoins = 100;
        public static int coinCollectPoints = 200;
        public static Vector2 rightMarioIdlingRange = new Vector2((float).2, (float).1);
        public static Vector2 leftMarioIdlingRange = new Vector2((float)-.2, (float)-.1);
        public static int itemSpawnTimer = 50;
        public static double itemSpawnRate = .3;
        public static int normalAnimationTimer = 90;
        public static int timerStart = 600;
        public static Vector2 textPosition = new Vector2(-40, 110);
        public static int remainingTimePoints = 50;
        public static int slowdownRate = 3;
    }
}

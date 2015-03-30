using System;

namespace Sprint4
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Game1 game = Game1.GetInstance())
            {
                game.Run();
            }
        }
    }
#endif
}


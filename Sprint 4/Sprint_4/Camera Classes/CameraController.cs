using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;

namespace Sprint4
{
    class CameraController
    {
       
        private Game1 game;
        private Vector2 location;
        private float height;
        private float width;


        public CameraController(Game1 game)
        {
            this.game = game;
            this.location = Vector2.Zero;
            this.height = 0;
            this.width = 0;
        }

        
    }
}

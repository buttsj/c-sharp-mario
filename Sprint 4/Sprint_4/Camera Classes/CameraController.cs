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
        private KeyboardState keyboardState;
        private Game1 game;

        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public CameraController(Game1 game)
        {
            this.game = game;

        }

        
    }
}

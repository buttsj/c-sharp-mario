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
    class PauseMenuKeyController : IController
    {
        private KeyboardState keyboardState;
        private Game1 game;

        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public PauseMenuKeyController(Game1 game)
        {
            this.game = game;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand(this.game));
            //commandLibrary.Add(Keys.Q, currentCommand = new TestQuitCommand(this.game));
        }

        public void Update()
        {
            currentCommand = new NullCommand(game);
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                }
                    currentCommand.Execute();              
           }
        }
    }
}

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

        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public PauseMenuKeyController()
        {
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand());
            commandLibrary.Add(Keys.Q, currentCommand = new QuitCommand());
        }

        public void Update()
        {
            currentCommand = new NullCommand();
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    currentCommand.Execute();    
                }          
           }
        }
    }
}

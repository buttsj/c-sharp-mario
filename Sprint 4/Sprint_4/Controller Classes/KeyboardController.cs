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
    public class KeyboardController : IController
    {
        private KeyboardState keyboardState;
        Mario mario;
        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public KeyboardController(Mario mario)
        {
            this.mario = mario;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new UpCommand(mario));
            commandLibrary.Add(Keys.X, currentCommand = new RunCommand(mario));
            commandLibrary.Add(Keys.Up, currentCommand = new UpCommand(mario));
            commandLibrary.Add(Keys.S, currentCommand = new DownCommand(mario));
            commandLibrary.Add(Keys.Down, currentCommand = new DownCommand(mario));
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand(mario));
            commandLibrary.Add(Keys.Left, currentCommand = new LeftCommand(mario));
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand(mario));
            commandLibrary.Add(Keys.Right, currentCommand = new RightCommand(mario));
            commandLibrary.Add(Keys.B, currentCommand = new ProjectileCommand(mario));
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand());
            commandLibrary.Add(Keys.Q, currentCommand = new QuitCommand());
            commandLibrary.Add(Keys.R, currentCommand = new ResetSceneCommand());
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
            mario.Idle();
        }
    }
}

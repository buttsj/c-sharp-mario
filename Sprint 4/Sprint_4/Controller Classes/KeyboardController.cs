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
    class KeyboardController : IController
    {
        private KeyboardState keyboardState;

        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public KeyboardController()
        {
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new UpCommand());
            commandLibrary.Add(Keys.X, currentCommand = new RunCommand());
            commandLibrary.Add(Keys.Up, currentCommand = new UpCommand());
            commandLibrary.Add(Keys.S, currentCommand = new DownCommand());
            commandLibrary.Add(Keys.Down, currentCommand = new DownCommand());
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand());
            commandLibrary.Add(Keys.Left, currentCommand = new LeftCommand());
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand());
            commandLibrary.Add(Keys.Right, currentCommand = new RightCommand());
            commandLibrary.Add(Keys.B, currentCommand = new FireballCommand());
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
            if ((Game1.GetInstance().level.mario.velocity.X < .2 && Game1.GetInstance().level.mario.velocity.X > -.2) &&
               (Game1.GetInstance().level.mario.velocity.Y < .1 && Game1.GetInstance().level.mario.velocity.Y > -.1) && 
               !Game1.GetInstance().level.mario.physState.GetType().Equals((new FallingState()).GetType()))
            {
               currentCommand = new IdleCommand();
               currentCommand.Execute();
           }
        }
    }
}

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
    class VVVVVVKeyController : IController
    {
        private KeyboardState keyboardState;
        Mario mario;
        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public VVVVVVKeyController(Mario mario)
        {
            this.mario = mario;
            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new FlipCommand(mario));
            commandLibrary.Add(Keys.Up, currentCommand = new FlipCommand(mario));
            commandLibrary.Add(Keys.S, currentCommand = new FlipCommand(mario));
            commandLibrary.Add(Keys.Down, currentCommand = new FlipCommand(mario));
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand(mario));
            commandLibrary.Add(Keys.Left, currentCommand = new LeftCommand(mario));
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand(mario));
            commandLibrary.Add(Keys.Right, currentCommand = new RightCommand(mario));
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
            if ((mario.velocity.X < ValueHolder.rightMarioIdlingRange.X && mario.velocity.X > ValueHolder.leftMarioIdlingRange.X) &&
               (mario.velocity.Y < ValueHolder.rightMarioIdlingRange.Y && mario.velocity.Y > ValueHolder.leftMarioIdlingRange.Y) && 
               !mario.physState.GetType().Equals((new FallingState()).GetType()))
            {
               currentCommand = new IdleCommand(mario);
               currentCommand.Execute();
           }
        }
    }
}

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
    public class VVVVVVKeyController : IController
    {
        private KeyboardState keyboardState;
        Mario mario;
        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;
        int flipPatience = 15;
        int flipBuffer = 0;
        ICommands flip;

        public VVVVVVKeyController(Mario mario)
        {
            flip = new FlipCommand(mario);
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
            flipBuffer++;
            currentCommand = new NullCommand();
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                    if (currentCommand.GetType() == flip.GetType())
                    {
                        if (flipBuffer >= flipPatience)
                        {
                            currentCommand.Execute();
                            flipBuffer = 0;
                        }
                    }
                    else
                    {
                        currentCommand.Execute();
                    }
                } 
           }
            if (currentCommand.GetType() == new NullCommand().GetType())
            {
               currentCommand = new IdleCommand(mario);
               currentCommand.Execute();
           }
        }
    }
}

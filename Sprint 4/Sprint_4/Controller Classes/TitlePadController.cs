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
    class TitlePadController : IController
    {
        private GamePadState gamepadState;
        public List<ICommands> commands;

        public TitlePadController()
        {
        }

        public void Update()
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            commands = new List<ICommands>();
            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new LoadLevelCommand(StringHolder.levelTwo));
            }
            if (gamepadState.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
            {
                commands.Add(new QuitCommand());
            }
            foreach (ICommands command in commands)
            {
                command.Execute();
            }
        }
    }
}


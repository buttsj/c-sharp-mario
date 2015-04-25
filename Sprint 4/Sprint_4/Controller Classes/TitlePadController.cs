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
    public class TitlePadController : IController
    {
        private GamePadState gamepadState;
        public List<ICommands> commands;
        GUI menu;

        public TitlePadController(GUI menu)
        {
            this.menu = menu;
        }

        public void Update()
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            commands = new List<ICommands>();
            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new MenuSelectCommand(menu));
            }
            if (gamepadState.Buttons.A == ButtonState.Pressed)
            {
                commands.Add(new MenuSelectCommand(menu));
            }
            if (gamepadState.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
            {
                commands.Add(new QuitCommand());
            }
            if (gamepadState.DPad.Down == ButtonState.Pressed)
            {
                commands.Add(new MenuDownCommand(menu));
            }
            if (gamepadState.DPad.Up == ButtonState.Pressed)
            {
                commands.Add(new MenuUpCommand(menu));
            }
            foreach (ICommands command in commands)
            {
                command.Execute();
            }
        }
    }
}


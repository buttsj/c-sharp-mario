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
    public class VVVVVVPadController : IController
    {
        private GamePadState gamepadState;
        ICommands currentCommand;
        public List<ICommands> commands;
        Mario mario;

        public VVVVVVPadController(Mario mario)
        {
            this.mario = mario;
        }

        public void Update()
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            commands = new List<ICommands>();

            if (gamepadState.DPad.Left.Equals(ButtonState.Pressed))
            {
                commands.Add(new LeftCommand(mario));
            }
            if (gamepadState.DPad.Right.Equals(ButtonState.Pressed))
            {
                commands.Add(new RightCommand(mario));
            }
            if (gamepadState.DPad.Down.Equals(ButtonState.Pressed))
            {
                commands.Add(new FlipCommand(mario));
            }
            if (gamepadState.Buttons.A.Equals(ButtonState.Pressed))
            {
                commands.Add(new FlipCommand(mario));
            }
            if (gamepadState.Buttons.Back == ButtonState.Pressed)
            {
                commands.Add(new ResetSceneCommand());
            }
            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new PauseCommand());
            }
            if (gamepadState.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
            {
                commands.Add(new QuitCommand());
            }
            foreach (ICommands command in commands)
            {
                command.Execute();
            }
            mario.Idle();
        }
    }
}


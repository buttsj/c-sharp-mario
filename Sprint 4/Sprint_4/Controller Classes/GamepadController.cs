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
    class GamepadController : IController
    {
        private GamePadState gamepadState;
        ICommands currentCommand;
        public List<ICommands> commands;

        public GamepadController()
        {
        }

        public void Update()
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            commands = new List<ICommands>();

            if (gamepadState.DPad.Left.Equals(ButtonState.Pressed))
            {
                commands.Add(new LeftCommand());
            }
            if (gamepadState.DPad.Right.Equals(ButtonState.Pressed))
            {
                commands.Add(new RightCommand());
            }
            if (gamepadState.DPad.Down.Equals(ButtonState.Pressed))
            {
                commands.Add(new DownCommand());
            }
            if (gamepadState.Buttons.A.Equals(ButtonState.Pressed))
            {
                commands.Add(new UpCommand());
            }
            if (gamepadState.Buttons.X.Equals(ButtonState.Pressed))
            {
                commands.Add(new RunCommand());
            }
            if (gamepadState.Buttons.Back == ButtonState.Pressed)
            {
                commands.Add(new ResetSceneCommand());
            }
            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new PauseCommand());
            }
            if (gamepadState.Buttons.B.Equals(ButtonState.Pressed))
            {
                commands.Add(new FireballCommand());                              
            }
            if (gamepadState.Buttons.LeftShoulder.Equals(ButtonState.Pressed))
            {
                commands.Add(new QuitCommand());
            }
            foreach (ICommands command in commands)
            {
                command.Execute();
            }
            if ((Game1.GetInstance().level.mario.velocity.X < .1 && Game1.GetInstance().level.mario.velocity.X > -.1) &&
               (Game1.GetInstance().level.mario.velocity.Y < .1 && Game1.GetInstance().level.mario.velocity.Y > -.1) && 
               !Game1.GetInstance().level.mario.physState.GetType().Equals((new FallingState()).GetType()))
            {
                currentCommand = new IdleCommand();
                currentCommand.Execute();
            }
        }
    }
}


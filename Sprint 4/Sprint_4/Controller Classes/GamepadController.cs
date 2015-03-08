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
        private Game1 game;
        ICommands currentCommand;
        public List<ICommands> commands;

        public GamepadController(Game1 game)
        {
            this.game = game;
        }

        public void Update()
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyState = Keyboard.GetState();
            commands = new List<ICommands>();

            if (gamepadState.DPad.Left.Equals(ButtonState.Pressed))
            {
                commands.Add(new LeftCommand(this.game));
            }
            if (gamepadState.DPad.Right.Equals(ButtonState.Pressed))
            {
                commands.Add(new RightCommand(this.game));
            }
            if (gamepadState.DPad.Down.Equals(ButtonState.Pressed))
            {
                commands.Add(new DownCommand(this.game));
            }
            if (gamepadState.Buttons.A.Equals(ButtonState.Pressed))
            {
                commands.Add(new UpCommand(this.game));
            }
            if (gamepadState.Buttons.Back == ButtonState.Pressed)
            {
                commands.Add(new ResetSceneCommand(this.game));
            }
            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                commands.Add(new TestQuitCommand(this.game));
            }
            foreach (ICommands command in commands)
            {
                command.Execute();
            }
            if ((game.level.mario.velocity.X < .1 && game.level.mario.velocity.X > -.1) &&
               (game.level.mario.velocity.Y < .1 && game.level.mario.velocity.Y > -.1) && !game.level.mario.physState.GetType().Equals((new FallingState(game)).GetType()))
            {
                currentCommand = new IdleCommand(this.game);
                currentCommand.Execute();
            }
        }
    }
}


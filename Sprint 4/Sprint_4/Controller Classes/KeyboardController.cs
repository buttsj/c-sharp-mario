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
        private Game1 game;

        ICommands currentCommand;
        Dictionary<Keys, ICommands> commandLibrary;

        public KeyboardController(Game1 game)
        {
            this.game = game;

            commandLibrary = new Dictionary<Keys, ICommands>();
            commandLibrary.Add(Keys.W, currentCommand = new UpCommand(this.game));
            commandLibrary.Add(Keys.X, currentCommand = new RunCommand(this.game));
            commandLibrary.Add(Keys.Up, currentCommand = new UpCommand(this.game));
            commandLibrary.Add(Keys.S, currentCommand = new DownCommand(this.game));
            commandLibrary.Add(Keys.Down, currentCommand = new DownCommand(this.game));
            commandLibrary.Add(Keys.A, currentCommand = new LeftCommand(this.game));
            commandLibrary.Add(Keys.Left, currentCommand = new LeftCommand(this.game));
            commandLibrary.Add(Keys.D, currentCommand = new RightCommand(this.game));
            commandLibrary.Add(Keys.Right, currentCommand = new RightCommand(this.game));
            commandLibrary.Add(Keys.B, currentCommand = new FireballCommand(this.game));
            commandLibrary.Add(Keys.Enter, currentCommand = new PauseCommand(this.game));
            commandLibrary.Add(Keys.Q, currentCommand = new TestQuitCommand(this.game));
            commandLibrary.Add(Keys.R, currentCommand = new ResetSceneCommand(this.game));
        }

        public void Update()
        {
            currentCommand = new NullCommand(game);
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            keyboardState = Keyboard.GetState();
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (commandLibrary.ContainsKey(key))
                {
                    currentCommand = commandLibrary[key];
                }
                    currentCommand.Execute();                             
           }
           if((game.level.mario.velocity.X < .2 && game.level.mario.velocity.X > -.2) && 
               (game.level.mario.velocity.Y < .1 && game.level.mario.velocity.Y > -.1) && !game.level.mario.physState.GetType().Equals((new FallingState(game)).GetType())){
               currentCommand = new IdleCommand(this.game);
               currentCommand.Execute();
           }
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LivesScreenGameState :IGameState
    {
        Game1 game;
        int timer = 200;
        SpriteFont font;
        SpriteFactory factory;
        IAnimatedSprite item;

        public LivesScreenGameState(Game1 game)
        {
            this.game = game;
            font = game.Content.Load<SpriteFont>("SpriteFont1");
            factory = new SpriteFactory();
            item = factory.build(SpriteFactory.sprites.coin);
        }

        public void Update(GameTime gameTime)
        {
            timer--;
            if (timer <= 0)
            {
                game.level = new Level(game, "/Maps/Map.csv");
                game.gameState = new PlayGameState(game);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.gameCamera.LookAt(new Vector2(0, 0));
            spriteBatch.DrawString(font, "Lives: ", game.gameCamera.Origin, Color.White);
            //item.Draw(spriteBatch, game.gameCamera.Origin);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Camera
    {

        // Credit for general idea of Camera code: http://www.david-gouveia.com/portfolio/2d-camera-with-parallax-scrolling-in-xna/

        private Game1 game;
        private Viewport viewport;

        public Camera(Viewport viewport, Game1 game)
        {
            this.viewport = viewport;
            this.game = game;
            Origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
            Zoom = 2.0f;
        }
        
        public Vector2 Position = new Vector2(0, 125.0f);
        public Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public void LookAt(Vector2 position)
        {
            Position.X = position.X - viewport.Width / 2.0f;

            if (Position.X < -200)
                Position.X = -200;
        }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            return Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public bool InCameraView(Rectangle obj)
        {
            if (new Rectangle((int)(Position.X + 200), 250, ((int)(viewport.Width / 2.0f)) + 30, (int)(viewport.Height / 2.0f)).Intersects(obj))
            {
                return true;
            }
            return false;
        }
    }
}

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
        public Vector2 CameraPosition = new Vector2(0, 125.0f);
        public Vector2 CenterScreen { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public Camera(Viewport viewport, Game1 game)
        {
            this.viewport = viewport;
            this.game = game;
            CenterScreen = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
            Zoom = 2.0f;
        }

        public void LookAt(Vector2 position)
        {
            CameraPosition.X = position.X - viewport.Width / 2.0f;
            if (CameraPosition.X < -200)
                CameraPosition.X = -200;
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-CameraPosition, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-CenterScreen, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(CenterScreen, 0.0f));
        }

        public bool InCameraView(Rectangle obj)
        {
            if (new Rectangle((int)(CameraPosition.X + 200), 250, ((int)(viewport.Width / 2.0f)) + 30, (int)(viewport.Height / 2.0f)).Intersects(obj))
            {
                return true;
            }
            return false;
        }
    }
}

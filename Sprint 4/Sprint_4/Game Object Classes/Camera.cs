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
        int valOneAdjust = 200;
        int valTwo = 250;
        int valThreeAdjust = 30;

        public Camera(Viewport viewport, Game1 game)
        {
            this.viewport = viewport;
            this.game = game;
            Zoom = 2.0f;
            CenterScreen = new Vector2(viewport.Width / Zoom, viewport.Height / Zoom);
        }

        public void LookAt(Vector2 position)
        {
            CameraPosition.X = position.X - viewport.Width / Zoom;
            if (CameraPosition.X < ValueHolder.camClamp)
                CameraPosition.X = ValueHolder.camClamp;
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
            if (new Rectangle((int)(CameraPosition.X + valOneAdjust), valTwo, ((int)(viewport.Width / Zoom)) + 
                valThreeAdjust, (int)(viewport.Height / Zoom)).Intersects(obj))
            {
                return true;
            }
            return false;
        }
    }
}

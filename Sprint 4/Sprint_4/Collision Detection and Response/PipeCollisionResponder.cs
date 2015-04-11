using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class PipeCollisionResponder
    {
        Game1 game;

        public PipeCollisionResponder(Game1 game)
        {
            this.game = game;
        }
        
        public void PipeMarioCollide(Mario mario, Pipe pipe, List<Pipe> standingPipes)
        {
            Rectangle marioRect = mario.state.GetBoundingBox(new Vector2(mario.position.X, mario.position.Y));
            Rectangle pipeRect = pipe.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(marioRect, pipeRect);

            if (intersection.Height > intersection.Width)
            {
                if (marioRect.Right > pipeRect.Left && marioRect.Right < pipeRect.Right)
                {
                    mario.position.X -= intersection.Width;
                    if(pipe.state.GetType().Equals(new LeftPipeState().GetType())){
                        pipe.Eat(mario);
                    }
                }
                else
                {
                    mario.position.X += intersection.Width;
                }               
            }
            else if (intersection.Height < intersection.Width)
            {
                if (marioRect.Bottom > pipeRect.Top && marioRect.Bottom < pipeRect.Bottom)
                {  
                    if (!mario.physState.GetType().Equals((new JumpingState()).GetType()))
                    {
                        mario.velocity.Y = 0;
                    }
                    if (intersection.Height > 1)
                    {
                        mario.position.Y -= intersection.Height;
                    }
                    standingPipes.Add(pipe);
                    if (pipe.state.GetType().Equals(new UpPipeState().GetType()) && mario.isCrouch)
                    {
                        pipe.Eat(mario);
                    }
                }
                else
                {
                    mario.position.Y += intersection.Height;
                }
            }
        }

        public void PipeItemCollide(ICollectable item, Pipe pipe)
        {
            Rectangle itemRect = item.GetBoundingBox();
            Rectangle pipeRect = pipe.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(itemRect, pipeRect);
            if (intersection.Height > intersection.Width)
            {
                if (itemRect.Right > pipeRect.Left && itemRect.Right < pipeRect.Right)
                {
                    item.position = new Vector2(item.position.X - intersection.Width, item.position.Y);
                    item.GoLeft();
                }
                else
                {
                    item.position = new Vector2(item.position.X + intersection.Width, item.position.Y);
                    item.GoRight();
                }
            }
            else
            {
                if (itemRect.Bottom > pipeRect.Top && itemRect.Bottom < pipeRect.Bottom)
                {
                    item.position = new Vector2(item.position.X, item.position.Y - intersection.Height);
                }
                else
                {
                    item.position = new Vector2(item.position.X, item.position.Y + intersection.Height);
                }
            }
        }

        public void PipeEnemyCollide(Enemy enemy, Pipe pipe)
        {
            Rectangle enemyRect = enemy.GetBoundingBox();
            Rectangle pipeRect = pipe.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(enemyRect, pipeRect);
            if (intersection.Height > intersection.Width)
            {
                if (enemyRect.Right > pipeRect.Left && enemyRect.Right < pipeRect.Right)
                {
                    enemy.position.X = enemy.position.X - intersection.Width;
                    enemy.GoLeft();
                }
                else
                {
                    enemy.position.X = enemy.position.X + intersection.Width;
                    enemy.GoRight();
                }
            }
            else
            {
                if (enemyRect.Bottom > pipeRect.Top && enemyRect.Bottom < pipeRect.Bottom)
                {
                    enemy.position.Y = enemy.position.Y - intersection.Height;
                }
                else
                {
                    enemy.position.Y = enemy.position.Y + intersection.Height;
                }
            }
        }
    }
}

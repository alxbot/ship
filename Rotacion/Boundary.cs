using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Rotacion
{
    public class Boundary
    {
        public Vector2 pointA;
        public Vector2 pointB;
        public float dist;

        public Boundary(float x1, float y1, float x2, float y2)
        {
            pointA = new Vector2(x1, y1);
            pointB = new Vector2(x2, y2);

        }

        // Line
        public void dLine(Vector2 p1, Vector2 p2, SpriteBatch sb, Texture2D line)
        {

            float angle = (float)Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
            dist = Vector2.Distance(p1, p2);



            sb.Draw(line, new Rectangle((int)p2.X, (int)p2.Y, (int)dist, 4), null, Color.White, angle, Vector2.Zero, SpriteEffects.None, 0f);



        }
    }
}


/*
 
         public Boundary(float x1, float y1, float x2, float y2)
        {
            pointA = new Vector2(x1, y1);
            pointB = new Vector2(x2, y2);

        }
 
 
 */
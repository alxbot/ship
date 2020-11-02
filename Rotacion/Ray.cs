using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rotacion
{
    public class Ray
    {
        public Vector2 pos;
        public Vector2 dir;
        public float angle;

        public Ray(int x, int y, float rangle)
        {
            pos = new Vector2(x, y);
            // TODO Create a Vector from angle
            dir = new Vector2((float)Math.Sin(rangle), (float)Math.Cos(rangle));
            // dir = new Vector2(1, 0);
            angle = rangle;


        }

        public void LookAt(float x, float y) {

            dir.X = x - pos.X;
            dir.Y = y - pos.Y;
            dir.Normalize();


        }

       public void showLine(SpriteBatch sb, Texture2D line)
        {

            //float angle =
            //float dist = Vector2.Distance(p1, p2);
            int width = 400;
            int height = 1;
            sb.Draw(line, new Rectangle((int)pos.X, (int)pos.Y, width, height), null, Color.White, (float)Math.Atan2(dir.Y, dir.X) + MathHelper.ToRadians(angle), new Vector2(0,0), SpriteEffects.None, 0f);


        }



        /*
         
                 // Line
        public void dLine(Vector2 p1, Vector2 p2, SpriteBatch sb, Texture2D line)
        {

            float angle = (float)Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
            dist = Vector2.Distance(p1, p2);



            sb.Draw(line, new Rectangle((int)p2.X, (int)p2.Y, (int)dist, 4), null, Color.White, angle, Vector2.Zero, SpriteEffects.None, 0f);



        }
         
         
         
         */




        public Vector2 Cast( Boundary wall)
        {
            Vector2 pt = new Vector2();
            float x1 = wall.pointA.X;
            float y1 = wall.pointA.Y;

            float x2 = wall.pointB.X;
            float y2 = wall.pointB.Y;

            float x3 = pos.X;
            float y3 = pos.Y;

            float x4 = pos.X + dir.X;
            float y4 = pos.Y + dir.Y;

            float den = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            if (den == 0)
            {
                return Vector2.Zero;
            }

            float t = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4))/ den;
            float u = - ((x1 - x2) * (y1 - y3) - (y1 - y2) * (x1 - x3)) / den;

            if ( t > 0 && t < 1 && u > 0)
            {
                
                pt.X = x1 + t * (x2 - x1);
                pt.Y = y1 + t * (y2 - y1);
                return pt;
            } else
            {
                return Vector2.Zero;
            }

        }
    }
}


/*
         // ray
        private void ray(int x, int y ) {
            Vector2 pos = new Vector2(x, y);
            Vector2 dir = new Vector2(0, 1);
        }

t = esta entre 0 y 1
u = es mayor a 0
 
 */
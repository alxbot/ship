using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rotacion
{
    public class Particle
    {
        public Vector2 pos;
        public List<Ray> rays = new List<Ray>();
        float width = 30;
        float height = 30;

        private SpriteBatch sbf;
        private Texture2D linef;
        public Boundary wall;


        public Particle(SpriteBatch sb, Texture2D line, Vector2 position, Boundary bound)
        {
            pos = position;
            sbf = sb;
            linef = line;
            wall = bound;
            for ( int i = 0; i < 360; i++ ) {
                rays.Add(new Ray((int)position.X, (int)position.Y, i));
                //Console.WriteLine(rays[i / 10]);

            }

        }

        public void show() {
            for (int i = 0; i < rays.Count; i++) {
                Vector2 pt = rays[i].Cast(wall);
                if (pt != Vector2.Zero) {
                    // dibujar una linea desde la posición de partida hasta la posicion de llegada
                    new Boundary(pos.X, pos.Y, pt.X, pt.Y).dLine(pos, pt, sbf, linef); 
                    //rays[i].showLine(sbf, linef);
                }
            }
        }
    }
}

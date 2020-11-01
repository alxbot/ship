using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Rotacion
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //elem vars
        Texture2D ship;
        Vector2 position = new Vector2(100,100);
        //Rectangle elem = new Rectangle();
        float rotation = 0;//6.28f;
        Vector2 origin = new Vector2(50, 50); //mid
        Vector2 scale = new Vector2(1, 1);
        float depth = 1f;
        MouseState mousePos;


        Texture2D pixel16;


        // Mouse target distance

        float distance;
        float distanceX;
        float distanceY;

        // text out
        SpriteFont log;
        SpriteFont logShip;

        //Speed
        float speed = 10f;

        // ray
        Ray ray = new Ray(0, 0, 0);
        Boundary wall = new Boundary(400, 300, 300, 400);
        Boundary line = new Boundary(100, 200, 100, 210);
        Particle part;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _graphics.HardwareModeSwitch = true;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ship = Content.Load<Texture2D>("ship");

            log = Content.Load<SpriteFont>("spaceFont");
            logShip = Content.Load<SpriteFont>("spaceFont");


            // Pixel

            pixel16 = Content.Load<Texture2D>("wall");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mousePos = Mouse.GetState();

            distance = Vector2.Distance(position, new Vector2(mousePos.X, mousePos.Y));

            distanceX = mousePos.X - position.X ;
            distanceY = mousePos.Y - position.Y;



            rotation = (float)Math.Atan2(distanceY , distanceX); //* 360 / (float)Math.PI

            ray.LookAt(mousePos.X, mousePos.Y);

            //Keys

            if (Keyboard.GetState().IsKeyDown(Keys.A)) {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += speed;
            }


            base.Update(gameTime);
        }







        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();







            _spriteBatch.Draw(
                ship,
                position,
                null,
                Color.White,
                rotation,
                origin,
                scale,
                SpriteEffects.None,
                depth
                );


            //Data MousePos
            _spriteBatch.DrawString(
                log,
                $"Distance X = { distanceX.ToString()} Y = {distanceY.ToString()}",
                new Vector2(0, 0), // position
                Color.White //Color
               );



            //Data ShipPos
            _spriteBatch.DrawString(
                logShip,
                position.ToString(),
                new Vector2(0, 700), // position
                Color.White //Color
               );

            //Data ShipAngle
            _spriteBatch.DrawString(
                logShip,
                rotation.ToString(),
                new Vector2(0, 600), // position
                Color.White //Color
               );


            //Data RAY
            _spriteBatch.DrawString(
                logShip,
                ray.Cast(wall).ToString(),
                new Vector2(0, 400), // position
                Color.White //Color
               );




            //drawwing WALL line
            wall.dLine(wall.pointA, wall.pointB,_spriteBatch,pixel16);


            // drawing ray
            ray.showLine(_spriteBatch, pixel16);
            ray.pos.X = position.X;
            ray.pos.Y = position.Y;
            //line.dLine(line.pointA, line.pointB, _spriteBatch, pixel16);


            // square signal
            _spriteBatch.Draw(
                 pixel16,
                 ray.Cast(wall),
                 null,
                 Color.Red,
                 0,
                 new Vector2(16 / 2, 16 / 2),
                 1,
                 SpriteEffects.None,
                 1

                 );

            // DRAWING PARTICLES
            //new Particle();

            part = new Particle(_spriteBatch, pixel16, new Vector2(position.X, position.Y),wall);
            part.show();


            //Data PArticle
            _spriteBatch.DrawString(
                logShip,
                part.rays[22].ToString(),
                new Vector2(0, 500), // position
                Color.White //Color
               );

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

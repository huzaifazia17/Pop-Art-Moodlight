using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Pop_Art_MoodLight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //  Declare Variables
        Texture2D backg;
        SpriteFont font;
        Quadrant[,] quads;
        Random rnd = new Random();
        string[,] phrase;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // load image and font
            backg = Content.Load<Texture2D>("donald");
            font = Content.Load<SpriteFont>("SpriteFont1");

            // set 2 dimensional array for words
            phrase = new string[2, 2];
            phrase[0, 0] = "My";
            phrase[0, 1] = "Name is";
            phrase[1, 0] = "Donald";
            phrase[1, 1] = "Trump";


            // 2 dimensional array for quadrants
            quads = new Quadrant[2, 2];
            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //sets values for x and y
                    quads[i, j] = 
                        new Quadrant
                        (
                            i,
                            j,
                            // sets position on screen for all 4 quadrants
                            new Rectangle(i * GraphicsDevice.Viewport.Width / 2,
                                          j * GraphicsDevice.Viewport.Height / 2, 
                                          GraphicsDevice.Viewport.Width / 2,
                                          GraphicsDevice.Viewport.Height / 2),
                            new Vector2(((GraphicsDevice.Viewport.Width / 4) + (GraphicsDevice.Viewport.Width / 2 * i) - (font.MeasureString(phrase[i, j]).X / 2)),
                                          (GraphicsDevice.Viewport.Height / 2) + (GraphicsDevice.Viewport.Height / 2 * j) - (font.MeasureString(phrase[i, j]).Y)),
                            rnd
                        );
                }
            }
            
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // update colour for loop 
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    quads[i, j].updateColor();
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            // wll draw quadrants and text onto screen
            for(int i = 0; i<2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    spriteBatch.Draw(backg, quads[i, j].getFrame(), quads[i, j].getClr());
                    spriteBatch.DrawString(font, phrase[i, j], quads[i, j].getVec(), Color.Black);
                }
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

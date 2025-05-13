using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Final_Project___Vee_s_Utopia
{
    enum Screens
    {
        Warning,
        Title,
        Lore,
        Lore2,
        Office
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //List of Things that I need:
        //Enumerations
        //Die Class for Mini-Game
        //All the Screens
        //See if Classes are Needed
        //Sprites
        //Music and Sounds
        //Fonts

        Texture2D titleTexture;
        Texture2D titleBackground;

        Rectangle titleRect;

        SpriteFont textFont;
        SpriteFont bigTextFont;

        Screens screens;
        KeyboardState keyboardState;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "Vee's Utopia - A Dandy's World AU Fan-Game";
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            screens = Screens.Warning;
            titleRect = new Rectangle(220, 10, 395, 200);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            textFont = Content.Load<SpriteFont>("Fonts/textFont");
            bigTextFont = Content.Load<SpriteFont>("Fonts/bigTextFont");

            titleTexture = Content.Load<Texture2D>("Images/vu_logo_2");
            titleBackground = Content.Load<Texture2D>("Images/vu_title_background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (screens == Screens.Warning)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screens = Screens.Title;
                }
            }
            else if (screens == Screens.Title)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    screens = Screens.Lore;
                }
            }
            else if (screens == Screens.Lore)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    screens = Screens.Lore2;
                }
            }
            else if (screens == Screens.Lore2)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screens = Screens.Office;
                }
            }
            else if (screens == Screens.Office)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screens == Screens.Warning)
            {
                _spriteBatch.DrawString(bigTextFont, "!-Warning-!", new Vector2(240, 5), Color.White);
                _spriteBatch.DrawString(textFont, "This game might contain Flashing Lights,\n      Jumpscares, and Shaking Screens", new Vector2(120, 130), Color.White);
                _spriteBatch.DrawString(textFont, "This is an AU and NOT related to Canon Dandy's \n                                    World Lore", new Vector2(40, 215), Color.White);
                _spriteBatch.DrawString(textFont, "Click to Continue", new Vector2(280, 450), Color.White);
            }
            else if (screens == Screens.Title)
            {
                _spriteBatch.Draw(titleBackground, new Rectangle(-5, 0, 810, 505), Color.White);
                _spriteBatch.Draw(titleTexture, titleRect, Color.White);
                _spriteBatch.DrawString(textFont, "Press Enter to Start", new Vector2(250, 430), Color.Black);
            }
            else if (screens == Screens.Lore)
            {
                _spriteBatch.DrawString(bigTextFont, "Story", new Vector2(320, 5), Color.White);
                _spriteBatch.DrawString(textFont,"Ever since Vee locked Dandy away and took over as \n  the Main Star of Gardenview, things have changed.\n    Gardenview has taken a more futuristic design,\n now called 'Cyberview', and Toons have been living\n  worry-free from the lingering threat of Ichor. Vee\n  calls it an utopia for all Toons and Machines alike.\n Everyone agrees. However, with the disappearance\n                  of Astro, suspicion has been rising.", new Vector2(4, 90), Color.White);
                _spriteBatch.DrawString(textFont, "Right Click to Continue", new Vector2(225, 450), Color.White);
            }
            else if (screens == Screens.Lore2)
            {
                _spriteBatch.DrawString(bigTextFont, "Story (Continued)", new Vector2(150, 5), Color.White);
                _spriteBatch.DrawString(textFont, "   You play as Rodger, the head detective and police\n   chief of Cyberview. Your job is to make sure that\n  rules are followed, danger is prevented, and peace\n                                         is restored.", new Vector2(4, 120), Color.White);
                _spriteBatch.DrawString(textFont, "To interact with objects or Toons, left click on them.", new Vector2(4, 300), Color.White);
                _spriteBatch.DrawString(textFont, "Left Click to Continue", new Vector2(225, 450), Color.White);
            }
            else
            {

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

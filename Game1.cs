using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Monogame_Final_Project___Vee_s_Utopia
{
    enum Screens
    {
        Warning,
        Title,
        Lore,
        Lore2,
        Office,
        LivingRoom,
        Outside,
        Kitchen,
        Elevator,
        Reception,
        VeeOffice,
        CrimeScene
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


        Texture2D titleTexture;
        Texture2D titleBackground;
        Texture2D rodOfficeBackground;
        Texture2D outsideBackground;
        Texture2D elevatorBackground;
        Texture2D kitchenBackground;

        Texture2D doorTexture;
        Texture2D magGlassTexture;
        Texture2D pictureTexture;
        Texture2D portraitTexture;
        Texture2D rackTexture;
        Texture2D rackClothesTexture;
        Texture2D rodDeskTexture;

        List<Texture2D> rodgerTextures;
        List<Texture2D> veeTextures;
        List<Texture2D> boxtenTextures;
        List <Texture2D> cosmoTextures;
        List<Texture2D> dazzleTextures;
        List <Texture2D> shrimpoTextures;
        List <Texture2D> teaganTextures;
        List <Texture2D> toodlesTextures;

        Rectangle titleRect;
        Rectangle doorRect;
        Rectangle magGlassRect;
        Rectangle pictureRect;
        Rectangle rodDeskRect;
        Rectangle portraitRect;
        Rectangle rackRect;
        Rectangle rackCRect;

        SpriteFont textFont;
        SpriteFont bigTextFont;

        SoundEffect titleMusic;
        SoundEffectInstance titleMusicInstance;

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
            doorRect = new Rectangle(580, 92, 160, 290);
            magGlassRect = new Rectangle(100, 100, 100, 100);
            pictureRect = new Rectangle(445, 200, 70, 70);
            rodDeskRect = new Rectangle(210, 250, 350, 220);
            portraitRect = new Rectangle(220, 40, 350, 420);
            rackRect = new Rectangle(474, 138, 100, 268);
            rackCRect = new Rectangle(450, 115, 170, 290);

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
            rodOfficeBackground = Content.Load<Texture2D>("Images/rod_office");
            elevatorBackground = Content.Load<Texture2D>("Images/elevator");
            outsideBackground = Content.Load<Texture2D>("Images/outside");
            kitchenBackground = Content.Load<Texture2D>("Images/kitchen");

            doorTexture = Content.Load<Texture2D>("Images/door");
            magGlassTexture = Content.Load<Texture2D>("Images/mag_glass");
            pictureTexture = Content.Load<Texture2D>("Images/picture");
            portraitTexture = Content.Load<Texture2D>("Images/portrait");
            rackTexture = Content.Load<Texture2D>("Images/rack");
            rackClothesTexture = Content.Load<Texture2D>("Images/rack_clothes");
            rodDeskTexture = Content.Load<Texture2D>("Images/rod_desk");

            titleMusic = Content.Load<SoundEffect>("Sounds-Music/vu_title_music");
            titleMusicInstance = titleMusic.CreateInstance();
            titleMusicInstance.IsLooped = true;

            //Rodger
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Idle"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Talk"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Talk_2"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Idle"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Talk"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Talk2"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Talk3"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Shook"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Think"));
            
            //Vee
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Idle"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Talk"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Talk2"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Weary"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_WearyTalk"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Mad"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_Annoyed"));
            veeTextures.Add(Content.Load<Texture2D>("Vee/V_AnnoyedTalk"));

            //Boxten
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Idle"));
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Idle2"));
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Talk"));
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Talk2"));
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Talk3"));

            //Cosmo
            cosmoTextures.Add(Content.Load<Texture2D>("Cosmo/C_Idle"));
            cosmoTextures.Add(Content.Load<Texture2D>("Cosmo/C_Talk"));
            cosmoTextures.Add(Content.Load<Texture2D>("Cosmo/C_Talk2"));
            cosmoTextures.Add(Content.Load<Texture2D>("Cosmo/C_Scared"));

            //Dazzle
            dazzleTextures.Add(Content.Load<Texture2D>("Dazzle/D_Idle"));
            dazzleTextures.Add(Content.Load<Texture2D>("Dazzle/D_Talk"));
            dazzleTextures.Add(Content.Load<Texture2D>("Dazzle/D_Talk2"));

            //Shrimpo
            shrimpoTextures.Add(Content.Load<Texture2D>("Shrimpo/S_Idle"));
            shrimpoTextures.Add(Content.Load<Texture2D>("Shrimpo/S_Talk"));
            shrimpoTextures.Add(Content.Load<Texture2D>("Shrimpo/S_Talk2"));

            //Teagan
            teaganTextures.Add(Content.Load<Texture2D>("Teagan/Te_Idle"));
            teaganTextures.Add(Content.Load<Texture2D>("Teagan/Te_Talk"));
            teaganTextures.Add(Content.Load<Texture2D>("Teagan/Te_Talk2"));
            teaganTextures.Add(Content.Load<Texture2D>("Teagan/Te_Talk3"));
            teaganTextures.Add(Content.Load<Texture2D>("Teagan/Te_Sit"));

            //Toodles
            toodlesTextures.Add(Content.Load<Texture2D>("Toodles/T_Idle"));
            toodlesTextures.Add(Content.Load<Texture2D>("Toodles/T_Talk"));
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
                titleMusicInstance.Play();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    titleMusicInstance.Stop();
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
            else if (screens == Screens.LivingRoom)
            {

            }
            else if (screens == Screens.Outside)
            {

            }
            else if (screens == Screens.Kitchen)
            {

            }
            else if (screens == Screens.Elevator)
            {

            }
            else
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
            else if (screens == Screens.Office) 
            {
                _spriteBatch.Draw(rodOfficeBackground, new Rectangle(-5, 0, 810, 505), Color.White);
                _spriteBatch.Draw(doorTexture, doorRect, Color.White);
                _spriteBatch.Draw(rodDeskTexture, rodDeskRect, Color.White);
                _spriteBatch.Draw(pictureTexture, pictureRect, Color.White);
                //_spriteBatch.Draw(portraitTexture, portraitRect, Color.White);
            }
            else if (screens == Screens.LivingRoom) 
            {
                //_spriteBatch.Draw(rackTexture, rackRect, Color.White);
                //_spriteBatch.Draw(rackClothesTexture, rackCRect, Color.White);
            }
            else if (screens == Screens.Outside)
            {
                _spriteBatch.Draw(outsideBackground, new Rectangle(-5, 0, 810, 505), Color.White);

            }
            else if (screens == Screens.Kitchen)
            {
                _spriteBatch.Draw(kitchenBackground, new Rectangle(-5, 0, 810, 505), Color.White);

            }
            else if (screens == Screens.Elevator)
            {
                _spriteBatch.Draw(elevatorBackground, new Rectangle(-5, 0, 810, 505), Color.White);

            }
            else
            {

            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

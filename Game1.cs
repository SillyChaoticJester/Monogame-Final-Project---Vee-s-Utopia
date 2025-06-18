using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Monogame_Final_Project___Vees_Utopia;
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
        CrimeScene,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //List of Things that I need:
        //Die Class for Mini-Game
        //Music and Sounds
        //Finish cutscenes and make sure the Vee scene is done at least.


        Texture2D titleTexture;
        Texture2D titleBackground;
        Texture2D rodOfficeBackground;
        Texture2D outsideBackground;
        Texture2D elevatorBackground;
        Texture2D kitchenBackground;
        Texture2D veeOfficeBackground;

        Texture2D doorTexture;
        Texture2D magGlassTexture;
        Texture2D pictureTexture;
        Texture2D portraitTexture;
        Texture2D rackTexture;
        Texture2D rackClothesTexture;
        Texture2D rodDeskTexture;
        Texture2D drawerTexture;

        Texture2D rodBoxTexture;
        Texture2D veeBoxTexture;
        Texture2D dazBoxTexture;
        Texture2D tooBoxTexture;

        Texture2D questionOneTexture;
        Texture2D questionTwoTexture;
        Texture2D questionThreeTexture;
        Texture2D questionFourTexture;
        Texture2D questionFiveTexture;

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
        Rectangle textboxRect;
        Rectangle drawerRect, glassDrawerRect;

        Rectangle toodlesRect;
        Rectangle tooTalkRect;

        Rectangle questionOneRect;
        Rectangle questionTwoRect;
        Rectangle questionThreeRect;
        Rectangle questionFourRect;
        Rectangle questionFiveRect;

        SpriteFont textFont;
        SpriteFont bigTextFont;

        SoundEffect titleMusic;
        SoundEffectInstance titleMusicInstance;
        SoundEffect interviewMusic;
        SoundEffectInstance interviewMusicInstance;

        Rodger rodger;
        Vee vee;

        int rSprite = 0;
        int vSprite = 0;
        int textboxCount = 0;

        bool isSpeaking = false;
        bool isVSpeaking = false;
        bool introSequence = false;
        bool officeIntro = true;
        bool isTTalking = false;
        bool lookGlass = false;
        bool lookPortrait = false;
        bool lookDrawer = false;
        bool haveGlass = false;
        bool haveClothes = false;

        bool showQOne = false;
        bool showQTwo = false;
        bool showQThree = false;
        bool showQFour = false;
        bool showQFive = false;

        bool askQOne = false;
        bool askQTwo = false;
        bool askQThree = false;
        bool askQFour = false;
        bool askQFive = false;

        string textbox;

        Screens screens;
        KeyboardState keyboardState;
        MouseState mouseState, prevMouseState;

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

            screens = Screens.VeeOffice;
            titleRect = new Rectangle(220, 10, 395, 200);
            doorRect = new Rectangle(580, 92, 160, 290);
            magGlassRect = new Rectangle(250, 20, 300, 330);
            pictureRect = new Rectangle(445, 200, 70, 70);
            rodDeskRect = new Rectangle(210, 250, 350, 220);
            portraitRect = new Rectangle(220, 20, 350, 420);
            rackRect = new Rectangle(474, 138, 100, 268);
            rackCRect = new Rectangle(450, 115, 170, 290);
            textboxRect = new Rectangle(0, 350, 800, 150);
            drawerRect = new Rectangle(220, 312, 125, 51);
            glassDrawerRect = new Rectangle(220, 368, 125, 51);

            toodlesRect = new Rectangle(250, 200, 100, 200);
            tooTalkRect = new Rectangle(560, 100, 180, 340);

            questionOneRect = new Rectangle(150, 375, 150, 100);
            questionTwoRect = new Rectangle(150, 375, 150, 100);
            questionThreeRect = new Rectangle(325, 375, 150, 100);
            questionFourRect = new Rectangle(500, 375, 150, 100);
            questionFiveRect = new Rectangle(325, 375, 150, 100);

            rodgerTextures = new List<Texture2D>();
            veeTextures = new List<Texture2D>();
            boxtenTextures = new List<Texture2D>();
            cosmoTextures = new List<Texture2D>();
            dazzleTextures = new List<Texture2D>();
            shrimpoTextures = new List<Texture2D>();
            teaganTextures = new List<Texture2D>();
            toodlesTextures = new List<Texture2D>();

            textbox = "Just another day in Cyberview... Should be another\nuneventful day.";

            rodger = new Rodger(rodgerTextures, new Rectangle(20, 120, 180, 370), rSprite);
            vee = new Vee(veeTextures, new Rectangle(150, 50, 500, 500), vSprite);

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
            veeOfficeBackground = Content.Load<Texture2D>("Images/vee_office");

            doorTexture = Content.Load<Texture2D>("Images/door");
            magGlassTexture = Content.Load<Texture2D>("Images/mag_glass");
            pictureTexture = Content.Load<Texture2D>("Images/picture");
            portraitTexture = Content.Load<Texture2D>("Images/portrait");
            rackTexture = Content.Load<Texture2D>("Images/rack");
            rackClothesTexture = Content.Load<Texture2D>("Images/rack_clothes");
            rodDeskTexture = Content.Load<Texture2D>("Images/rod_desk");
            drawerTexture = Content.Load<Texture2D>("Images/drawer");

            rodBoxTexture = Content.Load<Texture2D>("Textboxes/rod_textbox");
            veeBoxTexture = Content.Load<Texture2D>("Textboxes/vee_textbox");
            dazBoxTexture = Content.Load<Texture2D>("Textboxes/daz_textbox");
            tooBoxTexture = Content.Load<Texture2D>("Textboxes/too_textbox");

            questionOneTexture = Content.Load<Texture2D>("Textboxes/question1");
            questionTwoTexture = Content.Load<Texture2D>("Textboxes/question2");
            questionThreeTexture = Content.Load<Texture2D>("Textboxes/question3");
            questionFourTexture = Content.Load<Texture2D>("Textboxes/question4");
            questionFiveTexture = Content.Load<Texture2D>("Textboxes/question5");

            titleMusic = Content.Load<SoundEffect>("Sounds-Music/vu_title_music");
            titleMusicInstance = titleMusic.CreateInstance();
            titleMusicInstance.IsLooped = true;

            interviewMusic = Content.Load<SoundEffect>("Sounds-Music/interview");
            interviewMusicInstance = interviewMusic.CreateInstance();
            interviewMusicInstance.IsLooped = true;

            //Rodger
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Idle"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Talk"));
            rodgerTextures.Add(Content.Load<Texture2D>("Rodger/R_Casual_Talk2"));
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
            boxtenTextures.Add(Content.Load<Texture2D>("Boxten/B_Talk1"));
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
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (screens == Screens.Warning)
            {
                if (Click())
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
                if (Click())
                {
                    screens = Screens.Lore2;
                }
            }
            else if (screens == Screens.Lore2)
            {
                if (Click())
                {
                    screens = Screens.Office;
                    introSequence = true;
                    isSpeaking = true;
                    rSprite = 0;
                    textboxCount = 0;
                }
            }
            else if (screens == Screens.Office)
            {
                if (Click() && introSequence && textboxCount == 0)
                {
                    textbox = "However, I still have that interview with Vee in a \ncouple of hours...";
                    textboxCount++;

                }
                else if (Click() && introSequence && textboxCount == 1)
                {
                    textbox = "I should get myself ready to head towards Vee's \nOffice floor.";
                    textboxCount++; 

                }
                else if (Click() && introSequence && textboxCount == 2)
                {
                    textbox = "";
                    isSpeaking = false;
                    introSequence = false;
                    textboxCount = 0;
                }
                else if (Click() && pictureRect.Contains(mouseState.Position) && !introSequence)
                {
                    isSpeaking = true;
                    lookPortrait = true;
                    rodger.TextureIndex = 2;
                    textbox = "A portrait of my wonderful family. Oh, how much \nToodles has grown since that day...";
                    textboxCount++;
                }
                else if (Click() && lookPortrait && !introSequence && textboxCount == 1)
                {
                    isSpeaking = false;
                    lookPortrait = false;
                    textboxCount = 0;
                    rodger.TextureIndex = 0;
                }
                else if (Click() && drawerRect.Contains(mouseState.Position) && !introSequence)
                {
                    isSpeaking = true;
                    lookDrawer = true;
                    rodger.TextureIndex = 1;
                    textbox = "It's filled to the brim with various types of \npaperwork. A detective's job is never easy, but I \nalways get it done.";
                    textboxCount++;
                }
                else if (Click() && lookDrawer && textboxCount == 1 && !introSequence)
                {
                    isSpeaking = false;
                    lookDrawer = false;
                    rodger.TextureIndex = 0;
                    textboxCount = 0;
                }
                else if (Click() && glassDrawerRect.Contains(mouseState.Position) && !haveGlass && !introSequence)
                {
                    isSpeaking = true;
                    lookGlass = true;
                    rodger.TextureIndex = 2;
                    textbox = "Ah, there it is! My trusty magnifying glass! Never \ndone a case without it.";
                    textboxCount++;
                }
                else if (Click() && !introSequence && lookGlass && textboxCount == 1)
                {
                    isSpeaking = false;
                    lookGlass = false;
                    haveGlass = true;
                    rodger.TextureIndex = 0;
                    textboxCount = 0;
                }
                else if (Click() && doorRect.Contains(mouseState.Position) && !introSequence && !haveGlass)
                {
                    rodger.TextureIndex = 0;
                    isSpeaking = true;
                    textbox = "Hmm, it feels like I'm missing something... \nBetter check again.";
                    textboxCount++;
                }
                else if (Click() && doorRect.Contains(mouseState.Position) && haveGlass == true)
                {
                    isSpeaking = true;
                    textbox = "Looks like I got everything from here.";
                    textboxCount++;
                }
                else if (Click() && !introSequence && haveGlass && textboxCount == 1)
                {
                    isSpeaking = false;
                    textboxCount = 0;
                    screens = Screens.LivingRoom;
                }
            }
            else if (screens == Screens.LivingRoom)
            {
                if (Click() && toodlesRect.Contains(mouseState.Position) && !haveClothes)
                {
                    isTTalking = true;
                    textbox = "Papa! Papa! Are you going to go work again?";
                    textboxCount++;
                }
                else if (Click() && isTTalking && textboxCount == 1)
                {
                    isSpeaking = true;
                    isTTalking = false;
                    rodger.TextureIndex = 2;
                    textbox = "Heh, you may never know with how peaceful the \nstreets of Cyberview are nowadays.";
                    textboxCount++;
                }
                else if (Click() && isSpeaking && textboxCount == 2)
                {
                    isSpeaking = false;
                    isTTalking = true;
                    textbox = "You gotta let me join you one day! I'll be a great \njunior detective!";
                    textboxCount++;
                }
                else if (Click() && isTTalking && textboxCount == 3)
                {
                    isSpeaking = true;
                    isTTalking = false;
                    textbox = "I bet you will be, sweetie.";
                    textboxCount++;
                }
                else if (Click() && isSpeaking && textboxCount == 4)
                {
                    isSpeaking = false;
                    textboxCount = 0;
                    rodger.TextureIndex = 0;
                }
                else if (Click() && toodlesRect.Contains(mouseState.Position) && haveClothes)
                {
                    isSpeaking = true;
                    rodger.TextureIndex = 3;
                    textbox = "Don't have time to talk to Toodles now that I'm \nready.";
                    textboxCount++;
                }
                else if (Click() && rackCRect.Contains(mouseState.Position) && !isTTalking && !isSpeaking && !haveClothes)
                {
                    haveClothes = true;
                    rodger.TextureIndex = 4;
                    isSpeaking = true;
                    textbox = "Now that I'm properly attired, I can leave to go to \nthat meeting.";
                    textboxCount++;
                }
                else if (Click() && !isTTalking && isSpeaking && haveClothes && textboxCount != 5)
                {
                    rodger.TextureIndex = 3;
                    isSpeaking = false;
                    textboxCount = 0;
                }
                else if (Click() && rackCRect.Contains(mouseState.Position) && !isTTalking && !isSpeaking && haveClothes)
                {
                    rodger.TextureIndex = 3;
                    isSpeaking = true;
                    textbox = "There's nothing else I can do here.";
                    textboxCount++;
                }
                else if (Click() && doorRect.Contains(mouseState.Position) && !isTTalking && !isSpeaking && !haveClothes)
                {
                    rodger.TextureIndex = 0;
                    isSpeaking = true;
                    textbox = "Hmm, it feels like I'm missing something... \nBetter check again.";
                    textboxCount++;
                }
                else if (Click() && !isTTalking && isSpeaking && !haveClothes)
                {
                    isSpeaking = false;
                    textboxCount = 0;
                }
                else if (Click() && doorRect.Contains(mouseState.Position) && !isTTalking && !isSpeaking && haveClothes)
                {
                    rodger.TextureIndex= 3;
                    isSpeaking = true;
                    textbox = "Time for me to leave. Hope this goes well.";
                    textboxCount = 5;
                }
                else if (Click() && haveClothes && textboxCount == 5)
                {
                    isSpeaking = false;
                    officeIntro = true;
                    textboxCount = 0;
                    screens = Screens.VeeOffice;
                }
            }
            else if (screens == Screens.VeeOffice) 
            {
                if (Click() && officeIntro && !isSpeaking && textboxCount == 0)
                {
                    vee.TextureIndex = 0;
                    rodger.TextureIndex = 4;
                    isSpeaking = true;
                    textbox = "Afternoon, Vee.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 1)
                {
                    isSpeaking = false;
                    isVSpeaking = true;
                    vee.TextureIndex = 1;
                    textbox = "Rodger.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 2)
                {
                    isSpeaking = true;
                    isVSpeaking = false;
                    vee.TextureIndex = 0;
                    textbox = "You don't seem surprised to see me.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 3)
                {
                    isSpeaking = false;
                    isVSpeaking = true;
                    vee.TextureIndex = 1;
                    textbox = "I'm used to you pursuing knowledge whenever \npossible. I'm guessing that's why you came here.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 4)
                {
                    isSpeaking = true;
                    isVSpeaking = false;
                    vee.TextureIndex = 0;
                    rodger.TextureIndex = 5;
                    textbox = "You know me quite well. Yes, that is exactly why \nI'm here.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 5)
                {
                    isSpeaking = false;
                    isVSpeaking = true;
                    vee.TextureIndex = 1;
                    rodger.TextureIndex = 4;
                    textbox = "Very well, ask away. Just know the boundaries \nyou're stepping in.";
                    textboxCount++;
                }
                else if (Click() && officeIntro && textboxCount == 6)
                {
                    isSpeaking = true;
                    isVSpeaking = false;
                    officeIntro = false;
                    vee.TextureIndex = 0;
                    rodger.TextureIndex = 4;
                    textbox = "";
                    textboxCount = 0;
                    showQOne = true;
                    showQThree = true;
                    showQFour = true;
                    interviewMusicInstance.Play();
                }
                else if (Click() && questionOneRect.Contains(mouseState.Position))
                {
                    vee.TextureIndex = 1;
                    isSpeaking = false;
                    isVSpeaking= true;
                    askQOne = true;
                    showQOne = false;
                    showQThree = false;
                    showQFour = false;
                    textbox = "You ask as if you have amnesia. Do we need to get \nthat head of yours checked up on?";
                    textboxCount++;
                }
                else if (Click() && askQOne && textboxCount == 1)
                {
                    vee.TextureIndex = 0;
                    rodger.TextureIndex = 5;
                    isSpeaking = true;
                    isVSpeaking = false;
                    textbox = "No, no, my memory is perfectly fine. I'm just asking \nthis from a reporter standpoint so any newer Toons \ncan refer to a booklet for info they should know.";
                    textboxCount++;
                }
                else if (Click() && askQOne && textboxCount == 2)
                {
                    vee.TextureIndex = 1;
                    rodger.TextureIndex = 5;
                    isSpeaking = false;
                    isVSpeaking = true;
                    textbox = "Right, right, of course. Can't forget that newer \n Toons might not know everything.";
                    textboxCount++;
                }
                else if (Click() && askQOne && textboxCount == 3)
                {
                    vee.TextureIndex = 2;
                    textbox = "Well, you know me already, I am Vee. Vee Version 1.0, to be precise. And I run the entirety of Cyberview as the Main Star.";
                    textboxCount++;
                }
                else if (Click() && askQOne && textboxCount == 4)
                {
                    vee.TextureIndex = 0;
                    rodger.TextureIndex = 3;
                    isSpeaking = true;
                    isVSpeaking = false;
                    askQOne = false;
                    showQTwo = true;
                    showQThree = false;
                    showQFour = false;
                    textbox = "";
                    textboxCount = 0;
                }
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
                _spriteBatch.Draw(drawerTexture, drawerRect, Color.White);
                _spriteBatch.Draw(drawerTexture, glassDrawerRect, Color.White);
                if (lookPortrait == true)
                {
                    _spriteBatch.Draw(portraitTexture, portraitRect, Color.White);
                }
                if (lookGlass == true)
                {
                    _spriteBatch.Draw(magGlassTexture, magGlassRect, Color.White);
                }
                if (isSpeaking == true)
                {
                    rodger.Draw(_spriteBatch);
                    _spriteBatch.Draw(rodBoxTexture, textboxRect, Color.White);
                    _spriteBatch.DrawString(textFont, textbox, new Vector2(10, 360), Color.Black);
                }
                
            }
            else if (screens == Screens.LivingRoom) 
            {
                _spriteBatch.Draw(rodOfficeBackground, new Rectangle(-5, 0, 810, 505), Color.White);
                _spriteBatch.Draw(doorTexture, doorRect, Color.White);
                _spriteBatch.Draw(toodlesTextures[0], toodlesRect, Color.White);
                if (!haveClothes)
                {
                    _spriteBatch.Draw(rackClothesTexture, rackCRect, Color.White);
                }
                else if (haveClothes)
                {
                    _spriteBatch.Draw(rackTexture, rackRect, Color.White);
                }
                if (isSpeaking == true)
                {
                    rodger.Draw(_spriteBatch);
                    _spriteBatch.Draw(rodBoxTexture, textboxRect, Color.White);
                    _spriteBatch.DrawString(textFont, textbox, new Vector2(10, 360), Color.Black);
                }
                if (isTTalking == true)
                {
                    _spriteBatch.Draw(toodlesTextures[1], tooTalkRect, Color.White);
                    _spriteBatch.Draw(tooBoxTexture, textboxRect, Color.White);
                    _spriteBatch.DrawString(textFont, textbox, new Vector2(10, 360), Color.Black);
                }
            }
            else if (screens == Screens.VeeOffice)
            {
                _spriteBatch.Draw(veeOfficeBackground, new Rectangle(-5, 0, 810, 505), Color.White);
                vee.Draw(_spriteBatch);
                if (isVSpeaking)
                {
                    _spriteBatch.Draw(veeBoxTexture, textboxRect, Color.White);
                    _spriteBatch.DrawString(textFont, textbox, new Vector2(10, 360), Color.Black);
                }
                if (isSpeaking == true)
                {
                    rodger.Draw(_spriteBatch);
                    _spriteBatch.Draw(rodBoxTexture, textboxRect, Color.White);
                    _spriteBatch.DrawString(textFont, textbox, new Vector2(10, 360), Color.Black);
                }
                if (showQOne)
                {
                    _spriteBatch.Draw(questionOneTexture, questionOneRect, Color.White);
                }
                if (showQTwo)
                {
                    _spriteBatch.Draw(questionTwoTexture, questionTwoRect, Color.White);
                }
                if (showQThree)
                {
                    _spriteBatch.Draw(questionThreeTexture, questionThreeRect, Color.White);
                }
                if (showQFour)
                {
                    _spriteBatch.Draw(questionFourTexture, questionFourRect, Color.White);
                }
                if (showQFive)
                {
                    _spriteBatch.Draw(questionFiveTexture, questionFiveRect, Color.White);
                }
  
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected bool Click()
        {
            return prevMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed;
        }
       
    }
}

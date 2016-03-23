using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace RoomsMenu
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        StartMenu startMenu;
        InstructionsMenu instructionsMenu;
        EndMenu endMenu;
        Texture2D gameBackground;
        public int stopX;
        public int stopY;
        public static SpriteFont font;
        public static string GameState = "Startmenu";
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            startMenu = new StartMenu(this);
            instructionsMenu = new InstructionsMenu(this);
            endMenu = new EndMenu(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            stopX = graphics.PreferredBackBufferWidth = 800;
            stopY = graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            gameBackground = Content.Load<Texture2D>("pink");
            startMenu.LoadContent(Content);
            instructionsMenu.LoadContent(Content);
            endMenu.LoadContent(Content);
            IsMouseVisible = true;

        }

        protected override void UnloadContent()
        {
        }

        void UpdateGame(GameTime gameTime)
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || GameState == "Exit")
                this.Exit();
            switch (GameState)
            {
                case "Startmenu":
                    startMenu.Update(gameTime);
                    break;
                case "Information":
                    instructionsMenu.Update(gameTime);
                    break;
                case "Game":
                    UpdateGame(gameTime);
                    break;
                case "Endmenu":
                    endMenu.Update(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (GameState)
            {               
                case "Startmenu":
                startMenu.Draw(spriteBatch);
                    break;
                case "Information":
                    instructionsMenu.Draw(spriteBatch);
                    break;
                case "Game":
                    spriteBatch.Draw(gameBackground, new Rectangle(0, 0, gameBackground.Width, gameBackground.Height), Color.White);
                    break;
                case "Endmenu":
                    endMenu.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}

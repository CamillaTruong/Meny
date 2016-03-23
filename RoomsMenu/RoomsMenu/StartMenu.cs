using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace RoomsMenu
{
    class StartMenu
    {
        KeyboardState keyboard;
        KeyboardState previousKeyboard;
        Texture2D menuBackground;
        MouseState mouse;
        MouseState previousMouse;     
        SpriteFont spriteFont;
        Game1 game;
        int selected = 0;
        List<string> buttonList = new List<string>();

        public StartMenu(Game1 game)
        {
            buttonList.Add("Play");
            buttonList.Add("Information");
            buttonList.Add("Exit");
            this.game = game;
        }
        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("HUDFont");
            menuBackground = Content.Load<Texture2D>("black");

        }

        public void Update(GameTime gameTime)
        {
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();          
                if (CheckKeyboard(Keys.Up))
                {
                    if (selected > 0) selected--;
                }
                if (CheckKeyboard(Keys.Down))
                {
                    if (selected < buttonList.Count - 1) selected++;
                }
                if (CheckKeyboard(Keys.Enter))
                {
                    switch (selected)
                    {
                        case 0:
                            Game1.GameState = "Game";
                            break;
                        case 1:
                            Game1.GameState = "Information";
                            break;
                        case 2:
                            Game1.GameState = "Exit";
                            break;
                    }
                }
            
            previousMouse = mouse;
            previousKeyboard = keyboard;
        }
        public bool Check()
        {
            return (mouse.LeftButton == ButtonState.Pressed && previousMouse.LeftButton == ButtonState.Released);
        }
        public bool CheckKeyboard(Keys key)
        {
            return (keyboard.IsKeyDown(key) && previousKeyboard.IsKeyUp(key));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Color color;
            int linePadding = 3;
            spriteBatch.Draw(menuBackground, new Rectangle(0, 0, menuBackground.Width, menuBackground.Height), Color.White);
            for (int i = 0; i < buttonList.Count; i++)
            {
                color = (i == selected) ? Color.Gold : Color.White;
                spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((game.stopX / 2) - ((spriteFont.MeasureString(buttonList[i]).X / 2)),
                ((game.stopY / 2)-100) - (spriteFont.LineSpacing * buttonList.Count / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
            }
        }
    }
  
}

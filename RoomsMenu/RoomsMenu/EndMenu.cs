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
    class EndMenu
    {
        KeyboardState keyboard;
        KeyboardState previousKeyboard;
        Texture2D endBackground;
        MouseState mouse;
        MouseState previousMouse;     
        SpriteFont spriteFont;
        Game1 game;
        int selected = 0;
        List<string> buttonList = new List<string>();

        public EndMenu(Game1 game)
        {
            buttonList.Add("Back to Start");
            buttonList.Add("Exit");
            this.game = game;
        }
        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("HUDFont");
            endBackground = Content.Load<Texture2D>("blue");

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
                            Game1.GameState = "Startmenu";
                            break;
                        case 1:
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
            spriteBatch.Draw(endBackground, new Rectangle(0, 0, endBackground.Width, endBackground.Height), Color.White);
            for (int i = 0; i < buttonList.Count; i++)
            {
                color = (i == selected) ? Color.Gold : Color.White;
                spriteBatch.DrawString(spriteFont, buttonList[i], new Vector2((game.stopX / 2) - ((spriteFont.MeasureString(buttonList[i]).X / 2)),
                ((game.stopY / 2)-100) - (spriteFont.LineSpacing * buttonList.Count / 2) + ((spriteFont.LineSpacing + linePadding) * i)), color);
            }
        }
    }
}

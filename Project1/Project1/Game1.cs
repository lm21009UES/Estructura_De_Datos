using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D sprite;
        Texture2D fondo;
        int spriteX = 0;
        int spriteY = 0;
        int moveY=0;
        int moveX=0;
        int norects;//cantidad de paredes del laberinto
        Rectangle[] rects;//corrdenadas de las paredes del laberinto

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 1024;
            this._graphics.PreferredBackBufferHeight = 768;
            crearrectangulos();
        }
        void crearrectangulos()
        {
            norects = 55;
            rects = new Rectangle[norects];
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite = Content.Load<Texture2D>("pacman1");
            fondo = Content.Load<Texture2D>("mapa2");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState currentState = Keyboard.GetState();
            Keys[] currenkey = currentState.GetPressedKeys();
            
            /*if (gameTime.TotalGameTime.Milliseconds % 20 == 0)
            {
                //codigo que se ejecuta cada 20 mls
                moveX = sprite.Width;
                moveY = sprite.Height;
            }
            else
            {
                moveX = 0;
                moveY = 0;
            }*/
            if (gameTime.TotalGameTime.Milliseconds % 15 == 0)
            {
                sprite = Content.Load<Texture2D>("pacman1");
            }
            if (gameTime.TotalGameTime.Milliseconds % 48 == 0)
            {
                sprite = Content.Load<Texture2D>("pacman2");
            }
            foreach (Keys key in currenkey)
            {
                if (key == Keys.Up)
                {
                    moveY = -5;
                    moveX = 0;
                    if (checkbounds())
                        spriteY = spriteY - moveY;
                }
                if(key == Keys.Down)
                {
                    moveY = 5;
                    moveX = 0;
                    if(checkbounds())
                        spriteY = spriteY + moveY;
                }
                if(key == Keys.Left)
                {
                    moveY = 0;
                    moveX = -5;
                    if(checkbounds())
                        spriteX = spriteX - moveX;
                }
                if (key == Keys.Right)
                {
                    moveY = 0;
                    moveX = -1;
                    if(checkbounds())
                        spriteX = spriteX + moveX;
                }
                if(key == Keys.Escape)
                {
                    this.Exit();
                }
            }
            if (spriteX < 0)
                spriteX = 0;
            if (spriteY < 0)
                spriteY = 0;
            if(spriteX+moveX>_graphics.GraphicsDevice.Viewport.Width)//para manejar tamaño de pantalla
            {
                spriteX = _graphics.GraphicsDevice.Viewport.Width-moveX;
            }
            if (spriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)//para manejar tamaño de pantalla
            {
                spriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }
            base.Update(gameTime);
        }
        bool checkbounds()
        {
            Rectangle temprect = new Rectangle(spriteX+moveX, spriteY+moveY,sprite.Width,sprite.Height);
            bool temreturn = true;
            for(int i = 0; i < norects; i++)
            {
                if (temprect.Intersects(rects[i]))
                {
                    temreturn = false;
                }
            }
            return temreturn;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(sprite,new Rectangle(spriteX,spriteY,sprite.Width,sprite.Height),Color.White);
            _spriteBatch.Draw(fondo, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
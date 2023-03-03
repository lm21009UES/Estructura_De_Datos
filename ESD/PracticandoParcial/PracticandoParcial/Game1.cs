using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PracticandoParcial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D _fondo;
        Texture2D fantasma;
        int moveX = 0;
        int moveY = 0;
        int SpriteX = 200;
        int SpriteY = 200;

        SpriteFont text;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this._graphics.PreferredBackBufferWidth = 1200;
            this._graphics.PreferredBackBufferHeight = 700;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _fondo = Content.Load<Texture2D>("fondo");
            fantasma = Content.Load<Texture2D>("Among");
            text = Content.Load<SpriteFont>("File");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState currentState = Keyboard.GetState();
            Keys[] state = currentState.GetPressedKeys();
            if (gameTime.TotalGameTime.Milliseconds % 10 == 0)
            {
                moveX = 50;
                moveY = 50;
            }
            else
            {
                moveX = 0;
                moveY = 0;
            }
            foreach (Keys r in state)
            {
                if (r == Keys.Up)
                {
                    moveY = -5;
                    moveX = 0;
                    SpriteY = SpriteY + moveY;

                }
                if (r == Keys.Down)
                {
                    moveY = 5;
                    moveX = 0;
                    SpriteY = SpriteY + moveY;

                }
                if (r == Keys.Left)
                {
                    moveY = 0;
                    moveX = -5;
                    SpriteX = SpriteX + moveX;

                }
                if (r == Keys.Right)
                {
                    moveY = 0;
                    moveX = 5;
                    SpriteX = SpriteX + moveX;

                }
                if (r == Keys.Escape)
                {
                    this.Exit();
                }
            }
            if (SpriteX < 0)
                SpriteX = 0;
            if (SpriteY < 0)
                SpriteY = 0;
            if (SpriteX + moveX > _graphics.GraphicsDevice.Viewport.Width)//para manejar tamaño de pantalla
            {
                SpriteX = _graphics.GraphicsDevice.Viewport.Width - moveX;
            }
            if (SpriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)//para manejar tamaño de pantalla
            {
                SpriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_fondo, new Rectangle(0, 0, 1200,700), Color.White);
            _spriteBatch.Draw(fantasma, new Rectangle(SpriteX, SpriteY, 50,50), Color.White);
            _spriteBatch.DrawString(text, "PULSANDO TEXTO", new Vector2(4, 4), Color.Black);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        /*METODO PARA VERIFICAR COLISIONES
        bool checkbounds()
        {
            Rectangle temprect = new Rectangle(spriteX + moveX, spriteY + moveY, balonTextura.Width, balonTextura.Height);
            bool temreturn = true;
            for (int i = 0; i < norects; i++)
            {
                if (temprect.Intersects(rects[i]))
                {
                    temreturn = false;
                }
            }
            return temreturn;
        }
        */
    }
}
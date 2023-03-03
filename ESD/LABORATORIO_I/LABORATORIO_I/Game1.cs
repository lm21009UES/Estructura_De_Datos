using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

namespace LABORATORIO_I
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Color fondo = new Color(176, 196, 222);
        Texture2D balonTextura;//creamos objeto para la imagen
        Texture2D _fondo;
        Texture2D pared;
        Song musica;
        private SpriteFont _font;
        int spriteX = 358;
        int spriteY = 240;
        int moveY = 0;
        int moveX = 0;
        int norects;
        Rectangle[] rects;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 750;
            this._graphics.PreferredBackBufferHeight = 509;
            crearrectangulos();
        }
        void crearrectangulos()
        {
            norects = 12;
            rects = new Rectangle[norects];
            rects[0] = new Rectangle(30, 29, 686, 4);
            rects[1] = new Rectangle(30, 29, 3, 201);
            rects[2] = new Rectangle(14,227,19,3);
            rects[3] = new Rectangle(14,227,3,50);
            rects[4] = new Rectangle(14,274,19,3);
            rects[5] = new Rectangle(30,274,3,201);
            rects[6] = new Rectangle(30, 472,687,3);
            rects[7] = new Rectangle(714,274,3,201);
            rects[8] = new Rectangle(714,274,18,3);
            rects[9] = new Rectangle(729,227,3,50);
            rects[10] = new Rectangle(714,227,18,3);
            rects[11] = new Rectangle(714,29, 2, 201);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            balonTextura = Content.Load<Texture2D>("balon");//cargamos la imagen en memoria
            _fondo = Content.Load<Texture2D>("campo1");
            pared = Content.Load<Texture2D>("pared");
            _font=Content.Load<SpriteFont>("Aharoni");
            musica = Content.Load<Song>("estadio");
            MediaPlayer.Play(musica);
            MediaPlayer.IsRepeating = true;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState currentState = Keyboard.GetState();
            Keys[] currenkey = currentState.GetPressedKeys();
            if (gameTime.TotalGameTime.Milliseconds % 10 == 0)
            {
                //codigo que se ejecuta cada 20 mls
                moveX = 30;
                moveY = 30;
            }
            else
            {
                moveX = 0;
                moveY = 0;
            }
            foreach (Keys key in currenkey)
            {
                if (key == Keys.Up)
                {
                    moveY = -5;
                    moveX = 0;
                    if (checkbounds())
                    {
                        spriteY = spriteY + moveY;
                    }
                }
                if (key == Keys.Down)
                {
                    moveY = 5;
                    moveX = 0;

                    if (checkbounds())
                    {
                        spriteY = spriteY + moveY;
                    }
                }
                if (key == Keys.Left)
                {
                    moveY = 0;
                    moveX = -5;
                    if (checkbounds())
                    {
                        spriteX = spriteX + moveX;
                    }
                }
                if (key == Keys.Right)
                {
                    moveY = 0;
                    moveX = 5;
                    if (checkbounds())
                    {
                        spriteX = spriteX + moveX;
                    }
                }
                if (key == Keys.Escape)
                {
                    this.Exit();
                }
            }
            if (spriteX < 0)
                spriteX = 0;
            if (spriteY < 0)
                spriteY = 0;
            if (spriteX + moveX > _graphics.GraphicsDevice.Viewport.Width)//para manejar tamaño de pantalla
            {
                spriteX = _graphics.GraphicsDevice.Viewport.Width - moveX;
            }
            if (spriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)//para manejar tamaño de pantalla
            {
                spriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }
            base.Update(gameTime);
        }
        bool checkbounds()
        {
            Rectangle temprect = new Rectangle(spriteX + moveX, spriteY + moveY, balonTextura.Width, balonTextura.Height);
            bool temreturn = true;
            for(int i=0; i < norects; i++)
            {
                if (temprect.Intersects(rects[i]))
                {
                    temreturn= false;
                }
            }
            return temreturn;
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(fondo);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            //dibujamos la imagen
            _spriteBatch.Draw(_fondo, new Rectangle(0, 0, _fondo.Width, _fondo.Height),Color.White);
            _spriteBatch.Draw(balonTextura, new Rectangle(spriteX, spriteY, balonTextura.Width, balonTextura.Height), Color.White);
            _spriteBatch.DrawString(_font, "********* LM21009 ********", new Vector2(240, 4), Color.White);
            _spriteBatch.DrawString(_font, "* ERICK ADONY LOPEZ MELENDEZ *", new Vector2(245, 478), Color.White);
            for (int i=0; i < norects; i++)
            {
                _spriteBatch.Draw(pared, rects[i], Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
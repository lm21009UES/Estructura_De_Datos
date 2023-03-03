using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Parcial
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        int numT;//numero de troncos;
        int numR;// numero de rocas;
        int numRanas;//numero de ranas
        //posiciones en X Y de tronco
        int posXTronco = 30;
        int posYTronco = 50;
        //posciciones de X Y de ranas
        int posxRana = 600;
        int posyRana = 5;
        //POSICIONES DE X Y de rocas
        int posxRoca = 80;
        int posyRoca = 535;
        //movimientos iniciales
        int moveX = 40;
        int moveY = 40;
        //variables para dibujar ranas en tiempo de ejecucion
        int SpriteX = 0;
        int SpriteY = 0;
        //texturas empleadas
        Texture2D ranas;//vector para cargar la imagen de las ranas
        Texture2D _troncoObstaculo;
        Texture2D _rocas;
        Texture2D gameOver;
        Texture2D juegoGanado;
        //rectangulos para crear los troncos y rocas
        Rectangle[] troncos;//vector para crear los troncos
        Rectangle[] rocas;//vector para crear las rocas

        //variable para texto
        SpriteFont _text;
        //varaible para controlar las ranas que han cruzado
        int RanasCruzadas = 0;
        //variable para indicar si el juego ha terminado
        bool estadoJuego = false;
        //dirección de troncos
        //variables para controlar el movimiento de los troncos
        int d1 = 1;
        int d2 = 1;
        int d3 = 1;
        int d4 = 1;
        int d5 = 1;
        int d6 = 1;
        int d7 = 1;
        //estado de Ranas
        bool[] ranasEstado;
        void inicializandoEstado()
        {
            ranasEstado = new bool[5];
            for(int i=0; i<5; i++)
            {
                if (i == 0)
                {
                    ranasEstado[i] = true;
                }
                else
                {
                    ranasEstado[i]= false;
                }
                
            }
        }
        
        void crearTroncos()//función para crear los troncos
        {
            numT = 7;
            troncos = new Rectangle[7];
            for(int i = 0; i< numT; i++)
            {
                troncos[i] = new Rectangle(posXTronco, posYTronco, 80, 20);
                posXTronco = posXTronco + 115;
                posYTronco = posYTronco + 75;
            }
        }

        void crearRocas()//función para crear las rocas
        {
            numR = 6;
            rocas = new Rectangle[numR];
            for(int i = 0; i< numR; i++)
            {
                rocas[i] = new Rectangle(posxRoca, posyRoca, 50, 50);
                posxRoca = posxRoca + 120;
            }
        }
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 800;
            this._graphics.PreferredBackBufferHeight = 650;
            crearTroncos();
            crearRocas();
            SpriteX = posxRana;
            SpriteY = posyRana;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        void movTron()//metodo para verificar que los troncos no salgan de la pantalla
        {
            if (troncos[0].X > 720)
            {
                d1 = 2;
            }
            if (troncos[0].X < 0)
            {
                d1 = 1;
            }
            if (troncos[1].X > 720)
            {
                d2 = 2;
            }
            if (troncos[1].X < 0)
            {
                d2 = 1;
            }
            if (troncos[2].X > 720)
            {
                d3 = 2;
            }
            if (troncos[2].X < 0)
            {
                d3 = 1;
            }
            if (troncos[3].X > 720)
            {
                d4 = 2;
            }
            if (troncos[3].X < 0)
            {
                d4 = 1;
            }
            if (troncos[4].X > 720)
            {
                d5 = 2;
            }
            if (troncos[4].X < 0)
            {
                d5 = 1;
            }
            if (troncos[5].X > 720)
            {
                d6 = 2;
            }
            if (troncos[5].X < 0)
            {
                d6 = 1;
            }
            if (troncos[6].X > 720)
            {
                d7 = 2;
            }
            if (troncos[6].X < 0)
            {
                d7 = 1;
            }
        }
        void moverTroncos(GameTime game)//función que se ejecutara cada ves que pase determinado tiempo
        {
            movTron();//verificamos la dirección de cada uno de los troncos
            if(game.TotalGameTime.Milliseconds %10 == 0)//cada dirección es 1 a la derecha, 2 a la izquierda
            {//aumentamos el valor en las posiciones verticales de cada tronco
                if (d1==1){
                    troncos[0].X+=5;
                }
                if (d1 == 2)
                {
                    troncos[0].X-=5;
                }
                if(d2 == 1)
                {
                    troncos[1].X += 8;
                }
                if (d2 == 2)
                {
                    troncos[1].X -= 8;
                }
                if (d3 == 1)
                {
                    troncos[2].X += 12;
                }
                if (d3 == 2)
                {
                    troncos[2].X -= 12;
                }
                if (d4 == 1)
                {
                    troncos[3].X += 15;
                }
                if (d4 == 2)
                {
                    troncos[3].X -= 15;
                }
                if (d5 == 1)
                {
                    troncos[4].X += 5;
                }
                if (d5 == 2)
                {
                    troncos[4].X -= 5;
                }
                if (d6 == 1)
                {
                    troncos[5].X += 8;
                }
                if (d6 == 2)
                {
                    troncos[5].X -= 8;
                }
                if (d7 == 1)
                {
                    troncos[6].X += 5;
                }
                if (d7 == 2)
                {
                    troncos[6].X -= 5;
                }
            }
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _troncoObstaculo = Content.Load<Texture2D>("madera");
            _rocas = Content.Load<Texture2D>("rocas");
            ranas = Content.Load<Texture2D>("ranas");
            _text = Content.Load<SpriteFont>("Texto");
            gameOver = Content.Load<Texture2D>("gameOver");
            juegoGanado = Content.Load<Texture2D>("winner");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
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
            foreach(Keys key in currenkey)
            {
                if (key == Keys.Up)
                {
                    moveY = -5;
                    moveX = 0;
                    if (checkbounds())
                    {
                        SpriteY = SpriteY + moveY;
                    }
                    else
                    {
                        estadoJuego = true;
                    }
                }
                if (key == Keys.Down)
                {
                    moveY = 5;
                    moveX = 0;

                    if (checkbounds())
                    {
                        SpriteY = SpriteY + moveY;
                    }
                    else
                    {
                        estadoJuego = true;
                    }
                }
                if (key == Keys.Left)
                {
                    moveY = 0;
                    moveX = -5;
                    if (checkbounds())
                    {
                        SpriteX = SpriteX + moveX;
                    }
                    else
                    {
                        estadoJuego = true;
                    }
                }
                if (key == Keys.Right)
                {
                    moveY = 0;
                    moveX = 5;
                    if (checkbounds())
                    {
                        SpriteX = SpriteX + moveX;
                    }
                    else
                    {
                        estadoJuego = true;
                    }
                }
                if (key == Keys.Escape)
                {
                    this.Exit();
                }
            }
            if (SpriteX < 0)
            {
                SpriteX = 0;
            }
            if (SpriteY < 0)
            {
                SpriteY = 0;
            }
            if(SpriteY > 610)
            {
                SpriteY = posyRana;
                SpriteX = posxRana;
                RanasCruzadas++;
            }
            if (SpriteX + moveX > _graphics.GraphicsDevice.Viewport.Width)//para manejar tamaño de pantalla
            {
                SpriteX = _graphics.GraphicsDevice.Viewport.Width - moveX;
            }
            if (SpriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)//para manejar tamaño de pantalla
            {
                SpriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }
            moverTroncos(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            for(int i=0; i<numT; i++)
            {
                _spriteBatch.Draw(_troncoObstaculo, troncos[i], Color.AliceBlue);
            }
            for(int i=0; i<numR; i++)
            {
                _spriteBatch.Draw(_rocas, rocas[i], Color.CornflowerBlue);
            }
            
            _spriteBatch.Draw(_troncoObstaculo, new Rectangle(0, 0, 800, 50), Color.YellowGreen);
            _spriteBatch.Draw(_troncoObstaculo, new Rectangle(0, 590, 800, 60), Color.Brown);
            _spriteBatch.Draw(ranas, new Rectangle(SpriteX, SpriteY, 35, 35), Color.White);
            _spriteBatch.DrawString(_text,"RANAS CRUZADAS: ", new Vector2(4, 4), Color.Black);
            _spriteBatch.DrawString(_text, RanasCruzadas.ToString(), new Vector2(115, 4), Color.Black);
            if (estadoJuego)
            {
                _spriteBatch.Draw(gameOver, new Rectangle(0,0,800, 650), Color.White);
            }
            if(RanasCruzadas== 5)
            {
                _spriteBatch.Draw(juegoGanado, new Rectangle(0, 0, 800, 650), Color.White);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        bool checkbounds()//función para calcular colisiones con los troncos o con las rocas
        {
            Rectangle temprect = new Rectangle(SpriteX + moveX, SpriteY + moveY, 40, 40);//pasamos la posición que toma la rana
            bool temreturn = true;//variable de retorno
            for (int i = 0; i < numT; i++)//verificamos si colisiona con cada uno de los troncos
            {
                if (temprect.Intersects(troncos[i]))
                {
                    temreturn = false;
                }
            }
            for(int i = 0; i< numR; i++)//verificamos si interseca con las rocas
            {
                if (temprect.Intersects(rocas[i]))
                {
                    temreturn = false;
                }
            }
            return temreturn;
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Snake
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D Snake;//variable para la serpiente
        Texture2D fondoLevel3;
        Texture2D gameOver;
        Texture2D apple;//variable para controlar el alimento que se comerá la serpiente
        List<Rectangle> posicSegment = new List<Rectangle>();//variables que manejan el movimiento en x y Y
        int velocidad = 20, score = 0, level =1;//variable que controlaremos los pixeles que se ejecutaran por segundo
        int velocidadX = 20, velocidadY = 0;//variables para controlar el movimiento
        Rectangle[] rects;//para manejar las paredes hasta donde se movilizará el snake
        SpriteFont fuente;// variable para la cargar la fuente que se utilizara en el juego
        int posX, posY;//variables que controlaran las coordenadas que se generaran para apple
        List<Rectangle> manzanas = new List<Rectangle>();//lista que ocuparemos de auxiliar y trabajar con choques
        int fotogramaporSegundo = 2;
        bool finJuego;
        int sumaAScore = 10;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 630;//ancho pantalla
            this._graphics.PreferredBackBufferHeight = 676;//alto de pantalla
            crearparedes();
            posicSegment.Add(new Rectangle(305, 330,20,20));
            finJuego = false;
        }
        void modificarFotograma(int ap)
        {
            this.fotogramaporSegundo = ap;
        }
        void crearparedes()//metodo para crear paredes
        {
            int nrects = 4;//inicializamos una variable que nos muestra el numero de paredes
            rects = new Rectangle[nrects];//en la variable global inicializamos todos los rectangulos
            rects[0] = new Rectangle(15, 38, 602, 9);//coordenadas para pared lado izquierdo
            rects[1] = new Rectangle(15,38,9,594);//coordenadas para pared de arriba
            rects[2] = new Rectangle(15,632,602,9);//coordenadas pared de abajo
            rects[3] = new Rectangle(607, 38, 9, 602);//coordenadas pared lado derecho
        }
        void crearComida()
        {
            Random rn = new Random();//hacemos uso de ramdom para generar posiciones aleatorias
            posX = rn.Next(25, 595);//generamos una posición aleatoria en el eje x de 17 a 617
            posY = rn.Next(48, 611);//generamos una posición aleatoria en el eje y de 38 a 623
            manzanas.Add(new Rectangle(posX, posY, 20, 20));
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            crearComida();//hacemos que se generen coordenadas aleatorias nomas empiece el juego
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fondoLevel3 = Content.Load<Texture2D>("fondoLevel3");
            Snake = Content.Load<Texture2D>("Snake1");//cargamos la imgane de serpiente
            apple = Content.Load<Texture2D>("manzana");//cargamos la imagen de manzana
            fuente = Content.Load<SpriteFont>("Writ");
            gameOver = Content.Load<Texture2D>("gameOver");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (score >= 100 && score < 300)
            {
                modificarFotograma(5);
                sumaAScore = 20;
                level= 2;
            }
            if (score >= 300 && score < 900)
            {
                modificarFotograma(8);
                sumaAScore = 30;
                level= 3;
            }
            if (score >= 900 && score < 1800)
            {
                modificarFotograma(11);
                sumaAScore = 40;
                level= 4;
            }
            if (score >= 1800)
            {
                sumaAScore = 50;
                modificarFotograma(14);
                level= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {//si se presiona la tecla de control derecho
                if (posicSegment.Count >= 2)
                {
                    if (checkbound2(posicSegment[0].X, posicSegment[0].Y, velocidad, 0) == false)
                    {
                        velocidadX = velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                        velocidadY = 0;//en el eje Y no ocurre nada
                    }
                }
                else
                {
                    velocidadX = velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                    velocidadY = 0;//en el eje Y no ocurre nada
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {//si se presiona la tecla de control izquierdo

                if (posicSegment.Count >= 2)
                {
                    if (checkbound2(posicSegment[0].X, posicSegment[0].Y, -velocidad, 0) == false)
                    {
                        velocidadX = -velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                        velocidadY = 0;//en el eje Y no ocurre nada
                    }
                }
                else
                {
                    velocidadX = -velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                    velocidadY = 0;//en el eje Y no ocurre nada
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {//si se presiona la tecla de control hacia arriba
                if (posicSegment.Count >= 2)
                {
                    if (checkbound2(posicSegment[0].X, posicSegment[0].Y, 0, -velocidad) == false)
                    {
                        
                        velocidadY = -velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                        velocidadX = 0;//en el eje Y no ocurre nada

                    }
                }
                else
                {
                    velocidadY = -velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                    velocidadX = 0;//en el eje Y no ocurre nada
                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {// si se presiona la tecla de control hacia abajo
                if (posicSegment.Count >= 2)
                {
                    if (checkbound2(posicSegment[0].X, posicSegment[0].Y, 0, velocidad) == false)
                    {
                        velocidadY = velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                        velocidadX = 0;//en el eje Y no ocurre nada
                    }
                }
                else
                {
                    velocidadY = velocidad;//hacemos que en el eje x se mueva 2 unidades de acuerdo al lapso transcurrido en segundos
                    velocidadX = 0;//en el eje Y no ocurre nada
                }
            }
            for (int i = posicSegment.Count - 1; i >= 1; i--)//inicializamos el for para saber el tamaño de elementos con los que cuenta el snake
            {
                posicSegment[i] = posicSegment[i - 1];//mientras se mueve, el ultimo elemento, toma la posición del elemento antes de el
            }
            
            posicSegment[0] = new Rectangle((posicSegment[0].X + velocidadX), (posicSegment[0].Y + velocidadY), 20, 20);
            if (checkbound() > 0)
                finJuego = true;
            //comprobamos obstaculos
            foreach (Rectangle r in rects)
            {
                if (r.Intersects(new Rectangle((int)posicSegment[0].X, (int)posicSegment[0].Y, 20, 20)))
                {
                    finJuego = true;//si hay intersección con las paredes, se cierra el juego
                }
            }
            for (int i = 0; i < manzanas.Count; i++)//con un for recorremos la información que existe en la lista
                {
                    if (manzanas[i].Intersects(new Rectangle((int)posicSegment[0].X, (int)posicSegment[0].Y, 20, 20)))//si las coordenadas del elemento que se esta analizando de la lista
                                                                                                                      //coincide con las coordenadas del snake, entramos al if
                    {
                        manzanas.RemoveAt(i);//eliminamos la manzana generada
                        score += sumaAScore;//aumentamos en 10 puntos el score del juego
                        int xUltima = posicSegment[posicSegment.Count - 1].X;
                        int yUltima = posicSegment[posicSegment.Count - 1].Y;
                        posicSegment.Add(new Rectangle(xUltima - System.Math.Sign(velocidadX) * 20, yUltima - System.Math.Sign(velocidadY) * 20,20,20));
                        crearComida();//creamos una nueva manzana en una posición que nuevamente se generará de manera aleatoria
                    }
            }
            // TODO: Add your update logic here
            IsFixedTimeStep = true;
            TargetElapsedTime = System.TimeSpan.FromSeconds(1.0f / fotogramaporSegundo);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(fondoLevel3, new Rectangle(15, 38, 602, 598), Color.AliceBlue);//dibujamos la imagen que tenemos en la variable de fond
            if (level == 1)
            {
                GraphicsDevice.Clear(Color.GreenYellow);
            }
            if(level == 2)
            {
                GraphicsDevice.Clear(Color.Yellow);
            }
            if(level == 3)
            {
                GraphicsDevice.Clear(Color.Orange);
            }
            if(level == 4)
            {
                GraphicsDevice.Clear(Color.Red);
            }
            if(level == 5)
            {
                GraphicsDevice.Clear(Color.Purple);
            }
            foreach (Rectangle p in posicSegment)
            {//variable para controlar la posicion inicial de nuestra serpiente
                _spriteBatch.Draw(Snake, new Rectangle((int)p.X, (int)p.Y, 20,20),Color.White);
            }
            for(int i=0; i< rects.Length; i++)//inicializamos un for de acuerdo a la cantidad de rectangulos que tengamos diseñados
            {
                _spriteBatch.Draw(Snake, rects[i], Color.Black);//mientras hayan rectangulos por dibujar, se iran dibujando uno a uno
            }
            _spriteBatch.Draw(apple, new Rectangle(posX, posY, 20, 20), Color.White);//dibujamos la manzana
            //dibujamos encabezado de texto
            _spriteBatch.DrawString(fuente,"* SNAKE *", new Vector2(270, 2), Color.Black);//nombre del juego
            _spriteBatch.DrawString(fuente,"SCORE: ", new Vector2(120, 8), Color.Black);//apartado para el score
            _spriteBatch.DrawString(fuente, score.ToString(), new Vector2(210, 8), Color.Black);//apartado para poder mostrar el score
            _spriteBatch.DrawString(fuente, "LEVEL: #", new Vector2(400,8), Color.Black);
            _spriteBatch.DrawString(fuente, level.ToString(), new Vector2(500, 8), Color.Black);
            if (finJuego)
            {
                _spriteBatch.Draw(gameOver, new Rectangle(0, 0, 630, 676),Color.White);
                _spriteBatch.DrawString(fuente, "* PUNTAJE LOGRADO *", new Vector2(100, 580), Color.Red);
                _spriteBatch.DrawString(fuente, score.ToString(), new Vector2(175, 600), Color.Red);
                _spriteBatch.DrawString(fuente, "* NIVEL *", new Vector2(335, 580), Color.Red);
                _spriteBatch.DrawString(fuente, level.ToString(), new Vector2(370, 600), Color.Red);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        //metodo para colisiones del snake con snake
        int checkbound()//metodo para verificar que la cabeza del snake no tenga las mismas coordenadas que una parte de su cuerpo
        {
            int result = 0;//variable de retorno boolean
            for (int i = 1; i < posicSegment.Count; i++)//para colisionar se requieren de mas de 4 snake
            {
                if (posicSegment[i].Intersects(posicSegment[0]))//si el nuevo rectangulo es igual a las coordenadas de una parte del snake
                {
                    result++;//la variable de retorno es true;
                }
            }
                return result;//retornamos la variable
        }
        bool checkbound2(int CurrentX, int CurrentY, int AddX, int AddY)//función para verificar que si la serpiente tiene un gran tamaño
        {                                                               //no vuelva por el cuerpo de ella misma
            bool result = false;//variable de retorno boolean
            Rectangle aux = new Rectangle(CurrentX + AddX, CurrentY + AddY, 20, 20);//nuevo rectangulo que nos simulará la nueva posicion del snake 1
            if (aux.Intersects(new Rectangle(posicSegment[1].X, posicSegment[1].Y, 20, 20)))//si el nuevo rectangulo es igual a las coordenadas de una parte del snake
            {
                result = true;//la variable de retorno es true;
                goto local;
            }
           local:
                return result;//retornamos la variable
        }
    }
}
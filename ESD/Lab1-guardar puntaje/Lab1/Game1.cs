using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Lab1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D sprite;//pacman
        Texture2D fondo;//laberinto
        Texture2D pared;//pared
        int spriteX = 468;//pos personaje principal
        int spriteY =521;
        int moveY=0;//incremento de coordenadas
        int moveX=0;
        int norects;//cantidad de paredes del laberinto
        Rectangle[] rects;//arreglo maneja las coordenadas de las paredes del labe
        //Animación pacman
        Texture2D spriteCerrar;
        Texture2D spriteArriba;
        Texture2D spriteAbajo;
        Texture2D spriteIzquierda;
        Texture2D spriteDerecha;
        bool bocaAbierta=false;
        int spriteDireccion = 3;//0=Arriba,1=Abajo,2=Izquierda,3=Derecha
        Rectangle tunnel1;
        Rectangle tunnel2;
        Rectangle closedoor;

        //version -puntos
        int noPts;// numero de puntos
        Rectangle[] pts;// rectángulos que rodearán a los puntos para detectar colis.
        int puntosposibles;//cantidad de puntos a colocar en el laberinto
        Texture2D mpuntos; //forma o imagen de los puntos.
        //version--fantasma
        Texture2D fantasma;
        Texture2D fantasmaOjo;
        Texture2D fantasmaPupil;
        Texture2D puerta;
        int[] fantasmaX;
        int[] fantasmaY;
        int[] fantasmaMoveX;
        int[] fantasmaMoveY;
        int[] fantasmaUltimaDireccion;
        int noFantasmas = 3;
        int randomSemilla = 0;
        bool[] cambioDireccion;
        bool[] fantasmasCambio;
        bool[] forzarFantasmas;
        bool forzar = false;
        bool abrirPuerta = false;
        bool cerrarPuerta=false;
        //version --sacar fantasmas
        bool finJuego=false;// controla si el juego finalizo 
        double primeraCorrida=0;//verifica si es la primera vez que se ejecuta el juego
        int segundotranscurridos = 0;//tiempo transcurrido desde que inicia el juego
        bool juegoCorriendo = true;//controla si el juego sigue activo
        bool primeraverificacion = false;//controla estado inicial para tomar el tiempo del juego.

        //version--niveles
        int puntaje;
        int maximopuntaje;
        int vidas;
        int nivel;
        bool muriendo = false;
        bool fantasmaeditable=false;
        double secondsPassed = 0;
        Texture2D gameover;
        SpriteFont puntajeTexto;
        //version come fantasma
        bool[] fantasmaVivo; // Arreglo que guarda el estado de vida de  cada fantasma
        Texture2D fantasmaboca;

        SoundEffect pollo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this._graphics.PreferredBackBufferWidth = 1024;//ancho pantalla
           this._graphics.PreferredBackBufferHeight = 767;//alto
            crearrectangulos();
            //version--puntos
            crearpuntos();
            //version--fantasma
            crearFantasmas(noFantasmas);
            puntaje = 0;
            nivel = 1;
            vidas = 3;
        }




        //version--puntos método crearpuntos
        void crearpuntos()
        {
            noPts = 783; // 29 * 27 (Cuadricula de puntos) 
            pts = new Rectangle[noPts];
            int counter = -1;
            int x = 177;
            int y = 42;
            for (int i = 0; i < 29; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    counter++;
                    //version come fantasma
                    Rectangle tempRect;
                    // Si es el primer punto || es el ultimo de la primera fila || el primero de la fila 22
                    // || el ultimo de la fila 22
                    if ((j == 0 && i == 0) || (j == 25 && i == 0) || (j == 0 && i == 22) || (j == 25 &&i == 22))
                        //si ingresa aca son los puntos de la esquina
                        // el ancho de los puntos sera 16 y el alto 15
                        tempRect = new Rectangle(x + (j * 24) - 4, y + (i * 21) - 4, 16, 15);
                    else
                        // si ingresa aca son puntos normales
                        // el ancho de los puntos sera 8 y el alto 7
                        tempRect = new Rectangle(x + (j * 24), y + (i * 21), 8, 7);
                   // Rectangle tempRect = new Rectangle(x + (j * 24), y + (i * 21), 8, 7);
                    bool flag = false;
                    for (int t = 0; t < norects; t++)
                    {
                        if (tempRect.Intersects(rects[t]))
                            flag = true;
                    }
                    if (!flag)
                        pts[counter] = tempRect;
                    else
                        counter--;
                }
            }
            //****fantasma
            
            //******
            pts[156] = new Rectangle(1, 1, 1, 1);
            pts[157] = new Rectangle(1, 1, 1, 1);
            pts[158] = new Rectangle(1, 1, 1, 1);
            pts[160] = new Rectangle(1, 1, 1, 1);
            pts[161] = new Rectangle(1, 1, 1, 1);
            pts[162] = new Rectangle(1, 1, 1, 1);
            pts[163] = new Rectangle(1, 1, 1, 1);

            pts[164] = new Rectangle(1, 1, 1, 1);
            pts[165] = new Rectangle(1, 1, 1, 1);
            pts[167] = new Rectangle(1, 1, 1, 1);
            pts[168] = new Rectangle(1, 1, 1, 1);
            pts[169] = new Rectangle(1, 1, 1, 1);
            pts[170] = new Rectangle(1, 1, 1, 1);
            pts[171] = new Rectangle(1, 1, 1, 1);
            pts[172] = new Rectangle(1, 1, 1, 1);
            pts[173] = new Rectangle(1, 1, 1, 1);
            pts[174] = new Rectangle(1, 1, 1, 1);
            pts[177] = new Rectangle(1, 1, 1, 1);
            pts[178] = new Rectangle(1, 1, 1, 1);
            pts[180] = new Rectangle(1, 1, 1, 1);
            pts[181] = new Rectangle(1, 1, 1, 1);
            pts[182] = new Rectangle(1, 1, 1, 1);
            pts[184] = new Rectangle(1, 1, 1, 1);
            pts[185] = new Rectangle(1, 1, 1, 1);
            pts[186] = new Rectangle(1, 1, 1, 1);
            pts[187] = new Rectangle(1, 1, 1, 1);
            pts[188] = new Rectangle(1, 1, 1, 1);
            pts[189] = new Rectangle(1, 1, 1, 1);
            pts[190] = new Rectangle(1, 1, 1, 1);
            pts[191] = new Rectangle(1, 1, 1, 1);
            pts[192] = new Rectangle(1, 1, 1, 1);
            pts[193] = new Rectangle(1, 1, 1, 1);
            pts[195] = new Rectangle(1, 1, 1, 1);
            pts[196] = new Rectangle(1, 1, 1, 1);
            pts[197] = new Rectangle(1, 1, 1, 1);
            pts[198] = new Rectangle(1, 1, 1, 1);
            pts[200] = new Rectangle(1, 1, 1, 1);
            pts[201] = new Rectangle(1, 1, 1, 1);
            pts[204] = new Rectangle(1, 1, 1, 1);
            pts[205] = new Rectangle(1, 1, 1, 1);
            pts[253] = new Rectangle(1, 1, 1, 1);
            pts[254] = new Rectangle(1, 1, 1, 1);



            


            puntosposibles = 500;


        }//fin crearpuntos

        //versio--fantasma
        void crearFantasmas(int cuantos)
        {
            noFantasmas = cuantos;
            fantasmaX = new int[noFantasmas];
            fantasmaY = new int[noFantasmas];
            fantasmaMoveX = new int[noFantasmas];
            fantasmaMoveY = new int[noFantasmas];
            fantasmaUltimaDireccion = new int[noFantasmas];
            fantasmasCambio = new bool[noFantasmas];
            cambioDireccion = new bool[noFantasmas];
            forzarFantasmas = new bool[noFantasmas];
            fantasmaVivo= new bool[noFantasmas];
            for (int i = 0; i < noFantasmas; i++)
            {
                fantasmaVivo[i] = true;//version  comer fantasma
                fantasmaX[i] = 450;
                fantasmaY[i] = 310;
                fantasmaMoveX[i] = 0;
                fantasmaMoveY[i] = 0;
                fantasmaUltimaDireccion[i] = -1;
                fantasmasCambio[i] = false;
                cambioDireccion[i] = false;
                forzarFantasmas[i] = false;
            }
        }
        //fin version fantasma

        //version --mover fantasma


        //version comer fantasma
        void fantasmaSonEditables(bool sonE)
        {
            if (sonE)
            {
                fantasmaeditable = true;
            }
            else
            {
                fantasmaeditable = false;
            }
        }
        //fin comer fantasma
        void animarFantasmas()
        {
            // Necesitamos seleccionar una dirección aleatoria, 
            // para moverse en esa dirección sin que tengamos colision 

            for (int i = 0; i < noFantasmas; i++)

            {

                if (fantasmaVivo[i])
                {

                    if (forzarFantasmas[i] == false)
                    {
                        if (cambioDireccion[i])
                        {
                            cambioDireccion[i] = false; // Nos aseguramos  que nos podemos mover
                            randomSemilla++;
                            Random rnd = new Random(randomSemilla);

                            int randomDireccion = rnd.Next(0, 4);
                            if ((fantasmaUltimaDireccion[i] == 0) || (fantasmaUltimaDireccion[i] == 1))
                                randomDireccion = rnd.Next(2, 4);
                            else
                                randomDireccion = rnd.Next(0, 2);
                            if (randomDireccion == 0)
                            {
                                fantasmaMoveY[i] = -5;
                                fantasmaMoveX[i] = 0;
                            }
                            if (randomDireccion == 1)
                            {
                                fantasmaMoveY[i] = 5;
                                fantasmaMoveX[i] = 0;
                            }
                            if (randomDireccion == 2)
                            {
                                fantasmaMoveY[i] = 0;
                                fantasmaMoveX[i] = -5;
                            }
                            if (randomDireccion == 3)
                            {
                                fantasmaMoveY[i] = 0;
                                fantasmaMoveX[i] = 5;
                            }
                            fantasmaUltimaDireccion[i] = randomDireccion;
                        }
                        if (checkbounds(fantasmaX[i], fantasmaY[i], fantasmaMoveX[i], fantasmaMoveY[i], fantasma, false, i))
                        {
                            Rectangle tempRect = new Rectangle(fantasmaX[i], fantasmaY[i], fantasma.Width, fantasma.Height);
                            if (tempRect.Intersects(tunnel1))
                                fantasmaX[i] = tunnel2.Left - tempRect.Width - 1;
                            else if (tempRect.Intersects(tunnel2))
                                fantasmaX[i] = tunnel1.Left + tunnel1.Width + 1;
                            else
                                fantasmaX[i] = fantasmaX[i] + fantasmaMoveX[i];
                            fantasmaY[i] = fantasmaY[i] + fantasmaMoveY[i];
                        }
                        else // El fantasma que colisiona con algo, 
                             //marcado para luego calcular una nueva dirección
                        {
                            cambioDireccion[i] = true;
                        }
                        if (fantasmasCambio[i])
                        {
                            fantasmasCambio[i] = false;
                            randomSemilla++;
                            Random aleatorio = new Random(randomSemilla);
                            if (aleatorio.Next(0, 100) > 50)
                            {
                                cambioDireccion[i] = true;
                            }
                        }
                    }
                }
            }
        }


        void moverFantasma()
        {
            // Primero movemos cada fantasma a las coordenas X de la 
           // linea de la puerta +1px

            int puertaIzquierda = 458;
            int puertaAncho = 42;
            int puertaArriba = 276;
            for (int i = 0; i < noFantasmas; i++)
            {
                if (forzarFantasmas[i] == true)
                {
                    if ((fantasmaX[i] > puertaIzquierda) && (fantasmaX[i] + fantasma.Width < puertaIzquierda + puertaAncho))
                    {
                        // cuando el fantasma esta en la linea de la 
                       //  puera lo movemos fuera de la caja
                        fantasmaMoveX[i] = 0;
                        fantasmaMoveY[i] = -5;
                        // habilitamos la colición de los fantasmas 
                    }
                    else if (fantasmaX[i] > puertaIzquierda)
                    {
                        fantasmaMoveX[i] = -5;
                        fantasmaMoveY[i] = 0;
                    }
                    else if (fantasmaX[i] < puertaIzquierda)
                    {
                        fantasmaMoveX[i] = 5;
                        fantasmaMoveY[i] = 0;
                    }
                    fantasmaX[i] = fantasmaX[i] + fantasmaMoveX[i];
                    fantasmaY[i] = fantasmaY[i] + fantasmaMoveY[i];
                    if (fantasmaY[i] + fantasma.Height < puertaArriba)
                    {
                        fantasmaUltimaDireccion[i] = 0;
                        forzarFantasmas[i] = false;
                    }
                }
            }
        }
        //fin version mover fantasma
        void crearrectangulos()
        {

            tunnel1 = new Rectangle(200,297,10,42);
            tunnel2 = new Rectangle(750, 297, 10, 42);
            closedoor = new Rectangle(458, 276, 42, 9);

            norects = 55;
            rects = new Rectangle[norects];
            rects[0] = new Rectangle();
            rects[0] = new Rectangle(162, 22, 10, 207);
            rects[1] = new Rectangle(217, 74, 78, 42);
            rects[2] = new Rectangle(346, 74, 102, 42);
            rects[3] = new Rectangle(575, 74, 102, 42);
            rects[4] = new Rectangle(729, 74, 78, 42);
            rects[5] = new Rectangle(213, 163, 78, 21);
            rects[6] = new Rectangle(422, 166, 174, 21);
            rects[7] = new Rectangle(725, 166, 78, 21);
            rects[8] = new Rectangle(161, 12, 687, 15);
            rects[9] = new Rectangle(851, 15, 15, 207);
            rects[10] = new Rectangle(493, 15, 30, 93);
            rects[11] = new Rectangle(158, 228, 140, 11);
            rects[12] = new Rectangle(345, 225, 102, 21);
            rects[13] = new Rectangle(572, 225, 102, 21);
            rects[14] = new Rectangle(725, 225, 145, 15);
            rects[15] = new Rectangle(160, 455, 12, 249);
            rects[16] = new Rectangle(850, 455, 12, 249);
            rects[17] = new Rectangle(340, 160, 30, 147);
            rects[18] = new Rectangle(645, 160, 30, 147);
            rects[19] = new Rectangle(492, 160, 30, 84);
            rects[20] = new Rectangle(646, 366, 30, 86);
            rects[21] = new Rectangle(345, 366, 30, 86);
            rects[22] = new Rectangle(160, 695, 687, 12);
            rects[23] = new Rectangle(420, 425, 174, 25);
            rects[24] = new Rectangle(221, 495, 78, 25);
            rects[25] = new Rectangle(723, 495, 78, 25);
            rects[26] = new Rectangle(156, 305, 130, 12);
            rects[27] = new Rectangle(740, 305, 145, 12);
            rects[28] = new Rectangle(156, 360, 140, 12);
            rects[29] = new Rectangle(730, 360, 145, 12);
            rects[30] = new Rectangle(160, 437, 135, 12);
            rects[31] = new Rectangle(730, 437, 145, 12);
            rects[32] = new Rectangle(283, 360, 12, 84);
            rects[33] = new Rectangle(727, 360, 12, 84);
            rects[34] = new Rectangle(285, 233, 12, 84);
            rects[35] = new Rectangle(727, 233, 12, 84);
            rects[36] = new Rectangle(345, 499, 102, 14);
            rects[37] = new Rectangle(573, 499, 102, 14);
            rects[38] = new Rectangle(580, 632, 227, 14);
            rects[39] = new Rectangle(220, 632, 227, 14);
            rects[40] = new Rectangle(420, 565, 177, 14);
            rects[41] = new Rectangle(170, 566, 48, 14);
            rects[42] = new Rectangle(802, 566, 48, 14);
            rects[43] = new Rectangle(265, 495, 30, 87);
            rects[44] = new Rectangle(725, 495, 30, 87);
            rects[45] = new Rectangle(494, 426, 30, 87);
            rects[46] = new Rectangle(493, 565, 30, 87);
            rects[47] = new Rectangle(345, 563, 30, 87);
            rects[48] = new Rectangle(649, 563, 30, 87);
            rects[49] = new Rectangle(417, 300, 9, 84);
            rects[50] = new Rectangle(591, 300, 9, 84);
            rects[51] = new Rectangle(419, 371, 170, 9);
            rects[52] = new Rectangle(418, 296, 66, 9);
            rects[53] = new Rectangle(533, 296, 66, 9);
            rects[54] = new Rectangle(465, 296, 66, 9);//Esta es la puerta

        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            sprite = Content.Load<Texture2D>("pacman01");
            fondo = Content.Load<Texture2D>("nivel01");
            pared = Content.Load<Texture2D>("rect");
            spriteCerrar = Content.Load<Texture2D>("pacman2");
            spriteArriba = Content.Load<Texture2D>("pacmanUp");
            spriteAbajo = Content.Load<Texture2D>("pacmanDown");
            spriteIzquierda = Content.Load<Texture2D>("pacmanLeft");
            spriteDerecha = Content.Load<Texture2D>("pacmanRight");
            mpuntos = Content.Load<Texture2D>("point");//version --puntos
            //version fantasma
            fantasma = Content.Load<Texture2D>("ghost");
            fantasmaOjo = Content.Load<Texture2D>("eye");
            fantasmaPupil= Content.Load<Texture2D>("pupil");
            puerta = Content.Load<Texture2D>("door");
            //fin version fantasma
            // TODO: use this.Content to load your game content here
            gameover = Content.Load<Texture2D>("gameover");
            puntajeTexto = Content.Load<SpriteFont>("texto");
            fantasmaboca= Content.Load<Texture2D>("mouth");

            try
            {
                string ruta = Path.Combine("score.txt");//ruta del archivo
                StreamReader conjuntocaracteres = File.OpenText(ruta);//lee conjunto de letras y los almacena en la
                                                                      //variable conjuntodecaracteres
                maximopuntaje = int.Parse(conjuntocaracteres.ReadToEnd());//convierte a entero las letras
                conjuntocaracteres.Close();//cierra archivo
            }
            catch (Exception e)
            {
                // No existe el archivo de puntaje
                string msg = e.ToString();//error de lectura
                maximopuntaje = 0;//puntaje inicial en cero
            }

        }
        /**Este método realiza la inicialización de las principales variables del juego, se invoca a este metodo
         en el inicio de cada nuevo nivel**/
      void iniciojuego(int nuevopuntaje, int nuevonivel,int nuevavidas,bool limpiarpuntaje)
        {
            secondsPassed = 0;//segundos transcurridos desde el inicio del juego
            fantasmaeditable = false;//Hara que los fantasmas se animen al colisionar con pacman
            cerrarPuerta = true;//al inicio la puerta está cerrada
            abrirPuerta = false;//
            segundotranscurridos = 0;//similar a secondspassed
            puntaje = nuevopuntaje;//almacena el puntaje acumulado
            nivel = nuevonivel;//nivel donde se encuentra el jugador
            vidas= nuevavidas;// vidas disponibles
            spriteX = 463;//posicion x inicial de pacman
            spriteY = 491;
            spriteDireccion = 3;//direccion inicial de pacman (orientacion derecha)
            moveX = 0;//incremento inicial de pos  en X de pacman=0
            moveY = 0;
            forzar = false;// no se libera a los fantasmas
            finJuego = false;// al iniciar juego finjuego =false
            primeraverificacion = false;// verificara el almacenamiento de puntos
            crearFantasmas(noFantasmas);// crea fantasmas en otros niveles
            crearrectangulos();//crea rectangulos en otros niveles
            if(limpiarpuntaje)// si limpiapuntajes es cierto(true) creara puntos en el laberinto
            {
                crearpuntos();
            }
            juegoCorriendo = true;//al iniciar juegocorriedo=true
}//fin metodo inicijuego

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState currentState= Keyboard.GetState();
            Keys[] currenkey= currentState.GetPressedKeys();

            
            //fin version come fantasma
            if (gameTime.TotalGameTime.Milliseconds%20==0)
            {
                // codigo que se ejecuta cada 20ms
                moveX = sprite.Width;
                moveY= sprite.Height;
            }
            else
            {
                 moveY=0;
                 moveX=0;
            }
            
            if (gameTime.TotalGameTime.Milliseconds % 15 == 0)
            {
               sprite = Content.Load<Texture2D>("pacman01");
            }
            if (gameTime.TotalGameTime.Milliseconds % 40 == 0)
            {
                sprite = Content.Load<Texture2D>("pacman02");
            }

            //--VERSION sacar fantasmas
            //se encarga de cerrar la puerta
            if (randomSemilla > 2147483)
                randomSemilla = 0;
            if (primeraverificacion == false)
            {
                primeraverificacion = true;
                primeraCorrida = gameTime.TotalGameTime.TotalSeconds;
                ContentManager iniciap = new ContentManager(this.Services, @"Content\");
                pollo = iniciap.Load<SoundEffect>("SnakeDown");
                pollo.Play();
            }
            cerrarPuerta = false;
            if (forzar == true)
            {
                cerrarPuerta = true;
                for (int i = 0; i < noFantasmas; i++)
                {
                    if (forzarFantasmas[i] == true)
                        cerrarPuerta = false;
                }
                if (cerrarPuerta == true)
                {
                    // Cuando todos los fantasmas esten fuera 
                    // se debe cerrar la puerta. 
                    rects[54] = new Rectangle(465, 296, 66, 9);
                   // rects[54] = new Rectangle(420, 276, 42, 9); // Cierra la puerta
                   // rects[54] = new Rectangle(458, 276, 42, 9); // Cierra la puerta
                }
            }

            //---------------------------------

            if (!finJuego)//si no es el fin dek juego
            {
            

                if (forzar == false)// si no se ha forzado la salida del fantasma entrar
                {
                    //comparamos tiempo total de inicio del juego es mayo a 2
                    if (gameTime.TotalGameTime.TotalSeconds > primeraCorrida + 2)
                    {
                        //comparamos 
                        //if (segundotranscurridos == 0)
                       
                        //si total de tiempo es menor a 2s
                        if (gameTime.TotalGameTime.TotalSeconds < segundotranscurridos + 2)
                        {
                             //cada 0.25s o cada 250ms ingresa 
                            if (gameTime.TotalGameTime.Milliseconds % 250 == 0)
                            {
                                //si abrirPuerta=true
                                if (abrirPuerta)
                                {   //cambiar el estado
                                    abrirPuerta = false;
                                }
                                else
                                {  //si es false,tambien hay que cambair el estado
                                    abrirPuerta = true;
                                }
                            }
                        }
                        else//sie el total de tiempo es >2s
                        {  //abre la puerta
                            rects[54] = new Rectangle(1, 1, 1, 1);
                            //fuerza a cada uno de los fantas a salir
                            for (int i = 0; i < noFantasmas; i++)
                            {
                                forzarFantasmas[i] = true;
                            }
                            forzar = true;//activa la bandera de sacar a los fantasmas
                        }
                    }
                }

            
            animarFantasmas();
            moverFantasma();
               

                int startsecs = 2000;//milisegundos iniciales
                int[] moveSecs = new int[noFantasmas];//milisegundos para cada fantasma
                for (int i = 0; i < noFantasmas; i++)
                {
                    moveSecs[i] = startsecs + i * 100;//cada fantasma saldrá con 100ms de diferencia
                }
                for (int i = 0; i < noFantasmas; i++)
                {
                    if (gameTime.TotalGameTime.Milliseconds % moveSecs[i] == 0)//cada 100ms se verifica si el fantasma cambio
                    {
                        fantasmasCambio[i] = true;
                    }
                }



                

                if (juegoCorriendo)//variable que verifica si el juego está activo
                {

                    // version come fantasma
                  /*  if (gameTime.TotalGameTime.Milliseconds % 1000 == 0)
                    {
                        if (fantasmaeditable)
                        {
                            if (segundotranscurridos == 5)// Numero de segundos que el fantasma es comestible
                            {
                                segundotranscurridos = 0;
                                fantasmaeditable = false;
                            }
                        }
                    }*/

                    foreach (Keys key in currenkey)
                    {
                        if (key == Keys.Up)
                        {
                            spriteDireccion = 0;//Direccion del pacman
                            moveY = -5;
                            moveX = 0;
                            if(checkbounds(spriteX, spriteY, moveX, moveY, spriteDerecha, true,0))
                            {
                                Rectangle tempRect = new Rectangle(spriteX, spriteY, spriteDerecha.Width, spriteDerecha.Height);
                                if (tempRect.Intersects(tunnel1))
                                {
                                    spriteX = tunnel2.Left - tempRect.Width;

                                }
                                else if (tempRect.Intersects(tunnel2))
                                {
                                    spriteX = tunnel1.Left + tunnel1.Width;

                                }
                                else
                                {
                                    spriteY = spriteY + moveY;

                                }
                            }


                        }
                        if (key == Keys.Down)
                        {
                            spriteDireccion = 1;
                            moveY = 5;//CORREGIMOS
                            moveX = 0;
                            

                            if (checkbounds(spriteX, spriteY, moveX, moveY, spriteDerecha, true,0))
                            {
                                Rectangle tempRect = new Rectangle(spriteX, spriteY, spriteDerecha.Width, spriteDerecha.Height);
                                if (tempRect.Intersects(tunnel1))
                                {
                                    spriteX = tunnel2.Left - tempRect.Width;

                                }
                                else if (tempRect.Intersects(tunnel2))
                                {
                                    spriteX = tunnel1.Left + tunnel1.Width;

                                }
                                else
                                {
                                    spriteY = spriteY + moveY;

                                }
                            }




                        }
                        if (key == Keys.Left)
                        {
                            spriteDireccion = 2;
                            moveY = 0;
                            moveX = -5;

                            if (checkbounds(spriteX, spriteY, moveX, moveY, spriteDerecha, true,0))
                            {
                                Rectangle tempRect = new Rectangle(spriteX, spriteY, spriteDerecha.Width, spriteDerecha.Height);
                                if (tempRect.Intersects(tunnel1))
                                {
                                    spriteX = tunnel2.Left - tempRect.Width;

                                }
                                else if (tempRect.Intersects(tunnel2))
                                {
                                    spriteX = tunnel1.Left + tunnel1.Width;

                                }
                                else
                                {
                                    spriteX = spriteX + moveX;

                                }
                            }



                        }
                        if (key == Keys.Right)
                        {
                            spriteDireccion = 3;
                            moveY = 0;
                            moveX = 5;

                            if (checkbounds(spriteX, spriteY, moveX, moveY, spriteDerecha, true,0))
                            {
                                Rectangle tempRect = new Rectangle(spriteX, spriteY, spriteDerecha.Width, spriteDerecha.Height);
                                if (tempRect.Intersects(tunnel1))
                                {
                                    spriteX = tunnel2.Left - tempRect.Width;

                                }
                                else if (tempRect.Intersects(tunnel2))
                                {
                                    spriteX = tunnel1.Left + tunnel1.Width;

                                }
                                else
                                {
                                    spriteX = spriteX + moveX;

                                }
                            }

                        }
                        if (key == Keys.Escape)
                        {
                            this.Exit();
                        }
                    }
                   

                    

                }//juegocorriendo
            }//noes el fin del juego

            

            if (gameTime.TotalGameTime.Milliseconds % 500 == 0)
            {
                if(bocaAbierta)//pase si bocaAbierta=true
                {
                      
                    //true
                    bocaAbierta = false;
                }
                else
                {
                    bocaAbierta = true;
                }
            }

            if (spriteX<0)
                spriteX=0;
            if(spriteY<0)
                spriteY=0;
            if(spriteX+moveX>_graphics.GraphicsDevice.Viewport.Width)
            {
                spriteX = _graphics.GraphicsDevice.Viewport.Width-moveX;
            }
            if (spriteY + moveY > _graphics.GraphicsDevice.Viewport.Height)
            {
                spriteY = _graphics.GraphicsDevice.Viewport.Height - moveY;
            }

            // version come fantasma
            if (gameTime.TotalGameTime.Milliseconds % 1000 == 0)
            {
                if (fantasmaeditable)
                {
                    segundotranscurridos++;
                    if (segundotranscurridos >= 5)// Numero de segundos que el fantasma es comestible
                    {
                        segundotranscurridos = 0;
                        fantasmaeditable = false;
                    }
                }
            }

            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(fondo, new Rectangle(0, 0, fondo.Width, fondo.Height), Color.White);
            Rectangle tempRect = new Rectangle(spriteX, spriteY, spriteCerrar.Width, spriteCerrar.Height);

           //cerrar la puerta
            if (bocaAbierta || forzar)
            {
                if (!cerrarPuerta)
                    _spriteBatch.Draw(puerta, closedoor, Color.White);
            }



            if (bocaAbierta)
            {
               //validaciones de direccion
               if(spriteDireccion==0)
                {
                    _spriteBatch.Draw(spriteArriba, tempRect, Color.White);
                }
               else if(spriteDireccion==1)
                {
                    _spriteBatch.Draw(spriteAbajo, tempRect, Color.White);
                }
                else if (spriteDireccion == 2)
                {
                    _spriteBatch.Draw(spriteIzquierda, tempRect, Color.White);
                }
                else if (spriteDireccion == 3)
                {
                    _spriteBatch.Draw(spriteDerecha, tempRect, Color.White);
                }
            }
            else
            {

                _spriteBatch.Draw(spriteCerrar, tempRect, Color.White);
            }

            //_spriteBatch.Draw(sprite, new Rectangle(spriteX, spriteY, sprite.Width, sprite.Height), Color.White);


            _spriteBatch.Draw(pared, tunnel1, Color.White);
            _spriteBatch.Draw(pared, tunnel2, Color.White);

            for (int i=0;i<norects;i++)
            {
                _spriteBatch.Draw(pared, rects[i], Color.White);
            }
            //version--puntos
            for (int i = 0; i < noPts; i++)
            {
                Rectangle tester = new Rectangle(1, 1, 1, 1); // Aqui verifica si el rectangulo debe ser dibujado.
                if (pts[i] != tester)
                    _spriteBatch.Draw(mpuntos, pts[i], Color.White); //  Este es el punto. 
            }
            //fin 

            //version--fantasma
            Color[] fantasmasColores = new Color[5];
            fantasmasColores[0] = new Color(87, 171, 255);
            fantasmasColores[1] = new Color(255, 171, 255);
            fantasmasColores[2] = new Color(255, 131, 3);
            fantasmasColores[3] = new Color(255, 255, 255);
            fantasmasColores[4] = new Color(25, 255, 0);
            int tempContador = -1;

            //---------------------------------------------------------------------
            for (int i = 0; i < noFantasmas; i++)
            {
                if (fantasmaVivo[i])
                {
                    tempContador++;
                    _spriteBatch.Draw(fantasma, new Rectangle(fantasmaX[i], fantasmaY[i], fantasma.Width, fantasma.Height), fantasmasColores[i]);
                    _spriteBatch.Draw(fantasmaOjo, new Rectangle(fantasmaX[i] +
                    5, fantasmaY[i] + 4, fantasmaOjo.Width, fantasmaOjo.Height), Color.White);
                    _spriteBatch.Draw(fantasmaOjo, new Rectangle(fantasmaX[i] +
                     17, fantasmaY[i] + 4, fantasmaOjo.Width, fantasmaOjo.Height), Color.White);
                    if ((fantasmaUltimaDireccion[i] == 0) ||
                    (fantasmaUltimaDireccion[i] == -1))
                    {
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 7, fantasmaY[i] + 4, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 19, fantasmaY[i] + 4, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                    }
                    if (fantasmaUltimaDireccion[i] == 1)
                    {
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 7, fantasmaY[i] + 11, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 19, fantasmaY[i] + 11, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                    }
                    if (fantasmaUltimaDireccion[i] == 2)
                    {
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 4, fantasmaY[i] + 7, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 16, fantasmaY[i] + 7, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                    }
                    if (fantasmaUltimaDireccion[i] == 3)
                    {
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 10, fantasmaY[i] + 7, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                        _spriteBatch.Draw(fantasmaPupil, new
                        Rectangle(fantasmaX[i] + 22, fantasmaY[i] + 7, fantasmaPupil.Width,
                        fantasmaPupil.Height), Color.White);
                    }

                    if (fantasmaeditable)
                    {
                        _spriteBatch.Draw(fantasmaboca, new
                       Rectangle(fantasmaX[i] + 2, fantasmaY[i] + 16, fantasmaboca.Width,
                       fantasmaboca.Height), Color.White);
                    }
                    if (tempContador == 4)
                        tempContador = -1;

                }
            }




            if(finJuego)
            {
                _spriteBatch.Draw(gameover, new Rectangle(80, 25, 900, 500), Color.White);
            }
            
            /*VERSION PUNTAJE MAXIMO*/
            if (puntaje > maximopuntaje)// si el puntaje de la partida es mayor a maximopuntaje
            {
                try
                {
                    string ruta = Path.Combine("score.txt");//lee ruta del archivo
                    StreamWriter stream = File.CreateText(ruta);// lee caracteres
                    stream.Write(puntaje.ToString());//escribe puntaje en archivo
                    stream.Close();//cierra archivo
                    maximopuntaje = puntaje;// maximopuntaje es igual al puntaje
                }
                catch (Exception e)
                {
                    // Si el archivo no existe entonces el maximopuntaje es Cero
                    string msg = e.ToString();
                    maximopuntaje = 0;
                }
            }
            string maxpuntajecadena = maximopuntaje.ToString("0\n0\n0\n0\n0");
            _spriteBatch.DrawString(puntajeTexto, maxpuntajecadena, new Vector2(878.0f, 110.0f), Color.White);
            
            string puntajecadena = puntaje.ToString("0\n0\n0\n0\n0\n");
            _spriteBatch.DrawString(puntajeTexto, puntajecadena, new Vector2(60.0f, 110.0f), Color.White);


            for (int i = 0; i < (vidas-1);i++)
            {
                float temtop=(float)spriteDerecha.Height*(float)i*1.3f;
                _spriteBatch.Draw(spriteDerecha, new Rectangle(53, 570 + (int)temtop, spriteDerecha.Width,
                    spriteDerecha.Height), Color.Red);
            }

            //fin version fantasma
            _spriteBatch.End();
            // TODO: Add your drawing code here

           


            base.Draw(gameTime);
        }
        //METODO PERMITE 
        bool checkbounds()
        {
            Rectangle temprect = new Rectangle(spriteX + moveX, spriteY + moveY, sprite.Width, sprite.Height);
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

        //--version sacar fantasma
        bool checkbounds(int CurrentX,int CurrentY,int AddX,int AddY,Texture2D character,bool isSprite,int idfantasma)
        {
            Rectangle temprect = new Rectangle(CurrentX + AddX, CurrentY+AddY, sprite.Width, sprite.Height);

            bool tempReturn = true;
            if (isSprite)
            {
                for (int i = 0; i < noPts; i++)
                {
                    if (temprect.Intersects(pts[i]))
                    {
                        if (juegoCorriendo)
                        {
                            
                            if ((pts[i] == new Rectangle(177 + (0 *24) - 4, 42 + (0 * 21) - 4, 16, 15)) ||
                                (pts[i] == new Rectangle(177 + (25 * 24) - 4, 42 + (0 * 21) - 4,16, 15)) ||
                                (pts[i] == new Rectangle(177 + (0 * 24) - 4, 42 + (22 * 21) - 4,16, 15)) ||
                                (pts[i] == new Rectangle(177 + (25 * 24) - 4, 42 + (22 * 21) - 4,16, 15)))
                               {
                                puntaje += (nivel * 20);
                                fantasmaSonEditables(true);
                                
                               }
                            else
                            {
                                puntaje += (nivel * 10);
                            }
                            pts[i] = new Rectangle(1, 1, 1, 1);
                            puntosposibles--;
                            if (puntosposibles == 0) // Cuando el  nivel se completa, avanzamos al siguiente
                            {
                                noFantasmas++;
                                nivel++;
                                puntosposibles = 300;
                               iniciojuego(puntaje, nivel, vidas, true);
                                 
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < norects; i++)
            {
                if (temprect.Intersects(rects[i]))
                    tempReturn = false;
            }
            if (!isSprite)
            {
                if (temprect.Intersects(new Rectangle(spriteX, spriteY, spriteArriba.Width, spriteAbajo.Height)))
                {
                    tempReturn = false;
                    if (fantasmaeditable)
                    {
                        fantasmaVivo[idfantasma] = false;
                    }
                    else
                    {
                        if (!muriendo)
                        {
                            vidas--;
                            muriendo = true;
                            iniciojuego(puntaje, nivel, vidas, true);
                            muriendo = false;
                            if (vidas == 0)
                                finJuego = true;
                        }
                    }
                  
                }
            }


            return tempReturn;
        }//fin metodo checkbounds

    }//class
}//namespace

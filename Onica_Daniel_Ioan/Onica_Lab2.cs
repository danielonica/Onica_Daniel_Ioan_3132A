using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Onica_Daniel_Ioan
{


    /// <summary>
    /// Aplicatia porneste prin apsarea tastei R si se opreste prin apasarea tastei S , prin sageata la stanga, cubul se roteste la stanga ,p rin apasare la dreapta cubul se roteste la dreapta
    /// Onica Daniel Ioan
    /// 3132A
    /// 3
    ///
    /// </summary>
    class EgcLab2:GameWindow
    {
         
        bool start = false;
        bool TurnLeft = false;
        bool TurnRight = false;
        bool StartMove = false;       
        KeyboardState lastKeyPressed;
        private readonly Randomizer rando;
        private readonly Axes axes;
        private Triangle triunghi;
        private Cub cube;
        private readonly CameraViz camera;

   
        private const int XYZ_SIZE = 75;

        private const int colorMax = 255;
        private const int colorMin = 0;
        private readonly Color DEFAULT_BKG_COLOR = Color.FromArgb(49, 50, 51);


        private int[] ColorRed = new int[3];
        private int[] ColorGreen = new int[3];
        private int[] ColorBlue = new int[3];
        private int Increment = 5;

        private readonly string coordonateTriunghi = @"C:\Users\Admin\Documents\VisualStudio facultate\Onica_Daniel_Ioan\CoordonateTriunghi.txt";
        private readonly string coorodnateCub = @"C:\Users\Admin\Documents\VisualStudio facultate\Onica_Daniel_Ioan\CoordonateCub.txt";
  
        private int[] SeePort = new int[3];
        Color[] colors;

        public EgcLab2() : base(800, 600)
        {
            VSync = VSyncMode.On;
            KeyDown += Keyboard_KeyDown;
            SeePort[0] = SeePort[1] = SeePort[2] = 10;
            rando = new Randomizer();
            axes = new Axes();
            triunghi = Triangle.ReadCoordonates(coordonateTriunghi);
            cube = new Cub(coorodnateCub);
            camera = new CameraViz();
            DisplayHelp();
            colors = new Color[6];
            for (int i = 0; i < 6; i++)
                colors[i] = rando.RandomColor();

            ColorRed[0] = ColorGreen[0] = ColorBlue[0] = 0;
            ColorRed[1] = ColorGreen[1] = ColorBlue[1] = 100;
            ColorRed[2] = ColorGreen[2] = ColorBlue[2] = 150;
        }

        public bool CheckIfInRangeColor(int color)
        {
            if (color >= colorMin && color < colorMax)
                return true;
            return false;
        }

        private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

        }




        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);

            // set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            // set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            // set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 1024);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);


            // set the eye
            camera.SetCamera();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (keyboard[Key.Escape])
            {
                Exit();
            }

            if (keyboard[Key.F11])
            {
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            }

            if (keyboard[Key.H] && !lastKeyPressed[Key.H])
            {
                DisplayHelp();
            }

            if (keyboard[Key.B] && !lastKeyPressed[Key.B])
            {
                GL.ClearColor(rando.RandomColor());
            }

            if (keyboard[Key.K] && !lastKeyPressed[Key.K])
            {
                axes.ToggleVisibility();
            }

            if (keyboard[Key.P] && !lastKeyPressed[Key.P])
            {
                triunghi.ToggleVisibility();
            }

            if (keyboard[Key.C] && !lastKeyPressed[Key.L])
            {
                cube.ToggleVisibility();
            }

            /////Rezolvare exercitiu 3  ============ TEMA 4

            if (keyboard[Key.Number1] && !lastKeyPressed[Key.Number1])
            {
                colors[0] = rando.RandomColor();
            }

            if (keyboard[Key.Number2] && !lastKeyPressed[Key.Number2])
            {
                colors[1] = rando.RandomColor();
            }

            if (keyboard[Key.Number3] && !lastKeyPressed[Key.Number3])
            {
                colors[2] = rando.RandomColor();
            }

            if (keyboard[Key.Number4] && !lastKeyPressed[Key.Number4])
            {
                colors[3] = rando.RandomColor();
            }

            if (keyboard[Key.Number5] && !lastKeyPressed[Key.Number5])
            {
                colors[4] = rando.RandomColor();
            }

            if (keyboard[Key.Number6] && !lastKeyPressed[Key.Number6])
            {
                colors[5] = rando.RandomColor();
            }
            ////////////////////

            // camera control (isometric mode)
            if (keyboard[Key.W])
            {
                camera.MoveForward();
            }
            if (keyboard[Key.S])
            {
                camera.MoveBackward();
            }
            if (keyboard[Key.A])
            {
                camera.MoveLeft();
            }
            if (keyboard[Key.D])
            {
                camera.MoveRight();
            }
            if (keyboard[Key.Q])
            {
                camera.MoveUp();
            }
            if (keyboard[Key.E])
            {
                camera.MoveDown();
            }

            else if (keyboard[Key.R])
            {
                if (ColorRed[0] < colorMax - Increment)
                {
                    ColorRed[0] += Increment;
                }
                if (ColorRed[1] < colorMax - Increment)
                {
                    ColorRed[1] += Increment;
                }
                if (ColorRed[2] < colorMax - Increment)
                {
                    ColorRed[2] += Increment;
                }
                DisplayColors();
            }

            else if (keyboard[Key.T])
            {
                if (ColorBlue[0] < colorMax - Increment)
                {
                    ColorBlue[0] += Increment;
                }
                if (ColorBlue[1] < colorMax - Increment)
                {
                    ColorBlue[1] += Increment;
                }
                if (ColorBlue[2] < colorMax - Increment)
                {
                    ColorBlue[2] += Increment;
                }
                DisplayColors();
            }

            else if (keyboard[Key.Y])
            {
                if (ColorGreen[0] < colorMax - Increment)
                {
                    ColorGreen[0] += Increment;
                }
                if (ColorGreen[1] < colorMax - Increment)
                {
                    ColorGreen[1] += Increment;
                }
                if (ColorGreen[2] < colorMax - Increment)
                {
                    ColorGreen[2] += Increment;
                }
                DisplayColors();
            }

            else if (keyboard[Key.U])
            {
                if (ColorRed[0] > colorMax + Increment)
                {
                    ColorRed[0] -= Increment;
                }
                if (ColorRed[1] > colorMax + Increment)
                {
                    ColorRed[1] -= Increment;
                }
                if (ColorRed[2] > colorMax + Increment)
                {
                    ColorRed[2] -= Increment;
                }
                DisplayColors();
            }

            else if (keyboard[Key.I])
            {
                if (ColorBlue[0] > colorMax + Increment)
                {
                    ColorBlue[0] -= Increment;
                }
                if (ColorBlue[1] > colorMax + Increment)
                {
                    ColorBlue[1] -= Increment;
                }
                if (ColorBlue[2] > colorMax + Increment)
                {
                    ColorBlue[2] -= Increment;
                }
                DisplayColors();
            }

            else if (keyboard[Key.O])
            {
                if (ColorGreen[0] > colorMax + Increment)
                {
                    ColorGreen[0] -= Increment;
                }
                if (ColorGreen[1] > colorMax + Increment)
                {
                    ColorGreen[1] -= Increment;
                }
                if (ColorGreen[2] > colorMax + Increment)
                {
                    ColorGreen[2] -= Increment;
                }
                DisplayColors();
            }

            lastKeyPressed = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            axes.Draw();

            triunghi.A.SetColor(Color.FromArgb(ColorRed[0], ColorBlue[0], ColorGreen[0]));
            triunghi.B.SetColor(Color.FromArgb(ColorRed[1], ColorBlue[1], ColorGreen[1]));
            triunghi.C.SetColor(Color.FromArgb(ColorRed[2], ColorBlue[2], ColorGreen[2]));
            triunghi.DrawMeColor();

            cube.DrawMeColor(colors);

            this.SwapBuffers();
        }

        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Red);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Black);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Orange);

            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.Aquamarine);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.Black);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }

        private void DrawAxes()///////////////////// Axe de coordonate
        {
            //GL.LineWidth(3.0f);

            // Desenează axa Ox (cu roșu).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(XYZ_SIZE, 0, 0);
            GL.End();

            // Desenează axa Oy (cu galben).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, XYZ_SIZE, 0); ;
            GL.End();

            // Desenează axa Oz (cu verde).
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, XYZ_SIZE);
            GL.End();
        }
        private void DisplayHelp()
        {
            Console.WriteLine("FUNCTIONALITATE");
            Console.WriteLine(" H - help menu");
            Console.WriteLine(" ESC parasire aplicatie");
            Console.WriteLine(" F11 fullscreen");
            Console.WriteLine(" K view axe");
            Console.WriteLine(" P triunghi on/off");
            Console.WriteLine(" C cub on/off");
            Console.WriteLine(" B background culoare");
            Console.WriteLine(" R-T-Y - culoare triunghi size-up");
            Console.WriteLine(" U,I,O - culoare triunghi size-down)");
            Console.WriteLine(" 1,2,3,4,5,6 culoare fete cub");
            Console.WriteLine(" W,A,S,D - camera deplasare");
        }

        private void DisplayColors()
        {
            Console.WriteLine("Setul A :" + ColorRed[0].ToString() + " - " + ColorBlue[0].ToString() + " - " + ColorGreen[0].ToString());
            Console.WriteLine("Setul B :" + ColorRed[1].ToString() + " - " + ColorBlue[1].ToString() + " - " + ColorGreen[1].ToString());
            Console.WriteLine("Setul C :" + ColorRed[2].ToString() + " - " + ColorBlue[2].ToString() + " - " + ColorGreen[2].ToString() + "\n");
        }

    }
}


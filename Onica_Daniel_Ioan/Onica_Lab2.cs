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
        const float rotation_speed = 180.0f;
        float angle;
        private const int XYZ_SIZE = 75;
        private const int colorMax = 255;
        private const int colorMin = 0;
        private int redC = 0, greenC = 0, blueC = 0;
        private const String FileName = @"C:\Users\Admin\Documents\VisualStudio facultate\Onica_Daniel_Ioan\Onica_Daniel_Ioan\CoordonateTriunghi.txt";
        private bool showCube = true;
        private bool  mouseRight, mouseLeft;
        private int[] SeePort = new int[3];


        public EgcLab2() : base(800, 600)
        {
            VSync = VSyncMode.On;
            KeyDown += Keyboard_KeyDown;
            SeePort[0] = SeePort[1] = SeePort[2] = 10;
        
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
            GL.ClearColor(Color.MidnightBlue);
           // GL.Enable(EnableCap.DepthTest);
        }




        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(-10.0, 10.0, -10.0, 10.0, 0.0, 4.0);
            double aspect_ratio = Width / (double)Height;

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();



            ///
            /// Laborator 3 ---- Afisare in consola a RGB
            ///
            if (keyboard[OpenTK.Input.Key.G])
            {
                if (keyboard[OpenTK.Input.Key.Up])
                {
                    if (CheckIfInRangeColor(greenC))
                    {
                        greenC++;
                        Console.WriteLine("Red: " + redC + " Green: " + greenC + " Blue: " + blueC);
                    }
                }
                else if (keyboard[OpenTK.Input.Key.Down])
                {
                    if (CheckIfInRangeColor(greenC - 1))
                    {
                        greenC--;
                        Console.WriteLine("Red: " + redC + " Green: " + greenC + " Blue: " + blueC);
                    }
                }
            }

            if (keyboard[OpenTK.Input.Key.R])
            {
                if (keyboard[OpenTK.Input.Key.Up])
                {
                    if (CheckIfInRangeColor(redC))
                    {
                        redC++;
                        Console.WriteLine("Red: " + redC + " Green: " + greenC + " Blue: " + blueC);
                    }
                }
                else if (keyboard[OpenTK.Input.Key.Down])
                {
                    if (CheckIfInRangeColor(redC - 1))
                    {
                        redC--;
                        Console.WriteLine("Red: " + redC + " Ggreen: " + greenC + " Blue: " + blueC);
                    }
                }
            }

            if (keyboard[OpenTK.Input.Key.B])
            {
                if (keyboard[OpenTK.Input.Key.Up])
                {
                    if (CheckIfInRangeColor(blueC))
                    {
                        blueC++;
                        Console.WriteLine("Red: " + redC + " Green: " + greenC + " Blue: " + blueC);
                    }
                }
                else if (keyboard[OpenTK.Input.Key.Down])
                {
                    if (CheckIfInRangeColor(blueC - 1))
                    {
                        blueC--;
                        Console.WriteLine("Red: " + redC + " Green: " + greenC + " Blue: " + blueC);
                    }
                }
            }


            if (keyboard[Key.Escape])
            {
                Exit();
                return;
            }

            if (keyboard[Key.F11])
            {
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            }



            //Laborator 2 -------------------------------------


            else if (keyboard[Key.R] && !keyboard.Equals(lastKeyPressed))
            {
                if (!start)
                {
                    start = true;
                }
            }
            else if (keyboard[Key.S] && !keyboard.Equals(lastKeyPressed))
            {
                if (start)
                {
                    start = false;
                }
            }
            else if (keyboard[Key.Left] && !keyboard.Equals(lastKeyPressed))
            {
                if (TurnLeft)
                    TurnLeft = false;
                else
                    TurnLeft = true;
            }
            else if (keyboard[Key.Right] && !keyboard.Equals(lastKeyPressed))
            {
                if (TurnRight)
                    TurnRight = false;
                else
                    TurnRight = true;
            }

            if (mouse[MouseButton.Middle])
            {
                if (StartMove)
                {
                    StartMove = false;
                }
                else
                {
                    StartMove = true;
                }
            }

            if (mouse[MouseButton.Middle])
            {
                if (StartMove)
                {
                    StartMove = false;
                }
                else
                {
                    StartMove = true;
                }
            }


            /// 
            /// Schimbare unghi camera in functie de miscarea mouse-ului.
            /// 

            if (mouse.X < -50)
            {
                mouseLeft = true;
                if (SeePort[0] > -10)
                    SeePort[0]--;
            }
            else if (mouse.X > 100)
            {
                mouseRight = true;
                if (SeePort[0] < 20)
                    SeePort[0]++;
            }
            if (mouse.Y < -50)
            {
                mouseLeft = true;
                if (SeePort[1] > -10)
                    SeePort[1]--;
            }
            else if (mouse.Y > 100)
            {
                mouseRight = true;
                if (SeePort[1] < 20)
                    SeePort[1]++;
            }



            lastKeyPressed = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //Matrix4 lookat = Matrix4.LookAt(15, 15, 5, 0, 0, 0, 0, 1, 0);
            Matrix4 lookat = Matrix4.LookAt(SeePort[0], SeePort[1], SeePort[2], 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            DrawAxes();

            Triangle trg1 = Triangle.ReadCoordonates(FileName); //////////// Triunghi
            trg1.DrawMe(redC, greenC, blueC);


            angle += rotation_speed * (float)e.Time;

            if (start)
            {
                if (TurnRight)
                {
                    GL.Rotate(angle, 1.0f, -1.0f, 0.0f);
                }
                else if (TurnLeft)
                {
                    GL.Rotate(angle, 1.0f, 1.0f, 0.0f);
                }

               
                DrawCube();
            }
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

        static void Main()
        {
            using (EgcLab2 project = new EgcLab2())
            {
                project.Run(30.0, 0.0);
            }
        }
    }
}


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

        public EgcLab2() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
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
           

            lastKeyPressed = keyboard;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 lookat = Matrix4.LookAt(15, 15, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

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

        static void Main()
        {
            using (EgcLab2 project = new EgcLab2())
            {
                project.Run(30.0, 0.0);
            }
        }
    }
}


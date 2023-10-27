using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Diagnostics;

namespace ProGrafica
{
    class game : GameWindow
    {
        private Double theta = 0;
        Escena cuarto;
        Objeto objeto;

        public void thetaInc()
        {
            if (theta == 360)
            {
                theta = 0;
            }
            else
            {
                theta += 1;
            }
        }
        public game(int widht, int height, string title) : base(widht, height, GraphicsMode.Default, title)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            cuarto = JSON.Load<Escena>("Escena\\cuarto.txt");

            objeto = new Objeto(cuarto.buscarObjeto("Auto"));
            cuarto.translate(0.0, 5.0, 0.0);
            objeto.scale(1.5f);
            objeto.rotate("y", 45.0f);
            
            //cuarto.scale(0.5f);
            //cuarto.rotate("y", 45.0f);
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //wea de la doc

            GL.Rotate(10.0, 1.0, 0.0, 0.0); //rotar 10 grados en x
            GL.Rotate(theta, 0.0, 1.0, 0.0); //rotar theta grados en y
            Axis axis = new Axis();
            
            thetaInc();

            cuarto.draw();
            objeto.draw();

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Double escala = 7.0;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-escala, escala, -escala, escala, -escala, escala);//set escala
            GL.MatrixMode(MatrixMode.Modelview);


            base.OnResize(e);
        }
    }
}

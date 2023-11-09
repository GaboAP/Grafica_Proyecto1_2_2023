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
        private double phi = 0;
        Escena cuarto;


        public void thetaInc()
        {
            if (theta == 360)
            {
                theta = 0;
            }
            else
            {
                theta += 0.0001;
            }
            if (phi == 360)
            {
                
                phi = 0;
            }
            else
            {
                phi += 0.5;
            }
        }
        public game(int widht, int height, string title) : base(widht, height, GraphicsMode.Default, title)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Objeto auto = new Objeto();
            Objeto pared = new Objeto();
            Objeto repisa = new Objeto();
            Color colorCelestevidrio = Color.FromArgb(1, 168, 204, 215);
            Poligono vidrioDelantero = new Poligono(colorCelestevidrio, new Point(0, 0, 0.36));
                vidrioDelantero.addVertice(-0.1f, -0.125f, 0.125f);
                vidrioDelantero.addVertice(-0.1f, 0.125f, -0.125f);
                vidrioDelantero.addVertice(0.1f, 0.125f, -0.125f);
                vidrioDelantero.addVertice(0.1f, -0.125f, 0.125f);
            Poligono vidrioTrasero = new Poligono(colorCelestevidrio,new Point(0,0,-0.36));
                vidrioTrasero.addVertice(-0.1f, 0.125f, 0.125f);
                vidrioTrasero.addVertice(-0.1f, -0.125f, -0.125f);
                vidrioTrasero.addVertice(0.1f, -0.125f, -0.125f);
                vidrioTrasero.addVertice(0.1f, 0.125f, 0.125f);
            Color rojoAuto = Color.FromArgb(1, 170, 51, 51);
            Poligono techo = new Poligono(rojoAuto,new Point(0,0.125,0));
                techo.addVertice(-0.1f, 0, -0.25f);
                techo.addVertice(-0.1f, 0, 0.25f);
                techo.addVertice(0.1f, 0, 0.25f);
                techo.addVertice(0.1f, 0, -0.25f);
            Poligono cabinaIzq = new Poligono(rojoAuto,new Point(-0.1,0,0));
                cabinaIzq.addVertice(0, 0.125f, 0.24);
                cabinaIzq.addVertice(0, -0.125f, 0.5f);
                cabinaIzq.addVertice(0,-0.125f, -0.5f);
                cabinaIzq.addVertice(0, 0.125f, -0.24f);
            Poligono cabinaDer = new Poligono(rojoAuto,new Point(0.1,0,0));
                cabinaDer.addVertice(0, 0.125f, 0.24);
                cabinaDer.addVertice(0, -0.125f, 0.5f);
                cabinaDer.addVertice(0, -0.125f, -0.5f);
                cabinaDer.addVertice(0, 0.125f, -0.24f);
            Poligono parachoquesDelantero = new Poligono(rojoAuto);
            parachoquesDelantero.addVertice(-0.40f, 0.5f, 1.5f);
            parachoquesDelantero.addVertice(-0.40f, 0.2f, 1.5f);
            parachoquesDelantero.addVertice(-0.20f, 0.2f, 1.5f);
            parachoquesDelantero.addVertice(-0.20f, 0.5f, 1.5f);
            Poligono puertasIzq = new Poligono(rojoAuto);
            puertasIzq.addVertice(-0.40f, 0.5f, 1.5f);
            puertasIzq.addVertice(-0.40f, 0.2f, 1.5f);
            puertasIzq.addVertice(-0.40f, 0.2f, 0.5f);
            puertasIzq.addVertice(-0.40f, 0.5f, 0.5f);
            Poligono puertasTraseras = new Poligono(rojoAuto);
            puertasTraseras.addVertice(-0.40f, 0.5f, 0.5f);
            puertasTraseras.addVertice(-0.40f, 0.2f, 0.5f);
            puertasTraseras.addVertice(-0.20f, 0.2f, 0.5f);
            puertasTraseras.addVertice(-0.20f, 0.5f, 0.5f);
            Poligono puertasDer = new Poligono(rojoAuto);
            puertasDer.addVertice(-0.20f, 0.5f, 1.5f);
            puertasDer.addVertice(-0.20f, 0.2f, 1.5f);
            puertasDer.addVertice(-0.20f, 0.2f, 0.5f);
            puertasDer.addVertice(-0.20f, 0.5f, 0.5f);

            Partes chasisAuto = new Partes();
            chasisAuto.addPoligono("vidrioDelantero", vidrioDelantero);
            chasisAuto.addPoligono("vidrioTrasero", vidrioTrasero);
            chasisAuto.addPoligono("Techo", techo);
            chasisAuto.addPoligono("CabinaIzquierda", cabinaIzq);
            chasisAuto.addPoligono("CabinaDerecha", cabinaDer);
            chasisAuto.addPoligono("ParachoquesDelantero", parachoquesDelantero);
            chasisAuto.addPoligono("PuertaIzquierda", puertasIzq);
            chasisAuto.addPoligono("PuertaTrasera", puertasTraseras);
            chasisAuto.addPoligono("PuertaDerecha", puertasDer);

            Poligono ruedaCopilotoBack = new Poligono(Color.Yellow);
            Poligono ruedaCopiloto = new Poligono(Color.Yellow);
            Poligono ruedaPiloto = new Poligono(Color.Yellow);
            Poligono ruedaPilotoBack = new Poligono(Color.Yellow);
            ruedaCopilotoBack.addVertice(-0.41, 0.04, 0.90);
            ruedaCopilotoBack.addVertice(-0.41, 0.04, 0.65);
            ruedaCopilotoBack.addVertice(-0.41, 0.3, 0.65);
            ruedaCopilotoBack.addVertice(-0.41, 0.3, 0.90);

            ruedaCopiloto.addVertice(-0.41, 0.04, 1.35);
            ruedaCopiloto.addVertice(-0.41, 0.04, 1.1);
            ruedaCopiloto.addVertice(-0.41, 0.3, 1.1);
            ruedaCopiloto.addVertice(-0.41, 0.3, 1.35);

            ruedaPiloto.addVertice(-0.19, 0.04, 1.35);
            ruedaPiloto.addVertice(-0.19, 0.04, 1.1);
            ruedaPiloto.addVertice(-0.19, 0.3, 1.1);
            ruedaPiloto.addVertice(-0.19, 0.3, 1.35);

            ruedaPilotoBack.addVertice(-0.19, 0.04, 0.90);
            ruedaPilotoBack.addVertice(-0.19, 0.04, 0.65);
            ruedaPilotoBack.addVertice(-0.19, 0.3, 0.65);
            ruedaPilotoBack.addVertice(-0.19, 0.3, 0.90);

            Partes rueda1 = new Partes(); rueda1.addPoligono("Rueda1", ruedaPiloto);
            Partes rueda2 = new Partes(); rueda2.addPoligono("Rueda2", ruedaCopiloto);
            Partes rueda3 = new Partes(); rueda3.addPoligono("Rueda3", ruedaPilotoBack);
            Partes rueda4 = new Partes(); rueda4.addPoligono("Rueda4", ruedaCopilotoBack);
            auto.addParte("Chasis", chasisAuto);
            auto.addParte("RuedaDelPiloto", rueda1);
            auto.addParte("RuedaDelCopiloto", rueda2);
            auto.addParte("RuedaAtrasDelPiloto", rueda3);
            auto.addParte("RuedaAtrasDelCopiloto", rueda4);

            //PARED
            Color colorPared = Color.FromArgb(1, 255, 255, 204);
            Poligono paredpoly = new Poligono(colorPared);
            paredpoly.addVertice(-2.0f, -2.0f, 0.0f);
            paredpoly.addVertice(2.0f, -2.0f, 0.0f);
            paredpoly.addVertice(2.0f, 2.0f, 0.0f);
            paredpoly.addVertice(-2.0f, 2.0f, 0.0f);
            Partes paredPart = new Partes(); paredPart.addPoligono("CaraDeLaPared", paredpoly);

            pared.addParte("ParteDeLaPared", paredPart);

            //REPISA
            Color colorRepisa = Color.FromArgb(101, 56, 24);
            Poligono plataformaRepisa = new Poligono(colorRepisa);
            plataformaRepisa.addVertice(-1.0, 0.04, 0.01);
            plataformaRepisa.addVertice(-1.0, 0.04, 2.0);
            plataformaRepisa.addVertice(1.0, 0.04, 2.0);
            plataformaRepisa.addVertice(1.0, 0.04, 0.01);
            Poligono repisaIzq = new Poligono(colorRepisa);
            repisaIzq.addVertice(-1.0, 0.04, 0.01);
            repisaIzq.addVertice(-1.0, -0.04, 0.01);
            repisaIzq.addVertice(-1.0, -0.04, 2.0);
            repisaIzq.addVertice(-1.0, 0.04, 2.0);
            Poligono repisaDer = new Poligono(colorRepisa);
            repisaDer.addVertice(1.0, 0.04, 0.01);
            repisaDer.addVertice(1.0, -0.04, 0.01);
            repisaDer.addVertice(1.0, -0.04, 2.0);
            repisaDer.addVertice(1.0, 0.04, 2.0);
            Poligono repisaFront = new Poligono(colorRepisa);
            repisaFront.addVertice(-1.0, 0.04, 2.0);
            repisaFront.addVertice(-1.0, -0.04, 2.0);
            repisaFront.addVertice(1.0, -0.04, 2.0);
            repisaFront.addVertice(1.0, 0.04, 2.0);

            Partes repisaPart = new Partes();
            repisaPart.addPoligono("Plataforma", plataformaRepisa);
            repisaPart.addPoligono("LadoIzquierdo", repisaIzq);
            repisaPart.addPoligono("LadoDerecho", repisaDer);
            repisaPart.addPoligono("LadoFrontal", repisaFront);

            repisa.addParte("ParteRepisa", repisaPart);
            cuarto = new Escena();
            cuarto.addObjeto("Repisa", repisa);
            cuarto.addObjeto("Pared", pared);
            cuarto.addObjeto("Auto", auto);
            JSON.Save("Escena/cuarto.txt", cuarto);



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
            GL.Rotate(-phi, 0.0, 1.0, 0.0); //rotar theta grados en y
            cuarto.buscarObjeto("Auto").buscarPartes("Chasis").draw();
            Axis axis = new Axis();
            
            thetaInc();

            


            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Double escala = 3.0;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-escala, escala, -escala, escala, -escala, escala);//set escala
            GL.MatrixMode(MatrixMode.Modelview);


            base.OnResize(e);
        }
    }
}

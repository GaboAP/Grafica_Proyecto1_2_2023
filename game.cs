using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace ProGrafica
{
    class game : GameWindow
    {
        private Double theta = 0;
        private double phi = 0;
        Escena cuarto;
        public Ejecucion hilo;
        private Libreto libreto;
        Thread miHilo;



        public game(int widht, int height, string title) : base(widht, height, GraphicsMode.Default, title)
        {

            Color colorCelestevidrio = Color.FromArgb(1, 168, 204, 215);
            Poligono vidrioDelantero = new Poligono(colorCelestevidrio, new Point(-7, 0, 0));
            vidrioDelantero.addVertice(-2, -2, 2);
            vidrioDelantero.addVertice(2, 2, 2);
            vidrioDelantero.addVertice(2, 2, -2);
            vidrioDelantero.addVertice(-2, -2, -2);
            Poligono vidrioTrasero = new Poligono(colorCelestevidrio, new Point(7, 0, 0));
            vidrioTrasero.addVertice(-2, 2, 2);
            vidrioTrasero.addVertice(2, -2, 2);
            vidrioTrasero.addVertice(2, -2, -2);
            vidrioTrasero.addVertice(-2, 2, -2);
            Color rojoAuto = Color.FromArgb(1, 170, 51, 51);
            Poligono techo = new Poligono(rojoAuto, new Point(0, 2, 0));
            techo.addVertice(-5, 0, -2);
            techo.addVertice(-5, 0, 2);
            techo.addVertice(5, 0, 2);
            techo.addVertice(5, 0, -2);
            Poligono cabinaIzq = new Poligono(rojoAuto, new Point(0, 0, 2));
            cabinaIzq.addVertice(-5, 2, 0);
            cabinaIzq.addVertice(5, 2, 0);
            cabinaIzq.addVertice(9, -2, 0);
            cabinaIzq.addVertice(-9, -2, 0);
            Poligono cabinaDer = new Poligono(rojoAuto, new Point(0, 0, -2));
            cabinaDer.addVertice(-5, 2, 0);
            cabinaDer.addVertice(5, 2, 0);
            cabinaDer.addVertice(9, -2, 0);
            cabinaDer.addVertice(-9, -2, 0);
            //Poligono parachoquesDelantero = new Poligono(rojoAuto, new Point(0, 0, 0));
            //parachoquesDelantero.addVertice(-0.40f, 0.5f, 1.5f);
            //parachoquesDelantero.addVertice(-0.40f, 0.2f, 1.5f);
            //parachoquesDelantero.addVertice(-0.20f, 0.2f, 1.5f);
            //parachoquesDelantero.addVertice(-0.20f, 0.5f, 1.5f);
            //Poligono puertasIzq = new Poligono(rojoAuto);
            //puertasIzq.addVertice(-0.40f, 0.5f, 1.5f);
            //puertasIzq.addVertice(-0.40f, 0.2f, 1.5f);
            //puertasIzq.addVertice(-0.40f, 0.2f, 0.5f);
            //puertasIzq.addVertice(-0.40f, 0.5f, 0.5f);
            //Poligono puertasTraseras = new Poligono(rojoAuto);
            //puertasTraseras.addVertice(-0.40f, 0.5f, 0.5f);
            //puertasTraseras.addVertice(-0.40f, 0.2f, 0.5f);
            //puertasTraseras.addVertice(-0.20f, 0.2f, 0.5f);
            //puertasTraseras.addVertice(-0.20f, 0.5f, 0.5f);
            //Poligono puertasDer = new Poligono(rojoAuto);
            //puertasDer.addVertice(-0.20f, 0.5f, 1.5f);
            //puertasDer.addVertice(-0.20f, 0.2f, 1.5f);
            //puertasDer.addVertice(-0.20f, 0.2f, 0.5f);
            //puertasDer.addVertice(-0.20f, 0.5f, 0.5f);

            Dictionary<string, Poligono> poligonosChasis = new Dictionary<string, Poligono>();
            poligonosChasis.Add("vidrioDelantero", vidrioDelantero);
            poligonosChasis.Add("vidrioTrasero", vidrioTrasero);
            poligonosChasis.Add("Techo", techo);
            poligonosChasis.Add("CabinaIzquierda", cabinaIzq);
            poligonosChasis.Add("CabinaDerecha", cabinaDer);
            Partes chasisAuto = new Partes(new Point(0, 0, 0), poligonosChasis);
            //chasisAuto.addPoligono("ParachoquesDelantero", parachoquesDelantero);
            //chasisAuto.addPoligono("PuertaIzquierda", puertasIzq);
            //chasisAuto.addPoligono("PuertaTrasera", puertasTraseras);
            //chasisAuto.addPoligono("PuertaDerecha", puertasDer);

            Poligono ruedaCopilotoBack = new Poligono(Color.Yellow, new Point(0, 0, 0));
            ruedaCopilotoBack.addVertice(-2, 2, 0);
            ruedaCopilotoBack.addVertice(2, 2, 0);
            ruedaCopilotoBack.addVertice(2, -2, 0);
            ruedaCopilotoBack.addVertice(-2, -2, 0);

            Poligono ruedaCopiloto = new Poligono(Color.Yellow, new Point(0, 0, 0));
            ruedaCopiloto.addVertice(-2, 2, 0);
            ruedaCopiloto.addVertice(2, 2, 0);
            ruedaCopiloto.addVertice(2, -2, 0);
            ruedaCopiloto.addVertice(-2, -2, 0);

            Poligono ruedaPiloto = new Poligono(Color.Yellow, new Point(0, 0, 0));
            ruedaPiloto.addVertice(-2, 2, 0);
            ruedaPiloto.addVertice(2, 2, 0);
            ruedaPiloto.addVertice(2, -2, 0);
            ruedaPiloto.addVertice(-2, -2, 0);

            Poligono ruedaPilotoBack = new Poligono(Color.Yellow, new Point(0, 0, 0));
            ruedaPilotoBack.addVertice(-2, 2, 0);
            ruedaPilotoBack.addVertice(2, 2, 0);
            ruedaPilotoBack.addVertice(2, -2, 0);
            ruedaPilotoBack.addVertice(-2, -2, 0);

            Dictionary<string, Poligono> poligonosRueda1 = new Dictionary<string, Poligono>();
            Dictionary<string, Poligono> poligonosRueda2 = new Dictionary<string, Poligono>();
            Dictionary<string, Poligono> poligonosRueda3 = new Dictionary<string, Poligono>();
            Dictionary<string, Poligono> poligonosRueda4 = new Dictionary<string, Poligono>();
            poligonosRueda1.Add("Rueda1", ruedaPiloto);
            poligonosRueda2.Add("Rueda2", ruedaCopiloto);
            poligonosRueda3.Add("Rueda3", ruedaPilotoBack);
            poligonosRueda4.Add("Rueda4", ruedaCopilotoBack);
            Partes rueda1 = new Partes(new Point(-6, -3, 2.1f), poligonosRueda1);
            Partes rueda2 = new Partes(new Point(-6, -3, -2.1f), poligonosRueda2);
            Partes rueda3 = new Partes(new Point(6, -3, 2.1f), poligonosRueda3);
            Partes rueda4 = new Partes(new Point(6, -3, -2.1f), poligonosRueda4);

            Dictionary<string, Partes> partesAuto = new Dictionary<string, Partes>();
            partesAuto.Add("Chasis", chasisAuto);
            partesAuto.Add("Rueda1", rueda1);
            partesAuto.Add("Rueda2", rueda2);
            partesAuto.Add("Rueda3", rueda3);
            partesAuto.Add("Rueda4", rueda4);
            Objeto auto = new Objeto(new Point(0, 0, 0), partesAuto);



            //PARED
            Color colorPared = Color.FromArgb(1, 255, 255, 204);
            Poligono paredpoly = new Poligono(colorPared, new Point(0, 0, 0));
            paredpoly.addVertice(0, 40, 40);
            paredpoly.addVertice(0, -40, 40);
            paredpoly.addVertice(0, -40, -40);
            paredpoly.addVertice(0, 40, -40);
            Dictionary<string, Poligono> poligonosPared = new Dictionary<string, Poligono>();
            poligonosPared.Add("Pared", paredpoly);
            Partes paredPart = new Partes(new Point(20, 0, 0), poligonosPared);
            paredPart.addPoligono("CaraDeLaPared", paredpoly);

            //pared.addParte("ParteDeLaPared", paredPart);

            //REPISA
            Color colorRepisa = Color.FromArgb(101, 56, 24);
            Poligono plataformaRepisa = new Poligono(colorRepisa, new Point(0, -5, 0));
            plataformaRepisa.addVertice(-20, 0, -20);
            plataformaRepisa.addVertice(-20, 0, 20);
            plataformaRepisa.addVertice(20, 0, 20);
            plataformaRepisa.addVertice(20, 0, -20);
            Poligono repisaIzq = new Poligono(colorRepisa, new Point(0, -7, 20));
            repisaIzq.addVertice(-20, 2, 0);
            repisaIzq.addVertice(20, 2, 0);
            repisaIzq.addVertice(20, -2, 0);
            repisaIzq.addVertice(-20, -2, 0);
            Poligono repisaDer = new Poligono(colorRepisa, new Point(0, -7, -20));
            repisaDer.addVertice(-20, 2, 0);
            repisaDer.addVertice(20, 2, 0);
            repisaDer.addVertice(20, -2, 0);
            repisaDer.addVertice(-20, -2, 0);
            Poligono repisaDel = new Poligono(colorRepisa, new Point(-20, -7, 0));
            repisaDel.addVertice(0, 2, 20);
            repisaDel.addVertice(0, 2, -20);
            repisaDel.addVertice(0, -2, -20);
            repisaDel.addVertice(0, -2, 20);

            Dictionary<string, Poligono> poligonosRepisa = new Dictionary<string, Poligono>();
            poligonosRepisa.Add("Plataforma", plataformaRepisa);
            poligonosRepisa.Add("LadoIzquierdo", repisaIzq);
            poligonosRepisa.Add("LadoDerecho", repisaDer);
            poligonosRepisa.Add("LadoDelantero", repisaDel);
            Partes repisaPart = new Partes(new Point(0, 0, 0), poligonosRepisa);

            Color colorRampa = Color.FromArgb(78, 128, 147);
            Poligono rampaTecho = new Poligono(colorRampa, new Point(-27, -7, 0));
            rampaTecho.addVertice(9, 2, 5);
            rampaTecho.addVertice(9, 2, -5);
            rampaTecho.addVertice(-9, -2, -5);
            rampaTecho.addVertice(-9, -2, 5);
            




            //Dictionary<string, Poligono> poligonosRampa = new Dictionary<string, Poligono>();
            //poligonosRampa.Add("rampaTecho", rampaTecho);
            //Partes rampaPart = new Partes(new Point(0, 0, 0), poligonosRampa);

            //Dictionary<string, Partes> partesRampa = new Dictionary<string, Partes>();
            //partesRampa.Add("ParteRampa", rampaPart);
            //Objeto rampa = new Objeto(new Point(0, 0, 0), partesRampa);

            Dictionary<string, Partes> partesRepisa = new Dictionary<string, Partes>();
            partesRepisa.Add("ParteRepisa", repisaPart);
            partesRepisa.Add("Pared", paredPart);
            Objeto repisa = new Objeto(new Point(0, 0, 0), partesRepisa);

            Dictionary<string, Objeto> objetosCuarto = new Dictionary<string, Objeto>();
            objetosCuarto.Add("Repisa", repisa);
            objetosCuarto.Add("Auto", auto);
            //objetosCuarto.Add("Rampa", rampa);
            cuarto = new Escena(new Point(0, 0, 0), objetosCuarto);
            ////cuarto.addObjeto("Pared", pared);
            //JSON.Save("Escena/cuarto.txt", cuarto);





            //animacion
            List<Transformacion> listaDeConversiones = new List<Transformacion>();
            List<Transformacion> listaDeConversionesRueda1 = new List<Transformacion>();
            List<Transformacion> listaDeConversionesRueda2 = new List<Transformacion>();
            List<Transformacion> listaDeConversionesRueda3 = new List<Transformacion>();
            List<Transformacion> listaDeConversionesRueda4 = new List<Transformacion>();
            Transformacion accion = new Transformacion("Traslacion", -20, "x", 2000, 0);
            Transformacion accion1 = new Transformacion("Traslacion", -7, "x", 1000, 2000);
            Transformacion accion11 = new Transformacion("Traslacion", -7, "x", 1000, 3000);
            Transformacion accion12 = new Transformacion("Rotacion", 40, "z", 1000, 3000);
            Transformacion accion13 = new Transformacion("Traslacion", -7, "y", 1000, 3000);
            Transformacion accion14 = new Transformacion("Traslacion", -70, "y", 7000, 4000);
            Transformacion accion15 = new Transformacion("Rotacion", 1000, "z", 7000, 4000);
            
            Transformacion accion01 = new Transformacion("Rotacion", 1000, "z", 2500, 0);
            Transformacion accion02 = new Transformacion("Rotacion", 1000, "z", 2500, 0);
            Transformacion accion03 = new Transformacion("Rotacion", 1000, "z", 2500, 0);
            Transformacion accion04 = new Transformacion("Rotacion", 1000, "z", 2500, 0);

            //Transformacion accion2 = new Transformacion("Rotacion", -90, "x", 2000, 3000);
            //Transformacion accion3 = new Transformacion("Traslacion", 10, "x", 1000, 5000);
            //Transformacion accion31 = new Transformacion("Traslacion", 40, "x", 3000, 6000);
            //Transformacion accion32 = new Transformacion("Traslacion", 10, "x", 1000, 9000);
            //Transformacion accion33 = new Transformacion("Traslacion", 7, "x", 1000, 10000);
            //Transformacion accion34 = new Transformacion("Traslacion", 7, "x", 1000, 11000);
            //Transformacion accion4 = new Transformacion("Rotacion", -90, "x", 2000, 10000);
            //Transformacion accion5 = new Transformacion("Traslacion", 30, "x", 2000, 12000);
            //Transformacion accion51 = new Transformacion("Traslacion", -7, "x", 1000, 14000);
            //Transformacion accion52 = new Transformacion("Traslacion", -7, "x", 1000, 15000);
            //Transformacion accion6 = new Transformacion("Rotacion", -90, "x", 2000, 14000);
            //Transformacion accion7 = new Transformacion("Traslacion", -10, "x", 1000, 16000);
            //Transformacion accion71 = new Transformacion("Traslacion", -40, "x", 3000, 17000);
            //Transformacion accion72 = new Transformacion("Traslacion", -10, "x", 1000, 20000);
            //Transformacion accion73 = new Transformacion("Traslacion", -7, "x", 1000, 21000);
            //Transformacion accion74 = new Transformacion("Traslacion", -7, "x", 1000, 22000);
            //Transformacion accion8 = new Transformacion("Rotacion", -90, "x", 2000, 21000);
            listaDeConversiones.Add(accion);
            listaDeConversiones.Add(accion1);
            listaDeConversiones.Add(accion11);
            listaDeConversiones.Add(accion12);
            listaDeConversiones.Add(accion13);
            listaDeConversiones.Add(accion14);
            listaDeConversiones.Add(accion15);

            listaDeConversionesRueda1.Add(accion01);

            listaDeConversionesRueda2.Add(accion02);

            listaDeConversionesRueda3.Add(accion03);

            listaDeConversionesRueda4.Add(accion04);
            Acciones acciones = new Acciones("Auto", listaDeConversiones);
            Acciones acciones1 = new Acciones("Auto", "Rueda1", listaDeConversionesRueda1);
            Acciones acciones2 = new Acciones("Auto", "Rueda2", listaDeConversionesRueda2);
            Acciones acciones3 = new Acciones("Auto", "Rueda3", listaDeConversionesRueda3);
            Acciones acciones4 = new Acciones("Auto", "Rueda4", listaDeConversionesRueda4);
            List<Acciones> listaDeAcciones = new List<Acciones>();
            listaDeAcciones.Add(acciones);
            listaDeAcciones.Add(acciones1);
            listaDeAcciones.Add(acciones2);
            listaDeAcciones.Add(acciones3);
            listaDeAcciones.Add(acciones4);
            libreto = new Libreto(listaDeAcciones, cuarto);
            hilo = new Ejecucion(libreto);
            miHilo = new Thread(hilo.Execute);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);





            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-70, 70, -70, 70, -70, 70);
            GL.Enable(EnableCap.DepthTest);
            GL.Rotate(15f, 0, 1, 0);
            GL.Rotate(20f, 1, 0, 0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //wea de la doc
            
            cuarto.draw();
            //cuarto.buscarObjeto("Auto").rotate("z", 4);

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        [Obsolete]
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.K)
            {
                miHilo.Start();

            }

            if (e.Key == Key.L)
            {
                if (hilo.pause)
                {
                    hilo.UnPause();
                }
                else
                {
                    hilo.Pause();
                }
            }

            if (e.Key == Key.P)
            {
                hilo.Stop();

            }

            base.OnKeyDown(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);


            base.OnResize(e);
        }
    }
}

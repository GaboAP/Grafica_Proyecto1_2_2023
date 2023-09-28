using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ProGrafica
{
    internal class Cuarto
    {

        private double[] centro; 

        public Cuarto(double x, double y, double z) { 
            this.centro=new double[] { x, y, z };
        }
        public void dibujarCuarto()
        {
            dibujarAuto();
            dibujarPared();
            dibujarRepisa();
        }
        public static void DrawCircle(double x, double y, double z, double radius, double rotationAngleDegrees)
        {
            GL.PushMatrix(); // Save the current modelview matrix
            GL.Translate(x, y, z); // Translate to the circle's position
            GL.Rotate(rotationAngleDegrees, 0.0, 1.0, 0.0); // Apply the rotation to the circle

            GL.Begin(PrimitiveType.Polygon);
            int numSegments = 180;

            GL.Color4(Color.Yellow);

            for (int i = 0; i < numSegments; i++)
            {
                double angle = 2 * Math.PI * i / numSegments;
                double xPos = radius * Math.Cos(angle);
                double yPos = radius * Math.Sin(angle);

                GL.Vertex3(xPos, yPos, 0.0);
            }

            GL.End();

            GL.PopMatrix(); // Restore the previous modelview matrix
        }
        public void dibujarAuto()
        {
            GL.Begin(PrimitiveType.Quads); // Vidrio delantero
            GL.Color3(Color.FromArgb(1, 168, 204, 215));
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.5f, centro[2] + 1.50f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Vidrio trasero
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.FromArgb(1, 170, 51, 51)); // Techo
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Cabina izquierda
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.5f, centro[2] + 0.50f);
            GL.Vertex3(centro[0] - 0.4f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Cabina derecha
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 1.25f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.2f, centro[1] + 0.75f, centro[2] + 0.75f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Parachoques delantero
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.2f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.2f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Puertas izquierda
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.2f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.2f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Puertas traseras
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.40f, centro[1] + 0.2f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.2f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Puertas derechas
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.5f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.2f, centro[2] + 1.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.2f, centro[2] + 0.5f);
            GL.Vertex3(centro[0] - 0.20f, centro[1] + 0.5f, centro[2] + 0.5f);
            GL.End();

            DrawCircle(centro[0] - 0.41f, centro[1] + 0.25f, centro[2] + 0.8f, 0.15, 90.0); // Rueda izquierda trasera
            DrawCircle(centro[0] - 0.19f, centro[1] + 0.25f, centro[2] + 0.8f, 0.15, 90.0); // Rueda derecha trasera
            DrawCircle(centro[0] - 0.19f, centro[1] + 0.25f, centro[2] + 1.2f, 0.15, 90.0); // Rueda derecha delantera
            DrawCircle(centro[0] - 0.41f, centro[1] + 0.25f, centro[2] + 1.2f, 0.15, 90.0); // Rueda izquierda delantera
        }
        public void dibujarPared()
        {
            GL.Begin(PrimitiveType.Quads); // Se informa que forma estará dibujando para saber en qué orden trazar las líneas entre puntos

            GL.Color3(1.0f, 0.0f, 0.0f); // Color, es necesario pasar al menos una declaración de color
            GL.Vertex3(centro[0] - 2.0f, centro[1] - 2.0f, centro[2]); // Punto 1, Visto desde un cuadrado, es el de la izquierda abajo

            GL.Color3(0.0f, 1.0f, 0.0f);
            GL.Vertex3(centro[0] + 2.0f, centro[1] - 2.0f, centro[2]); // Punto 2, esquina inferior derecha

            GL.Color3(0.0f, 0.0f, 1.0f);
            GL.Vertex3(centro[0] + 2.0f, centro[1] + 2.0f, centro[2]); // Punto 3, esquina superior derecha

            GL.Vertex3(centro[0] - 2.0f, centro[1] + 2.0f, centro[2]);

            GL.End();
        }
        public void dibujarRepisa()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.FromArgb(101, 56, 24)); // Plataforma repisa
            GL.Vertex3(centro[0] - 1.0, centro[1] + 0.04, centro[2] + 0.01);
            GL.Vertex3(centro[0] - 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] + 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] + 1.0, centro[1] + 0.04, centro[2] + 0.01);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Repisa lado izquierdo
            GL.Vertex3(centro[0] - 1.0, centro[1] + 0.04, centro[2] + 0.01);
            GL.Vertex3(centro[0] - 1.0, centro[1] - 0.04, centro[2] + 0.01);
            GL.Vertex3(centro[0] - 1.0, centro[1] - 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] - 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Repisa lado derecho
            GL.Vertex3(centro[0] + 1.0, centro[1] + 0.04, centro[2] + 0.01);
            GL.Vertex3(centro[0] + 1.0, centro[1] - 0.04, centro[2] + 0.01);
            GL.Vertex3(centro[0] + 1.0, centro[1] - 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] + 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.End();

            GL.Begin(PrimitiveType.Quads); // Repisa frontal
            GL.Vertex3(centro[0] - 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] - 1.0, centro[1] - 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] + 1.0, centro[1] - 0.04, centro[2] + 2.0);
            GL.Vertex3(centro[0] + 1.0, centro[1] + 0.04, centro[2] + 2.0);
            GL.End();
        }
    }
}

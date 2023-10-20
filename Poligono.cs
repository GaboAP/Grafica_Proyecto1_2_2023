using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    internal class Poligono
    {
        [JsonProperty("vertices")]
        private List<Point> vertices;
        [JsonProperty("color")]
        private Color color { get; set; }
        [JsonProperty("radius")]
        private Double radius { get; set; }
        [JsonProperty("centroC")]
        private Point centroC;
        private Matrix3 transformacion;
        private Point traslacion;


        public Poligono()
        {
            vertices = new List<Point>();
            this.color = new Color();
            this.radius = 0;
            this.centroC = new Point(0.0, 0.0, 0.0);
            this.transformacion = Matrix3.Identity;
            this.traslacion = new Point(0.0, 0.0, 0.0);
        }
        public Poligono(Color color) {
            vertices = new List<Point>();
            this.color = color;
            this.radius = 0;
            this.centroC = new Point(0.0, 0.0, 0.0);
            this.transformacion = Matrix3.Identity;
            this.traslacion = new Point(0.0, 0.0, 0.0);
        }

        public Poligono(Color color, Double radius, Point centroC) //Constructor para un poligono en caso de que sea un circulo
        {
            vertices = new List<Point>();
            this.color = color;
            this.radius = radius;
            this.centroC = centroC;
            this.transformacion = Matrix3.Identity;
            this.traslacion = new Point(0.0, 0.0, 0.0);
        }
        public void addVertice(Double x, Double y, Double z)
        {
            vertices.Add(new Point(x, y, z));
        }
        public void removeVertice(int index)
        {
            vertices.RemoveAt(index);
        }
        public void draw(Point centroObj, Point centroScene, Point centroPart)
        {
            Point centroResto = centroObj + centroScene + centroPart;
            if (radius > 0)
            {
                drawCircle(centroResto, 90);
            }
            else
            {
                GL.Begin(PrimitiveType.Polygon);
                GL.Color3(color);
                foreach (Point v in vertices)
                {
                    Point vertexToDraw = v*transformacion;
                    vertexToDraw += centroC + centroResto + traslacion;
                    GL.Vertex3(vertexToDraw.X, vertexToDraw.Y, vertexToDraw.Z);
                }
                GL.End();
            }
        }
        public void drawCircle(Point centroResto, double rotationAngleDegrees)
        {
            GL.PushMatrix(); // Save the current modelview matrix
            //GL.Scale()
            GL.Translate(centroC.X + centroResto.X + traslacion.X,
                        centroC.Y + centroResto.Y + traslacion.Y,
                        centroC.Z + centroResto.Z + traslacion.Z);
            GL.Rotate(rotationAngleDegrees, 0.0, 1.0, 0.0); // Apply the rotation to the circle

            GL.Begin(PrimitiveType.Polygon);
            int numSegments = 180;

            GL.Color4(Color.Yellow);

            for (int i = 0; i < numSegments; i++)
            {
                double angle = 2 * Math.PI * i / numSegments;
                double xPos = radius * Math.Cos(angle);
                double yPos = radius * Math.Sin(angle);
                Point vertexToDraw=new Point(xPos, yPos,0);
                vertexToDraw *=transformacion;

                GL.Vertex3(vertexToDraw.X, vertexToDraw.Y, vertexToDraw.Z);
            }

            GL.End();

            GL.PopMatrix(); // Restore the previous modelview matrix
        }
        public void translate(double x, double y, double z)
        {
            this.traslacion=new Point(x, y, z);
        }
        public void scale(float scaleValue)
        {
            Matrix3 escalar = Matrix3.CreateScale(scaleValue);
            this.transformacion*=escalar;
        }
    }
}

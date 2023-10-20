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
        public void translate(double x, double y, double z)
        {
            this.traslacion=new Point(x, y, z);
        }
        public void scale(float scaleValue)
        {
            Matrix3 escalar = Matrix3.CreateScale(scaleValue);
            this.transformacion*=escalar;
        }
        public void rotate(string axis,float angle)
        {
            Matrix3 rotacion;
            if (axis=="x")
            {
                rotacion = Matrix3.CreateRotationX(angle);
            }
            else
            {
                if(axis=="y")
                {
                    rotacion= Matrix3.CreateRotationY(angle);
                }
                else
                {
                    rotacion=Matrix3.CreateRotationZ(angle);
                }
            }
            this.transformacion *= rotacion;
        }
    }
}

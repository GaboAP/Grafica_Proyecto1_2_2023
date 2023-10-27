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
        public Poligono(Poligono otroPoligono)
        {
            // Copia profunda de la lista de vértices
            this.vertices = new List<Point>();
            foreach (Point vertex in otroPoligono.vertices)
            {
                this.vertices.Add(new Point(vertex.X, vertex.Y, vertex.Z));
            }

            // Copia profunda de las demás propiedades
            this.color = otroPoligono.color;
            this.radius = otroPoligono.radius;

            // Copia profunda de la propiedad 'centroC'
            this.centroC = new Point(otroPoligono.centroC.X, otroPoligono.centroC.Y, otroPoligono.centroC.Z);

            // Copia profunda de la propiedad 'transformacion' (asumiendo que es una matriz)
            this.transformacion = new Matrix3(otroPoligono.transformacion.Row0, otroPoligono.transformacion.Row1, otroPoligono.transformacion.Row2);

            // Copia profunda de la propiedad 'traslacion'
            this.traslacion = new Point(otroPoligono.traslacion.X, otroPoligono.traslacion.Y, otroPoligono.traslacion.Z);
        }
        public void addVertice(Double x, Double y, Double z)
        {
            vertices.Add(new Point(x, y, z));
        }
        public void removeVertice(int index)
        {
            vertices.RemoveAt(index);
        }
        public void draw()
        {
            draw(new Point(0.0, 0.0, 0.0));
        }
        public void draw(Point centros)
        {
            Point centroResto = centros+centroC;
                GL.Begin(PrimitiveType.Polygon);
                GL.Color3(color);
                foreach (Point v in vertices)
                {
                    Point vertexToDraw = v*transformacion;
                    vertexToDraw += centroResto + traslacion;
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

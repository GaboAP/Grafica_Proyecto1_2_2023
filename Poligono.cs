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
        private Point centroTransformacion;
        private Point centroAcarreado;
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
            this.centroTransformacion= new Point(0.0, 0.0, 0.0);
            this.centroAcarreado= new Point(0.0, 0.0, 0.0); 
    }
        public Poligono(Color color) {
            vertices = new List<Point>();
            this.color = color;
            this.radius = 0;
            this.centroC = new Point(0.0, 0.0, 0.0);
            this.transformacion = Matrix3.Identity;
            this.traslacion = new Point(0.0, 0.0, 0.0);
            this.centroTransformacion = new Point(0.0, 0.0, 0.0);
            this.centroAcarreado = new Point(0.0, 0.0, 0.0);
        }

        public Poligono(Color color, Point centroC) //Constructor para un poligono en caso de que sea un circulo
        {
            vertices = new List<Point>();
            this.color = color;
            this.radius = 0;
            this.centroC = centroC;
            this.transformacion = Matrix3.Identity;
            this.traslacion = new Point(0.0, 0.0, 0.0);
            this.centroTransformacion = new Point(0.0, 0.0, 0.0);
            this.centroAcarreado = new Point(0.0, 0.0, 0.0);
            setCentroAcarreado(new Point(0.0, 0.0, 0.0));
        }
        public Point CentroC
        {
            get { return this.centroC; }
            set { this.centroC = value; }
        }
        public void setCentroAcarreado(Point centroAcarreado)
        {
            this.centroAcarreado = centroAcarreado;
        }
        public void addVertice(Double x, Double y, Double z)
        {
            vertices.Add(new Point(x, y, z));
        }
        public void removeVertice(int index)
        {
            vertices.RemoveAt(index);
        }
        public void UpdateVertices()
        {
                for (int i = 0; i < vertices.Count; i++)
                {
                    vertices[i] = new Point(vertices[i].X+traslacion.X, vertices[i].Y+traslacion.Y, vertices[i].Z+traslacion.Z);
                }
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
                    Point vertexToDraw = v+centroResto-centroTransformacion;
                    vertexToDraw *= transformacion;
                    vertexToDraw +=  traslacion+centroTransformacion;
                    GL.Vertex3(vertexToDraw.X, vertexToDraw.Y, vertexToDraw.Z);
                }
                GL.End();
        }
        public void translate(double x, double y, double z)
        {
            this.traslacion=new Point(x, y, z);
        }
        public void scale(float scaleValue,Point transformacion)
        {
            Matrix3 escalar = Matrix3.CreateScale(scaleValue);
            this.transformacion*=escalar;
            this.centroTransformacion = transformacion;
        }
        public void scale(float scaleValue)
        {
            Matrix3 escalar = Matrix3.CreateScale(scaleValue);
            this.transformacion *= escalar;
            this.centroTransformacion = this.centroC+this.centroAcarreado;
        }
        public void rotate(string axis,float angle, Point transformacion)
        {
            this.centroTransformacion = transformacion;
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
        public void rotate(string axis, float angle)
        {
            this.centroTransformacion = this.centroC+this.centroAcarreado;
            Matrix3 rotacion;
            if (axis == "x")
            {
                rotacion = Matrix3.CreateRotationX(angle);
            }
            else
            {
                if (axis == "y")
                {
                    rotacion = Matrix3.CreateRotationY(angle);
                }
                else
                {
                    rotacion = Matrix3.CreateRotationZ(angle);
                }
            }
            this.transformacion *= rotacion;
        }
    }
}

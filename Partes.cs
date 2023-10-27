using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    internal class Partes
    {
        [JsonProperty("poligonos")]
        private Dictionary<string, Poligono> poligonos;
        [JsonProperty("centro")]
        private Point centro; //implementar

        public Partes()
        {
            this.poligonos = new Dictionary<string, Poligono>();
            this.centro = new Point(0.0,0.0,0.0);
        }
        public Partes(Double x, Double y, Double z)
        {
            poligonos=new Dictionary<string, Poligono>();
            this.centro = new Point(x,y,z);
        }
        public Partes(Partes otrasPartes)
        {
            // Copia profunda del centro
            this.centro = new Point(otrasPartes.centro.X, otrasPartes.centro.Y, otrasPartes.centro.Z);

            // Copia profunda de la colección de polígonos
            this.poligonos = new Dictionary<string, Poligono>();
            foreach (var par in otrasPartes.poligonos)
            {
                this.poligonos.Add(par.Key, new Poligono(par.Value));
            }
        }
        public Point Centro
        {
            get { return centro; }
            set { this.centro = value; }
        }
        public void addPoligono(string name, Poligono poligono)
        {
            poligonos.Add(name, poligono);
        }
        public void removePoligono(string name)
        {
            poligonos.Remove(name);
        }
        public void draw()
        {
            draw(new Point(0.0, 0.0, 0.0));
        }
        public void draw(Point centroUp)
        {
            Point centroResto = centro + centroUp;
            foreach(Poligono poligono in poligonos.Values) 
            { 
                poligono.draw(centroResto);
            }
        }

        internal void translate(double x, double y, double z)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.translate(x, y, z);
            }
        }
        public void scale(float scaleValue)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.scale(scaleValue);
            }
        }
        public void rotate(string eje, float angle)
        {
            foreach (Poligono poligono in poligonos.Values)
            {
                poligono.rotate(eje,angle);
            }
        }
    }
}

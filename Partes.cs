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

        public void addPoligono(string name, Poligono poligono)
        {
            poligonos.Add(name, poligono);
        }
        public void removePoligono(string name)
        {
            poligonos.Remove(name);
        }
        public void draw(Point centroObj, Point centroScene)
        {
            foreach(Poligono poligono in poligonos.Values) 
            { 
                poligono.draw(centroObj, centroScene, centro);
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
    }
}

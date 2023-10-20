using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    internal class Objeto
    {
        [JsonProperty("partes")]
        private Dictionary<string, Partes> partes { get; set; }
        [JsonProperty("centro")]
        private Point centro{ get; set; }

        public Objeto()
        {
            this.partes = new Dictionary<string, Partes>();
            this.centro = new Point(0.0, 0.0, 0.0);
        }

        public Objeto(Double x, Double y, Double z)
        {
            this.centro=new Point(x,y,z);
            partes= new Dictionary<string, Partes>();
        }

        public void addParte(string nombre, Partes parte)
        {
            this.partes.Add(nombre, parte);
        }
        public void removeParte(string nombre)
        {
            this.partes.Remove(nombre);
        }
        public Double x
        {
            get { return centro.X;}
        }
        public Point Centro
        {
            get { return centro; }
            set { centro = value; }
        }
        public Double centroY
        {
            get { return centro.Y;}
        }
        public Double centroZ
        {
            get { return centro.Z;}
        }
        public void draw(Point sceneCentre)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.draw(centro, sceneCentre);
            }
        }

        internal void translate(double x, double y, double z)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.translate(x, y, z);
            }
        }
        public void scale(float scaleValue)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.scale(scaleValue);
            }
        }
        public void rotate(string eje,float angle)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.rotate(eje,angle);
            }
        }
    }
}

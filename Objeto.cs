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
        private Point centroEscenario { get; set; }

        public Objeto()
        {
            this.partes = new Dictionary<string, Partes>();
            this.centro = new Point(0.0, 0.0, 0.0);
            this.centroEscenario= new Point(0.0, 0.0, 0.0);
        }

        public Objeto(Double x, Double y, Double z, Dictionary<string, Partes> partes)
        {
            this.centro=new Point(x,y,z);
            this.partes = partes;
            this.centroEscenario = new Point(0.0, 0.0, 0.0);
            setSceneCentro(new Point(0.0, 0.0, 0.0));
        }
        public void setSceneCentro(Point centroEscenario)
        {
            this.centroEscenario=centroEscenario;
            foreach (var parte in partes.Values)
            {
                parte.setCentroResto(this.centro + this.centroEscenario);
            }
        }
        public void addParte(string nombre, Partes parte)
        {
            this.partes.Add(nombre, parte);
        }
        public void removeParte(string nombre)
        {
            this.partes.Remove(nombre);
        }
        public Partes buscarPartes(String nombre)
        {
            if (partes.ContainsKey(nombre))
            {
                return partes[nombre];
            }
            else
            {
                return null;
            }
        }
        public Double x
        {
            get { return centro.X;}
        }
        public Point Centro
        {
            get { return centro; }
            set { this.centro = value; }
        }
        public Double centroY
        {
            get { return centro.Y;}
        }
        public Double centroZ
        {
            get { return centro.Z;}
        }

        public void draw()
        {
            draw(new Point(0.0,0.0,0.0));
        }
        public void draw(Point sceneCentre)
        {
            Point centroObjSce = sceneCentre + this.centro;
            foreach (Partes parte in partes.Values)
            {
                parte.draw(centroObjSce);
            }
        }

        public void UpdateVertices()
        {
            foreach (string nombre in partes.Keys)
            {
                partes[nombre].UpdateVertices();
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
                parte.scale(scaleValue,centro+centroEscenario);
            }
        }
        public void scale(float scaleValue, Point transformacion)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.scale(scaleValue, transformacion);
            }
        }
        public void rotate(string eje,float angle)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.rotate(eje,angle,centro+centroEscenario);
            }
        }
        public void rotate(string eje, float angle,Point transformacion)
        {
            foreach (Partes parte in partes.Values)
            {
                parte.rotate(eje, angle, transformacion);
            }
        }
    }
}

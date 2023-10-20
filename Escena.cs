using Newtonsoft.Json;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProGrafica
{
    internal class Escena
    {
        [JsonProperty("objetos")]
        private Dictionary<string, Objeto> objetos{ get; set; }
        [JsonProperty("centro")]
        private Point centro { get; set; }

        public Escena() { 
            this.objetos= new Dictionary<string, Objeto>();
            this.centro = new Point(0.0, 0.0, 0.0);
        }
        public Escena(Double x, Double y, Double z) { 
            this.objetos = new Dictionary<string, Objeto>();
            this.centro= new Point(x,y,z);
        }
        public Double x
        {
            get { return this.centro.X; }
        }

        public Double y
        {
            get { return this.centro.Y; }
        }

        public Double z
        {
            get { return this.centro.Z; }
        }
        public Point Centro
        {
            get { return this.centro; }
            set { this.centro = value; }
        }
        public void addObjeto(String nombre,  Objeto objeto)
        {
            this.objetos.Add(nombre, objeto);
        }
        public void removeObjeto(String nombre)
        {
            this.objetos.Remove(nombre);
        }
        public Objeto buscarObjeto(String nombre)
        {
            if (objetos.ContainsKey(nombre))
            {
                return objetos[nombre];
            }
            else
            {
                // Si el objeto no se encuentra, puedes retornar null o manejar la situación de otra manera.
                return null;
            }
        }

        public void draw()
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.draw(centro);
            }
        }
        public void translate(double x, double y, double z)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.translate(x, y, z);
            }
        }
        public void scale(float scaleValue)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.scale(scaleValue);
            }
        }
        public void rotate(string eje,float angle)
        {
            foreach (Objeto objeto in objetos.Values)
            {
                objeto.rotate(eje,angle);
            }
        }
    }
}

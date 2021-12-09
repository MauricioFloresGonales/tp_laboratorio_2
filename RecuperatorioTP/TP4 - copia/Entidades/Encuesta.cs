using System;
using System.Collections.Generic;

namespace Entidades
{
    public delegate void DelegadoBuscar(string nombreDelObjeto);
    public class Encuesta
    {
        public event DelegadoBuscar EventoBuscar;
        int id;
        string nombre;
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public Encuesta() : base()
        {
        }
        public Encuesta(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public Encuesta(int id, string nombre) : this(nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public static List<T> Encontrar<T>(List<T> lista, int[] ids) where T : Encuesta
        {
            if (!object.ReferenceEquals(lista, null))
            {
                List<T> auxLista = new List<T>();
                foreach (int auxId in ids)
                {
                    foreach (T item in lista)
                    {
                        if (item.Id == auxId)
                        {
                             auxLista.Add(item);
                        }
                    }
                }
                return auxLista;
            }
            throw new Exception("La lista que quiere evaluar es nula");
        }
        public static int[] TransformarStringIds(string listaDeIds)
        {
            string[] auxlista = listaDeIds.Split(',');
            return Array.ConvertAll(auxlista, s => int.Parse(s));
        }
        public void ComenzarABuscar(string nombreDelObjeto)
        {
            if (!ReferenceEquals(EventoBuscar, null))
            {
                EventoBuscar.Invoke(nombreDelObjeto);
            }
        }
    }
}

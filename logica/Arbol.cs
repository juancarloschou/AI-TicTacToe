using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class Arbol<T>
    {
        private T valor;
        private ArrayList Hijos = new ArrayList(); //lista de hijos
 
        public Arbol(T valor) // constructor
        {
            this.valor = valor;
        }
        public Arbol() // constructor
        {
            this.valor = default(T);
        }

        public void Insertar(ref Arbol<T> nodo, T valor)
        {
            if (nodo == null)
                nodo = new Arbol<T>(valor);
            else
            {
                Arbol<T> nodohijo = new Arbol<T>(valor);
                nodo.Hijos.Add(nodohijo);
                /*
                if (nodo.valor.CompareTo(valor) > 0)
                    Insertar(ref nodo.nodoIzq, valor);
                else
                    Insertar(ref nodo.nodoDer, valor);
                */
            }
        }
 
        /*
        public List<T> Listar(Arbol<T> nodo, List<T> arbol)
        {
            if (nodo.nodoIzq != null)
                Listar(nodo.nodoIzq, arbol);
 
            arbol.Add(nodo.valor);
 
            if (nodo.nodoDer != null)
                Listar(nodo.nodoDer, arbol);
 
            return arbol;
        }
        */
    }
}

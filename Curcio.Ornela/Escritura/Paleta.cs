﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escritura
{
    public class Paleta
    {
        #region Atributos
        private Tempera[] temperas;
        private int cantidadMaximaColores;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto, inicializa en 5
        /// </summary>
        private Paleta(): this(5)
        {
        }
        /// <summary>
        /// Constructor de Paleta
        /// </summary>
        /// <param name="cantidadMaximaColores">Indica la capacidad máxima que posee la paleta</param>
        /// 
        private Paleta(int cantidadMaximaColores) 
        {
            this.cantidadMaximaColores = cantidadMaximaColores;
            this.temperas = new Tempera[cantidadMaximaColores];
        }
        /// <summary>
        /// Sobrecarga implicita entero Paleta
        /// </summary>
        /// <param name="n">recibe un entero, construye una paleta con n lugares</param>
        public static implicit operator Paleta(int n)
        {
            return new Paleta(n);
        }
        #endregion
        #region Metodo
        //        (-)Mostrar() :string
        /// <summary>
        /// Metodo privado de instancia p/ mostrar Paleta 
        /// </summary>
        /// <returns>string con la Paleta instanciada</returns>
        private string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Paleta: ");
            stringBuilder.AppendLine("Cantidad maxima de colores: ");
            stringBuilder.AppendLine(this.cantidadMaximaColores.ToString());
            stringBuilder.AppendLine("Listado de temperas: ");
            foreach (Tempera item in temperas)
            {
                if (item != null)
                {
                    stringBuilder.AppendLine(Tempera.Mostrar(item));
                }
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        /// Sobrecarga explicita para mostrar paleta
        /// </summary>
        /// <param name="a">paleta a mostrar</param>
        public static explicit operator string(Paleta a)
        {
            return a.Mostrar();
        }
        #endregion
        #region sobrecargas
        //==(paleta, tempera):bool
        //*->si tempera esta en paleta-->true
        public static bool operator ==(Tempera a, Paleta b)
        {
            foreach (Tempera item in b.temperas)
            {
                if(item == a)
                {
                    return true;
                    break; 
                }
            }
            return false; 
        }
        public static bool operator !=(Tempera a, Paleta b)
        {
            return !(a == b); 
        }
        ////obtenerIndice + 1overload
        //*)obtenerIndice() :int
        // *-> retorna el indice del primer lugar disponible(null) o valor neg.si no hay lugar
        public int ObtenerIndice()
        {
            int indice = -1;
            for (int i = 0; i < this.cantidadMaximaColores; i++)
            {
                if (this.temperas[i] == null)
                {
                    indice = i;
                    break;
                }
            }
            return indice; 
        }
        //*)obtenerIndice(Tempera) :int
        // *->retorna el indice donde se encuentra la tempera o valor neg.si no la encuentra
        public int ObtenerIndice(Tempera a)
        {
            int indice = -1;
            for (int i = 0; i < this.cantidadMaximaColores; i++)
            {
                if (this.temperas[i] == a)
                {
                    indice = i;
                    break; 
                }
            }
            return indice;
        }
        //+(paleta, tempera):paleta
        //*->si tempera esta en paleta-->incrementa cantidad en tempera
        //*->si no esta--> agrega la tempera en el primer lugar disponible
        public static Paleta operator +(Paleta a, Tempera b)
        {
            if (b == a) // xq no me deja invertirlo?? 
            {
                int indice = a.ObtenerIndice(b);
                a.temperas[indice] += b;
            }
            else 
            {
                int indice = a.ObtenerIndice();
                if(indice!=-1)
                { 
                    a.temperas[indice] = b; 
                }   
            }
            return a; 
        }
       
        //-(paleta, tempera):paleta
        //*->si tempera esta en paleta->decrementa cantidad
        //*)si cantidad menor o igual a cero, elimina la tempera(null)
        public static Paleta operator -(Paleta a, Tempera b)
        {
            if (b == a) // xq no me deja invertirlo?? 
            {
                int indice = a.ObtenerIndice(b);
                a.temperas[indice] +=(-b);
                if (a.temperas[indice] <= 0)
                {
                    a.temperas[indice] = null;
                }
            }
            return a;
        }
        //+(paleta, paleta):paleta
        //*->genera una paleta con los colores de ambas paletas.
        //*)si temperas son iguales-->suma cantidades
        public static Paleta operator +(Paleta a, Paleta b)
        {
            Paleta paletaTotal = null;
            int indice;
            if ((object)a != null && (object)b != null)
            {
                paletaTotal = a.cantidadMaximaColores + b.cantidadMaximaColores;

                a.temperas.CopyTo(paletaTotal.temperas, 0);

                foreach (Tempera item in b.temperas)
                {
                    if (item != null)
                    {
                        indice = paletaTotal.ObtenerIndice(item);
                        if (indice == -1)
                        {
                            paletaTotal.temperas.SetValue(item, paletaTotal.ObtenerIndice());
                            // paletaTotal.temperas[paletaTotal.ObtenerIndice()] = item; 
                        }
                        else
                        {
                            paletaTotal.temperas[indice] += item;
                        }
                    }
                }
            }
            return paletaTotal;
        }
        #endregion
    }
}

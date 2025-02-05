﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerClase33
{
    public class Libro
    {
        private List<string> paginas;

        public Libro()
        {
            this.paginas = new List<string>(); 
        }
        public int TotalPaginas()
        {
            return this.paginas.Count(); 
        }

        public string this[int i]
        {
            get 
            {
                if (i >= 0 && i < this.paginas.Count)
                {
                    return paginas[i];
                }
                return "";
            }
            set 
            {
                if (i > this.paginas.Count)
                {
                    this.paginas.Add(value);
                }
                else if (i >= 0)
                {
                    this.paginas.Insert(i, value);
                }
            }
        }
    }
}

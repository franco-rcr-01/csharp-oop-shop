using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_oop_shop
{
    internal class Prodotto
    {
        private static readonly HashSet<string> nomi = new HashSet<string>();
        public int Codice { get; }

        private string nome;
        public string Nome {
            get { return nome; }
            set { if (nomi.Contains(value))
                    throw new Exception("Product name already exists");
                nomi.Add(value);
                nome = value;
            }
        }
        public string? Descrizione { get; set; }

        public double Prezzo { get; set; }

        private double iva;
        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }

        private Random myRand;

        public Prodotto(string nome, string descrizione, double prezzo, double iva)
        {
            myRand = new Random();
            this.Nome = nome;
            this.Descrizione = descrizione;
            this.Prezzo = prezzo;
            this.Iva = iva;
            Codice = myRand.Next(); //ma se il codice è uguale a altri codici già creat??
        }

        public double GetPrezzoIvato()
        {
            return Prezzo * (1.0 + Iva);
        }

        public string NomeEsteso()
        {
            return String.Format("{0}-{1}", Codice, Nome);
        }
        public string GetCodiceFormatted()
        {
            string scod = Codice.ToString();
            if (scod.Length < 13)
                return new String('0', 13 - scod.Length) + scod;
            else
                return scod;
        }
    }
}

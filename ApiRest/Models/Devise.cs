using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class Devise
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Taux { get; set; }

        public Devise()
        {
            this.Id = 0;
            this.Nom = "Euros";
            this.Taux = 1.2;
        }

        public Devise(int id, string nom, double taux)
        {
            this.Id = id;
            this.Nom = nom;
            this.Taux = taux;
        }
    }
}
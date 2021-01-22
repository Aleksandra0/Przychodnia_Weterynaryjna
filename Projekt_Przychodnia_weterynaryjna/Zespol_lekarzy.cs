using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    /// <summary>Aggregates doctors (Lekarz)</summary>
    public class Zespol_lekarzy : Lekarz
    {
        private Lekarz lekarz;
        private List<Lekarz> lekarze;

        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public List<Lekarz> Lekarze { get => lekarze; set => lekarze = value; }


        /// <summary>Initializes a new instance of the <see cref="Zespol_lekarzy" /> class.</summary>
        public Zespol_lekarzy()
        {
            Lekarze = new List<Lekarz>();
            this.Lekarz = null;
        }

        /// <summary>Initializes a new instance of the <see cref="Zespol_lekarzy" /> class.</summary>
        /// <param name="lekarz">The lekarz.</param>
        public Zespol_lekarzy(Lekarz lekarz)
        {
            Lekarze = new List<Lekarz>();
            this.lekarz = new Lekarz();
        }

        /// <summary>Dodajs the lekarza.</summary>
        /// <param name="l">The l.</param>
        public void Dodaj_lekarza(Lekarz l)
        {
            this.lekarze.Add(l);
        }

        /// <summary>Usunlekarzas the specified pesel.</summary>
        /// <param name="PESEL">The pesel.</param>
        public void Usunlekarza(string PESEL)
        {
            for (int i = 0; i < lekarze.Count; i++)
            {
                if (Lekarze[i].Pesel == PESEL)
                {
                    Lekarze.Remove(Lekarze[i]);
                    return;
                }
            }
        }

        /// <summary>Clears the list</summary>
        public void Wyczysc_liste()
        {
            this.lekarze.Clear();
        }

        /// <summary>Sortujs the po pesel.</summary>
        public void SortujPoPESEL()
        {
            Lekarze.Sort(new peselComparator());
        }

        /// <summary>Sortujs this instance.</summary>
        public void Sortuj()
        {
           Lekarze.Sort();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder1 = new StringBuilder();
            foreach (Lekarz lekarz in lekarze)
            {
                stringBuilder1.AppendLine(lekarz.ToString());
            }
            return stringBuilder1.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    class idComparator : Comparer<Pacjent>
     {
        /// <summary>
        /// When overridden in a derived class, performs a comparison of two objects of the same type and returns a value indicating whether one object is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.
        /// Value
        /// Meaning
        /// Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.
        /// Zero
        /// <paramref name="x" /> equals <paramref name="y" />.
        /// Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public override int Compare(Pacjent x, Pacjent y)
         {
             return x.Id.ToString().CompareTo(y.Id.ToString());
         }
     }
    /// <summary>Information about patient</summary>
    public class Pacjent : Zwierze, ICloneable, IComparable<Pacjent>
    {
        private int id;
        private List<Przebyte_choroby> przebyte_choroby;
        private List<Szczepienia> szczepienia;
        private Klient wlasciciel;
        private Lekarz lekarz;

        public int Id { get => id; set => id = value; }
        public List<Przebyte_choroby> Przebyte_choroby { get => przebyte_choroby; set => przebyte_choroby = value; }
        public List<Szczepienia> Szczepienia { get => szczepienia; set => szczepienia = value; }
        public Lekarz Lekarz { get => lekarz; set => lekarz = value; }
        public Klient Wlasciciel { get => wlasciciel; set => wlasciciel = value; }

        /// <summary>Initializes a new instance of the <see cref="Pacjent" /> class.</summary>
        public Pacjent()
        {
            this.Id = 0;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.wlasciciel = null;
            this.Lekarz = null;
        }
        /// <summary>Initializes a new instance of the <see cref="Pacjent" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="gatunek">The gatunek.</param>
        /// <param name="rasa">The rasa.</param>
        /// <param name="barwa">The barwa.</param>
        /// <param name="znaki_szczegolne">The znaki szczegolne.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="lekarz">The lekarz.</param>
        /// <param name="wlasciciel">The wlasciciel.</param>
        public Pacjent(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Lekarz lekarz, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.lekarz = new Lekarz();
            this.wlasciciel = new Klient();
        }

        /// <summary>Initializes a new instance of the <see cref="Pacjent" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="gatunek">The gatunek.</param>
        /// <param name="rasa">The rasa.</param>
        /// <param name="barwa">The barwa.</param>
        /// <param name="znaki_szczegolne">The znaki szczegolne.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="lekarz">The lekarz.</param>
        /// <param name="wlasciciel">The wlasciciel.</param>
        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Lekarz lekarz, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.lekarz = new Lekarz();
            this.wlasciciel = new Klient();
        }

        /// <summary>Initializes a new instance of the <see cref="Pacjent" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="gatunek">The gatunek.</param>
        /// <param name="rasa">The rasa.</param>
        /// <param name="barwa">The barwa.</param>
        /// <param name="znaki_szczegolne">The znaki szczegolne.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="wlasciciel">The wlasciciel.</param>
        public Pacjent(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne, int id, Klient wlasciciel) : base(imie, data_urodzenia, plec, gatunek, rasa, barwa, znaki_szczegolne)
        {
            this.Id = id;
            Szczepienia = new List<Szczepienia>();
            Przebyte_choroby = new List<Przebyte_choroby>();
            this.wlasciciel = new Klient();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Id + " " + base.ToString();
        }

        /// <summary>Serializes to XML</summary>
        /// <param name="nazwa">The nazwa.</param>
        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>Deserializes from XML file</summary>
        /// <param name="nazwa">The nazwa.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Pacjent OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Pacjent));
                return serializer.Deserialize(reader) as Pacjent;
            }
        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        /// <summary>Clones the pacjent.</summary>
        /// <returns>
        ///   A new object that is a copy of this instance.
        /// </returns>
        public object ClonePacjent()
        {
            Pacjent klon = this.MemberwiseClone() as Pacjent;
            
            klon.lekarz = this.lekarz.Clone() as Lekarz;
            klon.wlasciciel = this.wlasciciel.Clone() as Klient;
            
            klon.przebyte_choroby = new List<Przebyte_choroby>();
            foreach (Przebyte_choroby choroba in przebyte_choroby)
                klon.Przebyte_choroby.Add(choroba.Clone() as Przebyte_choroby);

            klon.szczepienia = new List<Szczepienia>();
            foreach (Szczepienia szczepienie in szczepienia)
                klon.Szczepienia.Add(szczepienie.Clone() as Szczepienia);
            return klon;
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
        /// Value
        /// Meaning
        /// Less than zero
        /// This instance precedes <paramref name="other" /> in the sort order.
        /// Zero
        /// This instance occurs in the same position in the sort order as <paramref name="other" />.
        /// Greater than zero
        /// This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(Pacjent other)
        {
            return this.Imie.CompareTo(other.Imie);
        }

    }
}

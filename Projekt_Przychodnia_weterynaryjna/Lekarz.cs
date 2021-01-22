using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{

    class peselComparator : Comparer<Lekarz>
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
        public override int Compare(Lekarz x, Lekarz y)
        {
            return x.Pesel.CompareTo(y.Pesel);
        }
    }

    /// <summary>Information about doctors</summary>
    public class Lekarz : Osoba, IComparable<Lekarz>, ICloneable
    {
        private string numer_telefonu;
        private string email;
        private string specjalizacja;
        private string tytuly;
        private int staz_pracy;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Specjalizacja { get => specjalizacja; set => specjalizacja = value; }
        public string Tytuly { get => tytuly; set => tytuly = value; }
        public int Staz_pracy { get => staz_pracy; set => staz_pracy = value; }

        /// <summary>Initializes a new instance of the <see cref="Lekarz" /> class.</summary>
        public Lekarz()
        {
            this.numer_telefonu = null;
            this.email = null;
            this.specjalizacja = null;
            this.tytuly = null;
            this.staz_pracy = 0;
        }
        /// <summary>Initializes a new instance of the <see cref="Lekarz" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="numer_telefonu">The numer telefonu.</param>
        /// <param name="email">The email.</param>
        /// <param name="specjalizacja">The specjalizacja.</param>
        /// <param name="tytuly">The tytuly.</param>
        /// <param name="staz_pracy">The staz pracy.</param>
        public Lekarz(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
        }

        /// <summary>Initializes a new instance of the <see cref="Lekarz" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="numer_telefonu">The numer telefonu.</param>
        /// <param name="email">The email.</param>
        /// <param name="specjalizacja">The specjalizacja.</param>
        /// <param name="tytuly">The tytuly.</param>
        /// <param name="staz_pracy">The staz pracy.</param>
        public Lekarz(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string specjalizacja, string tytuly, int staz_pracy) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.specjalizacja = specjalizacja;
            this.tytuly = tytuly;
            this.staz_pracy = staz_pracy;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.tytuly + " " + this.Imie + " " + this.Nazwisko + "\nNumer telefonu: " + this.numer_telefonu + "\nEmail: " + this.email + "\nSpecjalizacja: " + this.specjalizacja + "\nStaż pracy: " + this.staz_pracy + "\n\n";
        }

        /// <summary>Serializes Lekarz to XML</summary>
        /// <param name="nazwa">The nazwa.</param>
        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lekarz));
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>Deserializes Lekarz from xml file</summary>
        /// <param name="nazwa">The nazwa.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Lekarz OdczytajXML(string nazwa)
        {
            Lekarz wynik = null;
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Lekarz));
                wynik =  serializer.Deserialize(reader) as Lekarz;
            }
            return wynik;
        }
        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
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
        public int CompareTo(Lekarz other)
        {
            if (this.Nazwisko != other.Nazwisko)
                return this.Nazwisko.CompareTo(other.Nazwisko);
            else
                return this.Imie.CompareTo(other.Imie);
        }

    }
}

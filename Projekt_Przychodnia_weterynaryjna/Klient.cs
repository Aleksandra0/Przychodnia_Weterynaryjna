using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    /// <summary>Information about clients</summary>
    public class Klient : Osoba, IZarzadzanie_pacjentami , ICloneable
    {
        private string numer_telefonu;
        private string email;
        private string adres;
        private List<Pacjent> zwierzeta;

        public string Numer_telefonu { get => numer_telefonu; set => numer_telefonu = value; }
        public string Email { get => email; set => email = value; }
        public string Adres { get => adres; set => adres = value; }
        public List<Pacjent> Zwierzeta { get => zwierzeta; set => zwierzeta = value; }
        /// <summary>Initializes a new instance of the <see cref="Klient" /> class.</summary>
        public Klient()
        {
            this.numer_telefonu = null;
            this.email = null;
            this.adres = null;
            Zwierzeta = new List<Pacjent>();
        }
        /// <summary>Initializes a new instance of the <see cref="Klient" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="numer_telefonu">The numer telefonu.</param>
        /// <param name="email">The email.</param>
        /// <param name="adres">The adres.</param>
        /// <param name="zwierzeta">The zwierzeta.</param>
        public Klient(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            Zwierzeta = new List<Pacjent>();
        }

        /// <summary>Initializes a new instance of the <see cref="Klient" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="numer_telefonu">The numer telefonu.</param>
        /// <param name="email">The email.</param>
        /// <param name="adres">The adres.</param>
        /// <param name="zwierzeta">The zwierzeta.</param>
        public Klient(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec, string numer_telefonu, string email, string adres, string zwierzeta) : base(imie, nazwisko, data_urodzenia, pesel, plec)
        {
            this.numer_telefonu = numer_telefonu;
            this.email = email;
            this.adres = adres;
            Zwierzeta = new List<Pacjent>();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return base.ToString() + "Numer telefonu: " + this.numer_telefonu + "\n\nEmail: " + this.email + "\n\nAdres: " + this.adres;
        }

        /// <summary>Converts to string2.</summary>
        /// <returns>
        ///   A <see cref="System.String" /> that represents this instance
        /// </returns>
        public string ToString2()
        {
            StringBuilder stringBuilder1 = new StringBuilder("\nPupile: \n");
            foreach (Pacjent zwierze in Zwierzeta)
            {
                stringBuilder1.AppendLine("\n" + zwierze.Imie + " (id: " + zwierze.Id + ")\nData urodzenia: " + zwierze.Data_urodzenia.ToString("dd-MM-yyyy") + "\n" + zwierze.Gatunek + ", rasa: " + zwierze.Rasa + ", barwa: " + zwierze.Barwa + "\nZnaki szczególne: " + zwierze.Znaki_szczegolne);
            }
            return stringBuilder1.ToString();
        }


        /// <summary>Adds patients to the list</summary>
        /// <param name="p">The p.</param>
        public void Dodaj_pacjenta(Pacjent p)
        {
            this.zwierzeta.Add(p);
        }

        /// <summary>Deletes patients from the list</summary>
        /// <param name="id">The identifier.</param>
        public void Usun_pacjenta(int id)
        {
            foreach (Pacjent p in this.zwierzeta)
            {
                if (p.Id == id)
                {
                    zwierzeta.Remove(p);
                    break;
                }
            }
        }

        /// <summary>Clears the list</summary>
        public void Wyczysc_liste()
        {
            this.zwierzeta.Clear();
        }

        /// <summary>Serilaizes type Klient to XML</summary>
        /// <param name="nazwa">The nazwa.</param>
        public void ZapiszXML(string nazwa)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                serializer.Serialize(writer, this);
            }
        }

        /// <summary>Deserializes Klient from xml file</summary>
        /// <param name="nazwa">The nazwa.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static Klient OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Klient));
                return serializer.Deserialize(reader) as Klient;
            }
        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }


        /// <summary>Clones the klient.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public object CloneKlient()
        {
            Klient klon = this.MemberwiseClone() as Klient;
            klon.Zwierzeta = new List<Pacjent>();
            foreach (Pacjent pacjent in Zwierzeta)
                klon.Zwierzeta.Add(pacjent.Clone() as Pacjent);
            return klon;
        }


        /// <summary>Sorts by name of patient</summary>
        public void Sortuj()
        {
            zwierzeta.Sort();
        }

        /// <summary>Sorts by id of patient</summary>
        public void SortujPoId()
        {
            Zwierzeta.Sort(new idComparator());
        }
    }
}

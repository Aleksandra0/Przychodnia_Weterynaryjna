using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    /// <summary>Abstract class Osoba</summary>
    public abstract class Osoba : IEquatable<Osoba>
    {
        public enum Plcie { K, M, I } //I - other (inna)

        private string imie;
        private string nazwisko;
        private DateTime data_urodzenia;
        private string pesel;
        private Plcie plec;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime Data_urodzenia { get => data_urodzenia; set => data_urodzenia = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public Plcie Plec { get => plec; set => plec = value; }

        /// <summary>Initializes a new instance of the <see cref="Osoba" /> class.</summary>
        public Osoba()
        {
            this.imie = null;
            this.nazwisko = null;
            this.data_urodzenia = DateTime.Today;
            this.pesel = null;
            this.plec = Plcie.K;
        }

        /// <summary>Initializes a new instance of the <see cref="Osoba" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        public Osoba(string imie, string nazwisko, DateTime data_urodzenia, string pesel, Plcie plec)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.data_urodzenia = data_urodzenia;
            this.pesel = pesel;
            this.plec = plec;
        }

        /// <summary>Initializes a new instance of the <see cref="Osoba" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="nazwisko">The nazwisko.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="pesel">The pesel.</param>
        /// <param name="plec">The plec.</param>
        public Osoba(string imie, string nazwisko, string data_urodzenia, string pesel, Plcie plec)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_urodzenia);
            this.pesel = pesel;
            this.plec = plec;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.imie + " " + this.Nazwisko + "\n\nData urodzenia: " + this.Data_urodzenia.ToString("dd-MM-yyyy") + "\n\nPesel: " + this.pesel + "\n\n";
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <span class="keyword">
        ///     <span class="languageSpecificText">
        ///       <span class="cs">true</span>
        ///       <span class="vb">True</span>
        ///       <span class="cpp">true</span>
        ///     </span>
        ///   </span>
        ///   <span class="nu">
        ///     <span class="keyword">true</span> (<span class="keyword">True</span> in Visual Basic)</span> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <span class="keyword"><span class="languageSpecificText"><span class="cs">false</span><span class="vb">False</span><span class="cpp">false</span></span></span><span class="nu"><span class="keyword">false</span> (<span class="keyword">False</span> in Visual Basic)</span>.
        /// </returns>
        public bool Equals(Osoba other)
        {
            return this.pesel == other.pesel;
        }
    }
}

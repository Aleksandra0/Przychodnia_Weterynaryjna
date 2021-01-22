using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projekt_Przychodnia_weterynaryjna
{
    /// <summary>Abstract class Zwierze</summary>
    public abstract class Zwierze : IEquatable<Zwierze>
    {
        public enum Plcie_zwierzat { samiec, samica };

        private string imie;
        private DateTime data_urodzenia;
        private Plcie_zwierzat plec;
        private string gatunek;
        private string rasa;
        private string barwa;
        private string znaki_szczegolne;

        public string Imie { get => imie; set => imie = value; }
        public DateTime Data_urodzenia { get => data_urodzenia; set => data_urodzenia = value; }
        internal Plcie_zwierzat Plec { get => plec; set => plec = value; }
        public string Gatunek { get => gatunek; set => gatunek = value; }
        public string Rasa { get => rasa; set => rasa = value; }
        public string Barwa { get => barwa; set => barwa = value; }
        public string Znaki_szczegolne { get => znaki_szczegolne; set => znaki_szczegolne = value; }

        /// <summary>Initializes a new instance of the <see cref="Zwierze" /> class.</summary>
        public Zwierze()
        {
            this.Imie = null;
            this.Data_urodzenia = DateTime.Today;
            this.Plec = Plcie_zwierzat.samiec;
            this.Gatunek = null;
            this.Rasa = null;
            this.Barwa = null;
            this.Znaki_szczegolne = null;
        }
        /// <summary>Initializes a new instance of the <see cref="Zwierze" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="gatunek">The gatunek.</param>
        /// <param name="rasa">The rasa.</param>
        /// <param name="barwa">The barwa.</param>
        /// <param name="znaki_szczegolne">The znaki szczegolne.</param>
        public Zwierze(string imie, DateTime data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne)
        {
            this.Imie = imie;
            this.Data_urodzenia = data_urodzenia;
            this.Plec = plec;
            this.Gatunek = gatunek;
            this.Rasa = rasa;
            this.Barwa = barwa;
            this.Znaki_szczegolne = znaki_szczegolne;
        }

        /// <summary>Initializes a new instance of the <see cref="Zwierze" /> class.</summary>
        /// <param name="imie">The imie.</param>
        /// <param name="data_urodzenia">The data urodzenia.</param>
        /// <param name="plec">The plec.</param>
        /// <param name="gatunek">The gatunek.</param>
        /// <param name="rasa">The rasa.</param>
        /// <param name="barwa">The barwa.</param>
        /// <param name="znaki_szczegolne">The znaki szczegolne.</param>
        public Zwierze(string imie, string data_urodzenia, Plcie_zwierzat plec, string gatunek, string rasa, string barwa, string znaki_szczegolne)
        {
            this.Imie = imie;
            DateTime.TryParseExact(data_urodzenia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_urodzenia);
            this.Plec = plec;
            this.Gatunek = gatunek;
            this.Rasa = rasa;
            this.Barwa = barwa;
            this.Znaki_szczegolne = znaki_szczegolne;
        }

        /// <summary>Counts age of animal</summary>
        public int Wiek()
        {
            int wiek = 0;
            wiek = DateTime.Today.Year - this.Data_urodzenia.Year;
            if (DateTime.Today < this.Data_urodzenia.AddYears(wiek) && wiek != 0)
            {
                wiek--;
            }
            return wiek;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Imie + " " + this.Data_urodzenia.ToString("dd-MM-yyyy") + " " + this.Plec + " " + this.Gatunek + " " + this.Rasa + " " + this.Barwa + " " + this.Znaki_szczegolne + ", Wiek: " + this.Wiek().ToString();
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
        public bool Equals(Zwierze other)
        {
            return this.imie == other.imie;
        }
    }
}

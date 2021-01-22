using System;
using System.Globalization;

namespace Projekt_Przychodnia_weterynaryjna
{
	/// <summary>Information about medical history</summary>
	public class Przebyte_choroby : ICloneable
	{
		public enum Typ_choroby {wirusowa,bakteryjna, grzybiczna, pasozytnicza};
		public enum Pasozyty {brak, pchly, kleszcze, p_wewnetrzne, wszy};
		private string nazwa_choroby;
		private DateTime data_choroby;
		private Pasozyty pasozyty;
		private Typ_choroby choroba;
		private string leki;
		private string zalecenia;
		private DateTime wizyta_kontrolna;
		private string dolegliwosci;


		public string Nazwa_choroby { get => nazwa_choroby; set => nazwa_choroby = value; }
		public DateTime Data_choroby { get => data_choroby; set => data_choroby = value; }
		public Pasozyty Pasozyt { get => pasozyty; set => pasozyty = value; }
		public Typ_choroby Choroba { get => choroba; set => choroba = value; }
		public string Leki { get => leki; set => leki = value; }
		public DateTime Wizyta_kontrolna { get => wizyta_kontrolna; set => wizyta_kontrolna = value; }
        public string Zalecenia { get => zalecenia; set => zalecenia = value; }
        public string Dolegliwosci { get => dolegliwosci; set => dolegliwosci = value; }

        /// <summary>Initializes a new instance of the <see cref="Przebyte_choroby" /> class.</summary>
        public Przebyte_choroby()
        {
			this.Nazwa_choroby = null;
			this.Data_choroby = DateTime.Today;
			this.Pasozyt = Pasozyty.brak;
			this.Dolegliwosci = null;
			this.Choroba = Typ_choroby.wirusowa;
			this.Leki = null;
			this.Zalecenia = null;
			this.Wizyta_kontrolna = DateTime.Today;
		}
        /// <summary>Initializes a new instance of the <see cref="Przebyte_choroby" /> class.</summary>
        /// <param name="nazwa_choroby">The nazwa choroby.</param>
        /// <param name="data_choroby">The data choroby.</param>
        /// <param name="pasozyty">The pasozyty.</param>
        /// <param name="dolegliwosci">The dolegliwosci.</param>
        /// <param name="choroba">The choroba.</param>
        /// <param name="leki">The leki.</param>
        /// <param name="zalecenia">The zalecenia.</param>
        /// <param name="wizyta_kontrolna">The wizyta kontrolna.</param>
        public Przebyte_choroby(string nazwa_choroby, DateTime data_choroby, Pasozyty pasozyty, string dolegliwosci, Typ_choroby choroba, string leki, string zalecenia, DateTime wizyta_kontrolna)
		{
			this.Nazwa_choroby = nazwa_choroby;
			this.Data_choroby = data_choroby;
			this.Pasozyt = pasozyty;
			this.Dolegliwosci = dolegliwosci;
			this.Choroba = choroba;
			this.Leki = leki;
			this.Zalecenia = zalecenia;
			this.Wizyta_kontrolna = wizyta_kontrolna;
		}

        /// <summary>Initializes a new instance of the <see cref="Przebyte_choroby" /> class.</summary>
        /// <param name="nazwa_choroby">The nazwa choroby.</param>
        /// <param name="data_choroby">The data choroby.</param>
        /// <param name="pasozyty">The pasozyty.</param>
        /// <param name="dolegliwosci">The dolegliwosci.</param>
        /// <param name="choroba">The choroba.</param>
        /// <param name="leki">The leki.</param>
        /// <param name="zalecenia">The zalecenia.</param>
        /// <param name="wizyta_kontrolna">The wizyta kontrolna.</param>
        public Przebyte_choroby(string nazwa_choroby, string data_choroby, Pasozyty pasozyty, string dolegliwosci, Typ_choroby choroba, string leki, string zalecenia, string wizyta_kontrolna)
		{
			this.Nazwa_choroby = nazwa_choroby;
			DateTime.TryParseExact(data_choroby, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_choroby);
			this.Pasozyt = pasozyty;
			this.Dolegliwosci = dolegliwosci;
			this.Choroba = choroba;
			this.Leki = leki;
			this.Zalecenia = zalecenia;
			DateTime.TryParseExact(wizyta_kontrolna, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.wizyta_kontrolna);
		}

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
			return this.nazwa_choroby + ": " + this.data_choroby.ToString("dd-MM-yyyy");
		}

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}

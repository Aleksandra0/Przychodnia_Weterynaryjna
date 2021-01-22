using System;
using System.Globalization;

namespace Projekt_Przychodnia_weterynaryjna
{
	/// <summary>Information about vaccination</summary>
	public class Szczepienia : ICloneable
	{
		public enum Rodzaj_szczepienia { obowiazkowe, dodatkowe };
		
		private DateTime data_szczepienia;
		private DateTime data_nastepnego_szczepienia;
		private string preparat;
		private string przeciw_czemu;
		private Rodzaj_szczepienia rodzaj_szczepienia;


        public string Preparat { get => preparat; set => preparat = value; }
        public DateTime Data_nastepnego_szczepienia { get => data_nastepnego_szczepienia; set => data_nastepnego_szczepienia = value; }
        public DateTime Data_szczepienia { get => data_szczepienia; set => data_szczepienia = value; }
		public Rodzaj_szczepienia Rodzaj_Szczepienia { get => rodzaj_szczepienia; set => rodzaj_szczepienia = value; }
        public string Przeciw_czemu { get => przeciw_czemu; set => przeciw_czemu = value; }

        /// <summary>Initializes a new instance of the <see cref="Szczepienia" /> class.</summary>
        public Szczepienia()
        {
			this.Data_szczepienia = DateTime.Today;
			this.Preparat = null;
			this.Przeciw_czemu = null;
			this.Data_nastepnego_szczepienia = DateTime.Today;
		}
        /// <summary>Initializes a new instance of the <see cref="Szczepienia" /> class.</summary>
        /// <param name="data_szczepienia">The data szczepienia.</param>
        /// <param name="preparat">The preparat.</param>
        /// <param name="przeciw_czemu">The przeciw czemu.</param>
        /// <param name="data_nastepnego_szczepienia">The data nastepnego szczepienia.</param>
        public Szczepienia(DateTime data_szczepienia, string preparat, string przeciw_czemu, DateTime data_nastepnego_szczepienia)
		{
			this.Data_szczepienia = data_szczepienia;
			this.Preparat = preparat;
			this.Przeciw_czemu = przeciw_czemu;
			this.Data_nastepnego_szczepienia = data_nastepnego_szczepienia;
		}

        /// <summary>Initializes a new instance of the <see cref="Szczepienia" /> class.</summary>
        /// <param name="data_szczepienia">The data szczepienia.</param>
        /// <param name="preparat">The preparat.</param>
        /// <param name="przeciw_czemu">The przeciw czemu.</param>
        /// <param name="data_nastepnego_szczepienia">The data nastepnego szczepienia.</param>
        public Szczepienia(string data_szczepienia, string preparat, string przeciw_czemu, string data_nastepnego_szczepienia)
		{
			DateTime.TryParseExact(data_szczepienia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_szczepienia);
			this.Preparat = preparat;
			this.Przeciw_czemu = przeciw_czemu;
			DateTime.TryParseExact(data_nastepnego_szczepienia, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "yyyy.MM.dd", "dd-MM-yyyy", "dd/MM/yyyy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out this.data_nastepnego_szczepienia);
		}

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
			return "Szczepienie: " + this.data_szczepienia.ToString("dd-MM-yyyy") + ", przeciwko: " + this.przeciw_czemu + ", zastosowany preparat: " + this.preparat;
		}

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Przychodnia_weterynaryjna
{
    /// <summary>
    ///   Interface for adding, deleting patients and clearing the list of patients
    /// </summary>
    interface IZarzadzanie_pacjentami
    {
        void Dodaj_pacjenta(Pacjent p);
        void Usun_pacjenta(int id);
        void Wyczysc_liste();
    }
}

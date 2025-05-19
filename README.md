# Veterinary Clinic Customer Service System

## Project Overview

The goal of this project was to develop a customer service system for a veterinary clinic. The solution is divided into two separate projects:

1. **Veterinary Clinic (Backend Logic)**
2. **Veterinary Clinic GUI (Graphical User Interface)**

---

## 1. Veterinary Clinic (Backend Logic)

This project contains the core logic of the clinic management system. It consists of:

- **9 classes** and **1 interface** (`IZarzadzanie_pacjentami`)
- **2 abstract classes**:
  - `Osoba` (Person)
  - `Zwierze` (Animal)
- **7 concrete classes**:
  - `Klient` (Client) – inherits from `Osoba`
  - `Lekarz` (Doctor) – inherits from `Osoba`
  - `Pacjent` (Patient) – inherits from `Zwierze`
  - `Przebyte_choroby` (Past Illnesses)
  - `Szczepienia` (Vaccinations)
  - `Zespol_lekarzy` (Medical Team)
  - `Program` – contains the `main` function to run the application

---

## 2. Veterinary Clinic GUI (Frontend Interface)

This project provides a graphical user interface for interacting with the backend system. It includes six GUI windows:

- `MainWindow`
- `Rejestracja` (Registration)
- `Rejestracja_Pacjent` (Patient Registration)
- `Podsumowanie` (Summary)
- `WyborLekarza` (Doctor Selection)
- `OknoKoncowe` (Final Window)

These windows guide the user through registering a client and patient, selecting a doctor, and summarizing the registration.

---

## Technologies Used

- Programming Language: C#
- UI Framework: Windows Forms (WinForms)

---

## Authors

- Project created by: Aleksandra Borkowska, Karolina Bujak, Katarzyna Blitek

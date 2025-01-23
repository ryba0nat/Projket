# Wypożyczalnia Sprzętu Narciarskiego

Aplikacja desktopowa do zarządzania wypożyczalnią sprzętu narciarskiego oraz karnetami. Program umożliwia dodawanie klientów, wypożyczanie sprzętu, zarządzanie karnetami oraz przechowywanie danych w pliku XML.

---

## **Funkcjonalności**
1. **Zarządzanie sprzętem narciarskim**:
   - Dodawanie nowego sprzętu (narty, snowboard) z określeniem typu, rozmiaru i stanu technicznego.
   - Usuwanie sprzętu.
   - Wypożyczanie sprzętu przez klientów.
   - Przechowywanie informacji o stanie sprzętu (dostępny/wypożyczony).

2. **Zarządzanie klientami**:
   - Dodawanie klientów do bazy.
   - Walidacja numeru PESEL (11 cyfr).
   - Powiązanie klientów z wypożyczeniami.

3. **Zarządzanie karnetami**:
   - Kupowanie karnetów (dzienny, tygodniowy, miesięczny) z wyliczaniem całkowitej ceny.
   - Wybór karnetu ulgowego lub normalnego.

4. **Zapisywanie i wczytywanie danych**:
   - Dane o sprzęcie, klientach i karnetach są przechowywane w pliku XML.
   - Automatyczne wczytywanie danych przy uruchomieniu programu.

---

## **Wymagania systemowe**
- System operacyjny: Windows 10 lub nowszy.
- .NET Framework: Wersja 4.7.2 lub nowsza.
- Visual Studio 2022 (dla programistów chcących rozwijać projekt).

---

## **Instrukcja instalacji**
1. Sklonuj repozytorium na swój komputer:
   ```bash
   git clone https://github.com/ryba0nat/Projket.git

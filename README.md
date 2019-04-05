# Duomenu apdorojimas

## v0.1
Studentų pažymių skaičiavimas pagal vidurkį arba medianą ir rezultatų išvedimas lentelėje.

## v0.2
Studentų nuskaitymas iš failo ir surūšiuotas rezultatų išvedimas lentelėje.

## v0.3
Patobulintas klaidų apdorojimas.

## v0.4
Studentų suskirstymas į kategorijas. Išmatuotas programos veikimo laikas nuskaitant studentus iš failo, priklausomai nuo studentų skaičiaus. Rezultatai pateikiami lentelėje: 

| Studentų skaičius | Užtruko laiko (ss:ms) |
|---------------|----------------------|
| 10            | 00.0105739           |
| 100           | 00.0162070           |
| 1000          | 00.0474129           |
| 10000         | 00.1749180           |
| 100000        | 01.3508633           |

Didėjant studentų skaičiui, didėja ir veikimo laikas.

## v0.5

| Konteineris   | 10         | 100        | 1000       | 10000      | 100000     |
|---------------|------------|------------|------------|------------|------------|
| List<T>       | 00.0105739 | 00.0299065 | 00.0340985 | 00.1076318 | 00.7782735 |
| LinkedList<T> | 00.0050590 | 00.0065381 | 00.0201505 | 00.1057368 | 00.7343116 |
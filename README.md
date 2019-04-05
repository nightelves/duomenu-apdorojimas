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
Išmatuotas programos veikimo laikas su skirtingais konteineriais ir skirtingais studentų skaičiais. Rezultatai pateikiami lentelėje (laikas atvaizduojamus ss:ms formatu);

| Konteineris   | 10         | 100        | 1000       | 10000      | 100000     |
|---------------|------------|------------|------------|------------|------------|
| List &lt;T&gt;       | 00.0105739 | 00.0299065 | 00.0340985 | 00.1076318 | 00.7782735 |
| LinkedList &lt;T&gt; | 00.0050590 | 00.0065381 | 00.0201505 | 00.1057368 | 00.7343116 |
| Deque &lt;T&gt;      | 00.0051131 | 00.0058560 | 00.0198602 | 00.0842828 | 00.7656510 |

Greičiausias - `LinkedList`, lečiausias - `List`

## v1.0

### 1 strategija

| Konteineris   | 10         | 100        | 1000       | 10000      | 100000     |
|---------------|------------|------------|------------|------------|------------|
| List<T>       |            |            |            |            |            |
| LinkedList<T> |            |            |            |            |            |
| Deque<T>      | 00.0125775 | 00.0198390 | 00.0252961 | 00.1588843 | 01.1896728 |

| Konteineris   | 10       | 100      | 1000     | 10000    | 100000   |
|---------------|----------|----------|----------|----------|----------|
| List<T>       |          |          |          |          |          |
| LinkedList<T> |          |          |          |          |          |
| Deque<T>      | 16596992 | 16617472 | 19116032 | 22900736 | 54140928 |

### 2 strategija
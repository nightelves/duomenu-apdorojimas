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
| Deque &lt;T&gt;      | 00.0060783 | 00.0079333 | 00.0219175 | 00.1069328 | 00.7677842 |

Greičiausias - `LinkedList`, lečiausias - `List`

## v1.0

### 1 strategija
Išmatuotas programos veikimo laikas pagal 1 strategija. Rezultatai pateikiami lentelėje (laikas atvaizduojamus ss:ms formatu);

| Konteineris   | 10         | 100        | 1000       | 10000      | 100000     |
|---------------|------------|------------|------------|------------|------------|
| List &lt;T&gt;       | 00.0192976 | 00.0213836 | 00.0361253 | 00.1423622 | 01.1887621 |
| LinkedList &lt;T&gt; | 00.0177115 | 00.0211130 | 00.0370386 | 00.1605567 | 01.2686796 |
| Deque &lt;T&gt;      | 00.0125775 | 00.0198390 | 00.0252961 | 00.1588843 | 01.1896728 |

Išmatuotas programos naudojama atmintis pagal 1 strategija. Naudojama atmintis pateikiamia lentelėje (baitais);

| Konteineris   | 10       | 100      | 1000     | 10000    | 100000   |
|---------------|----------|----------|----------|----------|----------|
| List &lt;T&gt;       | 16134144 | 16703488 | 19173376 | 19173376 | 54001664 |
| LinkedList &lt;T&gt; | 16138240 | 16592896 | 19079168 | 19079168 | 67571712 |
| Deque &lt;T&gt;      | 16596992 | 16617472 | 19116032 | 19116032 | 54140928 |

Naudojant 1 strategiją, pagal spartą greičiausias yra `Deque`, iškart po jo - `List`, o lečiausiai veikė `LinkedList`. Mažiausiai atminties naudoja `List`, kiek daugiau naudoja `Deque`, o daugiausia `LinkedList`. Renkantis pagal spartą, geriausias konteineris yra `Deque`, pagal atmintį - `List`, blogiausiai pasirodė `LinkedList`.

Naudojant šią strategiją yra naudojama daugiau atminties - pavyzdziui `Deque` su 100000 studentų naudoja 1585152 baitais daugiau negu prieš tai esanti versija su tokia pačia struktūra ir studentu skaičiumi.

### 2 strategija
Išmatuotas programos veikimo laikas pagal 2 strategija. Rezultatai pateikiami lentelėje (laikas atvaizduojamus ss:ms formatu);

| Konteineris   | 10         | 100        | 1000       | 10000      | 100000     |
|---------------|------------|------------|------------|------------|------------|
| List &lt;T&gt;       | 00.0102766 | 00.0121702 | 00.0241046 | 00.1545364 | 01.8154789 |
| LinkedList &lt;T&gt; | 00.0103353 | 00.0286509 | 00.0367516 | 00.1409296 | 01.3043825 |
| Deque &lt;T&gt;      | 00.0113243 | 00.0265129 | 00.0325673 | 00.1543366 | 01.0570848 |

Išmatuotas programos naudojama atmintis pagal 2 strategija. Naudojama atmintis pateikiamia lentelėje (baitais);

| Konteineris   | 10       | 100      | 1000     | 10000    | 100000   |
|---------------|----------|----------|----------|----------|----------|
| List &lt;T&gt;       | 16199680 | 16642048 | 19095552 | 22118400 | 52572160 |
| LinkedList &lt;T&gt; | 16093184 | 16576512 | 19116032 | 22523904 | 58454016 |
| Deque &lt;T&gt;      | 16154624 | 16687104 | 19144704 | 22384640 | 53248000 |

Naudojant 2 strategija, pagal sparta greičiausias `Deque`, po jo - `LinkedList`, o lečiausiai veikė `List`.

Palyginus su 1 strategija, yra naudojama mažiau atminties, o sparta yra panaši.

### Naudojimosi instrukcija
Paleisti `duomenu-apdorojimas.exe` ir vadovautis intrukcijomis:
- Jei norite nuskaityti studentus iš failo, iveskit simbolių `f`. Jei norite dirbti su konsole - bet kokį kitą simbolių.

Pasirinkus skaitymą iš failo:
- Įveskite, iš kokio failo skaityti.

Dirbant su konsole:
- Įveskite informaciją apie studentą.
- Įvedus `x` bus pradėdamas skaičiuoti galutinis balas.

### Įdiegimo instrukcija
- Atidaryti `duomenu-apdorojimas.sln` su Visual Studio (patikrinta su Visual Studio 2017 versija)
- Sukurti `.exe` failą paspaudus `F7`

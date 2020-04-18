# Spartos tyrimai vyko su failu, kuris turėjo 100000 studentų.
## ``List<T>``

| Command        | Execution time|
| ------------- |----------------|
| Read student file to the collection   | Elapsed miliseconds: 630ms  |
| Sort collection | Elapsed miliseconds: 1073ms   |
| Output results | Elapsed miliseconds: 30341ms |

## ``LinkedList<T>``

| Command        | Execution time|
| ------------- |----------------|
| Read student file to the collection  | Elapsed miliseconds: 631ms  |
| Sort collection | Elapsed miliseconds: 1079ms   |
| Output results | Elapsed miliseconds: 30406ms |

## ``Queue<T>``

| Command        | Execution time|
| ------------- |----------------|
| Read student file to the collection  | Elapsed miliseconds: 626ms  |
| Sort collection | Elapsed miliseconds: 1084ms   |
| Output results | Elapsed miliseconds: 30440ms |

# v. 1.0
## Spartos tyrimai su 3 skirtingomis strategijomis. 1 ir 2 iš užduoties, 3 mano. Studentų kiekis buvo 100000.

Geriausia strategija iš spartos bei atminties dalies buvo mano. Ji leido naudoti tik viena kontainerį. Nereikėjo atlikinti pašalinimų, pridėjimų į kitus konteinerius. Pats `Student` tipas gali pasakyti ar studentas geras ar blogas mokinys. 
Palyginimų lentelę su visomis trijomis kolekcijomis
Skirtumai tarp antros strategijos ir trečios yra sąlyginai nedideli.
Ši analizė parodė, kad `LinkedList<T>` konteineris geriausiai atlieka skaitymo iš failo ir įrašymo į failą užduotį. Skirtumas tarp `List<T>` ir `Queue<T>` kontainerių su geresne strategija vis mažėja, kol galiausiai su trečia `List<T>` kontaineris veikia sparčiau.

## Pirma strategija
| Collection        | Average Execution time|
| ------------- |----------------|
| `List<T>`   | Elapsed miliseconds: 1814ms |
| `Queue<T>` | Elapsed miliseconds: 1548ms   |
| `LinkedList<T>` | Elapsed miliseconds: 1092ms |

## Antra strategija
| Collection        | Average Execution time|
| ------------- |----------------|
| `List<T>`   | Elapsed miliseconds: 1451ms  |
| `Queue<T>` | Elapsed miliseconds: 1334ms   |
| `LinkedList<T>` | Elapsed miliseconds: 1099ms |

## Trečia strategija
| Collection        | Average Execution time|
| ------------- |----------------|
| `List<T>`   | Elapsed miliseconds: 1319ms  |
| `Queue<T>` | Elapsed miliseconds: 1337ms   |
| `LinkedList<T>` | Elapsed miliseconds: 990ms |

# Programą naudoti labai paprasta, programos meniu viską pats pasakys ko tikimasi iš vartotojo.

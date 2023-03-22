# DogWorkEvaluationSheet
Aplikacja konsolowa
Net7.0

# Opis: 
Program służy do zapisu wyników konkursu psów myśliwskich wraz ze statystykami w postaci tzw. Karty zawodnika.
Karta zawodnika z danymi psa i wynikami zapisywana jest w pliku o nazwie = imieniu psa. Zapisywana jest data.


# Logika programu jest zgodna z regulaminem konkursu i obejmuje następujące zasady:

I. Pracę psów w poszczególnych konkurencjach ocenia się stopniami od „0” do „4”. Każda z konkurencji ma inną wagę.

II. Znalezienie sumy punktów.

III. Przyznanie (albo nieprzyznanie) dyplomu Iº, IIº i IIIº, zależnie od uzyskanej ogólnej liczby punktów, odpowiednio >=90%, >=70%, >=60%.

//
tego jeszcze nie ma
IV. Kolejność lokat ustala się biorąc pod uwagę:
1. Liczbę uzyskanych punktów.
2. Jeżeli liczba punktów jest taka sama decyduje wiek psa (młodszy przed starszym) i ostatecznie płeć (suka przed psem).
3. W przypadku gdyby taką samą ilość punktów uzyskały dwa psy lub dwie suki, którzy są rówieśnikami, należy im przyznać dwie równorzędne, przysługujące im
lokaty, a kolejny pies zajmuje lokatę obniżoną nie o jeden, a dwa miejsca. Np. dwie suki zajęły lokatę trzecią to kolejny pies zajmuje nie czwartą, a piątą lokatę.
Więcej o zawodach: https://www.pzlow.pl/images/Kynologia/Regulaminy/POSTANOWIENIA_OGÓLNE.pdf
//

# Problemy:
Program działa poprawnie dla psów o różnych imionach, jeżeli są psy o tych samych należy nadać im obok imienia licznik, np.: Kajtek_1, inaczej karty obu psów znajdą się w jednym pliku.
Nie ma możliwości odczytu danych, poza wglądem w zawartość pliku.

Pelin tarkoitus:

Pelin tarkoituksena on, että pelaaja kontrolloi ritaria ja taistelee erilaisia hirviöitä vastaan. Pelaajan tehtävänä on saavuttaa mahdollisimman suuri taso ja kerätä palkintoja hirviöiden kukistamisesta. Pelaaja aloittaa pelin tietyn tason ritareilla ja voi päivittää ritariaan kerättyään tarpeeksi palkintoja.

Pelin mekaniikka:

Pelaaja aloittaa pelin valitsemalla uuden pelin.
Pelaaja valitsee ritaria, jonka hän haluaa käyttää. Aluksi pelaajalla on käytössä vain yksi ritari, mutta hän voi päivittää ritariaan myöhemmin pelin edetessä.
Pelialueella on erilaisia hirviöitä, joita pelaajan ritari voi taistella. Jokainen hirviö antaa tietyn määrän pisteitä ja mahdollisuuden ansaita palkintoja.
Pelaajan ritari taistelee hirviöitä vastaan käyttäen erilaisia hyökkäyksiä, kuten miekka-iskuja ja erikoisvoimia. Hirviöt hyökkäävät myös takaisin, joten pelaajan tulee olla valmis puolustamaan itseään.
Pelaaja ansaitsee palkintoja jokaisen kukistetun hirviön jälkeen. Palkinnot voivat olla esimerkiksi rahaa tai taistelukokemusta, joita pelaaja voi käyttää ritariensa päivittämiseen tai uusien ritarien hankkimiseen.
Pelaaja voi päivittää ritariaan keräämillään palkinnoilla. Päivitetyllä ritarilla on paremmat hyökkäys- ja puolustustaidot, jolloin hän pystyy taistelemaan paremmin vahvempia hirviöitä vastaan.
Pelin tavoitteena on saavuttaa mahdollisimman korkea taso ja kerätä mahdollisimman paljon palkintoja.
Pelin tekninen toteutus:

Peli toteutetaan C# konsoli applikaationa. Pelaajan käyttöliittymä koostuu tekstikäyttöliittymästä, jossa pelaaja saa tietoa pelin tilanteesta, hirviöiden tilanteesta ja ritarien tilanteesta. Pelaajan ritarien ja hirviöiden tila pidetään muistissa pelin edetessä. Pelissä käytetään satunnaistettuja arvoja, jotta hirviöiden voima vaihtelee ja peli pysyy haastavana. Pelaaja voi käyttää erilaisia komentoja, kuten hyökkää, puolusta, käytä erikoisvoimaa, päivitä ritaria jne.Pelaaja syöttää komennot käyttäen konsolissa näppäimistöä. Peli käyttää erilaisia luokkia, kuten ritari-luokka, hirviö-luokka ja taistelu-luokka, joita käytetään pelin toimintojen toteuttamiseen. Peli tallentaa pelaajan edistymisen ja ritarien tiedot tekstitiedostoon, jotta pelaaja voi jatkaa peliä myöhemmin.


# CRC-kortit

## Knight
Class: Knight

Responsibilities:
Taistella hirviöitä vastaan
Käyttää erilaisia aseita ja varusteita taistelussa
Kerätä kokemuspisteitä ja palkintoja

Collaborators:
Taistelu-luokka
Varuste-luokka
Pelin tallennusluokka

## Monster
Class: Monster

Responsibilities:
Taistella ritaria vastaan
Käyttää erilaisia hyökkäyksiä ja kykyjä taistelussa
Antaa kokemuspisteitä ja palkintoja, kun ne on voitettu

Collaborators:
Taistelu-luokka

## Taistelu
Class: Taistelu

Responsibilities:
Aloittaa taistelun ritarien ja hirviöiden välillä
Hallitsee vuoropohjaista taistelujärjestelmää
Laskee vahingot ja hoitaa taistelun loppuun

Collaborators:
Knight-luokka
Monster-luokka

## Varuste
Class: Varuste

Responsibilities:
Tarjoaa ritareille erilaisia varusteita
Antaa bonuksia ja kykyjä ritareille
Käyttää resursseja ja vaatii rahaa ostettaessa

Collaborators:
Knight-luokka

## Tallennus
Class: Tallennus

Responsibilities:
Tallentaa pelin tilan tekstitiedostoon
Lataa pelin tilan takaisin, kun pelaaja aloittaa pelin uudelleen
Tarjoaa mahdollisuuden tallentaa ja ladata pelin edistymistä

Collaborators:
Knight-luokka
Varuste-luokka
Monster-luokka
Taistelu-luokka

## Pelaaja
Class: Pelaaja

Responsibilities:
Syöttää komennot pelin etenemiseksi
Kerää kokemuspisteitä ja palkintoja
Käyttää rahaa ja ostaa varusteita ritareille

Collaborators:
Knight-luokka
Varuste-luokka
Tallennus-luokka

## Pelin käynnistys
Class: Pelin käynnistys

Responsibilities:
Aloittaa pelin ja esittelee sen säännöt ja tavoitteet
Lataa tallennetun pelin tilan, jos sellainen on olemassa

Collaborators:
Tallennus-luokka
Pelaaja-luokka
Knight-luokka
Varuste-luokka
Monster-luokka
Taistelu-luokka

## Palkinnot
Class: Palkinnot

Responsibilities:
Tarjoaa erilaisia palkintoja, kuten uusia varusteita ja kokemuspisteitä
Antaa pelaajalle tavoitteen ja palkitsee heitä saavutusten perusteella

Collaborators:
Pelaaja-luokka

## Kauppa
Class: Kauppa

Responsibilities:
Tarjoaa erilaisia varusteita pelaajan ostettavaksi
Hallitsee varusteiden hinnat ja saatavuuden
Tarjoaa pelaajalle mahdollisuuden myydä vanhoja varusteita

Collaborators:
Pelaaja-luokka
Varuste-luokka
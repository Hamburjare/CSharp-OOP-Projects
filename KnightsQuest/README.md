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
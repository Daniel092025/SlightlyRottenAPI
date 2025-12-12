# Tester 

## MovieTests

*Movie_CanBeCreated_WithValidValues*
- Denne tester om man kan legge til en film å lagre data rett.
- Lager en film med alle verdier
- Filmen har korrekte verdier
- Passer på at Movie.cs funker som den skal

*Movie_OptionalPropertiesCanBeNull*
- Tester at verdier kan inneholde null verdi, siden vi har tillat det med "string?"
- Men ikke ID! Den kan ikke være null // Endret i ettertid
- Tester dette da man kan evt. legge til en film uten alle verdier.

*Movie_CanHaveDifferentYears*
- Sjekker om år kan ha forskjellige verdier, og kan hvilken som helst integer.

*Movie_CanHaveDifferentPlaytimes*
- Sjekker at playtimes kan ha forskjellige verdier.


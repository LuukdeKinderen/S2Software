# S2Software
## Doel
Maak een aantal projecten waar je alle leerdoelen van Semester 2 Software in aan kunt tonen. 
### Leerdoelen
1. Je baseert je keuzes op feedback van stakeholders en onderbouwt ze op een heldere en professionele wijze.
2. Je werkt samen en communiceert met anderen op constructieve en professionele.
3. Je documenteert gevalideerde gebruikersspecificaties voor applicaties en vertaalt deze in correcte softwareontwerpen.
4. Je bouwt, ontwerpt en levert herhaaldelijk veilige en onderhoudbare applicaties op (waarvan er tenminste één web-gebaseerd is) die verbinding maken met een database en gebruik maken van OO-principes en standaard technieken gebaseerd op gevalideerde gebruikerseisen.
5. Je redeneert over computationele uitdagingen en implementeert algoritmisch complexe problemen in software.
6. Je ontwerpt, bouwt en bevraagt een relationeel databasesysteem en integreert dit met een applicatie.
7. Je verbetert en toont de kwaliteit van je software continue aan, gebruikmakend van standaard technieken en hulpmiddelen

# individueel project: Skippy
Is een kassasysteem voor een dierenwinkel.
## Analyse
### Requirements
Ingedeeld met MoSCoW. 
**M**ust have
**C**ould have
**S**hould have
**W**ould have
- **M** Het systeem heeft producten.
    - **W** Je kunt binnen het systeem zoeken naar producten.
    - **M** producten kunnen worden toegevoegd aan het systeem.
    - **M** producten kunnen bekeken, gewijzigd en verwijderd worden.
- **S** Het systeem heeft categorieën
    - **S** Categorieën kunnen worden toegevoegd aan het systeem.
    - **S** Categorieën kunnen bekeken, gewijzigd en verwijderd worden.
    - **S** producten kunnen aan een categorie gekoppeld worden.
    - **S** producten kunnen per categorie gesorteerd weergegeven worden.
    - **W** categorieën kunnen hebben subcategorieën
- **M** Het systeem heeft orders (verzameling van producten)
    - **M** Een order kan worden aangemaakt.
    - **M** Aan een order kunnen producten worden toegevoegd/ verwijderd.
    - **M** Een order kan worden afgerond. 
    - **S** Op een order is een totaalprijs van alle producten te zien.
- **W** Het systeem heeft een klantenbestand.
    - **W** Orders kunnen op rekening van een klant worden gezet.
- **C** Het systeem kan een overzicht maken van alle verkochte producten in een periode.
### UI Schetsen
![UI Schetsen](/Diagrams/img/UI_Schetsen.png)
### Use cases
|     | UC01 |
| --- | --- |
| Naam | Product toevoegen aan de Database |
| Samenvatting | Een nieuw product wordt toegevoegd aan de database. |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Products/create. <br> 2. Het systeem toont een pagina met alle input velden die bij een nieuw product horen. <br> 3. De actor vult de gegevens in van het nieuwe product. <br> 4. De actor klikt op 'nieuw product toevoegen' <br> 5. Het systeem controleert de gegevens en voegt het product toe aan de database (1) |
| Uitzonderingen | 1. De gegevens zijn niet correct of van een onjuist type. Ga terug naar stap 2. Het systeem geeft waar nodig per input veld een foutmelding aan. |
| Resultaat | Een product in toegevoegd aan de database |

|     | UC02 |
| --- | --- |
| Naam | Categorie toevoegen aan de Database |
| Samenvatting | Een nieuwe categorie wordt toegevoegd aan de database. |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Categories/create.<br> 2. Het systeem toont een pagina met alle input velden die bij een nieuwe categorie horen.<br> 3. De actor vult de gegevens in van de nieuwe categorie. <br> 4. De actor klikt op 'nieuwe categorie toevoegen'<br> 5. Het systeem controleert de gegevens en voegt de categorie toe aan de database (1) |
| Uitzonderingen | 1. De gegevens zijn niet correct of van een onjuist type. Ga terug naar stap 2. Het systeem geeft waar nodig per input veld een foutmelding aan. |
| Resultaat | Een product in toegevoegd aan de database |

|     | UC03 |
| --- | --- |
| Naam | Product toevoegen aan categorie |
| Samenvatting | Je hebt een categorie en product aangemaakt. Je wilt deze nu verbinden |
| Actors | Manager |
| Aannamen | 1. Het systeem heeft minstens 1 product.<br> 2. Het systeem heeft minstens 1 categorie.  |
| Omschrijving | 1. De actor opent een categorie <br> 2. De actor klikt op ‘Product toevoegen’ <br> 3. Het systeem laat een lijst zien van alle producten. <br> 4. De actor selecteert het product dat hij wil toevoegen. <br> 5. Het systeem voegt het product toe aan de categorie |
| Uitzonderingen | Geen |
| Resultaat | Het product is toegevoegd aan de categorie. |


|     | UC04 |
| --- | --- |
| Naam | Product opzoeken in categorie |
| Samenvatting | Een product moet worden opgezocht zodat er handelingen mee gedaan kunnen worden |
| Actors | Kassa medewerker, manager |
| Aannamen | Het systeem heeft categorieën (evt. met sub categorieën) waar producten in staan |
| Omschrijving | 1. De actor klikt op de categorie waar het gezochte product zich in bevind <br> 2. Het systeem toont een lijst met alle producten in deze categorie (1) <br> 3. De actor selecteert het gezochte product in de lijst. |
| Uitzonderingen | 1. De categorie heeft subcategorieën. Het systeem toont alle sub categorieën. Ga terug naar stap 1 |
| Resultaat | De detail pagina van het geselecteerde product wordt getoond. |

|     | UC05 |
| --- | --- |
| Naam | Product wijzigen in database |
| Samenvatting | Een opgezocht product word gewijzigd in de database. |
| Actors | Manager |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. De detail pagina van het product is geopend. |
| Omschrijving | 1. De actor klikt op 'Product wijzigen' <br> 2. Het systeem toont een pagina met input velden die gewijzigd kunnen worden. <br> 3. De actor veranderd velden waar hij dat wil. <br>  4. De actor klikt op 'wijzigingen opslaan' <br> 5. Het systeem controleert de gegevens en wijzigt de database (1) |
| Uitzonderingen | 1. De gegevens zijn niet correct of van een onjuist type. Ga terug naar stap 2. Het systeem geeft waar nodig per input veld een foutmelding aan. |
| Resultaat | Een product is gewijzigd in de database |

|     | UC06 |
| --- | --- |
| Naam | Product toevoegen aan een order |
| Samenvatting | Een opgezocht product wordt toegevoegd aan een order |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. De detail pagina van het product is geopend. |
| Omschrijving | 1. De actor vult een gewenst getal in bij het 'aantal' input veld <br> 2. De actor klikt op 'Toevoegen' <br> 3. Het systeem geeft een popup en vraag een bevestiging om het product x aantal toe te voegen aan de order (1) (2) <br>  4. De actor klikt op 'Bevestigen' <br>  5. Het systeem berekend de totaalprijs van de order en weergeeft deze |
| Uitzonderingen | 1. Het aantal input veld is geen correct getal. Het systeem geeft een foutmelding en voegt het product niet toe aan de order. Ga terug naar stap 1. <br> 2. Het product is al toegevoegd aan de order. Het systeem geeft een foutmelding en geeft als tip dat je het aantal in de order kan wijzigen |
| Resultaat | Een product met aantal is toegevoegd aan de order. |

|     | UC07 |
| --- | --- |
| Naam | Aantal wijzigen in een order |
| Samenvatting | Je wil het aantal producten wijzigen in de order. |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor wijzigt een waarde in de kolom 'aantal' binnen de order <br> 2. Het systeem berekend de nieuwe totaalprijs van de order en weergeeft deze (1) |
| Uitzonderingen | 1. Het ingevoerde veld is geen getal. Het systeem geeft een foutmelding wijzigt de order niet. Ga terug naar stap 1. |
| Resultaat | Het aantal van een product op de order is gewijzigd |

|     | UC08 |
| --- | --- |
| Naam | Product uit order verwijderen |
| Samenvatting | Je gaat een product verwijderen uit een order |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor klikt op het kruisje naast een product in de order <br> 2. Het systeem verwijderd het product en berekend de nieuwe totaalprijs van de order en weergeeft deze |
| Uitzonderingen | Geen |
| Resultaat | Een product is verwijderd uit de order |

## Ontwerp
### Conceptueel Model
![Conceptueel Model](/Diagrams/img/Conceptueel_Model.png)
### Database Ontwerp
![Database Ontwerp](/Diagrams/img/DatabaseOntwerp.png)

## Voortgang individueel project
Ik heb deze iteratie mezelf vooral beziggehouden met het toevoegen van een logica en DB layer. Hier heb ik met behulp van workshops erg veel voortgang in geboekt. De scheiding tussen deze lagen lukt steeds beter.
Momentele functionaliteit:
- producten toevoegen
- producten bekijken

# Algoritmiek
## Project Euler puzzels
Ik heb tot nu toe de eerste 2 puzzels gemaakt. Ik vond het erg interessant en leerzaam om dit te doen. De antwoorden zijn ingeleverd op canvas en uitgeschreven naar een txt bestand in de project Solutions. 
## Circus trein
Deze opdracht heb ik afgerond. Na het verwerken van de feedback is deze opdracht met succes voltooid. In de toekomst zou ik de scheiding van UI en Logica beter implementeren.
## Container schip
Ik ben begonnen met het maken van een conceptueel model. Op basis van dit model heb ik een class diagram gemaakt. Deze classes heb ik ook al gemaakt code. Daarnaast heb ik al een UI gemaakt, deze is niet heel mooi maar is voldoende voor deze opdracht. De logica is nog niet af en hier moet nog aan gewerkt worden.
### Conceptueel Model
![Containerschip Conceptueel Model](/Algoritmiek/Diagrams/ContainerSchip_ConceptueelModel.png)
### Class Diagram
![Containerschip Class Diagram](/Algoritmiek/Diagrams/ContainerSchip_ClassDiagram.png)

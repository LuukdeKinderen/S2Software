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
    - **W** Je kunt binnnen het systeem zoeken naar producten.
    - **M** prodcuten kunnen worden toegevoegd aan het systeem.
    - **M** prodcuten kunnen bekeken, gewijzigd en verwijderd worden.
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
#### UC01
| naam | 000 |
| Samenvatting | 000 |
| Actors | 000 |
| Aannamen | 000 |
| Omschrijving | 1. test<br> 2. test2 |
| Uitzonderingen | 1. test 2. test2 |
| Resultaat | test |

#### UC02
| naam | 000 |
| Samenvatting | 000 |
| Actors | 000 |
| Aannamen | 000 |
| Omschrijving | 1. test<br> 2. test2 |
| Uitzonderingen | 1. test 2. test2 |
| Resultaat | test |

## Ontwerp
### Conceptueel Model
![Conceptueel Model](/Diagrams/img/Conceptueel_Model.png)
### Database Ontwerp
![Database Ontwerp](/Diagrams/img/DatabaseOntwerp.png)

## Voortgang individueel project
Ik heb deze iteratie mezelf vooral bezig gehouden met het toevoegen van een logica en DB layer. Hier heb ik met behulp van workshops erg veel voortgang in geboekt. De scheiding tussen deze lagen lukt steeds beter.
Momentele functionaliteit:
- producten toevoegen
- producten bekijken

# Algoritmiek
## Project Euler puzzles
Ik heb tot nu toe de eerste 2 puzzles gemaakt. Ik vond het erg interresant en leerzaam om dit te doen. De antwoorden zijn ingeleverd op canvas en uitgescheven naar een txt bestand in de project solutions. 
## Circus trein
Deze opracht heb ik afgerond. Na het verwerken van de feedback is deze opdracht met succes voltooid. In de toekomst zou ik de sheiding van UI en Logica beter inplementeren.
## Container schip
Ik ben begonnne met het maken van een conceptueel model. Op basis van dit model heb ikeen class diagram gemaakt. Deze classes heb ik ook al gemaakt code. Daarnaas heb ik al een UI gemaakt, deze is niet heel mooi maar voldoet aan de eisen. De logica is nog niet af en hier moet nog aan gewerkt worden.
### Conceptueel Model
![ContainerSchip Conceptueel Model](/Algoritmiek/Diagrams/ContainerSchip_ConceptueelModel.png)
### Class Diagram
![ContainerSchip Class Diagram](/Algoritmiek/Diagrams/ContainerSchip_ClassDiagram.png)

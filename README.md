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
**S**hould have
**C**ould have
**W**on't have

 - **FR-01** De Kassamedewerker kan een overzicht van alle producten zien. **M**
     - **B-01.1** Het overzicht is per categorie te sorteren.
     - **K-01.1** Het overzicht is te beperken met een zoekterm.
 - **FR-02** De Manager moet producten kunnen toevoegen/ wijzigen. **M**
     - **B-02.1** Een product heeft een Naam, omschrijving en prijs.
     - **B-02.2** Naam en Prijs zijn verplicht om in te vullen.
 - **FR-03** De Manager moet producten kunnen verwijderen. **S**
 - **FR-04** De Manager moet categorieën kunnen toevoegen/ wijzigen. **S**
     - **B-04.1** Een categorie heeft een Naam.
     - **B-04.2** Naam is verplicht om in te vullen.
 - **FR-05** De Manager moet categorieën kunnen verwijderen. **C**
 - **FR-06** De Manager moet subcategorieën kunnen toevoegen aan Categorieën. **C**
     - **K-06.1** Aan een categorie met een of meerder producten, kan geen sub categorie worden toegevoegd.
     - **K-06.2** Een categorie kan maar een keer als sub categorie toegevoegd worden.
 - **FR-07** De Manager kan producten toevoegen aan een categorie. **S**
     - **K-07.1** Aan een categorie met een of meerdere sub categorieën, kan geen product worden toegevoegd.
     - **K-07.2** Een product kan maar een keer aan een categorie toegevoegd worden.
 - **FR-08** De Kassamedewerker een order opstellen. **M**
     - **B-08.1** Een order heeft producten, een datum, klant nr. en betaalstatus.
     - **B-08.2** Er kunnen meerdere producten op een order staan.
     - **B-08.3** Per product moet er een aantal worden toegevoegd
     - **B-08.4** Bij afronding zijn datum en betaalstatus zijn verplicht.
     - **B-08.5** Bij afronding is klantnummer alleen verplicht als betaalstatus 'niet betaald' is.
 - **FR-09** De Manager moet klanten kunnen toevoegen/ wijzigen. **C**
     - **B-09.1** Een klant heeft een Klantnummer, Naam en factuur adres.
     - **B-09.2** Alle gegevens zijn verplicht om in te vullen.
 - **FR-10** De Manager moet een overzicht kunnen inzien van alle verkochte producten **C**
 - **FR-11** De Manager moet kunnen inloggen en manager rechten krijgen **M**
 - **K-ALG.01** Bij onjuiste invoer moet een duidelijke foutmelding getoond worden.
 - **K-ALG.02** Wanneer de Manager niet ingelogd is zullen opties die alleen voor de manager bedoeld zijn niet zichtbaar zijn.

### UI Schetsen
![UI Schetsen](/Diagrams/img/UI_Schetsen.png)
### Use cases
Algemene uitzondering: Wanneer als actor Manager staat vastgesteld, kan de Use case alleen worden uitgevoergd wanneer als manager ingelogd is. (FR-11)

|     | UC01 |
| --- | --- |
| Naam | Product toevoegen |
| Samenvatting | Een nieuw product wordt toegevoegd aan het systeem |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Products/create. <br> 2. Het systeem toont een pagina met alle input velden die bij een nieuw product horen. (B-02.1) <br> 3. De actor vult de gegevens in voor het nieuwe product en klikt op 'toevoegen' <br> 4. Het systeem controleert de gegevens en voegt het product toe (1,2) |
| Uitzonderingen | 1. Niet alle verplichte velden zijn ingevuld. Toon een melding en ga terug naar stap 2. (B-02.2) <br> 2. Bij prijs wordt geen getal ingevoerd. Toon een melding en ga terug naar stap 2. (K-ALG.01) |
| Resultaat | Een product is toegevoegd aan het systeem |

|     | UC02 |
| --- | --- |
| Naam | Categorie toevoegen |
| Samenvatting | Een nieuwe categorie wordt toegevoegd aan het systeem |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Categories/create. <br> 2. Het systeem toont een pagina met alle input velden die bij een nieuwe categorie horen. (B-04.1) <br> 3. De actor vult de gegevens in voor de nieuwe categorie en klikt op 'toevoegen' <br> 4. Het systeem controleert de gegevens en voegt de categorie toe (1) |
| Uitzonderingen | 1. Niet alle verplichte velden zijn ingevuld. Toon een melding en ga terug naar stap 2. (B-04.2) |
| Resultaat | Een categorie is toegevoegd aan het systeem |

|     | UC03 |
| --- | --- |
| Naam | Subcategorie toevoegen aan categorie |
| Samenvatting | Je hebt twee categorieën en wilt ze verbinden door een parent-child relatie (subcategorie). |
| Actors | Manager |
| Aannamen | 1. Het systeem heeft ten minste 2 categorieën.  |
| Omschrijving | 1. De actor opent de categorie die als parent gaat dienen en klikt op 'Categorie toevoegen' (1) <br> 2. Het systeem laat een lijst van alle categorieën zien. (2) <br> 3. De actor selecteert de categorie die hij wil toevoegen. <br> 4. Het systeem voegt de subcategorie toe aan de categorie |
| Uitzonderingen | 1. de parent categorie bevat een of meerdere producten. 'Categorie toevoegen' Wordt niet getoond. (K-06.1)<br> 2. Categorie is al een subcategorie van de parent. Categorie wordt niet getoond in lijst (K-06.2) |
| Resultaat | De categorie heeft een nieuwe subcategorie. |

|     | UC04 |
| --- | --- |
| Naam | Product toevoegen aan categorie |
| Samenvatting | Je voegt in product toe aan een categorie |
| Actors | Manager |
| Aannamen | 1. Het systeem heeft ten minste 1 product. <br> 2. Het systeem heeft ten minste 1 categorie.  |
| Omschrijving | 1. De actor opent een categorie en klikt op 'Product toevoegen' (1) <br> 2. Het systeem laat een lijst van alle producten zien. (2) <br> 3. De actor selecteert het product dat hij wil toevoegen. <br> 4. Het systeem voegt het product toe aan de categorie |
| Uitzonderingen | 1. De categorie bevat een of meerdere sub categorieën. 'Product toevoegen' Wordt niet getoond. (K-07.1) <br> 2. Product bevindt zich al in de categorie. Product wordt niet getoond in lijst (K-07.2) |
| Resultaat | Het product is toegevoegd aan de categorie. |

|     | UC05 |
| --- | --- |
| Naam | Product opzoeken in categorie |
| Samenvatting | Een product wordt opgezocht door te navigeren naar de juiste categorie en daar het product te selecteren |
| Actors | Kassa medewerker, manager |
| Aannamen | Het systeem heeft categorieën (evt. met sub categorieën) waar producten in staan |
| Omschrijving | 1. De actor klikt op de categorie waar het gezochte product zich in bevind <br> 2. Het systeem toont een lijst met alle producten in deze categorie (1) <br> 3. De actor selecteert het gezochte product in de lijst. |
| Uitzonderingen | 1. De categorie heeft subcategorieën. Het systeem toont alle sub categorieën. Ga terug naar stap 1 |
| Resultaat | De detail pagina van het geselecteerde product wordt getoond. |

|     | UC06 |
| --- | --- |
| Naam | Product gegevens wijzigen |
| Samenvatting | Een opgezocht product word gewijzigd. |
| Actors | Manager |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. De detail pagina van het product is geopend. |
| Omschrijving | 1. De actor klikt op 'Product wijzigen' <br> 2. Het systeem toont een pagina met input velden die gewijzigd kunnen worden. (B-02.1) <br> 3. De actor veranderd velden waar hij dat wil. en klikt op 'opslaan' <br> 4. Het systeem controleert de gegevens en slaat de wijzigingen op (1,2) |
| Uitzonderingen | 1. Niet alle verplichte velden zijn ingevuld. Toon een melding en ga terug naar stap 2. (B-02.2) <br> 2. Bij prijs wordt geen getal ingevoerd. Toon een melding en ga terug naar stap 2. (K-ALG.01) |
| Resultaat | Een product is gewijzigd |

|     | UC07 |
| --- | --- |
| Naam | Product toevoegen aan een order |
| Samenvatting | Een opgezocht product wordt toegevoegd aan een order |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. De detail pagina van het product is geopend. |
| Omschrijving | 1. De actor vult een gewenst getal in bij het 'aantal' input veld en klikt op 'Toevoegen' <br> 2. Het systeem voegt het huidige product x aantal toe aan de order (1,2,3) <br> 3. Het systeem berekend de totaalprijs van de order en laat deze zien |
| Uitzonderingen | 1. Het 'aantal' input veld is geen (correct) getal. Het systeem geeft een foutmelding en voegt het product niet toe aan de order. Ga terug naar stap 1. (K-ALG.01) <br> 2. Het product is al toegevoegd aan de order. Het systeem geeft een foutmelding en laat weten dat je het aantal op de order kunt wijzigen (K-ALG.01) |
| Resultaat | Een product met aantal is toegevoegd aan de order. |

|     | UC08 |
| --- | --- |
| Naam | **Aantal** wijzigen in een order |
| Samenvatting | Je wil het aantal producten wijzigen in de order. |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor wijzigt een waarde in de kolom 'aantal' binnen de order <br> 2. Het systeem berekend de nieuwe totaalprijs van de order en weergeeft deze (1) |
| Uitzonderingen | 1. Het ingevoerde veld is geen getal. Het systeem geeft een foutmelding wijzigt de order niet. Ga terug naar stap 1. (K-ALG.01) |
| Resultaat | Het aantal van een product op de order is gewijzigd |

|     | UC09 |
| --- | --- |
| Naam | Product uit order verwijderen |
| Samenvatting | Je gaat een product verwijderen uit een order |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 product. <br> 2. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor klikt op het kruisje naast een product in de order <br> 2. Het systeem verwijderd het product en berekend de nieuwe totaalprijs van de order en weergeeft deze |
| Uitzonderingen | Geen |
| Resultaat | Een product is verwijderd uit de order |

|     | UC10 |
| --- | --- |
| Naam | Klant toevoegen |
| Samenvatting | Je gaat nieuwe klant toevoegen aan het systeem |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Customers/create. <br> 2. Het systeem toont een pagina met alle input velden die bij een nieuwe klant horen. (B-09.1 ) <br> 3. De actor vult de gegevens in voor de nieuwe klant en klikt op 'toevoegen' <br> 4. Het systeem controleert de gegevens en voegt de klant toe (1) |
| Uitzonderingen | 1. Niet alle verplichte velden zijn ingevuld. Toon een melding en ga terug naar stap 2. (B-09.2) |
| Resultaat | Een klant is toegevoegd aan het systeem |

|     | UC11 |
| --- | --- |
| Naam | Klant wijzigen |
| Samenvatting | Je gaat bestaande klant wijzigen |
| Actors | Manager |
| Aannamen | Geen |
| Omschrijving | 1. De actor navigeert naar /Customers en selecteert de klant die hij wil wijzigen. <br> 2. Het systeem toont een pagina met alle input velden die bij de klant horen. <br> 3. De actor wijzigt de gegevens en klik op 'wijzigen' <br> 4. Het systeem controleert de gegevens en wijzigt de klant (1) |
| Uitzonderingen | 1. Niet alle verplichte velden zijn ingevuld. Toon een melding en ga terug naar stap 2. (B-09.2) |
| Resultaat | Een klant is gewijzigd in het systeem |


|     | UC12 |
| --- | --- |
| Naam | Klant nummer toevoegen aan Order |
| Samenvatting | Je gaat een order zo opstellen dat hij voor een specifieke klant is |
| Actors | Kassa medewerker |
| Aannamen | 1. Het systeem heeft minstens 1 klant. <br> 2. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor klikt op klantnummer. <br> 2. Het systeem opent een lijst van alle klanten in het systeem <br> 3. De actor klikt op de juiste klant die hij wil toevoegen. <br> 4. Het systeem voegt het klantnummer toe aan de order |
| Uitzonderingen | Geen |
| Resultaat | Er is een klantnummer toegevoegd aan de order |


|     | UC13 |
| --- | --- |
| Naam | Order afronden |
| Samenvatting | Een order is compleet je gaat deze afronden |
| Actors | Kassa medewerker |
| Aannamen | 1. In de huidige order zit minimaal 1 product |
| Omschrijving | 1. De actor klikt 'afronden' in de order. <br> 2. Het systeem vraag welke betaalstatus de order heeft. (1) <br> 3. De actor maakt een keuze tussen 'betaald' of 'niet betaald'. <br> 4. Het systeem past de betaalstatus aan. <br> 5. Het systeem archiveert de order. |
| Uitzonderingen | 1. Er is geen klantnummer toegevoegd. De betaalstatus wordt 'betaald' Ga door naar stap 5.  |
| Resultaat | De order is afgerond en gearchiveerd. |

|     | UC14 |
| --- | --- |
| Naam | Inloggen |
| Samenvatting | Om manager rechten te krijgen moet de gebruiker inloggen |
| Actors | Manager |
| Aannamen | 1. De manager weet het wachtwoord |
| Omschrijving | 1. De actor navigeert naar het loginschrem, vult de gegevens in en klikt op inloggen. <br> 2. Het syteem controleert de gegevens en geeft bericht dat je manager rechten hebt. (1) |
| Uitzonderingen | 1. De inloggegevens zijn niet juist ingevoerd. Geef een melding en ga terug naar stap 1. (K-ALG.01)  |
| Resultaat | De manager is ingelogd en kan nu manager opdrachten gaan uitvoeren. |

### Use case diagram
![Use case diagram](/Diagrams/img/UseCaseDiagram.png)

### Test Cases
| Test case | Use case(s) | Invoer | Verwacht uitvoer |
| --- | --- | --- | --- |
| TC01 | UC01 | **naam**: "legkorrel" <br> **omschrijving**: "stevige korrel" <br> **Prijs**: 10,20 <br> **Gebruiker**: Manager | Product toegevoegd door manager |
| TC02 | UC01 | **naam**: "legkorrel" <br> **omschrijving**: "stevige korrel" <br> **Prijs**: 10,20 <br> **Gebruiker**: Kassamedewerker | Product toevoegen geweigerd als kassamedewerker |
| TC03 | UC01 | **naam**: "" <br> **omschrijving**: "stevige korrel" <br> **Prijs**: 10,20 <br> **Gebruiker**: Manager | Product toevoegen geweigerd. foutmelding: niet alle verplichte velden zijn ingevuld |
| TC04 | UC01 | **naam**: "legkorrel" <br> **omschrijving**: "" <br> **Prijs**: "tien euro en twintig cent" <br> **Gebruiker**: Manager | Product toevoegen geweigerd. foutmelding: vul een getal in bij prijs |
| TC05 | UC02 | **naam**: "kip" <br> **Gebruiker**: Manager | Categorie toegevoegd door manager |
| TC06 | UC02 | **naam**: "kip" <br> **Gebruiker**: Kassamedewerker | Categorie toevoegen geweigerd als kassamedewerker |
| TC07 | UC02 | **naam**: "" <br> **Gebruiker**: Manager | Categorie toevoegen geweigerd. foutmelding: niet alle verplichte velden zijn ingevuld |
| TC08 | UC03 | **parent categorie**: "kip (bevat 0 producten)"<br> **child categorie**: "kippenvoer" <br> **Gebruiker**: Manager | Subcategorie toegevoegd door manager |
| TC09 | UC03 | **parent categorie**: "kip (bevat 0 producten)"<br> **child categorie**: "kippenvoer" <br> **Gebruiker**: kassamedewerker | Subcategorie toevoegen geweigerd als kassamedewerker |
| TC10 | UC03 | **parent categorie**: "kip (bevat 2 producten)"<br> **Gebruiker**: Manager | Kan geen subcategorie selecteren |
| TC11 | UC03 | **parent categorie**: "kip (bevat kippenvoer als subcategorie)" <br> **child categorie**: "kippenvoer" <br> **Gebruiker**: Manager | Kan kippenvoer niet selecteren |
| TC12 | UC04 | **Categorie**: "kip (bevat 0 subcategorieën en 0 producten)" <br> **Product**: "legkorrel" <br> **Gebruiker**: Manager | Product toegevoegd aan categorie |
| TC13 | UC04 | **Categorie**: "kip (bevat 0 subcategorieën en 0 producten)" <br> **Product**: "legkorrel" <br> **Gebruiker**: kassamedewerker |  Product toevoegen aan categorie geweigerd als kassamedewerker |
| TC14 | UC04 | **Categorie**: "kip (bevat 1 subcategorie)" <br> **Gebruiker**: Manager | Kan geen product selecteren |
| TC15 | UC04 | **Categorie**: "kip (bevat legkorrel als product)" <br> **Product**: "legkorrel" <br> **Gebruiker**: Manager | Kan legkorrel niet selecteren |
| TC16 | UC05 | **Categorie**: "kip (bevat legkorrel als product)" <br> **Product**: "legkorrel" <br> **Gebruiker**: Manager | Product detailpagina wordt getoond |
| TC17 | UC05 | **Categorie**: "kip (bevat legkorrel als product)" <br> **Product**: "legkorrel" <br> **Gebruiker**: Kassamedewerker | Product detailpagina wordt getoond |
| TC18 | UC05 | **Categorie**: "kip (bevat subcategorie kippenvoer)" <br> **Subcategorie**: "kippenvoer (bevat product legkorrel)"<br> **Product**: "legkorrel" <br> **Gebruiker**: Kassamedewerker | Product detailpagina wordt getoond |
| TC19 | UC06 | **Product**: "naam: "legkorrel" omschrijving: "stevige korrel" Prijs: 10,20" <br> **Wijziging**: "omschrijving: "extra stevige korrel" " <br> **Gebruiker**: Manager | Product gewijzigd door manager |
| TC20 | UC06 | **Product**: "naam: "legkorrel" omschrijving: "stevige korrel" Prijs: 10,20" <br> **Wijziging**: "omschrijving: "extra stevige korrel" " <br> **Gebruiker**: kassamedewerker | Product weizigen geweigerd als kassamedewerker |
| TC21 | UC06 | **Product**: "naam: "legkorrel" omschrijving: "stevige korrel" Prijs: 10,20" <br> **Wijziging**: "naam: "" " <br> **Gebruiker**: Manager | Product weizigen geweigerd. foutmelding: niet alle verplichte velden zijn ingevuld |
| TC22 | UC06 | **Product**: "naam: "legkorrel" omschrijving: "stevige korrel" Prijs: 10,20" <br> **Wijziging**: "Prijs: "tien euro en twintig cent" " <br> **Gebruiker**: Manager | Product weizigen eweigerd. foutmelding: vul een getal in bij prijs |
| TC23 | UC07 | **Aantal**: 1 <br> **Gebruiker**: Kassamedewerker | Geopend product toegevoegd aan order |
| TC24 | UC07 | **Aantal**: "een" <br> **Gebruiker**: Kassamedewerker | Product toevoegen geweigerd. foutmelding: vul een getal in bij Aantal |
| TC25 | UC07 | **Aantal**: "" <br> **Gebruiker**: Kassamedewerker | Product toevoegen geweigerd. foutmelding: vul een getal in bij Aantal |
| TC26 | UC07 | **Order**: "bevat huidig product al" <br> **Aantal**: 1 <br> **Gebruiker**: Kassamedewerker | Product toevoegen geweigerd. foutmelding: Product bestaat al in order, weizig Aantal binnen order |
| TC27 | UC08 | **Aantal**: 2 <br> **Gebruiker**: Kassamedewerker | Order gewijzigd |
| TC28 | UC08 | **Aantal**: "twee" <br> **Gebruiker**: Kassamedewerker | Order wijzigen geweigerd. foutmelding: vul een getal in bij Aantal |
| TC29 | UC08 | **Aantal**: "" <br> **Gebruiker**: Kassamedewerker | Order wijzigen geweigerd. foutmelding: vul een getal in bij Aantal |
| TC30 | UC09 | **Gebruiker**: Kassamedewerker | Order gewijzigd |
| TC31 | UC10 | **Klantnummer**: 12345 <br> **naam**: "Barrie Butsers" <br> **Factuur adres**: "Rachelsmolen 1, 5612 MA Eindhoven" <br> **Gebruiker**: Manager | Klant aangemaakt |
| TC32 | UC10 | **Klantnummer**: 12345 <br> **naam**: "Barrie Butsers" <br> **Factuur adres**: "Rachelsmolen 1, 5612 MA Eindhoven" <br> **Gebruiker**: Kassamedewerker | Klant aanmaken geweigerd als kassamedewerker |
| TC33 | UC10 | **Klantnummer**: 12345 <br> **naam**: "" <br> **Factuur adres**: "Rachelsmolen 1, 5612 MA Eindhoven" <br> **Gebruiker**: Manager | Klant aanmaken geweigerd. foutmelding: niet alle verplichte velden zijn ingevuld. |
| TC34 | UC11 | **Klant**: "Klantnummer: 12345 naam: "Barrie Butsers" Factuur adres: "Rachelsmolen 1, 5612 MA Eindhoven" " <br> **Wijziging**: "naam: "Richard Batsbak" "  <br> **Gebruiker**: Manager | Klant gewijzigd |
| TC35 | UC11 | **Klant**: "Klantnummer: 12345 naam: "Barrie Butsers" Factuur adres: "Rachelsmolen 1, 5612 MA Eindhoven" " <br> **Wijziging**: "naam: "Richard Batsbak" "  <br> **Gebruiker**: Kassamedewerker | Klant weizigen geweigerd als kassamedewerker |
| TC36 | UC11 | **Klant**: "Klantnummer: 12345 naam: "Barrie Butsers" Factuur adres: "Rachelsmolen 1, 5612 MA Eindhoven" " <br> **Wijziging**: "naam: "" "  <br> **Gebruiker**: Manager | Klant weizigen geweigerd. foutmelding: niet alle verplichte velden zijn ingevuld |
| TC37 | UC12 | **Gebruiker**: Kassamedewerker | Klantnummer toegevoegd |
| TC38 | UC13 | **Klantnummer**: ""<br> **Gebruiker**: Kassamedewerker | Order afgerond, status: betaald |
| TC39 | UC13 | **Klantnummer**: "12345" <br> **betaalstatus**: "betaald" <br> **Gebruiker**: Kassamedewerker | Order afgerond, status: betaald |
| TC40 | UC13 | **Klantnummer**: "12345" <br> **betaalstatus**: "niet betaald" <br> **Gebruiker**: Kassamedewerker | Order afgerond, status: niet betaald |
| TC41 | UC14 | **Login**: "correcte gegevens" | Gebruiker krijg manager status |
| TC42 | UC14 | **Login**: "niet correcte gegevens" | Gebruiker krijg geen manager status |

### Test Matrix
|     | F R 0 1 | B 0 1 . 1 | K 0 1 . 1 | F R 0 2 | B 0 2 . 1 | B 0 2 . 2 | F R 0 3 | F R 0 4 | B 0 4 . 1 | B 0 4 . 2 | F R 0 5 | F R 0 6 | K 0 6 . 1 | K 0 6 . 2 | F R 0 7 | K 0 7 . 1 | K 0 7 . 2 | F R 0 8 | B 0 8 . 1 | B 0 8 . 2 | B 0 8 . 3 | B 0 8 . 4 | B 0 8 . 5 | F R 0 9 | B 0 9 . 1 | B 0 9 . 2  | F R 1 0 | F R 1 1 | K A L G . 0 1 | K A L G . 0 2 | 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| TC01 |     |     |     |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC02 |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |
| TC03 |     |     |     |  x  |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC04 |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC05 |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC06 |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |
| TC07 |     |     |     |     |     |     |     |  x  |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC08 |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC09 |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |
| TC10 |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC11 |     |     |     |     |     |     |     |     |     |     |     |  x  |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC12 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC13 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |
| TC14 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC15 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC16 |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC17 |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC18 |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC19 |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |
| TC20 |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |
| TC21 |     |     |     |  x  |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC22 |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC23 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |  x  |     |     |     |     |     |     |     |     |     |
| TC24 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC25 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC26 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |  x  |     |     |     |     |     |     |     |  x  |     |
| TC27 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |  x  |  x  |     |     |     |     |     |     |     |     |     |
| TC28 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC29 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |  x  |     |
| TC30 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |     |     |     |     |     |     |     |
| TC31 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |
| TC32 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |  x  |
| TC33 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |  x  |     |     |  x  |     |
| TC34 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |
| TC35 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |     |     |     |  x  |
| TC36 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |  x  |     |     |  x  |     |
| TC37 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |     |     |     |     |     |     |     |     |     |
| TC38 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |  x  |     |     |     |     |     |     |     |     |
| TC39 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |  x  |     |     |     |     |     |     |     |     |
| TC40 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |     |  x  |  x  |     |     |     |     |     |     |     |
| TC41 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |     |     |
| TC42 |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |     |  x  |  x  |     |

## Ontwerp
### Conceptueel Model
![Conceptueel Model](/Diagrams/img/Conceptueel_Model.png)
### Database Ontwerp
![Database Ontwerp](/Diagrams/img/DatabaseOntwerp.png)

# Algoritmiek
## Project Euler puzzels
Ik heb tot nu toe de eerste 2 puzzels gemaakt. Ik vond het erg interessant en leerzaam om dit te doen. De antwoorden zijn ingeleverd op canvas en uitgeschreven naar een txt bestand in de project Solutions. 
## Circus trein
Deze opdracht heb ik afgerond. Na het verwerken van de feedback is deze opdracht met succes voltooid. In de toekomst zou ik de scheiding van UI en Logica beter implementeren.
## Container schip
### Conceptueel Model
![Containerschip Conceptueel Model](/Algoritmiek/Diagrams/Container_Schip_ConceptueelModel.png)
### Class Diagram
![Containerschip Class Diagram](/Algoritmiek/Diagrams/Container_Schip_ClassDiagram.png)



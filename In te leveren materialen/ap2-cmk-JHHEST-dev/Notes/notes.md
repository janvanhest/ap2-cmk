# Maandag 11 maart Feedback Ema
Tijdens de les van Ema feedback gekregen op mijn voorlopig conceptueel model: 
- Gebruik de juiste vormen (geen cirkels maar teken vierkanten voor je concepten).
- Wat gaat je algoritme doen. Denk na over de stappen die je algoritme gaat doorlopen. maak gebruik van een flowchart. Denk na over de stappen bij bijvoorbeeld. 
  - Implementeer een stukje gedrag in je app. Wanneer een gebruiker 5 dagen actief is geef een melding in de app. (learning streak.)
- Wat als je wilt uitbreiden naar andere badges, talen, of activiteiten etc
  - Maak verschillende soorten badges/diploma's en zorg ervoor dat er makkelijk een nieuwe type badge toegevoegd kan worden(door een class uit te breiden). 
- Zorg ervoor dat je  de S.O.L.I.D. principes toepast bij bovenstaande voorbeelden. 
- Hoe maak je de Dashboards interactief en hoe verwerk je ze in je algoritme? 
  - Maak bijv leaderboard. Kijk waar je de algortime kan uitbreiden of meer complexiteit kan toevoegen, verwerk dit in een flowchart. 


Maandag 11 maart les Marco. 
- Domain 

RideDTO. 
Wat veranderd de state van jouw object -> methodes. 


Visitor class. 

Werken met exceptions zit niet in de leeruitkomsten!!!

Statisch gebruik je wanneer je geen state wilt toepassen. Handig bij helper klasses, maar funest voor encapsulatie. 

Static en internal. Twee verschillende termen. 


# Les  13 mei.
Single Responsibility Principle
- A class should have only one reason to change.
Elke laag heeft een eigen verantwoordelijkheid. (ui houd zich alleen bezig met ui en niet de business logic)

Moet ik in een klasse zoals het berekenen van een leeftijd. 

Helper classes zijn niet per definitie slecht.
het gaat er om dat je je code in kleinere modules kan opdelen. 

bijv. bankrekening demo. 
Alle code in 1 klasse is niet per definitie slecht.
Je kan het dan nog steeds in kleinere modules opdelen.
Denk aan de debitRule. 

Singe Responsibility Principle
- Check voor grote en complexe classes. 
- Vraag jezelf af of de members van de class wel bij elkaar horen of dat ze misschien wel in een aparte classen horen. 
- Als je een class hebt die meerdere verantwoordelijkheden heeft, dan is het misschien tijd om de class op te splitsen.
- Domein classes moeten geisoleerd zijn van cross-cutting concerns. Code veranwoordelijkheid voor opslag, input-validatie, logging, etc. moeten niet in de domein classes zitten. Input validatie hoor in ui thuis. 

Code smells
- https://refactoring.guru/smells/large-class
- https://refacrtoring.guru/smells/long-method
- https://refacrtoring.guru/smells/long-parameter-list


Open/Closed Principle
- open for extension (interfaces, base classes/ overerving) 
- Ik accepteer iets van een abstractie. 
  
- interface segragation.

IDebitValidator. 

## Code smells

what is encapsulation. 


Zoek meer informatie over factory method pattern. 

Closed for modification -> geef mij iets abstract mee. 

Tight coupling. 
looscoupling. 


Depending on an abstraction (dependency inversion)


Drie belangrijkste solid is sod. 
Dependency inversion

Is het duidelijk wat er verwacht wordt bij het functioneel ontwerp. 
Ik mis het uitwerken van functionaliteiten. 
Dan denk ik, hoe moet ik dit gaan implementeren? 
Hoe kom ik tot test cases? 
Use Case descriptions en algoritme hebben een stricte relatie met elkaar en zou ik graag terug zien in een functioneel ontwerp. 

Je mag in een functioneel beschrijven wat je wil. 

Dit zijn mijn belangrijkste usecases. 

Focus ook op de onderhoudbaarheid en de uitbreidbaarheid van je code.
HOe vertaalt dat naar je technisch ontwerp. 

Functioneel ontwerp aftikken en doorzetten. 

Lesweek 12. 
6 weken. 
Technisch Ontwerp.
Inleiding tot het technisch ontwerp
Dit document schetst het technische ontwerp voor de LingoPartner-applicatie, die in meerdere lagen is gestructureerd om modulariteit, onderhoudbaarheid en schaalbaarheid te garanderen. Het ontwerp omvat domeinmodellen, databaseschema’s en verschillende algoritmen om gebruikersinteracties en leervoortgangen af te handelen.

Domain Layer UML Diagram
Het Domain Layer UML-diagram toont de kernentiteiten en hun relaties binnen de LingoPartner-applicatie. De belangrijkste klassen zijn User, LearningModule, LearningActivity, Progress, en Reward. Enumeraties definiëren vaste sets constanten zoals gebruikersrollen, leeractiviteittypes, en voortgangsstatussen. Deze laag bevat de bedrijfslogica en regels.

Het model heeft verschillende revisies ondergaan, alsmede het pakketdiagram. In het onderdeel aannames en overwegingen zal ik daar dieper op in gaan.

<![if !vml]>![Tekstvak: Figuur 2Uml klassendiagram](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image001.png)<![endif]><![if !vml]>

![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image003.png)

<![endif]><![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image005.png)<![endif]>

Databaseschema diagram
Het databaseschemadiagram biedt een gedetailleerd overzicht van de databasestructuur, inclusief tabellen, kolommen en relaties. Dit schema waarborgt gegevensintegriteit en ondersteunt efficiënt gegevensbeheer. Ik heb het als geheugen steun gebruikt om de database op te kunnen zetten. <![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image007.png)<![endif]>.

Pakketdiagram
Het pakketdiagram toont de organisatie van de codebase in verschillende pakketten, elk verantwoordelijk voor specifieke functionaliteit:

LingoPartnerConsole
Doel:

Bevat het toegangspunt van de applicatie en verwerkt de consolegebaseerde gebruikersinterface.

Bevat o.a.:

<![if !supportLists]>· <![endif]>Hoofdingang: Programma

<![if !supportLists]>· <![endif]>Weergaven: ConsoleDashboardView, UserList, UserAdd, LearningActivityList, LearningActivityAdd, LearningModuleList, LearningModuleAdd en andere welke de usecases ondersteunen.

<![if !supportLists]>· <![endif]>Menu: Menu, MenuHelper

<![if !supportLists]>· <![endif]>Helpers: ConsoleHelper, AuthenticatieHelper, LoggingHelper

Afhankelijk van:

<![if !supportLists]>· <![endif]>LingoPartnerDomain

<![if !supportLists]>· <![endif]>LingoPartnerInfrastructure

<![if !supportLists]>· <![endif]>LingoPartnerShared.

Toelichting:

In het LingoPartnerConsole-project wordt de consolegebaseerde gebruikersinterface geïmplementeerd. Het project bevat verschillende weergaven die de gebruiker in staat stellen om de applicatie te gebruiken. De weergaven zijn verantwoordelijk voor het weergeven van informatie en het verwerken van invoer van de gebruiker. Het project bevat ook een menuklasse die de navigatie tussen de verschillende weergaven regelt. De menuklasse maakt gebruik van een menuhelperklasse om de navigatie te vergemakkelijken. Het project bevat ook verschillende hulpprogramma’s die worden gebruikt om de gebruikersinterface te ondersteunen, zoals een hulpprogramma voor authenticatie en een hulpprogramma voor logging.

LingoPartnerDomain
Doel:

Bevat kernbedrijfslogica, domeinmodellen en interfaces.

Bevat o.a.:

<![if !supportLists]>· <![endif]>Domeinmodellen: FriendRequest, LearningModule, LearningActivity, User, Progress, Reward, LearningStreak.

<![if !supportLists]>· <![endif]>Interfaces: ILearningModuleRepository, ILearningActivityRepository, IUserRepository, IProgressRepository, ILearningStreakService, ILearningModuleService, IAuthenticationService.

<![if !supportLists]>· <![endif]>Diensten: LearningStreakService, LearningModuleService, AuthenticatieService.

<![if !supportLists]>· <![endif]>Strategieën: SimpleScoringStrategie, BonusScoringStrategie, Opeenvolgende DagenStrategie, WeekendSkipStrategie.

<![if !supportLists]>· <![endif]>Enums: UserRole, RewardType, ProgressType, ProgressStatus, LearningActivityType, FriendRequestStatus.

Afhankelijk van:

<![if !supportLists]>· <![endif]>LingoPartnerShared.

Toelichting:

In het LingoPartnerDomain-project wordt de kernbedrijfslogica van de applicatie geïmplementeerd. Het project bevat domeinmodellen die de entiteiten van de applicatie vertegenwoordigen, zoals gebruikers, leermodules, leeractiviteiten en voortgang. Het project bevat ook interfaces die worden gebruikt om de toegang tot gegevens en services te definiëren. Daarnaast bevat het project diensten die de bedrijfslogica implementeren en strategieën die worden gebruikt om de scoring en streaks te berekenen. Het project bevat ook enumeraties die worden gebruikt om verschillende statussen en typen te definiëren.

LingoPartnerInfrastructuur
Doel:

Verzorgt de toegang tot en opslag van gegevens en implementeert opslagplaatsen en services.

Bevat:

<![if !supportLists]>· <![endif]>Opslagplaatsen: ProgressRepository, LearningActivityRepository, UserRepository, LearningModuleRepository.

<![if !supportLists]>· <![endif]>Helpers: InfraStructureHelper.

Afhankelijk van:

<![if !supportLists]>· <![endif]>LingoPartnerDomain

<![if !supportLists]>· <![endif]>LingoPartnerShared.

Toelichting:

In het LingoPartnerInfrastructure-project wordt de toegang tot en opslag van gegevens geïmplementeerd. Het project bevat opslagplaatsen die worden gebruikt om gegevens op te halen en op te slaan. Het project bevat ook hulpprogramma’s die worden gebruikt om de toegang tot gegevens te vergemakkelijken.

LingoPartnerShared
Doel:

Omvat gedeelde hulpprogramma’s, helpers en gemeenschappelijke klassen die in projecten worden gebruikt.

Bevat:

<![if !supportLists]>· <![endif]>algemene utility classes, uitbreidingsmethoden, gedeelde bronnen.

Afhankelijk van:

Geen.

Toelichting:

In het LingoPartnerShared-project worden hulpprogramma’s, helpers en gemeenschappelijke klassen geïmplementeerd die in verschillende projecten worden gebruikt. Het project bevat algemene hulpprogramma’s die worden gebruikt om de ontwikkeling van de applicatie te vergemakkelijken. Vooralsnog heeft dit project alleen een LoggingHelper en een Resultclass. De resultclass is niet gebruikt in de huidige implementatie, maar kan in de toekomst worden gebruikt om resultaten van bewerkingen terug te geven. De logginghelper wordt gebruikt om logboeken te schrijven naar de console en naar een logbestand.

LingoPartnerTests
Doel:

Gebruikt voor unit-tests, integratietests en andere geautomatiseerde tests.

Bevat:

<![if !supportLists]>· <![endif]>Testklassen zoals AdministrationTests.

Afhankelijk van:

<![if !supportLists]>· <![endif]>Alle andere projecten voor testdoeleinden.

Toelichting:

In het LingoPartnerTests-project worden verschillende soorten tests geïmplementeerd, zoals unit-tests en integratietests. De testklassen worden gebruikt om de functionaliteit van de applicatie te testen en ervoor te zorgen dat de applicatie correct werkt. De testklassen zijn afhankelijk van de andere projecten in de oplossing en maken gebruik van de interfaces en klassen die in die projecten zijn geïmplementeerd.

Toelichting op PackageDiagram schema.
Hetgeen hierboven beschreven is, wordt weergegeven in het onderstaande packagediagram. Het diagram toont de structuur van de codebase en de relaties tussen de verschillende projecten. De pijlen geven de afhankelijkheden tussen de pakketten aan. Je ziet dat het Console project afhankelijk is van het Domain, Infrastructure en Shared project. Het Domain project is afhankelijk van het Shared project en het Infrastructure project. Het Infrastructure project is afhankelijk van het Domain en Shared project. Het Shared project is niet afhankelijk van andere projecten. Het Tests project is afhankelijk van alle andere projecten voor testdoeleinden.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image009.png)<![endif]>

Figuur 3 Package Diagram

Algoritme
Het “LearningStreak” Algoritme.
In de volgende paragraaf wordt de interne werking van het algoritme uitgelegd. Ik heb een specifieke service voor dit algoritme gemaakt, genaamd ‘LearningStreakService’. Ik dacht dat het een goed idee zou zijn om een specifieke klasse te hebben die verantwoordelijk is voor het LearningStreak-algoritme.

Het algoritme heeft een paar ingrediënten nodig om goed te kunnen werken: het moet de gebruiker kennen, het moet weten wanneer (niet noodzakelijkerwijs precies wat) een gebruiker interactie had of activiteiten deed met de app. Wanneer een gebruiker iets doet, wordt dit in de database bijgehouden in de “progress” tabel. Om het simpel te houden, zijn we alleen geïnteresseerd in de datum van de interactie en maken we indien nodig een lijst met unieke data.

Terwijl we gebruik maken van de serviceprovider, kunnen we de ProgressRepository en de UserAuthenticationService injecteren om de benodigde gegevens te verkrijgen. Ik vind dit soort abstracties wel leuk. Voor het gebruiksgemak heb ik dit als toelichting in het diagram vermeld.

LearningStreakService
Ik wil graag één plek hebben die verantwoordelijk is voor “leerresultaten”. Dit is de reden waarom ik de LearningStreakService heb gemaakt. Deze dienst is verantwoordelijk voor het berekenen van de “LearningStreaks” en het scoren ervan.

We kunnen de “progressRepository” en “userAuthenticationService” in de constructor van de “LearningStreakService” injecteren en we hoeven ons geen zorgen te maken over hun exacte implementatiedetails; de interne werking wordt beschreven in interfaces.

Ik heb alles samengebracht in een activiteitendiagram. Dit diagram toont de stappen die de “LearningStreakService” neemt om de leerreeksen te berekenen en te scoren. Het is een leuke manier om het algoritme te visualiseren en te zien hoe de verschillende onderdelen samenwerken.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image011.png)<![endif]>

Figuur 4 LearningStreakService activiteiten diagram

LearningStreak
Als we het hebben over een “LearningStreakService” die meerdere leerreeksen afhandelt, hebben we een klasse nodig die verantwoordelijk is voor één enkele leerreeks. Dit is de reden waarom ik de “LearningStreak” klasse heb gemaakt.

Deze klasse is verantwoordelijk voor het bijhouden van de leerreeks van een gebruiker. Het heeft een paar eigenschappen, zoals de gebruiker, de startdatum en de einddatum van de streak. Het heeft ook een score-eigenschap, die wordt berekend door de scorestrategie. Het is niet zo spannend, maar het is een leuke manier om alle informatie over een leerreeks op één plek te bewaren. Het is ook een leuke manier om het algoritme schoon en gemakkelijk te begrijpen te houden. Op deze manier is er een klasse die verantwoordelijk is voor één enkele leerreeks, en die complexiteit wordt niet vermengd met de leerreeksservice.

Ik heb de “scoringStrategy” geïmplementeerd in de “LearningStreak-klasse”. Hoewel ik het niet actief gebruik, is het er voor toekomstig gebruik. Op dit moment gebeurt de scoring in de “LearningStreakService”, dus alles staat op één plek.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image013.png)<![endif]>LearningStreak Activity Diagram
Het activiteitendiagram van de “LearningStreak” klasse toont de stappen die de “LearningStreak” klasse neemt om te initialiseren, de lengte te berekenen, de begin- en einddatum in te stellen en, indien nodig, de score te berekenen.

<![if !vml]>![Tekstvak: Figuur 5 LearningStreak Class Activity Diagram](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image014.png)<![endif]>

AddActivityDate Method Activity Diagram
Just needed to add a date to the list, makes sure it is unique, and updates the date range.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image016.png)<![endif]>

Figuur 6 AddActivityDate Method ActivityDiagram

UpdateDateRange Method Activity Diagram
Sets the start and end date of the streak based on the activity dates.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image018.png)<![endif]>

Figuur 7 UpdateDateRange Method ActivityDiagram

MeetCriteria Method Activity Diagram
Een methode die specifiek controleert of een “learningStreak” aan specifieke voorwaarden voldoet. In dit geval moet de learningstreak uit ten minste 2 dagen bestaan

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image020.png)<![endif]>

Figuur 8 MeetCriteria Method Activity Diagram

hoe zat het ook alweer met de strategieën? Ik zal ze in de volgende paragraaf uitleggen.

Strategy patterns.
Het learning streak-algoritme is gebaseerd op een aantal strategieën. Deze strategieën zijn verantwoordelijk voor het verzamelen van “LearningStreaks” en er zijn die verantwoordelijk zijn voor het scoren van de “LearningStreaks”.

LearningStrategieën
Ik heb twee strategieën ontwikkeld, de ConsecutiveDaysStrategy en de WeekendSkipStrategy. De ConsecutiveDaysStrategy is verantwoordelijk voor het berekenen van de leerreeksen op basis van opeenvolgende dagen. De WeekendSkipStrategy is verantwoordelijk voor het berekenen van de leerreeksen op basis van het overslaan van de weekenden.

ConsecutiveDaysStrategy
Berekent leerreeksen op basis van opeenvolgende dagen van activiteit.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image022.png)<![endif]>

Figuur 9 Calculate Learning Streaks with WeekendSkipStrategy

WeekendSkipStrategy
Maakt het mogelijk om weekenden over te slaan zonder de leerreeks te onderbreken.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image024.png)<![endif]>

Figuur 10 Calculate learning Streaks With WeekendSkipStrategy

Scorestrategieën
Er zijn twee scorestrategieën, de SimpleScoringStrategy en de BonusScoringStrategy. De SimpleScoringStrategy is verantwoordelijk voor het scoren van de leerreeksen op basis van de lengte van de reeks. De BonusScoringStrategy is verantwoordelijk voor het scoren van de leerreeksen op basis van de lengte van de reeks en het aantal activiteiten.

SimpleScoringStrategie
Wijst een score toe op basis van de lengte van de leerreeks.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image026.png)<![endif]>

Figuur 11 Score Learning Streaks with SimpleScoringStrategy

BonusScoringStrategy
Wijst extra bonuspunten toe voor langere streaks of speciale omstandigheden.

<![if !vml]>![](file:////Users/janvanhest/Library/Group%20Containers/UBF8T346G9.Office/TemporaryItems/msohtmlclip/clip_image028.png)<![endif]>

Figuur 12 Score Learning Streaks With BonusScoringStrategy

Toelichting op algoritme.
Waarom zouden we al dit gedoe doen? Welnu, we willen het algoritme flexibel en gemakkelijk te onderhouden houden. We kunnen verschillende strategieën gebruiken om de leerreeksen te berekenen en te scoren. We kunnen eenvoudig tussen strategieën schakelen door ze aan te bieden in de constructor van de LearningStreakService. Ook in de toekomst kunnen we eenvoudig nieuwe strategieën toevoegen zonder de bestaande code te wijzigen. Nu hebben we een mooie en schone service die verantwoordelijk is voor het leerreeksalgoritme. Wij kunnen deze dienst eenvoudig gebruiken in onze verwerkingsverantwoordelijken of andere diensten.

Bij het omgaan met meerdere learningStreaks is alle logica ingekapseld in de service. Als we te maken hebben met een enkele LearningStreak, kunnen we de LearningStreak-klasse gebruiken.

Deze abstractie zou het eenvoudig moeten maken om het algoritme te testen. We zouden de afhankelijkheden gemakkelijk moeten kunnen bespotten en het algoritme met verschillende scenario’s kunnen testen.

Het algoritme is niet extreem complex, maar het is een mooi voorbeeld van hoe je abstracties en interfaces kunt gebruiken om je code flexibeler en onderhoudbaarder te maken.

### Aannames en overwegingen

Tijdens de ontwikkeling van de LingoPartner-applicatie zijn enkele belangrijke aannames en overwegingen gemaakt die de architectuur en het ontwerp hebben beïnvloed.
Het model heeft verschillende revisies ondergaan, alsmede het pakketdiagram. In dit onderdeel aannames en overwegingen wil ik hier dieper op in gaan.

In het begin van het project had ik een eenvoudiger package diagram. Uiteraard bestond het uit de domeinlaag, de infrastructuur en de console. Ik had geen shared project. Ik had ook geen tests project. Ik had geen strategieën. Ik had geen specifieke service voor de streaks. Ik had geen specifieke klasse voor de streaks. Alle data had ik onbewust in de adminstration klass gepropt. De repository's waren direct geinitialiseerd in de adminstrationclass en alle data werd daar verzameld. Dit was niet erg handig. Als ik iets wilde testen kwam ik al snel in de knoop.

Later in de les kregen wij het principe van dependency inversion uitgelegd. Dit was een eye opener. Twee belangrijke dingen kwamen naar voren:
- **Gewone afhankelijkheid**: Een softwaremodule (bijvoorbeeld een app) heeft andere modules of bibliotheken nodig om te functioneren.
- **Omgekeerde afhankelijkheid**: Andere modules of apps zijn afhankelijk van een bepaalde module of bibliotheek om te functioneren.

Reverse dependency is simpelweg het omdraaien van het perspectief: in plaats van te kijken wat je nodig hebt, kijk je naar wie jou nodig heeft. Dit is essentieel voor het 
begrijpen van de volledige impact van wijzigingen in je software en helpt bij het handhaven van stabiliteit en kwaliteit in grotere systemen.

Het leuke hiervan is dat je reverse dependency injection kunt gebruiken om je codebase flexibeler en testbaarder te maken. Je kan een interface maken en deze injecteren in de klasse die de interface nodig heeft. Dit maakt het eenvoudig om te testen. Je kan een mock maken van de interface en deze injecteren in de klasse die je wilt testen. Dit is een van de redenen waarom ik de LingoPartner applicatie heb aangepast. Ik heb de afhankelijkheden van de console omgedraaid. De pijlen van het package diagram stonden van de view layer naar de domain layer en de infrastructuurlaag. Dit heb ik veranderd. Nu staan de pijlen van de LingoPartnerConsole(viewlayer) en de LingoPartnerInfrastructure(infrastructuurlaag) naar de LingoPartnerDomain(domainlaag). De LingoPartnerConsole en de LingoPartnerInfrastructure zijn nu afhankelijk van de LingoPartnerDomain. Dit maakt de codebase flexibeler en testbaarder. Dependency injection heeft een aantal voordelen:
- **Eenvoudiger Onderhoud**: _Als er iets verandert in hoe een onderdeel werkt (bijvoorbeeld de databaseverbinding), hoef je de wijziging maar op één plek door te voeren in plaats van overal in je code._
- **Betere Testbaarheid**: _Je kunt makkelijk testen door onderdelen te vervangen met testversies. Stel je wilt testen hoe je app werkt zonder echte databaseverbinding, je kunt eenvoudig een nep-databaseverbinding injecteren._
- **Loose Coupling**: _De onderdelen van je app zijn minder afhankelijk van elkaar. De app hoeft niet te weten hoe een databaseverbinding precies werkt, alleen dat het een verbinding nodig heeft. Dit maakt je code flexibeler en beter bestand tegen veranderingen._
- **Herbruikbaarheid**: *Omdat onderdelen (zoals de databaseverbinding) centraal beheerd worden, kunnen ze makkelijk hergebruikt worden in verschillende delen van je app.*

Het viel mij op dat ik de adminstration class nodig had om mijn gebruiker te authenticeren. Zo waren er nog wat dingen waar de adminstration class verantwoordelijk was. eigenlijk was de adminstration class zo'n beetje overal verantwoordelijk voor. Volgen de S van SOLID is dat allesbehalve "single responsibility". Ik heb de verantwoordelijkheden van de adminstration class weggehaald en gekeken waar ik deze verantwoordelijkheden kon plaatsen. Zo heb ik de authenticatie verantwoordelijkheid in een aparte service gestopt. Ik heb de streaks verantwoordelijkheid in een aparte service gestopt. Dit wil ik doorzetten en ik hoop dat ik als ik de applicatie af heb ik de administration class niet meer nodig hebt. Ik wil er op deze manier ervoor zorgen dat mijn codebase flexibeler en testbaarder wordt. Ook wanneer ik de geauthenticeerde gebruiker nodig heb, dan kan ik de authenticatie service injecteren in de klasse die de geauthenticeerde gebruiker nodig heeft. Dit maakt het eenvoudig om te testen. Ik kan een mock maken van de authenticatie service en deze injecteren in de klasse die ik wil testen.

Later kwam ik erachter dat men in C# een serviceCollection kan gebruiken in C# om de afhankelijkheden te injecteren. In het .NET framework, en specifiek in C#, is een ServiceProvider een manier om Dependency Injection te implementeren. Het is een centrale plaats waar je al je afhankelijkheden kunt registreren en vervolgens kunt opvragen wanneer je ze nodig hebt. Dat leek mij wel een tof idee en na het besproken te hebben met mijn leerkracht ben ik het gaan implementeren. Het heeft een aantal voordelen. 
- **Loose coupling**:_Je code wordt minder strak gekoppeld. Het koffiezetapparaat hoeft niet te weten hoe de waterpomp wordt gemaakt, alleen dat het er een nodig heeft._
- **Testbaarheid**:_Omdat afhankelijkheden worden geïnjecteerd, kun je gemakkelijk mock- of fake-objecten gebruiken voor tests._
- **Onderhoudbaarheid**:_Het is eenvoudiger om een afhankelijkheid te veranderen. Als je de waterpomp-implementatie wilt wijzigen, hoef je dat alleen te doen op de plaats waar het geregistreerd is, niet overal in je code._




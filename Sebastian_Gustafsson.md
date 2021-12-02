<h6 align="right">Sebastian Gustafsson</h6>
<h1 align="center">Rapport Projektarbete Datalagring</h1>

<h3>Planering</h3>
Så fort gruppindelningen var färdig skapade vi en discord grupp där alla kunde skriva och stämma av om något problem skulle uppstå. Vi bestämde att höras av mellan 09-12 varje
måndag, torsdag och fredag, men vi ställde även frågor utanför dessa intervall.
  <br />  <br />
I framtiden skulle vi kunna lägga upp planeringen i lite mer detalj. Det hade, exemeplvis, fungerat bättre om vi skapat en test-suite för alla tester och sedan lagt till våra egna tester.

<h3>Implementering</h3>
Vi valde att basera våran kod på Jakobs modell eftersom den hade bra grundläggande funktionalitet och information. Vi valde att lägga till namn till maträtterna, för att enklare veta vilken maträtt som är vilken. För att skapa inloggningssystemet bestämde vi att lägga till email och lösenord till varje kunds privata info i Customer-tabellen. Adminkontot har en statisk inloggning där användarnamn och lösenord är hårdkodade. Anledningen till att adminkontot är hårdkodat är för att slippa lägga till ett konto för adminen i Customer-tabellen. Den tabellen hör nämligen lite mer till kunderna. Vi hade dock två ideer för hur vi skulle implementera inloggningen.
  <br />  <br />
Lösning 1 var att vi lägger till en property "Password" till Customer och Restaurant tabellerna. Vi kan lägga till en property för email och/eller telefonnummer i Customer-tabellen, och använda något av dem som användarnamn. Restaurant har redan en unik property (Name) som vi kan använda som användarnamn för restaurangerna. Admin har för tillfället ett statiskt användarnamn och lösenord som är hårdkodat in i AdminBackend-klassen. Vill vi ha mer än ett admin-konto  så får vi ta och skapa en tabell för specifikt admins.
  <br />  <br />
Lösning 2 var att vi, som förra lösningen, lägger till en property "Password" till Customer och Restaurant tabellerna. Vi måste också ha en unik identifierare som användarnamn för en Customer (email, telefon). Restarangen kan använda "Name" här också. Den stora skillnaden blir att vi lägger till en tabell med roller (admin, customer, restaurant). Då kan en admin skapa ett Customer-konto, men ha rollen admin. En kund får då rollen customer, och en restaurangen får rollen restaurant. Fördelen med denna lösningen är att vi kan enkelt ha flera admins, men jag tycker, som sagt, att det är lite konstigt att adminsen ligger i samma tabell som kunderna. 
  <br />  <br />
Vi valde den första lösningen men skippade att lägga till ett konto för restaurangerna. Det hade egentligen varit bättre om restaurangerna också hade ett konto, men vi bestämde att det räckte med att användaren hade ett inloggningssystem.
  <br />  <br />
Jag hade kunnat ladda upp adminklassen så fort reset-metoden var färdig, så att de andras klasser hade rätt reset-metod från början. Vi hade även kunnat lägga mer tid på att debugga och skriva tester, samt implementera ett bättre inloggningssystem.

<h3>Mest nöjd med</h3>
Jag blev mest nöjd med hur bra vårt teamwork var. Det gjorde att vi kunde göra färdigt projektet väldigt snabbt och fokusera på tillägg, som att göra ett winformsprojekt till adminklienten. Det bästa jag själv bidrog med var ideer till inloggningssystemet och mitt winformsprojekt. Eftersom jag inte har gjort något professionellt i winforms än blev jag väldigt nöjd med hur den ser ut och fungerar.
<h3></h3>

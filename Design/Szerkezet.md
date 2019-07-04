# Rendszerterv

## Rétegrend
Az alkalmazás logikáit az objektumorientált (OOP) tervezési minta szerint 
objektumokba foglaljuk.
Az így kialakított objektumokat feladatuk és ismertségi viszonyaik szerint 
a következő rétegekbe szervezzük:

### Megjelenítési réteg
Ebben a rétegben a felhasználói eseteket megvalósító objektumok helyezkednek el.
A rétegben a Nézet-NézetModell-Modell (MVVM) tervezési mintának Nézet és 
NézetModell objektumai vannak.

A Nézet szerepet betöltő objektum felügyeli a felhasználói felület látható 
elemeit megvalósító objektumok életciklusát. A Nézet hozza ezeket létre és 
szünteti meg. A Nézet köti össze őket egymással és a NézetModell egyes 
szolgáltatásaival az eseményvezérelt párbeszéd megvalósulásához.

A NézetModell szerepet betöltő objektum felügyeli a Modell szerepkört betöltő 
üzleti objektumok életciklusát.

A NézetModell tudja, hogy az adott felhasználói esethez mely üzleti objektumok 
(Modellek) és azok mely funkciói szükségesek. Ezért a NézetModell gondoskodik 
ezek létrejöttéről (egy Tároló fogyasztásával), és ezekre támaszkodva az adott 
felhasználói eset igényei szerinti szolgáltatásokat nyújt (amit a Nézet fogyaszt). 
A kapcsolat egyirányú: a NézetModell nem ismeri a Nézet objektum címét, nem 
tudja megszólítani azt. A Nézet ismeri a NézetModell címét, fogyasztja a 
szolgáltatásait, de a Modellek közül csak azokat érheti el, melyeket a NézetModell 
neki átad valamelyik szolgáltatása keretében.

### Üzleti réteg
Ebben a rétegben laknak a Modell szerepet betöltő üzleti objektumok. Ezek azokat 
a logikákat tartalmazzák, melyek felhasználói esettől függetlenek, azaz minden 
felhasználó esetre közösek.

A rétegben a Tároló (Repository) és az EgységnyiVáltozás (Unit-of-Work) tervezési 
mintát követjük.

A Tároló szerepet betöltő objektum egyforma üzleti objektumok életciklusát felügyeli.
A réteg több Tároló osztályt ismer, üzleti objektum osztályonként egyet. A Tároló 
nem ismeri az objektumok rögzítésének-betöltésének módját. Kérésre tud adni egy új 
üzleti objektumot, be tud tenni, ki tud venni egyet a gyűjteményből. Az általa 
kezelt üzleti objektumokon kívül nem ismer más objektumokat, csak mások fogyasztják 
az ő szolgáltatásait.

Az EgységnyiVáltozás szerepet betöltő objektum felügyeli az egy vagy több 
felhasználói esetben okozott, de egyetlen felhasználói jelzésre együtt rögzítendő 
változásban érintett üzleti objektumok (Modellek) életciklusát. Az EgységnyiVáltozás 
feladata a tárolási réteg szolgáltatásaira támaszkodva olyan Tárolókat adni a 
NézetModellnek, melyekben a NézetModell által kért Modellek ott vannak. Köteles 
követni a Modellekben a NézetModell vagy a Nézet vagy a Modell saját logikája 
által okozott változásokat (hozzáadás, módosítás, törlés) és kérésre azok állapotát 
a tárolási réteg szolgáltatásaival rögzíteni.

A Modell feladata tárolni az üzleti entitás adatait és megvédeni ezek összefüggéseit.
A Modellek kialakítása során a SzakterületVezérelt (DDD) tervezési mintát követjük
Korlátos Környezetek (Bounded Context) kialakításával.

### Tárolási réteg
Ebben a rétegben laknak azok az objektumok, amelyek képesek a Modellek állapotának 
rögzítésére és visszatöltésére. Ezek kötelesek elfedni az EgységnyiVáltozás és a 
Tároló elől a rögzítés megvalósításának részleteit (fájl, relációs adatbázis, 
webszolgáltatás, stb.) 

### Szolgáltatási réteg
Ebben a rétegben vannak azok az objektumok, amelyek a többi réteg objektumainak 
nyújtanak szolgáltatásokat (pl. naplózás, nyomtatás, rendszeridő, felhasználó
azonosítás és feljogosítás, stb.)

![rétegrend](Retegrend.svg)

## Névtér- és Szerelvény-szervezési stratégia
Annak érdekében, hogy a kialakuló komponensek minél jobban újrafelhasználhatók
legyenek más, később megalkotandó alkalmazásokhoz, a köztük levő függőségi
viszonyokat csökkenteni kell.
Továbbá, hogy az idővel változó technológiák (UI, ORM, stb.) követhetők legyenek,
azok jellegzetességeinek átszivárgását más rétegekbe meg kell akadályozni.
Ezen célok érdekében a névtereket a Megjelenítési Rétegben felhasználói-esetcsoportok
köré szervezzük, az Üzleti- és a Tárolás Rétegben pedig a Korlátos Környezetek köré.
A szerelvényeket ezeken a névtereken *belül*, a réteghatárok és az alkalmazott
technológiák köré szervezzük.

![szerelvények](Szerelvenyek.svg)

### Szerelvények nevezéktana
A szerelvények neve három tagból áll:
- réteg (M-megjelenítési, U-üzleti, T-tárolás, S-szolgáltatási)
- funkció (megjelenítési rétegben a felhasználói esetcsoport megnevezése, üzleti- és 
tárolási rétegben a Korlátos Környezet megnevezése)
- technológia (ha azonos funkcióra különböző technológiájú megoldások állnak rendelkezésre)

A tagok között alávonás karaktert kell alkalmazni.

Példák:

|név|jelentés|
|---|---|
|M_Partner_WPF|A 'Partner' felhasználói esetcsoportba tartozó felhasználói esetek megjelenítését WPF technológiával megvalósító objektumokat tartalmazó szerelvény.
|M_Partner_ASP|A 'Partner' felhasználói esetcsoportba tartozó felhasználói esetek megjelenítését ASP.NET technológiával megvalósító objektumokat tartalmazó szerelvény.
|U_Partner|A 'Partner' Korlátos Környezetet alkotó üzleti objektumokat tartalmazó szerelvény
|T_Partner_SQL|A 'Partner' Korlátos Környezetet alkotó üzleti objektumok rögzítését relációs adatkezelő technológiával megvalósító objektumokat tartalmazó szerelvény.
|T_Partner_NoSQL|A 'Partner' Korlátos Környezetet alkotó üzleti objektumok rögzítését séma-mentes technológiával megvalósító objektumokat tartalmazó szerelvény.
|S_Tarolas_SQL|A relációs adattároláshoz szolgáltatásokat nyújtó objektumokat tartalmazó szerelvény.

### Névterek nevezéktana
Az összes felvett névteret egyetlen, saját gyökér névtérbe foglaljuk (pl.: Sajat).

A névterek két tagból állnak:
- funkció neve
- névtér típusa (FE-felhasználói eset, KK-korlátos környezet)

A technológiai függőséget alárendelt névtérrel fejezzük ki.

Példák:

|név|jelentés|
|---|---|
|Sajat.PartnerFE.WPF|A partnerekkel kapcsolatos felhasználói eseteket WPF technológiával megvalósító objektumok tartoznak ide.
|Sajat.PartnerKK|A Partner Korlátos Környezet objektumai tartoznak ide.

## Alkalmazáskeret


![AlkalmazásKeret](AppFrame.svg)

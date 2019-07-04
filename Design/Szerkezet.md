## Rétegrend
Az alkalmazás logikáit az OOP tervezési minta szerint objektumokba szervezzük.
Az objektumokat feladatuk szerint a következő rétegekbe szervezzük:

### Megjelenítési réteg
Ebben a rétegben a felhasználói eseteket megvalósító objektumok helyezkednek el. A rétegben a Nézet-NézetModell-Modell (MVVM) tervezési mintának Nézet és NézetModell objektumai vannak

A Nézet szerepet betöltő objektum felügyeli a felhasználói felület látható elemeit megvalósító objektumok életciklusát. A Nézet hozza ezeket létre és szünteti meg. A Nézet köti össze őket egymással és a NézetModell egyes szolgáltatásaival az eseményvezérelt párbeszéd megvalósulásához.

A NézetModell szerepet betöltő objektum felügyeli a Modell szerepkört betöltő üzleti objektumok életciklusát.

A NézetModell tudja, hogy az adott felhasználói esethez mely üzleti objektumok (Modellek) és azok mely funkciói szükségesek. Ezért a NézetModell gondoskodik ezek létrejöttéről (egy Tároló fogyasztásával), és ezekre támaszkodva az adott felhasználói eset igényei szerinti szolgáltatásokat nyújt (amit a Nézet fogyaszt). A kapcsolat egyirányú: a NézetModell nem ismeri a Nézet objektum címét, nem tudja megszólítani azt. A Nézet ismeri a NézetModell címét, fogyasztja a szolgáltatásait, de a Modellek közül csak azokat érheti el, melyeket a NézetModell neki átad valamelyik szolgáltatása keretében.

### Üzleti réteg
Ebben a rétegben laknak a Modell szerepet betöltő üzleti objektumok. Ezek azokat a logikákat tartalmazzák, melyek felhasználói esettől függetlenek, azaz minden felhasználó esetre közösek.

A rétegben a Tároló (Repository) és az EgységnyiVáltozás (Unit-of-Work) tervezési mintát követjük.

A Tároló szerepet betöltő objektum egyforma üzleti objektumok életciklusát felügyeli. A réteg több Tároló osztályt ismer, üzleti objektum osztályonként egyet. A Tároló nem ismeri az objektumok rögzítésének-betöltésének módját. Kérésre tud adni egy új üzleti objektumot, be tud tenni, ki tud venni egyet a gyűjteményből. Az általa kezelt üzleti objektumokon kívül nem ismer más objektumokat, csak mások fogyasztják az ő szolgáltatásait.

Az EgységnyiVáltozás szerepet betöltő objektum felügyeli az egy vagy több felhasználói esetben okozott, de egyetlen felhasználói jelzésre együtt rögzítendő változásban érintett üzleti objektumok (Modellek) életciklusát. Az EgységnyiVáltozás feladata a tárolási réteg szolgáltatásaira támaszkodva olyan Tárolókat adni a NézetModellnek, melyekben a NézetModell által kért Modellek ott vannak. Köteles követni a Modellekben a NézetModell vagy a Nézet vagy a Modell saját logikája által okozott változásokat (hozzáadás, módosítás, törlés) és kérésre azok állapotát a tárolási réteg szolgáltatásaival rögzíteni.

### Tárolási réteg
Ebben a rétegben laknak azok az objektumok, amelyek képesek a Modellek állapotának rögzítésére és visszatöltésére. Ezek kötelesek elfedni az EgységnyiVáltozás és a Tároló elől a rögzítés megvalósításának részleteit (fájl, relációs adatbázis, webszolgáltatás, stb.) 


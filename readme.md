# **TOWER DEFENSE GAME**


## Features
- je kan een speler besturen

- je kan verschillende torens plaatsen

- er zijn enemies die geschoten kunnen worden 
als je ze schiet krijg je geld

- je kan dingen upgraden

- je kan geld  **cheaten**

- als je deze repository pulled kan je het builden en spelen

![screenshot van de game](screenshot.png)

## Technisch
### Menu
- Het spel begint met een scene waarin je het spel kan starten en het spel kan sluiten

### Main Game
- als je het spel start begint er een timer te lopen, als die timer op 0 komt start er een wave

- de wave bestaat uit 8 enemies die een pad van punten volgen als de enemies spawnen worden ze toegevoegd aan een list

-er is rechts van de game een menu waar je torens kan plaatsen en dingen upgraden

-als je een toren plaatst instantiate er een toren en zijn attributen ligt aan de class die gekozen word als je de knop van de toren aanklikt
als de toren word geinstantiate word deze toren toegevoegd aan een list

-een van de attributen van de toren is de range hij kijkt via een foreach loop waar de enemies zijn

-als een van de enemies in de range komt van de toren schiet de toren in de richting van de enemy met een dictionary met een vector en een gameobject

-als de enemies niet dood zijn aan het einde van het pad doen ze damage aan de base en worden de enemies uit de lijst gehaald en gedestroyed

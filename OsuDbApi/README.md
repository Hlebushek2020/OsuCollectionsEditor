# OsuDbApi
- [Общие типы данных](#общие-типы-данных)
  - [Enum GameplayMode](#enum-gameplaymode)
- [Типы osu!.db](#типы-osudb)
## Общие типы данных
### Enum GameplayMode
**namespace OsuDbApi.Enums**  
Значения:
- Standart = 1;
- Taiko = 2;
- CTB = 4;
- Mania = 8.
## Типы osu!db
### Сlass OsuDbReader
**namespace OsuDbApi.OsuDb**  
Реализации: 
- IDisposable.

Конструкторы:
- OsuDbReader(string osuDbFile).

Методы:
Возвращаемый тип|Метод|Назначение
---|---|---
bool|Next()|Читает следующую запись Beatmap из файла в буфер и возвращает значение, указывающее успешность операции
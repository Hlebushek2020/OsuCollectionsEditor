# OsuDbApi
- [Общие типы данных](#общие-типы-данных)
  - [Enum GameplayMode](#enum-gameplaymode)
- [Типы osu!.db](#типы-osudb)
  - [Class OsuDbReader](#class-osudbreader)
  - [Class Beatmap](#class-beatmap)
  - [Struct IntDoublePair](#struct-intdoublepair)
  - [Struct TimingPoint](#struct-timingpoint)
  - [Enum RankedStatus](#enum-rankedstatus)
  - [Enum UserPermissions](enum-userpermissions)
- [Типы collection.db](#типы-collectiondb)
  - [Class CollectionDbReader](#class-collectiondbreader)
  - [Class CollectionDbWritter](#class-collectiondbwritter)
- [Типы scores.db](#типы-scoresdb)
  - [Class ScoresDbReader](#class-scoresdbreader)
  - [Class BeatmapScores](#class-beatmapscores)
  - [Class Score](#class-score)
  - [Enum Mods](#enum-mods)

## Общие типы данных
### Enum GameplayMode
**namespace OsuDbApi.Enums**  
Значения:
- Standart = 1;
- Taiko = 2;
- CTB = 4;
- Mania = 8.

## Типы osu!.db
### Class OsuDbReader
**namespace OsuDbApi.OsuDb**  
Реализации: 
- IDisposable.

Конструкторы:
- OsuDbReader(string osuDbFile).

Методы:
Возвращаемый тип|Метод|Назначение
---|---|---
bool|Next()|Читает следующую запись Beatmap из файла в буфер и возвращает значение, указывающее успешность операции
[Beatmap](#class-beatmap)|GetValue()|Возвращает прочитанное значение из буфера
-|Dispose()|Освобождает все ресурсы, связанные с текущим объектом

Свойства:
Тип|Свойство|Описание
---|---|---
bool|IsDisposed|Указывает, были ли освобождены все ресурсы, связанные с текущим объектом
int|BeatmapReadCount|Количество прочитанных карт
int|OsuVersion|Версия osu!
int|FolderCount|Количество папок
bool|AccountUnlocked|Если false, учетная запись заблокирована
DateTime|DateAccountUnlocked|Дата разблокировки учетной записи
string|PlayerName|Имя игрока
int|BeatmapsCount|Количество битмапов
[UserPermissions](enum-userpermissions)|UserPermissions|Разрешения пользователя
string|OsuDbFile|Абсолютный путь к файлу osu!.db, с которым работает текущий экземпляр OsuDbReader
### Class Beatmap
**namespace OsuDbApi.OsuDb.Models**  
Конструкторы:  
- Beatmap().

Свойства:
Тип|Свойство|Описание
---|---|---
int?|SizeInBytes|Размер записи beatmap в байтах. Присутствует только в том случае, если версия меньше 20191106.
string|ArtistName|Имя исполнителя
string|ArtistNameUnicode|Имя исполнителя, в Юникоде
string|SongTitle|Название песни
string|SongTitleUnicode|Название песни, в Юникоде
string|CreatorName|Имя создателя
string|Difficulty|Сложность
string|AudioFileName|Имя аудиофайла
string|Md5Hash|MD5 хэш битмапа
string|OsuFileName|Имя файла osu, соответствующего этой битмапе
[RankedStatus](#enum-rankedstatus)|RankedStatus|Ранк статус
short|HitcirclesCount|Количество нот
short|SlidersCount|Количество слайдеров
short|SpinnersCount|Количество спинеров
DateTime|LastModificationTime|Время последнего изменения карты
float|ApproachRate|AR карты
float|CircleSize|CS карты
float|HpDrain|HP drain
float|OverallDifficulty|OD карты
double|SliderVelocity|Скорость слайдеров
List<[IntDoublePair](#struct-intdoublepair)>|StarRatingStandart|Информация о star-рейтинге для osu! Standard. Null, если версия меньше 20140609.
List<[IntDoublePair](#struct-intdoublepair)>|StarRatingTaiko|Информация о star-рейтинге для osu! Taiko. Null, если версия меньше 20140609.
List<[IntDoublePair](#struct-intdoublepair)>|StarRatingCtb|Информация о star-рейтинге для osu! CTB. Null, если версия меньше 20140609.
List<[IntDoublePair](#struct-intdoublepair)>|StarRatingMania|Информация о star-рейтинге для osu! Mania. Null, если версия меньше 20140609.
TimeSpan|DrainTime|Время слива
TimeSpan|TotalTime|Общее время
TimeSpan|AudioPreviewTime|Время, когда начинается предварительный просмотр аудио
List<[TimingPoint](#struct-timingpoint)>|TimingPoints|Временные точки
int|Id|Beatmap ID
int|SetId|Beatmap set ID
int|ThreadId|Thread ID
byte|GradeAchievedStandard|Ранг, достигнутый в osu! Standard
byte|GradeAchievedTaiko|Ранг, достигнутый в osu! Taiko
byte|GradeAchievedCtb|Ранг, достигнутый в osu! CTB
byte|GradeAchievedMania|Ранг, достигнутый в osu! Mania
short|LocalOffset|Локальный offset битовой карты
float|StackLeniency|Стек снисходительности
[GameplayMode](#enum-gameplaymode)|GameplayMode|Игровой режим
string|SongSource|Источник песни
string|SongTags|Теги песен
short|OnlineOffset|Онлайн-offset
string|FontTitleSong|Шрифт, используемый для названия песни
bool|IsUnplayed|Если true, то данная карта ещѐ не сыграна юзером
DateTime|LastTimePlay| В последний раз, когда битмап игралась
bool|IsOsz2|Является ли битмап osz2
string|FolderName|Имя папки beatmap относительно папки Songs
DateTime|LastTimeCheckedRepository|Дата последней проверки карты с загруженной на репозиторий оригиналом
bool|IgnoreSound|Если true, игнорировать битмап звук
bool|IgnoreSkin|Если true, игнорировать скин beatmap
bool|DisableStoryboard|Если true, отключить storyboard
bool|DisableVideo|Если true, отключить видео
bool|VisualOverride|Если true, визуальное переопределение
byte|ManiaScrollSpeed|Скорость прокрутки Mania
### Struct IntDoublePair
**namespace OsuDbApi.OsuDb.Models**  
Конструкторы:
- IntDoublePair();
- IntDoublePair(int intValue, double doubleValue).

Свойства:
Тип|Свойство|Описание
---|---|---
int|IntValue|Целое число
double|DoubleValue|Число с плавающей запятой
### Struct TimingPoint
**namespace OsuDbApi.OsuDb.Models**  
Конструкторы:
- TimingPoint();
- TimingPoint(double bpm, double offset, bool isInherit).

Свойства:
Тип|Свойство|Описание
---|---|---
double|BPM|BPM
double|Offset|Смещение в песне (в миллисекундах)
bool|IsInherit|Указывает, наследуется эта временная точка или нет, если true то наследуется
### Enum RankedStatus
**namespace OsuDbApi.OsuDb.Enums**  
Значения:
- Unknown = 0;
- Unsubmitted = 1;
- PendingWipGraveyard = 2;
- Unused = 3;
- Ranked = 4;
- Approved = 5;
- Qualified = 6;
- Loved = 7.

### Enum UserPermissions
**namespace OsuDbApi.OsuDb.Enums**  
Значения:
- None = 0;
- Normal = 1;
- Moderator = 2;
- Supporter = 4;
- Friend = 8;
- Peppy = 16;
- WorldCupStaff = 32.

## Типы collection.db
### Class CollectionDbReader
**namespace OsuDbApi.CollectionDb**  
Реализации:
- IDisposable.

Конструкторы:
- CollectionDbReader(string collectionDbFile).

Методы:
Возвращаемый тип|Метод|Назначение
---|---|---
bool|Next()|Читает следующую запись KeyValuePair<string, List<string>> из файла в буфер (где string - название коллекции, а List<string> - список хешей карт, входящих в эту коллекцию) и возвращает значение, указывающее успешность операции.
KeyValuePair<string, List<string>>|GetValue()|Возвращает прочитанное значение из буфера
-|Dispose()|Освобождает все ресурсы, связанные с текущим объектом

Свойства:
Тип|Свойство|Описание
---|---|---
bool|IsDisposed|Указывает, были ли освобождены все ресурсы, связанные с текущим объектом
int|BeatmapCollectionReadCount|Количество прочитанных коллекций
int|OsuVersion|Версия osu!
int|BeatmapCollectionsCount|Количество коллекций
string|CollectionDbFile|Абсолютный путь к файлу collection.db, с которым работает текущий экземпляр CollectionDbReader
### Class CollectionDbWritter
**namespace OsuDbApi.CollectionDb**  
Конструкторы:
- CollectionDbWritter(string collectionDbFile);
- CollectionDbWritter(string collectionDbFile, int osuVersion).

**Если аргумент osuVersion отсутствует, будет установлено дефолтное значение: 20201210.**

Методы:
Возвращаемый тип|Метод|Назначение
---|---|---
-|Save()|Записывает все данные в файл collection.db

Свойства:
Тип|Свойство|Описание
---|---|---
Dictionary<string, List<string>>|BeatmapCollections|Список коллекций для записи (где string - название коллекции, а List<string> - список хешей карт, входящих в эту коллекцию)
int|OsuVersion|Версия osu!
string|CollectionDbFile|Абсолютный путь к файлу collection.db, с которым работает текущий экземпляр CollectionDbWriter
## Типы scores.db
### Class ScoresDbReader
**namespace OsuDbApi.ScoresDb**  
  Реализации:
- IDisposable.

Конструкторы:
- ScoresDbReader(string scoresDbFile).

Методы:
Возвращаемый тип|Метод|Назначение
---|---|---
bool|Next()|Читает следующую запись BeatmapScores из файла в буфер и возвращает значение, указывающее успешность операции.
[BeatmapScores](#class-beatmapscores)|GetValue()|Возвращает прочитанное значение из буфера
-|Dispose()|Освобождает все ресурсы, связанные с текущим объектом

Свойства:
Тип|Свойство|Описание
---|---|---
bool|IsDisposed|Указывает, были ли освобождены все ресурсы, связанные с текущим объектом
int|BeatmapScoresReadCount|Количество прочитанных Beatmap скоров
int|OsuVersion|Версия osu!
int|BeatmapScoresCount|Количество Beatmap скоров
string|ScoresDbFile|Абсолютный путь к файлу scores.db, с которым работает текущий экземпляр ScoresDbReader
### Class BeatmapScores
**namespace OsuDbApi.ScoresDb.Models**  
Конструкторы:
- BeatmapScores().

Свойства:
Тип|Свойство|Описание
---|---|---
string|BeatmapHash|Beatmap хеш
List<[Score](#class-score)>|Scores|Скоры на этой beatmap
### Class Score
**namespace OsuDbApi.ScoresDb.Models**  
Конструкторы:
- Score().

Свойства:
Тип|Свойство|Описание
---|---|---
[GameplayMode](#enum-gameplaymode)|GameplayMode|Игровой режим
int|ScoreVersion|Версия скора (повтора)
string|BeatmapHash|Хеш beatmap
string|PlayerName|Имя игрока
string|Md5Hash|Хеш записи
short|Count300|Количество 300-х
short|Count100|Количество 100-х в Osu!Standard, 150-х в Taiko, 100-х в CTB, 100-х в Mania
short|Count50|Количество 50-х в Osu!Standard, маленький фрукт в CTB, 50-х в Mania
short|GekiCount|Количество Geki в Osu!Standard, Макс 300-x в Mania
short|KatuCount|Количество Katu в Osu!Standard, 200-х в Mania
short|MissCount|Количество промахов
int|ReplayScore|Скор
short|MaxCombo|Максимальное Комбо
bool|PerfectCombo|Если true, идеальное карта сыграна на FC (Full Combo)
[Mods](#enum-mods)|CombinationModsUsed|Побитовая комбинация модов
DateTime|TimestampReplay|Дата, когда скор был поставлен
long|OnlineScoreId|Онлайн-идентификатор скора
### Enum Mods
**namespace OsuDbApi.ScoresDb.Enums**  
Значения:
- None = 0;
- NoFail = 1;
- Easy = 2;
- TouchDevice = 4;
- Hidden = 8;
- HardRock = 16;
- SuddenDeath = 32;
- DoubleTime = 64;
- Relax = 128;
- HalfTime = 256;
- Nightcore = 512;
- Flashlight = 1024;
- Autoplay = 2048;
- SpinOut = 4096;
- Autopilot = 8192;
- Perfect = 16384;
- Key1 = 67108864;
- Key2 = 268435456;
- Key3 = 134217728;
- Key4 = 32768;
- Key5 = 65536;
- Key6 = 131072;
- Key7 = 262144;
- Key8 = 524288;
- Key9 = 16777216;
- KeyMod = 1015808;
- FadeIn = 1048576;
- Random = 2097152;
- Cinema = 4194304;
- TargetPractice = 8388608;
- Coop = 33554432.
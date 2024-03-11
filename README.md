# FootballSimpleApp - 

В процессе выполенения тестового задания, использовал принципы чистой архитектуры, в соотвествии с которыми поделил приложение не следующие слои:
- Football.Domain (Business Logic)
- Football.Persistence (Infrastructure)
- Football.API (Application)
- Football.Client (Presentation)

## Football.Domain
В процессе анализа тех.задания выявил несколько объектов: Player (Футболист), Team (Команда). При написания кода решил использовать анемичную предметную модель, по причине отсутсвия большого количества бизнес-логики, поэтому объекты имею только поля и правила валидации.

## Football.Persistence
Слой содержит логику работы с базой данных, миграции. В качестве ORM используется Entity Framework.

## Football.API
Слой приложение является asp.net core сервером с SignalR, реализуется api через контроллеры.

## Football.Client
Frontend часть приложения реализована при помощи Blazor (WASM), Bootstrap и библиотеки компонетов Radzen. Использовует HttpClient для работы с Football.API, а также SignalR для обновления данных в реальной времени.

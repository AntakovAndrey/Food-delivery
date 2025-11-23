# TODO: Delivery Service

## Общее описание
Сервис управления доставкой. Назначение курьеров, отслеживание доставки в реальном времени, оптимизация маршрутов.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок (Domain, Application, Infrastructure, API)
- [ ] Добавить необходимые NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] NetTopologySuite (для геолокации)
  - [ ] FluentValidation
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] Swashbuckle.AspNetCore
  - [ ] MediatR
  - [ ] MassTransit
  - [ ] SignalR (для real-time обновлений)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Deliveryman (Id, UserId, Status, CurrentLocation, VehicleType, Rating, TotalDeliveries, IsAvailable, CreatedAt)
  - [ ] DeliveryAssignment (Id, OrderId, DeliverymanId, AssignedAt, PickedUpAt, DeliveredAt, Status)
  - [ ] DeliveryLocation (Id, AssignmentId, Latitude, Longitude, Timestamp, Accuracy)
  - [ ] DeliveryRoute (Id, AssignmentId, Waypoints, EstimatedTime, ActualTime, Distance)
  - [ ] DeliveryRating (Id, OrderId, DeliverymanId, Rating, Comment, CreatedAt)
- [ ] Создать Enum:
  - [ ] DeliverymanStatus (Available, Busy, Offline, OnDelivery)
  - [ ] VehicleType (Bicycle, Motorcycle, Car, Walking)
- [ ] Создать Value Objects:
  - [ ] Location (Latitude, Longitude, Accuracy)
  - [ ] Route (Waypoints, Distance, EstimatedTime)
- [ ] Создать Domain Events:
  - [ ] CourierAssignedEvent
  - [ ] CourierLocationUpdatedEvent
  - [ ] OrderPickedUpEvent
  - [ ] OrderDeliveredEvent
- [ ] Создать исключения:
  - [ ] DeliverymanNotFoundException
  - [ ] NoAvailableDeliverymanException
  - [ ] InvalidLocationException
  - [ ] OrderAlreadyAssignedException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (DeliveryDbContext)
- [ ] Настроить PostgreSQL с PostGIS
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IDeliverymanRepository
  - [ ] IDeliveryAssignmentRepository
  - [ ] IDeliveryLocationRepository
- [ ] Реализовать репозитории с поддержкой:
  - [ ] Поиска курьеров по местоположению
  - [ ] Фильтрации по статусу
  - [ ] Геопространственных запросов
- [ ] Настроить Redis для хранения текущих местоположений курьеров
- [ ] Настроить интеграцию с Message Broker
- [ ] Настроить интеграцию с Order Service
- [ ] Настроить интеграцию с Identity Service
- [ ] Настроить SignalR Hub для real-time обновлений

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] DeliverymanDto
  - [ ] DeliveryAssignmentDto
  - [ ] UpdateLocationDto
  - [ ] AssignDeliverymanDto
  - [ ] DeliveryTrackingDto
  - [ ] DeliveryRouteDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] UpdateLocationValidator
  - [ ] AssignDeliverymanValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IDeliverymanService
  - [ ] IDeliveryAssignmentService
  - [ ] IRouteOptimizationService
  - [ ] ILocationTrackingService
- [ ] Реализовать сервисы:
  - [ ] DeliverymanService:
    - [ ] GetAvailableDeliverymenAsync
    - [ ] GetDeliverymanByIdAsync
    - [ ] UpdateStatusAsync
    - [ ] UpdateLocationAsync
    - [ ] GetNearbyDeliverymenAsync
  - [ ] DeliveryAssignmentService:
    - [ ] AssignDeliverymanAsync
    - [ ] AcceptAssignmentAsync
    - [ ] MarkAsPickedUpAsync
    - [ ] MarkAsDeliveredAsync
    - [ ] GetAssignmentByOrderIdAsync
  - [ ] RouteOptimizationService:
    - [ ] CalculateOptimalRoute
    - [ ] EstimateDeliveryTime
    - [ ] GroupOrdersForDelivery
  - [ ] LocationTrackingService:
    - [ ] TrackLocationAsync
    - [ ] GetCurrentLocationAsync
    - [ ] GetLocationHistoryAsync
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] DeliverymanController:
    - [ ] GET /api/delivery/deliverymen/{id} - информация о курьере
    - [ ] GET /api/delivery/deliverymen/available - доступные курьеры
    - [ ] PUT /api/delivery/deliverymen/{id}/status - изменить статус
    - [ ] PUT /api/delivery/deliverymen/{id}/location - обновить местоположение
  - [ ] DeliveryController:
    - [ ] GET /api/delivery/orders/available - доступные заказы для доставки
    - [ ] POST /api/delivery/orders/{orderId}/assign - назначить курьера
    - [ ] POST /api/delivery/orders/{orderId}/accept - принять заказ (курьер)
    - [ ] POST /api/delivery/orders/{orderId}/pickup - отметить как забран
    - [ ] POST /api/delivery/orders/{orderId}/deliver - отметить как доставлен
    - [ ] GET /api/delivery/orders/{orderId}/tracking - отслеживание доставки
  - [ ] RouteController:
    - [ ] GET /api/delivery/routes/{assignmentId} - маршрут доставки
    - [ ] POST /api/delivery/routes/optimize - оптимизировать маршрут
- [ ] Настроить SignalR Hub для real-time обновлений
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS

---

## 6. Назначение курьеров

- [ ] Получение доступных заказов из Order Service
- [ ] Поиск ближайших доступных курьеров
- [ ] Алгоритм назначения (ближайший, наименее загруженный)
- [ ] Автоматическое назначение или ручное
- [ ] Уведомление курьера о новом заказе
- [ ] Принятие заказа курьером
- [ ] Отправка события CourierAssigned

---

## 7. Отслеживание местоположения

- [ ] Получение обновлений местоположения от курьера (GPS)
- [ ] Хранение текущего местоположения в Redis
- [ ] Сохранение истории местоположений в PostgreSQL
- [ ] Real-time обновления через SignalR
- [ ] Расчет расстояния до точки доставки
- [ ] Расчет примерного времени доставки
- [ ] Валидация координат

---

## 8. Оптимизация маршрутов

- [ ] Построение оптимального маршрута
- [ ] Учет текущего местоположения курьера
- [ ] Учет адреса ресторана и клиента
- [ ] Расчет расстояния и времени
- [ ] Группировка заказов для одного курьера (batch delivery)
- [ ] Интеграция с картографическими API (Google Maps, Mapbox)

---

## 9. Управление статусами доставки

- [ ] Отслеживание статуса доставки:
  - [ ] Assigned - назначен курьеру
  - [ ] Accepted - принят курьером
  - [ ] PickedUp - забран из ресторана
  - [ ] OnTheWay - в пути к клиенту
  - [ ] Delivered - доставлен
- [ ] Автоматическое обновление статуса при достижении точек
- [ ] Уведомления о изменении статуса
- [ ] Интеграция с Order Service для обновления статуса заказа

---

## 10. Рейтинг курьеров

- [ ] Хранение рейтингов курьеров
- [ ] Расчет среднего рейтинга
- [ ] Учет рейтинга при назначении заказов
- [ ] История рейтингов
- [ ] Интеграция с Review Service

---

## 11. Интеграции

- [ ] Интеграция с Order Service:
  - [ ] Получение доступных заказов
  - [ ] Обновление статуса заказа
  - [ ] Получение информации о заказе
- [ ] Интеграция с Identity Service:
  - [ ] Валидация курьеров
  - [ ] Получение информации о пользователе
- [ ] Интеграция с Notification Service:
  - [ ] Уведомления курьерам о новых заказах
  - [ ] Уведомления клиентам о статусе доставки
- [ ] Интеграция с Review Service:
  - [ ] Получение рейтингов курьеров
- [ ] Отправка событий в Message Broker:
  - [ ] CourierAssigned
  - [ ] CourierLocationUpdated
  - [ ] OrderPickedUp
  - [ ] OrderDelivered
- [ ] Подписка на события:
  - [ ] OrderCreated (из Order Service)
  - [ ] OrderStatusChanged (из Order Service)

---

## 12. Real-time обновления

- [ ] Настроить SignalR Hub
- [ ] Реализовать обновления местоположения курьера в реальном времени
- [ ] Обновления статуса доставки
- [ ] Подключение клиентов к Hub
- [ ] Обработка отключений и переподключений

---

## 13. Геолокация

- [ ] Настроить PostGIS для геопространственных запросов
- [ ] Хранение координат (Point тип)
- [ ] Поиск курьеров в радиусе
- [ ] Расчет расстояния между точками
- [ ] Построение маршрутов
- [ ] Геофенсинг (определение достижения точки)

---

## 14. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Unit тесты для оптимизации маршрутов
- [ ] Integration тесты для API endpoints
- [ ] Тесты геолокации
- [ ] Тесты SignalR Hub
- [ ] Тесты производительности

---

## 15. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать алгоритмы назначения
- [ ] Документировать SignalR Hub

---

## 16. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (количество доставок, среднее время)
- [ ] Логирование всех обновлений местоположения
- [ ] Мониторинг доступности курьеров

---

## 17. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить PostGIS расширение
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer (PostGIS, Redis)
- Application Layer (DeliverymanService, DeliveryAssignmentService)
- API Layer
- Назначение курьеров
- Отслеживание местоположения

**Средний приоритет:**
- Оптимизация маршрутов
- Real-time обновления (SignalR)
- Рейтинг курьеров
- Интеграции

**Низкий приоритет:**
- Расширенные функции оптимизации
- Batch delivery
- Геофенсинг


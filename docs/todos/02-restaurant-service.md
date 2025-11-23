# TODO: Restaurant Service

## Общее описание
Сервис управления ресторанами. Управление информацией о ресторанах, категориями, рейтингами, геолокацией.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок (Domain, Application, Infrastructure, API)
- [ ] Добавить необходимые NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] FluentValidation
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] Swashbuckle.AspNetCore
  - [ ] NetTopologySuite (для геолокации)
  - [ ] MediatR (опционально, для CQRS)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Restaurant (Id, Name, Description, Rating, Address, Coordinates, PhotoURL, CategoryId, RestaurantAdminId, IsActive, CreatedAt, UpdatedAt)
  - [ ] RestaurantCategory (Id, Name, Description, IconURL)
  - [ ] RestaurantHours (Id, RestaurantId, DayOfWeek, OpenTime, CloseTime, IsClosed)
  - [ ] RestaurantSettings (Id, RestaurantId, MinOrderAmount, DeliveryFee, EstimatedDeliveryTime, IsDeliveryAvailable, IsPickupAvailable)
  - [ ] RestaurantImage (Id, RestaurantId, ImageURL, IsPrimary, Order)
- [ ] Создать Value Objects:
  - [ ] Address (Street, City, PostalCode, Country)
  - [ ] Coordinates (Latitude, Longitude)
  - [ ] Rating (Value, Count)
- [ ] Создать Domain Events:
  - [ ] RestaurantCreatedEvent
  - [ ] RestaurantUpdatedEvent
  - [ ] RestaurantRatingUpdatedEvent
- [ ] Создать исключения:
  - [ ] RestaurantNotFoundException
  - [ ] RestaurantAlreadyExistsException
  - [ ] InvalidCoordinatesException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (RestaurantDbContext)
- [ ] Настроить PostgreSQL с поддержкой PostGIS (для геолокации)
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IRestaurantRepository
  - [ ] IRestaurantCategoryRepository
  - [ ] IRestaurantSettingsRepository
- [ ] Реализовать репозитории с поддержкой:
  - [ ] Поиска по радиусу (геолокация)
  - [ ] Фильтрации и сортировки
  - [ ] Пагинации
- [ ] Настроить Redis для кэширования популярных ресторанов
- [ ] Создать сервис для работы с изображениями (IStorageService)
- [ ] Настроить интеграцию с Review Service для получения рейтингов

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] RestaurantDto
  - [ ] CreateRestaurantDto
  - [ ] UpdateRestaurantDto
  - [ ] RestaurantListDto
  - [ ] RestaurantCategoryDto
  - [ ] RestaurantSearchRequestDto
  - [ ] NearbyRestaurantsRequestDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] CreateRestaurantValidator
  - [ ] UpdateRestaurantValidator
  - [ ] RestaurantSearchRequestValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IRestaurantService
  - [ ] IRestaurantCategoryService
  - [ ] IGeolocationService
- [ ] Реализовать сервисы:
  - [ ] RestaurantService:
    - [ ] GetByIdAsync
    - [ ] GetAllAsync (с пагинацией и фильтрами)
    - [ ] SearchAsync
    - [ ] GetNearbyAsync (по радиусу)
    - [ ] CreateAsync
    - [ ] UpdateAsync
    - [ ] DeleteAsync
    - [ ] UpdateRatingAsync (получение из Review Service)
  - [ ] RestaurantCategoryService:
    - [ ] GetAllAsync
    - [ ] GetByIdAsync
    - [ ] GetRestaurantsByCategoryAsync
  - [ ] GeolocationService:
    - [ ] CalculateDistance
    - [ ] GetRestaurantsInRadius
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] RestaurantController:
    - [ ] GET /api/restaurants (с фильтрами, пагинацией)
    - [ ] GET /api/restaurants/{id}
    - [ ] POST /api/restaurants (только RestaurantAdmin)
    - [ ] PUT /api/restaurants/{id}
    - [ ] DELETE /api/restaurants/{id}
    - [ ] GET /api/restaurants/search?query={query}
    - [ ] GET /api/restaurants/nearby?lat={lat}&lng={lng}&radius={km}
    - [ ] GET /api/restaurants/{id}/rating
  - [ ] RestaurantCategoryController:
    - [ ] GET /api/restaurants/categories
    - [ ] GET /api/restaurants/categories/{id}
    - [ ] GET /api/restaurants/categories/{id}/restaurants
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS
- [ ] Добавить кэширование для популярных запросов

---

## 6. Поиск и фильтрация

- [ ] Реализовать полнотекстовый поиск по названию и описанию
- [ ] Фильтрация по категориям
- [ ] Фильтрация по рейтингу (мин. рейтинг)
- [ ] Фильтрация по расстоянию
- [ ] Фильтрация по времени работы
- [ ] Фильтрация по минимальной сумме заказа
- [ ] Сортировка (по рейтингу, расстоянию, популярности)
- [ ] Пагинация результатов

---

## 7. Геолокация

- [ ] Настроить PostGIS расширение в PostgreSQL
- [ ] Реализовать хранение координат (Point тип)
- [ ] Реализовать поиск ресторанов в радиусе
- [ ] Расчет расстояния между точками
- [ ] Кэширование результатов геопоиска
- [ ] Валидация координат

---

## 8. Управление изображениями

- [ ] Создать endpoint для загрузки изображений
- [ ] Валидация форматов изображений
- [ ] Ресайз изображений (оптимизация)
- [ ] Хранение в облачном хранилище (S3, Azure Blob) или локально
- [ ] Удаление старых изображений при обновлении
- [ ] Поддержка множественных изображений

---

## 9. Интеграции

- [ ] Интеграция с Review Service для получения рейтингов
- [ ] Отправка событий в Message Broker:
  - [ ] RestaurantCreated
  - [ ] RestaurantUpdated
  - [ ] RestaurantRatingUpdated
- [ ] Подписка на события из других сервисов
- [ ] Интеграция с Identity Service для проверки прав доступа

---

## 10. Кэширование

- [ ] Кэширование списка популярных ресторанов
- [ ] Кэширование категорий ресторанов
- [ ] Кэширование детальной информации о ресторане
- [ ] Инвалидация кэша при обновлении данных
- [ ] Настроить TTL для кэша

---

## 11. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Unit тесты для геолокации
- [ ] Integration тесты для API endpoints
- [ ] Тесты поиска и фильтрации
- [ ] Тесты производительности (нагрузочное тестирование)

---

## 12. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать модели данных
- [ ] Документировать фильтры и параметры поиска

---

## 13. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (количество запросов, время ответа)
- [ ] Логирование важных операций

---

## 14. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить seed данные (категории ресторанов)
- [ ] Протестировать миграции с PostGIS
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer (DbContext, репозитории, PostGIS)
- Application Layer (RestaurantService, поиск)
- API Layer
- Геолокация (базовая функциональность)

**Средний приоритет:**
- Расширенный поиск и фильтрация
- Кэширование
- Управление изображениями
- Интеграции

**Низкий приоритет:**
- Расширенные функции геолокации
- Оптимизация производительности


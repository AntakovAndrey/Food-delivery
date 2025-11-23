# TODO: Review Service

## Общее описание
Сервис управления отзывами и рейтингами ресторанов, блюд и курьеров.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок
- [ ] Добавить NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] FluentValidation
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] MassTransit
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Review (Id, OrderId, UserId, EntityType, EntityId, Rating, Comment, Photos, CreatedAt, UpdatedAt)
  - [ ] ReviewPhoto (Id, ReviewId, ImageURL)
  - [ ] ReviewModeration (Id, ReviewId, Status, ModeratorId, Notes, ReviewedAt)
- [ ] Создать Enum:
  - [ ] EntityType (Restaurant, Dish, Deliveryman)
  - [ ] ModerationStatus (Pending, Approved, Rejected)
- [ ] Создать Value Objects:
  - [ ] Rating (Value 1-5)
- [ ] Создать Domain Events:
  - [ ] ReviewCreatedEvent
  - [ ] ReviewApprovedEvent
  - [ ] RatingUpdatedEvent

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext
- [ ] Создать миграции
- [ ] Настроить репозитории
- [ ] Настроить интеграцию с другими сервисами

---

## 4. Application Layer

- [ ] Создать DTOs
- [ ] Создать интерфейсы:
  - [ ] IReviewService
  - [ ] IRatingService
  - [ ] IModerationService
- [ ] Реализовать сервисы:
  - [ ] CreateReviewAsync
  - [ ] GetReviewsAsync
  - [ ] CalculateAverageRatingAsync
  - [ ] ModerateReviewAsync

---

## 5. API Layer

- [ ] ReviewController:
  - [ ] POST /api/reviews/restaurants/{id}
  - [ ] POST /api/reviews/dishes/{id}
  - [ ] POST /api/reviews/delivery/{orderId}
  - [ ] GET /api/reviews/restaurants/{id}
  - [ ] GET /api/reviews/dishes/{id}
  - [ ] GET /api/reviews/restaurants/{id}/rating

---

## 6. Модерация

- [ ] Автоматическая модерация (фильтрация спама)
- [ ] Ручная модерация администраторами
- [ ] Жалобы на отзывы

---

## 7. Интеграции

- [ ] Отправка событий RatingUpdated в Restaurant/Menu/Delivery сервисы
- [ ] Интеграция с Order Service (проверка завершенных заказов)

---

## 8. Тестирование

- [ ] Unit тесты
- [ ] Integration тесты

---

## Приоритеты

**Высокий:** Настройка, Domain, Infrastructure, Application, API, Расчет рейтингов
**Средний:** Модерация, Фото
**Низкий:** Расширенная модерация


# TODO: Analytics Service

## Общее описание
Сервис сбора и анализа данных, генерация отчетов, бизнес-аналитика.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок
- [ ] Добавить NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] MassTransit
  - [ ] ClosedXML (для Excel)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] AnalyticsEvent (Id, EventType, EntityType, EntityId, Data, Timestamp)
  - [ ] Report (Id, Type, Parameters, GeneratedAt, FileURL)
  - [ ] Dashboard (Id, Name, Widgets, UserId)
- [ ] Создать Enum:
  - [ ] EventType (OrderCreated, OrderDelivered, PaymentProcessed, etc.)
  - [ ] ReportType (Daily, Weekly, Monthly, Custom)

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext
- [ ] Создать миграции
- [ ] Настроить репозитории
- [ ] Настроить подписку на события от других сервисов
- [ ] Настроить ClickHouse для больших данных (опционально)

---

## 4. Application Layer

- [ ] Создать DTOs
- [ ] Создать интерфейсы:
  - [ ] IAnalyticsService
  - [ ] IReportService
  - [ ] IDashboardService
- [ ] Реализовать сервисы:
  - [ ] GetRestaurantOverviewAsync
  - [ ] GetOrderStatisticsAsync
  - [ ] GetPopularDishesAsync
  - [ ] GetRevenueStatisticsAsync
  - [ ] GenerateReportAsync

---

## 5. API Layer

- [ ] AnalyticsController:
  - [ ] GET /api/analytics/restaurants/{id}/overview
  - [ ] GET /api/analytics/restaurants/{id}/orders
  - [ ] GET /api/analytics/restaurants/{id}/dishes
  - [ ] GET /api/analytics/restaurants/{id}/revenue
  - [ ] GET /api/analytics/admin/platform-overview
  - [ ] GET /api/analytics/reports/generate

---

## 6. Сбор данных

- [ ] Подписка на события от всех сервисов
- [ ] Агрегация данных
- [ ] Хранение метрик
- [ ] Реализация ETL процессов

---

## 7. Отчеты

- [ ] Генерация ежедневных отчетов
- [ ] Генерация недельных отчетов
- [ ] Генерация месячных отчетов
- [ ] Экспорт в Excel/PDF
- [ ] Планировщик отчетов

---

## 8. Дашборды

- [ ] Создание дашбордов
- [ ] Виджеты для отображения метрик
- [ ] Real-time обновления
- [ ] Настройка дашбордов пользователями

---

## 9. Интеграции

- [ ] Подписка на все события от других сервисов
- [ ] Интеграция с Identity Service для авторизации

---

## 10. Тестирование

- [ ] Unit тесты
- [ ] Integration тесты
- [ ] Тесты генерации отчетов

---

## Приоритеты

**Высокий:** Настройка, Domain, Infrastructure, Application, API, Сбор данных
**Средний:** Отчеты, Дашборды
**Низкий:** Расширенная аналитика, ML


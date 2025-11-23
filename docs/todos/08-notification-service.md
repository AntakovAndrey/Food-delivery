# TODO: Notification Service

## Общее описание
Сервис отправки уведомлений пользователям через различные каналы (Email, SMS, Push).

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок
- [ ] Добавить NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] FluentEmail (или SendGrid SDK)
  - [ ] Twilio (для SMS)
  - [ ] Firebase Admin SDK (для Push)
  - [ ] MassTransit
  - [ ] Serilog
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Notification (Id, UserId, Type, Channel, Subject, Body, Status, SentAt, ReadAt)
  - [ ] NotificationTemplate (Id, Type, Channel, Subject, Body, Variables)
  - [ ] NotificationPreference (Id, UserId, Channel, IsEnabled)
- [ ] Создать Enum:
  - [ ] NotificationType (OrderCreated, OrderStatusChanged, PaymentProcessed, etc.)
  - [ ] NotificationChannel (Email, SMS, Push, InApp)
  - [ ] NotificationStatus (Pending, Sent, Failed, Read)
- [ ] Создать Domain Events:
  - [ ] NotificationSentEvent
  - [ ] NotificationReadEvent

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext
- [ ] Создать миграции
- [ ] Настроить репозитории
- [ ] Настроить Email сервис (SendGrid/SMTP)
- [ ] Настроить SMS сервис (Twilio)
- [ ] Настроить Push сервис (Firebase)
- [ ] Настроить Message Broker подписки

---

## 4. Application Layer

- [ ] Создать DTOs
- [ ] Создать интерфейсы:
  - [ ] INotificationService
  - [ ] IEmailService
  - [ ] ISmsService
  - [ ] IPushService
- [ ] Реализовать сервисы:
  - [ ] SendEmailAsync
  - [ ] SendSmsAsync
  - [ ] SendPushAsync
  - [ ] SendNotificationAsync (универсальный)
- [ ] Реализовать шаблоны уведомлений
- [ ] Реализовать персонализацию

---

## 5. API Layer

- [ ] NotificationController:
  - [ ] GET /api/notifications - история уведомлений
  - [ ] PUT /api/notifications/{id}/read - отметить как прочитанное
  - [ ] PUT /api/notifications/preferences - настройки уведомлений
  - [ ] POST /api/notifications/subscribe - подписка на push

---

## 6. Интеграции

- [ ] Подписка на события от других сервисов
- [ ] Обработка событий и отправка уведомлений
- [ ] Интеграция с Identity Service

---

## 7. Тестирование

- [ ] Unit тесты
- [ ] Integration тесты
- [ ] Тесты шаблонов

---

## Приоритеты

**Высокий:** Настройка проекта, Domain, Infrastructure, Application, API, Интеграции
**Средний:** Шаблоны, Персонализация
**Низкий:** Расширенные функции


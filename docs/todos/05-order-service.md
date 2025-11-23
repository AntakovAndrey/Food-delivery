# TODO: Order Service

## Общее описание
Сервис управления заказами. Создание заказов, управление жизненным циклом, отслеживание статусов.

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
  - [ ] MediatR (для CQRS и событий)
  - [ ] MassTransit (для работы с Message Broker)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Order (Id, CustomerId, RestaurantId, DeliverymanId, Status, Address, TotalPrice, DeliveryFee, Discount, CreatedAt, UpdatedAt, EstimatedDeliveryTime)
  - [ ] OrderItem (Id, OrderId, DishId, Quantity, UnitPrice, TotalPrice, Modifiers)
  - [ ] OrderItemModifier (Id, OrderItemId, ModifierId, OptionId)
  - [ ] OrderStatusHistory (Id, OrderId, Status, ChangedAt, ChangedBy, Notes)
  - [ ] OrderPayment (Id, OrderId, PaymentId, Amount, Status, CreatedAt)
- [ ] Создать Enum:
  - [ ] OrderStatus (Pending, Confirmed, Preparing, Ready, Assigned, PickedUp, OnTheWay, Delivered, Cancelled, Refunded)
- [ ] Создать Value Objects:
  - [ ] Address (Street, City, PostalCode, Country, Coordinates)
  - [ ] Money (Amount, Currency)
- [ ] Создать Domain Events:
  - [ ] OrderCreatedEvent
  - [ ] OrderStatusChangedEvent
  - [ ] OrderCancelledEvent
  - [ ] OrderDeliveredEvent
  - [ ] OrderAssignedToDeliverymanEvent
- [ ] Создать исключения:
  - [ ] OrderNotFoundException
  - [ ] InvalidOrderStatusException
  - [ ] OrderCannotBeCancelledException
  - [ ] OrderAlreadyAssignedException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (OrderDbContext)
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IOrderRepository
  - [ ] IOrderItemRepository
  - [ ] IOrderStatusHistoryRepository
- [ ] Реализовать репозитории с поддержкой:
  - [ ] Фильтрации по пользователю
  - [ ] Фильтрации по ресторану
  - [ ] Фильтрации по статусу
  - [ ] Фильтрации по дате
  - [ ] Пагинации
- [ ] Настроить интеграцию с Message Broker (RabbitMQ/Kafka)
- [ ] Настроить интеграцию с Cart Service
- [ ] Настроить интеграцию с Payment Service
- [ ] Настроить интеграцию с Delivery Service
- [ ] Настроить интеграцию с Notification Service

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] OrderDto
  - [ ] CreateOrderDto
  - [ ] OrderItemDto
  - [ ] OrderListDto
  - [ ] UpdateOrderStatusDto
  - [ ] CancelOrderDto
  - [ ] OrderTrackingDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] CreateOrderValidator
  - [ ] UpdateOrderStatusValidator
  - [ ] CancelOrderValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IOrderService
  - [ ] IOrderStatusService
  - [ ] IOrderTrackingService
- [ ] Реализовать сервисы:
  - [ ] OrderService:
    - [ ] CreateOrderAsync (из корзины)
    - [ ] GetOrderByIdAsync
    - [ ] GetOrdersByUserIdAsync
    - [ ] GetActiveOrdersByUserIdAsync
    - [ ] GetOrdersByRestaurantIdAsync
    - [ ] GetActiveOrdersByRestaurantIdAsync
    - [ ] GetOrdersByDeliverymanIdAsync
    - [ ] CancelOrderAsync
  - [ ] OrderStatusService:
    - [ ] UpdateStatusAsync
    - [ ] GetStatusHistoryAsync
    - [ ] CanChangeStatus (валидация переходов статусов)
  - [ ] OrderTrackingService:
    - [ ] GetOrderTrackingAsync
    - [ ] CalculateEstimatedDeliveryTime
- [ ] Настроить AutoMapper профили
- [ ] Настроить обработчики событий (MediatR)

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] OrderController:
    - [ ] POST /api/orders - создать заказ
    - [ ] GET /api/orders - список заказов пользователя
    - [ ] GET /api/orders/{id} - детали заказа
    - [ ] GET /api/orders/active - активные заказы
    - [ ] POST /api/orders/{id}/cancel - отменить заказ
    - [ ] GET /api/orders/{id}/tracking - отслеживание заказа
    - [ ] GET /api/orders/{id}/status-history - история статусов
  - [ ] RestaurantOrderController (для RestaurantAdmin):
    - [ ] GET /api/orders/restaurants/{restaurantId} - заказы ресторана
    - [ ] GET /api/orders/restaurants/{restaurantId}/active - активные заказы
    - [ ] PUT /api/orders/{id}/status - изменить статус
  - [ ] DeliveryOrderController (для Deliveryman):
    - [ ] GET /api/orders/deliverymen/{deliverymanId} - заказы курьера
    - [ ] GET /api/orders/available - доступные заказы для доставки
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS
- [ ] Добавить авторизацию с проверкой ролей

---

## 6. Создание заказа

- [ ] Получение корзины из Cart Service
- [ ] Валидация корзины (доступность блюд, минимальная сумма)
- [ ] Создание заказа из корзины
- [ ] Расчет итоговой стоимости
- [ ] Создание записей OrderItem
- [ ] Очистка корзины после создания заказа
- [ ] Отправка события OrderCreated
- [ ] Инициализация платежа (интеграция с Payment Service)

---

## 7. Управление статусами заказа

- [ ] Реализовать State Machine для статусов:
  - [ ] Pending → Confirmed / Cancelled
  - [ ] Confirmed → Preparing / Cancelled
  - [ ] Preparing → Ready / Cancelled
  - [ ] Ready → Assigned / Cancelled
  - [ ] Assigned → PickedUp / Cancelled
  - [ ] PickedUp → OnTheWay / Cancelled
  - [ ] OnTheWay → Delivered
  - [ ] Delivered (финальный статус)
  - [ ] Cancelled → Refunded (при необходимости)
- [ ] Валидация переходов между статусами
- [ ] Сохранение истории изменений статусов
- [ ] Отправка уведомлений при изменении статуса
- [ ] Автоматическое изменение статуса (таймауты)

---

## 8. Отмена заказа

- [ ] Валидация возможности отмены (статус, время)
- [ ] Отмена заказа клиентом (до подтверждения)
- [ ] Отмена заказа рестораном
- [ ] Автоматическая отмена при таймауте
- [ ] Инициализация возврата средств (интеграция с Payment Service)
- [ ] Отправка уведомлений
- [ ] Отправка события OrderCancelled

---

## 9. Отслеживание заказа

- [ ] Получение текущего статуса заказа
- [ ] История изменений статуса
- [ ] Расчет примерного времени доставки
- [ ] Интеграция с Delivery Service для real-time отслеживания
- [ ] WebSocket для real-time обновлений (опционально)

---

## 10. Интеграции

- [ ] Интеграция с Cart Service:
  - [ ] Получение корзины
  - [ ] Очистка корзины после создания заказа
- [ ] Интеграция с Payment Service:
  - [ ] Создание платежа при создании заказа
  - [ ] Обработка результатов платежа
  - [ ] Инициализация возврата при отмене
- [ ] Интеграция с Delivery Service:
  - [ ] Получение доступных заказов для доставки
  - [ ] Назначение курьера
  - [ ] Отслеживание доставки
- [ ] Интеграция с Notification Service:
  - [ ] Отправка уведомлений о статусе заказа
  - [ ] Email, SMS, Push уведомления
- [ ] Интеграция с Restaurant Service:
  - [ ] Валидация ресторана
  - [ ] Получение информации о ресторане
- [ ] Отправка событий в Message Broker:
  - [ ] OrderCreated
  - [ ] OrderStatusChanged
  - [ ] OrderCancelled
  - [ ] OrderDelivered
- [ ] Подписка на события:
  - [ ] PaymentProcessed (из Payment Service)
  - [ ] PaymentFailed (из Payment Service)
  - [ ] CourierAssigned (из Delivery Service)

---

## 11. Автоматизация

- [ ] Автоматическое подтверждение заказа (если ресторан принимает автоматически)
- [ ] Автоматическая отмена при таймауте подтверждения
- [ ] Автоматическое изменение статуса на "Ready" по таймеру (опционально)
- [ ] Напоминания о заказах (для ресторанов и курьеров)

---

## 12. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для State Machine статусов
- [ ] Unit тесты для Application сервисов
- [ ] Integration тесты для API endpoints
- [ ] Тесты создания заказа (end-to-end)
- [ ] Тесты изменения статусов
- [ ] Тесты отмены заказа
- [ ] Тесты интеграций с другими сервисами

---

## 13. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать статусы заказа
- [ ] Документировать State Machine
- [ ] Документировать интеграции

---

## 14. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (количество заказов, среднее время доставки)
- [ ] Логирование всех изменений статусов
- [ ] Алерты на критические события

---

## 15. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить seed данные (примеры статусов)
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer (особенно State Machine)
- Infrastructure Layer
- Application Layer (OrderService, OrderStatusService)
- API Layer
- Создание заказа
- Управление статусами

**Средний приоритет:**
- Отмена заказа
- Отслеживание заказа
- Интеграции
- Автоматизация

**Низкий приоритет:**
- Расширенные функции отслеживания
- WebSocket для real-time


# TODO: Payment Service

## Общее описание
Сервис обработки платежей. Интеграция с платежными системами, управление транзакциями, возвраты, чаевые.

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
  - [ ] MediatR
  - [ ] MassTransit
  - [ ] Stripe.NET (или другие платежные SDK)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Payment (Id, OrderId, Amount, Currency, Status, PaymentMethod, PaymentProvider, TransactionId, CreatedAt, ProcessedAt)
  - [ ] PaymentMethod (Id, UserId, Type, Provider, Token, IsDefault, Last4Digits, ExpiryDate)
  - [ ] Transaction (Id, PaymentId, Type, Amount, Status, ProviderTransactionId, CreatedAt)
  - [ ] Refund (Id, PaymentId, Amount, Reason, Status, CreatedAt, ProcessedAt)
  - [ ] Tip (Id, OrderId, DeliverymanId, Amount, CreatedAt)
  - [ ] PromoCode (Id, Code, DiscountType, DiscountValue, MinOrderAmount, MaxUses, ExpiresAt, IsActive)
  - [ ] PromoCodeUsage (Id, PromoCodeId, OrderId, UserId, UsedAt)
- [ ] Создать Enum:
  - [ ] PaymentStatus (Pending, Processing, Completed, Failed, Refunded, Cancelled)
  - [ ] PaymentMethodType (Card, PayPal, ApplePay, GooglePay, Cash)
  - [ ] PaymentProvider (Stripe, PayPal, Square, Custom)
  - [ ] DiscountType (Percentage, FixedAmount)
- [ ] Создать Value Objects:
  - [ ] Money (Amount, Currency)
  - [ ] CardDetails (Last4Digits, Brand, ExpiryDate)
- [ ] Создать Domain Events:
  - [ ] PaymentProcessedEvent
  - [ ] PaymentFailedEvent
  - [ ] RefundProcessedEvent
  - [ ] TipAddedEvent
- [ ] Создать исключения:
  - [ ] PaymentNotFoundException
  - [ ] PaymentFailedException
  - [ ] InvalidPaymentMethodException
  - [ ] InsufficientFundsException
  - [ ] InvalidPromoCodeException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (PaymentDbContext)
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IPaymentRepository
  - [ ] IPaymentMethodRepository
  - [ ] ITransactionRepository
  - [ ] IRefundRepository
  - [ ] ITipRepository
  - [ ] IPromoCodeRepository
- [ ] Реализовать репозитории
- [ ] Настроить интеграцию с платежными провайдерами:
  - [ ] Stripe интеграция
  - [ ] PayPal интеграция (опционально)
  - [ ] Другие провайдеры (опционально)
- [ ] Создать интерфейсы для платежных провайдеров:
  - [ ] IPaymentProvider
  - [ ] IStripeProvider
  - [ ] IPayPalProvider
- [ ] Реализовать провайдеры
- [ ] Настроить безопасное хранение платежной информации (PCI DSS compliance)
- [ ] Настроить интеграцию с Message Broker
- [ ] Настроить интеграцию с Order Service

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] PaymentDto
  - [ ] ProcessPaymentDto
  - [ ] PaymentMethodDto
  - [ ] AddPaymentMethodDto
  - [ ] RefundDto
  - [ ] TipDto
  - [ ] PromoCodeDto
  - [ ] ValidatePromoCodeDto
  - [ ] TransactionDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] ProcessPaymentValidator
  - [ ] AddPaymentMethodValidator
  - [ ] RefundValidator
  - [ ] TipValidator
  - [ ] PromoCodeValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IPaymentService
  - [ ] IPaymentMethodService
  - [ ] IRefundService
  - [ ] ITipService
  - [ ] IPromoCodeService
- [ ] Реализовать сервисы:
  - [ ] PaymentService:
    - [ ] ProcessPaymentAsync
    - [ ] GetPaymentByIdAsync
    - [ ] GetPaymentsByOrderIdAsync
    - [ ] GetPaymentStatusAsync
  - [ ] PaymentMethodService:
    - [ ] AddPaymentMethodAsync
    - [ ] GetPaymentMethodsAsync
    - [ ] SetDefaultPaymentMethodAsync
    - [ ] DeletePaymentMethodAsync
  - [ ] RefundService:
    - [ ] ProcessRefundAsync
    - [ ] GetRefundByIdAsync
    - [ ] GetRefundsByPaymentIdAsync
  - [ ] TipService:
    - [ ] AddTipAsync
    - [ ] GetTipsByOrderIdAsync
  - [ ] PromoCodeService:
    - [ ] ValidatePromoCodeAsync
    - [ ] ApplyPromoCodeAsync
    - [ ] CalculateDiscountAsync
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] PaymentController:
    - [ ] POST /api/payment/process - обработать платеж
    - [ ] GET /api/payment/{id} - получить платеж
    - [ ] GET /api/payment/orders/{orderId} - платежи по заказу
    - [ ] GET /api/payment/transactions - история транзакций
  - [ ] PaymentMethodController:
    - [ ] GET /api/payment/methods - методы оплаты пользователя
    - [ ] POST /api/payment/methods - добавить метод оплаты
    - [ ] PUT /api/payment/methods/{id}/default - установить по умолчанию
    - [ ] DELETE /api/payment/methods/{id} - удалить метод оплаты
  - [ ] RefundController:
    - [ ] POST /api/payment/refund - обработать возврат
    - [ ] GET /api/payment/refunds/{id} - получить возврат
  - [ ] TipController:
    - [ ] POST /api/payment/tip - добавить чаевые
    - [ ] GET /api/payment/tips/orders/{orderId} - чаевые по заказу
  - [ ] PromoCodeController:
    - [ ] POST /api/payment/promocodes/validate - проверить промокод
    - [ ] POST /api/payment/promocodes/apply - применить промокод
    - [ ] GET /api/payment/promocodes - список промокодов (для админов)
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS
- [ ] Добавить авторизацию

---

## 6. Обработка платежей

- [ ] Создание платежа при создании заказа
- [ ] Интеграция с платежными провайдерами
- [ ] Обработка успешных платежей
- [ ] Обработка неудачных платежей
- [ ] Retry логика для failed платежей
- [ ] Webhook обработка от платежных провайдеров
- [ ] Идемпотентность платежей
- [ ] Отправка события PaymentProcessed/PaymentFailed

---

## 7. Управление методами оплаты

- [ ] Сохранение методов оплаты (токенизация)
- [ ] Безопасное хранение (PCI DSS compliance)
- [ ] Управление методами оплаты пользователя
- [ ] Установка метода оплаты по умолчанию
- [ ] Валидация методов оплаты
- [ ] Удаление методов оплаты

---

## 8. Возвраты и возвраты

- [ ] Инициализация возврата при отмене заказа
- [ ] Частичные возвраты
- [ ] Полные возвраты
- [ ] Обработка возвратов через платежные провайдеры
- [ ] История возвратов
- [ ] Отправка события RefundProcessed

---

## 9. Чаевые

- [ ] Добавление чаевых к заказу
- [ ] Валидация суммы чаевых
- [ ] Распределение чаевых курьеру
- [ ] История чаевых
- [ ] Отправка события TipAdded

---

## 10. Промокоды и скидки

- [ ] Создание промокодов
- [ ] Валидация промокодов (срок действия, количество использований)
- [ ] Применение промокодов
- [ ] Расчет скидки (процент или фиксированная сумма)
- [ ] Ограничения промокодов (минимальная сумма заказа)
- [ ] История использования промокодов
- [ ] Управление промокодами (для админов)

---

## 11. Безопасность

- [ ] PCI DSS compliance
- [ ] Токенизация платежной информации
- [ ] Шифрование чувствительных данных
- [ ] Валидация всех платежных запросов
- [ ] Защита от мошенничества
- [ ] Rate limiting для платежных endpoints
- [ ] Аудит всех транзакций
- [ ] Логирование без чувствительных данных

---

## 12. Интеграции

- [ ] Интеграция с Order Service:
  - [ ] Создание платежа при создании заказа
  - [ ] Обновление статуса заказа при успешном платеже
  - [ ] Инициализация возврата при отмене
- [ ] Интеграция с Cart Service:
  - [ ] Применение промокодов
- [ ] Интеграция с Delivery Service:
  - [ ] Распределение чаевых
- [ ] Отправка событий в Message Broker:
  - [ ] PaymentProcessed
  - [ ] PaymentFailed
  - [ ] RefundProcessed
  - [ ] TipAdded
- [ ] Подписка на события:
  - [ ] OrderCreated (из Order Service)
  - [ ] OrderCancelled (из Order Service)

---

## 13. Webhooks

- [ ] Настройка webhook endpoints для платежных провайдеров
- [ ] Обработка webhook событий от Stripe
- [ ] Обработка webhook событий от PayPal
- [ ] Валидация webhook подписей
- [ ] Идемпотентность обработки webhooks
- [ ] Retry логика для failed webhooks

---

## 14. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Unit тесты для платежных провайдеров (моки)
- [ ] Integration тесты для API endpoints
- [ ] Тесты обработки платежей
- [ ] Тесты возвратов
- [ ] Тесты промокодов
- [ ] Тесты безопасности
- [ ] Тесты webhooks

---

## 15. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать интеграцию с платежными провайдерами
- [ ] Документировать webhooks
- [ ] Документировать безопасность

---

## 16. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (количество платежей, успешность, средняя сумма)
- [ ] Логирование всех транзакций (без чувствительных данных)
- [ ] Алерты на failed платежи
- [ ] Мониторинг webhooks

---

## 17. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить секреты для платежных провайдеров
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию
- [ ] Настроить webhook URLs в платежных провайдерах

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer (интеграция с Stripe)
- Application Layer (PaymentService, RefundService)
- API Layer
- Обработка платежей
- Безопасность (PCI DSS)

**Средний приоритет:**
- Управление методами оплаты
- Возвраты
- Промокоды
- Webhooks

**Низкий приоритет:**
- Чаевые
- Интеграция с другими платежными провайдерами
- Расширенные функции промокодов


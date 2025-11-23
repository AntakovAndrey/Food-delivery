# TODO: Cart Service

## Общее описание
Сервис управления корзинами пользователей. Добавление/удаление блюд, расчет стоимости, применение промокодов.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок (Domain, Application, Infrastructure, API)
- [ ] Добавить необходимые NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] StackExchange.Redis (для кэширования корзин)
  - [ ] FluentValidation
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] Swashbuckle.AspNetCore
  - [ ] MediatR (опционально)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Cart (Id, UserId, RestaurantId, PromoCodeId, CreatedAt, UpdatedAt, ExpiresAt)
  - [ ] CartItem (Id, CartId, DishId, Quantity, Modifiers, UnitPrice, TotalPrice)
  - [ ] CartItemModifier (Id, CartItemId, ModifierId, OptionId)
  - [ ] PromoCode (Id, Code, DiscountType, DiscountValue, MinOrderAmount, MaxUses, ExpiresAt, IsActive)
- [ ] Создать Value Objects:
  - [ ] Money (Amount, Currency)
  - [ ] Quantity (Value, Min, Max)
- [ ] Создать Domain Events:
  - [ ] CartCreatedEvent
  - [ ] ItemAddedToCartEvent
  - [ ] ItemRemovedFromCartEvent
  - [ ] CartClearedEvent
  - [ ] PromoCodeAppliedEvent
- [ ] Создать исключения:
  - [ ] CartNotFoundException
  - [ ] DishNotAvailableException
  - [ ] InvalidPromoCodeException
  - [ ] CartExpiredException
  - [ ] MinimumOrderAmountNotMetException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (CartDbContext) для PostgreSQL
- [ ] Настроить Redis для хранения активных корзин
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] ICartRepository
  - [ ] ICartItemRepository
  - [ ] IPromoCodeRepository
- [ ] Реализовать репозитории:
  - [ ] Redis репозиторий для активных корзин
  - [ ] PostgreSQL репозиторий для истории
- [ ] Настроить интеграцию с Menu Service (проверка доступности блюд)
- [ ] Настроить интеграцию с Restaurant Service (проверка минимальной суммы заказа)

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] CartDto
  - [ ] CartItemDto
  - [ ] AddItemToCartDto
  - [ ] UpdateCartItemDto
  - [ ] ApplyPromoCodeDto
  - [ ] CartSummaryDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] AddItemToCartValidator
  - [ ] UpdateCartItemValidator
  - [ ] ApplyPromoCodeValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] ICartService
  - [ ] IPromoCodeService
  - [ ] ICartCalculationService
- [ ] Реализовать сервисы:
  - [ ] CartService:
    - [ ] GetCartAsync
    - [ ] CreateCartAsync
    - [ ] AddItemAsync
    - [ ] UpdateItemAsync
    - [ ] RemoveItemAsync
    - [ ] ClearCartAsync
    - [ ] GetCartSummaryAsync
  - [ ] PromoCodeService:
    - [ ] ValidatePromoCodeAsync
    - [ ] ApplyPromoCodeAsync
    - [ ] RemovePromoCodeAsync
  - [ ] CartCalculationService:
    - [ ] CalculateSubtotal
    - [ ] CalculateDiscount
    - [ ] CalculateDeliveryFee
    - [ ] CalculateTotal
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] CartController:
    - [ ] GET /api/cart - получить корзину пользователя
    - [ ] POST /api/cart/items - добавить блюдо в корзину
    - [ ] PUT /api/cart/items/{itemId} - изменить количество
    - [ ] DELETE /api/cart/items/{itemId} - удалить блюдо
    - [ ] DELETE /api/cart - очистить корзину
    - [ ] GET /api/cart/summary - получить итоговую сумму
    - [ ] POST /api/cart/promocode - применить промокод
    - [ ] DELETE /api/cart/promocode - удалить промокод
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS
- [ ] Добавить авторизацию (только для авторизованных пользователей)

---

## 6. Валидация корзины

- [ ] Проверка доступности блюд (интеграция с Menu Service)
- [ ] Проверка минимальной суммы заказа ресторана
- [ ] Валидация модификаторов блюд
- [ ] Проверка актуальности цен
- [ ] Валидация промокодов
- [ ] Проверка срока действия корзины

---

## 7. Расчет стоимости

- [ ] Расчет стоимости блюд с учетом количества
- [ ] Расчет стоимости модификаторов
- [ ] Применение промокодов (процент или фиксированная сумма)
- [ ] Расчет стоимости доставки (интеграция с Delivery Service)
- [ ] Расчет итоговой суммы
- [ ] Валидация минимальной суммы заказа

---

## 8. Промокоды и скидки

- [ ] Создание промокодов
- [ ] Валидация промокодов (срок действия, количество использований)
- [ ] Применение промокодов к корзине
- [ ] Расчет скидки (процент или фиксированная сумма)
- [ ] Ограничения промокодов (минимальная сумма заказа)
- [ ] История использования промокодов

---

## 9. Кэширование в Redis

- [ ] Хранение активных корзин в Redis
- [ ] Настройка TTL для корзин (автоматическое истечение)
- [ ] Сериализация/десериализация корзин
- [ ] Инвалидация кэша при обновлении
- [ ] Миграция корзин из Redis в PostgreSQL при создании заказа

---

## 10. Интеграции

- [ ] Интеграция с Menu Service:
  - [ ] Проверка доступности блюд
  - [ ] Получение актуальных цен
  - [ ] Валидация модификаторов
- [ ] Интеграция с Restaurant Service:
  - [ ] Проверка минимальной суммы заказа
  - [ ] Получение стоимости доставки
- [ ] Интеграция с Identity Service:
  - [ ] Проверка авторизации пользователя
- [ ] Отправка событий в Message Broker:
  - [ ] ItemAddedToCart
  - [ ] ItemRemovedFromCart
  - [ ] CartCleared
  - [ ] PromoCodeApplied
- [ ] Подписка на события:
  - [ ] DishAvailabilityChanged (из Menu Service)
  - [ ] PriceChanged (из Menu Service)

---

## 11. Управление жизненным циклом корзины

- [ ] Автоматическое создание корзины при первом добавлении блюда
- [ ] Автоматическое истечение неактивных корзин
- [ ] Очистка корзины после создания заказа
- [ ] Сохранение истории корзин в PostgreSQL
- [ ] Восстановление корзины из истории

---

## 12. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Unit тесты для расчета стоимости
- [ ] Unit тесты для валидации промокодов
- [ ] Integration тесты для API endpoints
- [ ] Тесты интеграции с Redis
- [ ] Тесты производительности

---

## 13. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать модели данных
- [ ] Документировать промокоды

---

## 14. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (количество корзин, средний размер корзины)
- [ ] Логирование важных операций

---

## 15. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить Redis подключение
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer (Redis, PostgreSQL)
- Application Layer (CartService, CartCalculationService)
- API Layer
- Валидация корзины
- Расчет стоимости

**Средний приоритет:**
- Промокоды и скидки
- Кэширование в Redis
- Интеграции

**Низкий приоритет:**
- Расширенные функции промокодов
- Аналитика корзин


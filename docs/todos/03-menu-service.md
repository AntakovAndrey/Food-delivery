# TODO: Menu Service

## Общее описание
Сервис управления меню и блюдами ресторанов. Управление блюдами, категориями блюд, ценами, доступностью.

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
  - [ ] MediatR (опционально, для CQRS)
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] Dish (Id, Name, Description, Price, Weight, PhotoURL, CategoryId, RestaurantId, IsAvailable, CreatedAt, UpdatedAt)
  - [ ] DishCategory (Id, Name, Description, RestaurantId, Order)
  - [ ] DishModifier (Id, DishId, Name, Type, Options, IsRequired)
  - [ ] ModifierOption (Id, ModifierId, Name, Price, IsDefault)
  - [ ] DishImage (Id, DishId, ImageURL, IsPrimary, Order)
  - [ ] DishNutrition (Id, DishId, Calories, Proteins, Fats, Carbs, Allergens)
  - [ ] Menu (Id, RestaurantId, Name, IsActive, StartDate, EndDate)
  - [ ] MenuSection (Id, MenuId, Name, Order)
- [ ] Создать Value Objects:
  - [ ] Price (Amount, Currency)
  - [ ] Weight (Value, Unit)
- [ ] Создать Domain Events:
  - [ ] DishCreatedEvent
  - [ ] DishUpdatedEvent
  - [ ] DishAvailabilityChangedEvent
  - [ ] PriceChangedEvent
- [ ] Создать исключения:
  - [ ] DishNotFoundException
  - [ ] DishNotAvailableException
  - [ ] InvalidPriceException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (MenuDbContext)
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IDishRepository
  - [ ] IDishCategoryRepository
  - [ ] IMenuRepository
  - [ ] IDishModifierRepository
- [ ] Реализовать репозитории с поддержкой:
  - [ ] Фильтрации по ресторану
  - [ ] Фильтрации по категории
  - [ ] Фильтрации по доступности
  - [ ] Поиска по названию
  - [ ] Пагинации
- [ ] Настроить Redis для кэширования меню ресторанов
- [ ] Создать сервис для работы с изображениями (IStorageService)
- [ ] Настроить интеграцию с Restaurant Service для валидации ресторанов

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] DishDto
  - [ ] CreateDishDto
  - [ ] UpdateDishDto
  - [ ] DishListDto
  - [ ] DishCategoryDto
  - [ ] DishModifierDto
  - [ ] MenuDto
  - [ ] DishSearchRequestDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] CreateDishValidator
  - [ ] UpdateDishValidator
  - [ ] PriceValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IDishService
  - [ ] IDishCategoryService
  - [ ] IMenuService
- [ ] Реализовать сервисы:
  - [ ] DishService:
    - [ ] GetByIdAsync
    - [ ] GetByRestaurantIdAsync
    - [ ] GetByCategoryIdAsync
    - [ ] SearchAsync
    - [ ] CreateAsync
    - [ ] UpdateAsync
    - [ ] DeleteAsync
    - [ ] UpdateAvailabilityAsync
    - [ ] UpdatePriceAsync
  - [ ] DishCategoryService:
    - [ ] GetByRestaurantIdAsync
    - [ ] GetByIdAsync
    - [ ] CreateAsync
    - [ ] UpdateAsync
    - [ ] DeleteAsync
  - [ ] MenuService:
    - [ ] GetRestaurantMenuAsync
    - [ ] CreateMenuAsync
    - [ ] UpdateMenuAsync
    - [ ] ActivateMenuAsync
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] DishController:
    - [ ] GET /api/menu/dishes/{id}
    - [ ] GET /api/menu/restaurants/{restaurantId}/dishes
    - [ ] GET /api/menu/categories/{categoryId}/dishes
    - [ ] GET /api/menu/dishes/search?query={query}
    - [ ] POST /api/menu/dishes (только RestaurantAdmin)
    - [ ] PUT /api/menu/dishes/{id}
    - [ ] DELETE /api/menu/dishes/{id}
    - [ ] PUT /api/menu/dishes/{id}/availability
    - [ ] PUT /api/menu/dishes/{id}/price
  - [ ] DishCategoryController:
    - [ ] GET /api/menu/restaurants/{restaurantId}/categories
    - [ ] GET /api/menu/categories/{id}
    - [ ] POST /api/menu/categories
    - [ ] PUT /api/menu/categories/{id}
    - [ ] DELETE /api/menu/categories/{id}
  - [ ] MenuController:
    - [ ] GET /api/menu/restaurants/{restaurantId}/menu
    - [ ] POST /api/menu/menus
    - [ ] PUT /api/menu/menus/{id}
- [ ] Настроить Swagger документацию
- [ ] Добавить обработку ошибок
- [ ] Настроить CORS
- [ ] Добавить кэширование меню

---

## 6. Управление доступностью

- [ ] Реализовать изменение доступности блюда
- [ ] Автоматическое скрытие при отсутствии ингредиентов (интеграция с Inventory Service - опционально)
- [ ] Временное изменение цен (акции, скидки)
- [ ] Уведомление других сервисов об изменении доступности
- [ ] История изменений доступности

---

## 7. Модификаторы блюд

- [ ] Реализовать создание модификаторов (размеры, дополнения)
- [ ] Управление опциями модификаторов
- [ ] Расчет цены с учетом модификаторов
- [ ] Валидация обязательных модификаторов
- [ ] Отображение модификаторов в API

---

## 8. Управление изображениями

- [ ] Создать endpoint для загрузки изображений блюд
- [ ] Валидация форматов изображений
- [ ] Ресайз изображений (оптимизация)
- [ ] Хранение в облачном хранилище
- [ ] Поддержка множественных изображений
- [ ] Удаление старых изображений

---

## 9. Поиск и фильтрация

- [ ] Полнотекстовый поиск по названию и описанию
- [ ] Фильтрация по категории
- [ ] Фильтрация по цене (диапазон)
- [ ] Фильтрация по доступности
- [ ] Фильтрация по ресторану
- [ ] Сортировка (по цене, популярности, названию)
- [ ] Пагинация результатов

---

## 10. Интеграции

- [ ] Интеграция с Restaurant Service для валидации ресторанов
- [ ] Отправка событий в Message Broker:
  - [ ] DishCreated
  - [ ] DishUpdated
  - [ ] DishAvailabilityChanged
  - [ ] PriceChanged
- [ ] Подписка на события из других сервисов
- [ ] Интеграция с Cart Service (проверка доступности при добавлении)
- [ ] Интеграция с Review Service для отображения рейтингов блюд

---

## 11. Кэширование

- [ ] Кэширование меню ресторанов
- [ ] Кэширование списка категорий
- [ ] Кэширование популярных блюд
- [ ] Инвалидация кэша при обновлении данных
- [ ] Настроить TTL для кэша

---

## 12. Питательная информация

- [ ] Реализовать хранение питательной информации (калории, БЖУ)
- [ ] Управление аллергенами
- [ ] API для получения питательной информации
- [ ] Фильтрация по диетическим требованиям (веган, без глютена и т.д.)

---

## 13. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Unit тесты для валидации цен
- [ ] Integration тесты для API endpoints
- [ ] Тесты поиска и фильтрации
- [ ] Тесты модификаторов

---

## 14. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии
- [ ] Создать примеры запросов/ответов
- [ ] Документировать модели данных
- [ ] Документировать модификаторы

---

## 15. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики
- [ ] Логирование важных операций (создание, обновление, изменение цен)

---

## 16. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить seed данные (примеры категорий)
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer
- Application Layer (DishService, DishCategoryService)
- API Layer
- Управление доступностью

**Средний приоритет:**
- Модификаторы блюд
- Управление изображениями
- Поиск и фильтрация
- Кэширование

**Низкий приоритет:**
- Питательная информация
- Расширенные функции меню


# Food Delivery - Система доставки еды

## Описание проекта

Food Delivery - это масштабируемая система доставки еды, построенная на микросервисной архитектуре. Проект находится в стадии переписывания с монолитной архитектуры на современную микросервисную платформу.

**Текущий статус**: Backend переписывается на микросервисную архитектуру. Frontend будет переписан в следующей фазе разработки.

## Архитектура системы

### Микросервисная архитектура

Система разделена на независимые микросервисы, каждый из которых отвечает за свою бизнес-доменную область:

```
┌─────────────────────────────────────────────────────────────┐
│                    API Gateway                              │
│              (Routing, Load Balancing)                      │
└─────────────────────────────────────────────────────────────┘
                            │
        ┌───────────────────┼───────────────────┐
        │                   │                   │
┌───────▼────────┐  ┌──────▼──────┐  ┌────────▼────────┐
│ Identity       │  │ Restaurant  │  │ Menu Service    │
│ Service        │  │ Service     │  │                 │
└────────────────┘  └─────────────┘  └─────────────────┘
        │                  │                  │
┌───────▼────────┐  ┌──────▼──────┐  ┌────────▼────────┐
│ Cart Service   │  │ Order       │  │ Delivery        │
│                │  │ Service     │  │ Service         │
└────────────────┘  └─────────────┘  └─────────────────┘
        │                  │                   │
┌───────▼────────┐  ┌──────▼───────┐  ┌────────▼────────┐
│ Payment        │  │ Notification │  │ Analytics       │
│ Service        │  │ Service      │  │ Service         │
└────────────────┘  └──────────────┘  └─────────────────┘
```

## Технологический стек

### Backend (Микросервисы)
- **.NET 9.0** - основная платформа для всех микросервисов
- **ASP.NET Core WebAPI** - RESTful API
- **Entity Framework Core 9.0** - ORM для работы с базами данных
- **PostgreSQL / SQL Server** - базы данных (каждый сервис имеет свою БД)
- **Redis** - кэширование и очереди сообщений
- **RabbitMQ / Apache Kafka** - обмен сообщениями между сервисами
- **JWT Authentication** - аутентификация и авторизация
- **Ocelot / YARP** - API Gateway
- **Docker & Docker Compose** - контейнеризация и оркестрация
- **Swagger/OpenAPI** - документация API
- **Serilog** - логирование
- **Health Checks** - мониторинг здоровья сервисов

### Frontend (Будет переписан)
- Планируется современный стек (React/Vue/Angular)
- Интеграция с микросервисами через API Gateway

## Микросервисы и их функциональность

### 1. Identity Service (Сервис аутентификации и авторизации)

**Ответственность**: Управление пользователями, аутентификация, авторизация, управление ролями и правами доступа.

#### Функционал:
- ✅ **Регистрация пользователей**
  - Создание нового аккаунта
  - Валидация данных
  - Хеширование паролей (BCrypt/Argon2)
  - Email верификация

- ✅ **Аутентификация**
  - Вход по email/паролю
  - JWT токены (Access + Refresh tokens)
  - OAuth 2.0 интеграция (Google, Facebook)
  - Двухфакторная аутентификация (2FA)

- ✅ **Управление профилями**
  - Обновление профиля пользователя
  - Смена пароля
  - Управление адресами доставки
  - Загрузка аватара

- ✅ **Управление ролями**
  - User (клиент)
  - Admin (администратор системы)
  - Deliveryman (курьер)
  - RestaurantAdmin (администратор ресторана)
  - Support (поддержка)

- ✅ **Авторизация**
  - Role-based access control (RBAC)
  - Policy-based authorization
  - Управление сессиями

**API Endpoints:**
- `POST /api/identity/register` - регистрация
- `POST /api/identity/login` - вход
- `POST /api/identity/refresh-token` - обновление токена
- `POST /api/identity/logout` - выход
- `GET /api/identity/profile` - профиль пользователя
- `PUT /api/identity/profile` - обновление профиля
- `POST /api/identity/change-password` - смена пароля
- `POST /api/identity/verify-email` - верификация email
- `POST /api/identity/forgot-password` - восстановление пароля

**База данных**: PostgreSQL (IdentityDB)

---

### 2. Restaurant Service (Сервис ресторанов)

**Ответственность**: Управление ресторанами, их информацией, категориями, рейтингами и настройками.

#### Функционал:
- ✅ **Управление ресторанами**
  - Создание, обновление, удаление ресторанов
  - Получение списка ресторанов с пагинацией
  - Поиск ресторанов по названию, адресу
  - Фильтрация по категориям, рейтингу, расстоянию
  - Детальная информация о ресторане

- ✅ **Категории ресторанов**
  - Управление категориями (Итальянская, Азиатская, Фастфуд и т.д.)
  - Получение ресторанов по категории

- ✅ **Рейтинги и отзывы**
  - Расчет среднего рейтинга на основе отзывов
  - Отображение рейтинга ресторана
  - История изменений рейтинга

- ✅ **Геолокация**
  - Координаты ресторана
  - Поиск ресторанов в радиусе
  - Расчет расстояния до клиента

- ✅ **Настройки ресторана**
  - Время работы
  - Минимальная сумма заказа
  - Время доставки
  - Стоимость доставки
  - Статус (открыт/закрыт)

- ✅ **Медиа**
  - Загрузка фотографий ресторана
  - Галерея изображений

**API Endpoints:**
- `GET /api/restaurants` - список ресторанов (с фильтрами и пагинацией)
- `GET /api/restaurants/{id}` - детали ресторана
- `POST /api/restaurants` - создание ресторана (только RestaurantAdmin)
- `PUT /api/restaurants/{id}` - обновление ресторана
- `DELETE /api/restaurants/{id}` - удаление ресторана
- `GET /api/restaurants/search?query={query}` - поиск ресторанов
- `GET /api/restaurants/nearby?lat={lat}&lng={lng}&radius={km}` - рестораны рядом
- `GET /api/restaurants/categories` - категории ресторанов
- `GET /api/restaurants/categories/{id}/restaurants` - рестораны по категории
- `GET /api/restaurants/{id}/rating` - рейтинг ресторана

**База данных**: PostgreSQL (RestaurantDB)

---

### 3. Menu Service (Сервис меню и блюд)

**Ответственность**: Управление меню ресторанов, блюдами, категориями блюд, ценами и доступностью.

#### Функционал:
- ✅ **Управление блюдами**
  - Создание, обновление, удаление блюд
  - Получение блюд ресторана
  - Детальная информация о блюде
  - Фильтрация по категориям, цене, доступности

- ✅ **Категории блюд**
  - Управление категориями (Супы, Салаты, Горячее и т.д.)
  - Получение блюд по категории

- ✅ **Меню ресторана**
  - Структурированное меню ресторана
  - Сезонные меню
  - Специальные предложения

- ✅ **Управление доступностью**
  - Отметка блюда как недоступного
  - Автоматическое скрытие при отсутствии ингредиентов
  - Временные изменения цен

- ✅ **Модификаторы блюд**
  - Размеры порций
  - Дополнительные ингредиенты
  - Варианты приготовления

- ✅ **Медиа**
  - Загрузка фотографий блюд
  - Галерея изображений

**API Endpoints:**
- `GET /api/menu/restaurants/{restaurantId}/dishes` - блюда ресторана
- `GET /api/menu/dishes/{id}` - детали блюда
- `POST /api/menu/dishes` - создание блюда (RestaurantAdmin)
- `PUT /api/menu/dishes/{id}` - обновление блюда
- `DELETE /api/menu/dishes/{id}` - удаление блюда
- `GET /api/menu/restaurants/{restaurantId}/categories` - категории блюд ресторана
- `GET /api/menu/categories/{id}/dishes` - блюда по категории
- `GET /api/menu/restaurants/{restaurantId}/menu` - полное меню ресторана
- `PUT /api/menu/dishes/{id}/availability` - изменение доступности
- `GET /api/menu/dishes/search?query={query}` - поиск блюд

**База данных**: PostgreSQL (MenuDB)

---

### 4. Cart Service (Сервис корзины)

**Ответственность**: Управление корзинами пользователей, добавление/удаление блюд, расчет стоимости.

#### Функционал:
- ✅ **Управление корзиной**
  - Создание корзины для пользователя
  - Добавление блюд в корзину
  - Удаление блюд из корзины
  - Изменение количества блюд
  - Очистка корзины

- ✅ **Валидация корзины**
  - Проверка доступности блюд
  - Проверка минимальной суммы заказа ресторана
  - Валидация модификаторов блюд

- ✅ **Расчет стоимости**
  - Расчет стоимости корзины
  - Применение промокодов
  - Расчет стоимости доставки
  - Итоговая сумма

- ✅ **Кэширование**
  - Хранение корзины в Redis для быстрого доступа
  - Автоматическое истечение неактивных корзин

**API Endpoints:**
- `GET /api/cart` - получить корзину пользователя
- `POST /api/cart/items` - добавить блюдо в корзину
- `PUT /api/cart/items/{itemId}` - изменить количество
- `DELETE /api/cart/items/{itemId}` - удалить блюдо
- `DELETE /api/cart` - очистить корзину
- `GET /api/cart/total` - расчет итоговой суммы
- `POST /api/cart/apply-promocode` - применить промокод
- `DELETE /api/cart/promocode` - удалить промокод

**База данных**: Redis (кэш) + PostgreSQL (CartDB для истории)

---

### 5. Order Service (Сервис заказов)

**Ответственность**: Создание заказов, управление жизненным циклом заказа, отслеживание статусов.

#### Функционал:
- ✅ **Создание заказов**
  - Создание заказа из корзины
  - Валидация данных заказа
  - Расчет итоговой стоимости
  - Очистка корзины после создания заказа

- ✅ **Управление статусами заказа**
  - `Pending` - заказ создан, ожидает подтверждения
  - `Confirmed` - заказ подтвержден рестораном
  - `Preparing` - заказ готовится
  - `Ready` - заказ готов к доставке
  - `Assigned` - заказ назначен курьеру
  - `PickedUp` - курьер забрал заказ
  - `OnTheWay` - заказ в пути
  - `Delivered` - заказ доставлен
  - `Cancelled` - заказ отменен
  - `Refunded` - заказ возвращен

- ✅ **Просмотр заказов**
  - История заказов пользователя
  - Активные заказы
  - Заказы ресторана
  - Заказы курьера

- ✅ **Отмена заказов**
  - Отмена заказа клиентом (до подтверждения)
  - Отмена заказа рестораном
  - Автоматическая отмена при таймауте

- ✅ **Уведомления о статусе**
  - Отправка событий в Notification Service
  - WebSocket для real-time обновлений

**API Endpoints:**
- `POST /api/orders` - создать заказ
- `GET /api/orders` - список заказов пользователя
- `GET /api/orders/{id}` - детали заказа
- `GET /api/orders/active` - активные заказы
- `PUT /api/orders/{id}/status` - изменить статус
- `POST /api/orders/{id}/cancel` - отменить заказ
- `GET /api/orders/restaurants/{restaurantId}` - заказы ресторана
- `GET /api/orders/deliverymen/{deliverymanId}` - заказы курьера
- `GET /api/orders/{id}/tracking` - отслеживание заказа

**База данных**: PostgreSQL (OrderDB)

**События (Events):**
- `OrderCreated`
- `OrderStatusChanged`
- `OrderCancelled`
- `OrderDelivered`

---

### 6. Delivery Service (Сервис доставки)

**Ответственность**: Управление доставкой, назначение курьеров, отслеживание доставки в реальном времени.

#### Функционал:
- ✅ **Управление курьерами**
  - Регистрация курьеров
  - Статус курьера (доступен/занят/недоступен)
  - Текущее местоположение курьера
  - История доставок

- ✅ **Назначение курьеров**
  - Автоматическое назначение ближайшего курьера
  - Ручное назначение администратором
  - Принятие заказа курьером

- ✅ **Отслеживание доставки**
  - Real-time отслеживание местоположения курьера
  - Расчет примерного времени доставки
  - История маршрута

- ✅ **Оптимизация маршрутов**
  - Построение оптимального маршрута
  - Группировка заказов для одного курьера
  - Учет загруженности курьеров

- ✅ **Рейтинг курьеров**
  - Расчет рейтинга на основе отзывов
  - Статистика доставок

**API Endpoints:**
- `GET /api/delivery/available-orders` - доступные заказы для доставки
- `POST /api/delivery/orders/{orderId}/assign` - назначить курьера
- `POST /api/delivery/orders/{orderId}/accept` - принять заказ (курьер)
- `POST /api/delivery/orders/{orderId}/pickup` - отметить как забран
- `POST /api/delivery/orders/{orderId}/deliver` - отметить как доставлен
- `GET /api/delivery/orders/{orderId}/tracking` - отслеживание доставки
- `PUT /api/delivery/couriers/{id}/location` - обновить местоположение курьера
- `GET /api/delivery/couriers/{id}/status` - статус курьера
- `PUT /api/delivery/couriers/{id}/status` - изменить статус курьера

**База данных**: PostgreSQL (DeliveryDB)

**События (Events):**
- `CourierAssigned`
- `CourierLocationUpdated`
- `OrderPickedUp`
- `OrderDelivered`

---

### 7. Payment Service (Сервис платежей)

**Ответственность**: Обработка платежей, управление транзакциями, возвраты, интеграция с платежными системами.

#### Функционал:
- ✅ **Обработка платежей**
  - Интеграция с платежными системами (Stripe, PayPal, и др.)
  - Обработка карт, электронных кошельков
  - Безопасное хранение платежной информации (PCI DSS)

- ✅ **Управление транзакциями**
  - История транзакций
  - Статусы платежей
  - Обработка ошибок платежей

- ✅ **Возвраты и возвраты**
  - Обработка возвратов
  - Частичные возвраты
  - Автоматические возвраты при отмене заказа

- ✅ **Чаевые**
  - Добавление чаевых курьеру
  - Распределение чаевых

- ✅ **Промокоды и скидки**
  - Применение промокодов
  - Автоматические скидки
  - Накопительные программы

**API Endpoints:**
- `POST /api/payment/process` - обработать платеж
- `GET /api/payment/transactions` - история транзакций
- `GET /api/payment/transactions/{id}` - детали транзакции
- `POST /api/payment/refund` - возврат средств
- `POST /api/payment/tip` - добавить чаевые
- `POST /api/payment/promocodes/validate` - проверить промокод
- `POST /api/payment/promocodes/apply` - применить промокод

**База данных**: PostgreSQL (PaymentDB)

**События (Events):**
- `PaymentProcessed`
- `PaymentFailed`
- `RefundProcessed`

---

### 8. Notification Service (Сервис уведомлений)

**Ответственность**: Отправка уведомлений пользователям через различные каналы.

#### Функционал:
- ✅ **Email уведомления**
  - Подтверждение регистрации
  - Уведомления о статусе заказа
  - Промо-рассылки

- ✅ **SMS уведомления**
  - Код подтверждения
  - Уведомления о доставке

- ✅ **Push уведомления**
  - Мобильные push-уведомления
  - Web push-уведомления

- ✅ **In-app уведомления**
  - Уведомления в приложении
  - История уведомлений

- ✅ **Шаблоны уведомлений**
  - Многоязычные шаблоны
  - Персонализация

**API Endpoints:**
- `POST /api/notifications/send` - отправить уведомление
- `GET /api/notifications` - история уведомлений пользователя
- `PUT /api/notifications/{id}/read` - отметить как прочитанное
- `PUT /api/notifications/preferences` - настройки уведомлений
- `POST /api/notifications/subscribe` - подписка на push-уведомления

**База данных**: PostgreSQL (NotificationDB)

**События (Events):**
- Подписка на события от других сервисов
- `NotificationSent`

---

### 9. Review Service (Сервис отзывов и рейтингов) - НОВАЯ ФИЧА

**Ответственность**: Управление отзывами, рейтингами ресторанов, блюд и курьеров.

#### Функционал:
- ✅ **Отзывы о ресторанах**
  - Создание отзывов
  - Редактирование отзывов
  - Модерация отзывов
  - Расчет среднего рейтинга

- ✅ **Отзывы о блюдах**
  - Оценка блюд
  - Текстовые отзывы
  - Фотографии блюд

- ✅ **Отзывы о курьерах**
  - Оценка качества доставки
  - Оценка вежливости
  - Влияние на рейтинг курьера

- ✅ **Модерация**
  - Автоматическая модерация
  - Ручная модерация администраторами
  - Фильтрация спама

**API Endpoints:**
- `POST /api/reviews/restaurants/{restaurantId}` - создать отзыв о ресторане
- `POST /api/reviews/dishes/{dishId}` - создать отзыв о блюде
- `POST /api/reviews/delivery/{orderId}` - создать отзыв о доставке
- `GET /api/reviews/restaurants/{restaurantId}` - отзывы о ресторане
- `GET /api/reviews/dishes/{dishId}` - отзывы о блюде
- `PUT /api/reviews/{id}` - обновить отзыв
- `DELETE /api/reviews/{id}` - удалить отзыв
- `GET /api/reviews/restaurants/{restaurantId}/rating` - рейтинг ресторана

**База данных**: PostgreSQL (ReviewDB)

---

### 10. Analytics Service (Сервис аналитики) - НОВАЯ ФИЧА

**Ответственность**: Сбор и анализ данных, генерация отчетов, бизнес-аналитика.

#### Функционал:
- ✅ **Аналитика для ресторанов**
  - Статистика заказов
  - Популярные блюда
  - Пиковые часы
  - Выручка по периодам
  - Конверсия

- ✅ **Аналитика для администраторов**
  - Общая статистика платформы
  - Активность пользователей
  - Топ рестораны
  - Географическая аналитика

- ✅ **Отчеты**
  - Ежедневные отчеты
  - Недельные отчеты
  - Месячные отчеты
  - Экспорт в Excel/PDF

- ✅ **Дашборды**
  - Real-time дашборды
  - Визуализация данных
  - Графики и диаграммы

**API Endpoints:**
- `GET /api/analytics/restaurants/{restaurantId}/overview` - обзор статистики ресторана
- `GET /api/analytics/restaurants/{restaurantId}/orders` - статистика заказов
- `GET /api/analytics/restaurants/{restaurantId}/dishes` - популярные блюда
- `GET /api/analytics/restaurants/{restaurantId}/revenue` - выручка
- `GET /api/analytics/admin/platform-overview` - обзор платформы
- `GET /api/analytics/reports/generate` - сгенерировать отчет
- `GET /api/analytics/dashboards/{dashboardId}` - данные дашборда

**База данных**: PostgreSQL (AnalyticsDB) + ClickHouse (для больших данных)

---

### 11. API Gateway

**Ответственность**: Единая точка входа для всех клиентских запросов, маршрутизация, балансировка нагрузки, аутентификация.

#### Функционал:
- ✅ **Маршрутизация**
  - Маршрутизация запросов к соответствующим микросервисам
  - Load balancing

- ✅ **Аутентификация**
  - Проверка JWT токенов
  - Перенаправление на Identity Service

- ✅ **Rate Limiting**
  - Ограничение количества запросов
  - Защита от DDoS

- ✅ **Логирование**
  - Централизованное логирование запросов
  - Мониторинг

- ✅ **Кэширование**
  - Кэширование часто запрашиваемых данных

**Технологии**: Ocelot / YARP (Yet Another Reverse Proxy)

---

## Дополнительные компоненты

### Message Broker (RabbitMQ / Apache Kafka)
- Асинхронная коммуникация между сервисами
- Event-driven архитектура
- Очереди сообщений
- Обработка событий

### Redis
- Кэширование данных
- Сессии пользователей
- Очереди задач
- Pub/Sub для real-time обновлений

### Service Discovery
- Автоматическое обнаружение сервисов
- Health checks
- Балансировка нагрузки

### Centralized Logging
- Aggregation логов из всех сервисов
- ELK Stack (Elasticsearch, Logstash, Kibana) или Seq
- Поиск и анализ логов

### Monitoring & Observability
- Prometheus + Grafana для метрик
- Distributed tracing (Jaeger/Zipkin)
- Health checks endpoints
- Alerting

---

## Docker Compose структура

Проект использует Docker Compose для оркестрации всех микросервисов и зависимостей:

```yaml
services:
  # API Gateway
  api-gateway:
    build: ./src/ApiGateway
    ports:
      - "5000:80"
    depends_on:
      - identity-service
      - restaurant-service
      # ... другие сервисы
  
  # Микросервисы
  identity-service:
    build: ./src/Services/Identity
    environment:
      - ConnectionStrings__DefaultConnection=...
    depends_on:
      - identity-db
      - redis
  
  restaurant-service:
    build: ./src/Services/Restaurant
    depends_on:
      - restaurant-db
      - redis
  
  # ... остальные сервисы
  
  # Базы данных
  identity-db:
    image: postgres:15
    environment:
      POSTGRES_DB: identitydb
      POSTGRES_USER: postgres
      POSTGRES_PASSWORD: postgres
  
  # Redis
  redis:
    image: redis:7-alpine
  
  # Message Broker
  rabbitmq:
    image: rabbitmq:3-management
    ports:
      - "5672:5672"
      - "15672:15672"
  
  # Monitoring
  prometheus:
    image: prom/prometheus
    volumes:
      - ./monitoring/prometheus.yml:/etc/prometheus/prometheus.yml
  
  grafana:
    image: grafana/grafana
    ports:
      - "3001:3000"
```

---

## Новые функции (планируемые)

### 1. Система лояльности
- [ ] Накопительные баллы
- [ ] Программа лояльности
- [ ] Скидки для постоянных клиентов
- [ ] Реферальная программа

### 2. Расширенный поиск и фильтры
- [ ] Поиск по ингредиентам
- [ ] Фильтры по диетическим требованиям (веган, без глютена и т.д.)
- [ ] Фильтры по цене, рейтингу, времени доставки
- [ ] Сохраненные поиски

### 3. Подписки и абонементы
- [ ] Подписка на рестораны
- [ ] Абонементы на доставку
- [ ] Семейные подписки

### 4. Групповые заказы
- [ ] Совместные заказы
- [ ] Разделение счета
- [ ] Групповые скидки

### 5. Предзаказы
- [ ] Заказ на определенное время
- [ ] Планирование заказов
- [ ] Повторяющиеся заказы

### 6. Интеграция с социальными сетями
- [ ] Вход через социальные сети
- [ ] Поделиться заказом
- [ ] Интеграция с Instagram/Facebook

### 7. Многоязычность
- [ ] Поддержка нескольких языков
- [ ] Локализация интерфейса
- [ ] Локализация контента

### 8. Расширенная аналитика
- [ ] Machine Learning для рекомендаций
- [ ] Прогнозирование спроса
- [ ] Оптимизация меню

### 9. Безопасность
- [ ] Rate limiting
- [ ] DDoS защита
- [ ] WAF (Web Application Firewall)
- [ ] Аудит безопасности

### 10. Мобильные приложения
- [ ] iOS приложение
- [ ] Android приложение
- [ ] React Native / Flutter

---

## Установка и запуск

### Предварительные требования

- Docker Desktop (Windows/Mac) или Docker + Docker Compose (Linux)
- .NET 9.0 SDK (для локальной разработки)
- Git

### Запуск через Docker Compose

1. Клонируйте репозиторий:
```bash
git clone <repository-url>
cd Food-delivery
```

2. Настройте переменные окружения:
```bash
cp .env.example .env
# Отредактируйте .env файл с необходимыми настройками
```

3. Запустите все сервисы:
```bash
docker-compose up -d
```

4. Проверьте статус сервисов:
```bash
docker-compose ps
```

5. API Gateway будет доступен по адресу: `http://localhost:5000`
6. Swagger документация: `http://localhost:5000/swagger`
7. RabbitMQ Management: `http://localhost:15672` (guest/guest)
8. Grafana: `http://localhost:3001` (admin/admin)

### Локальная разработка

1. Убедитесь, что запущены зависимости (PostgreSQL, Redis, RabbitMQ):
```bash
docker-compose up -d postgres redis rabbitmq
```

2. Запустите конкретный микросервис:
```bash
cd src/Services/Identity
dotnet run
```

3. Для запуска API Gateway:
```bash
cd src/ApiGateway
dotnet run
```

---

## Структура проекта

```
Food-delivery/
├── src/
│   ├── ApiGateway/              # API Gateway
│   ├── Services/
│   │   ├── Identity/            # Identity Service
│   │   ├── Restaurant/          # Restaurant Service
│   │   ├── Menu/                # Menu Service
│   │   ├── Cart/                # Cart Service
│   │   ├── Order/               # Order Service
│   │   ├── Delivery/            # Delivery Service
│   │   ├── Payment/             # Payment Service
│   │   ├── Notification/        # Notification Service
│   │   ├── Review/              # Review Service
│   │   └── Analytics/           # Analytics Service
│   └── Shared/                  # Общие библиотеки
│       ├── Contracts/           # Контракты/интерфейсы
│       ├── Events/              # События
│       └── Infrastructure/      # Общая инфраструктура
├── docker-compose.yml            # Docker Compose конфигурация
├── docker-compose.override.yml  # Переопределения для разработки
├── .env.example                 # Пример переменных окружения
└── README.md                    # Этот файл
```

---

## Разработка

### Соглашения о коде

- **C# Coding Standards**: Следование Microsoft C# Coding Conventions
- **RESTful API**: Следование REST принципам
- **Clean Architecture**: Разделение на слои (Domain, Application, Infrastructure, API)
- **SOLID принципы**: Применение SOLID в архитектуре
- **DDD**: Domain-Driven Design подходы где применимо

### Тестирование

- Unit тесты для бизнес-логики
- Integration тесты для API
- E2E тесты для критических сценариев
- Использование xUnit, Moq, FluentAssertions

### CI/CD

- GitHub Actions / GitLab CI для автоматизации
- Автоматические тесты при коммитах
- Автоматический деплой при merge в main
- Docker образы для каждого сервиса

---

## Лицензия

См. файл [LICENSE](LICENSE)

---

## Roadmap

### Фаза 1: Backend (Текущая)
- [x] Проектирование архитектуры
- [ ] Реализация Identity Service
- [ ] Реализация Restaurant Service
- [ ] Реализация Menu Service
- [ ] Реализация Cart Service
- [ ] Реализация Order Service
- [ ] Реализация Delivery Service
- [ ] Реализация Payment Service
- [ ] Реализация Notification Service
- [ ] Реализация Review Service
- [ ] Реализация Analytics Service
- [ ] Настройка API Gateway
- [ ] Настройка Docker Compose
- [ ] Интеграционное тестирование

### Фаза 2: Frontend
- [ ] Выбор технологического стека
- [ ] Проектирование UI/UX
- [ ] Реализация клиентского приложения
- [ ] Интеграция с микросервисами
- [ ] Тестирование

### Фаза 3: Оптимизация и масштабирование
- [ ] Оптимизация производительности
- [ ] Настройка мониторинга
- [ ] Настройка логирования
- [ ] Настройка CI/CD
- [ ] Документация API

---

## Контакты и поддержка

Для вопросов и предложений создавайте Issues в репозитории.

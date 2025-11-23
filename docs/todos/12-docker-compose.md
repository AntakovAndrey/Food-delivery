# TODO: Docker Compose

## Общее описание
Настройка Docker Compose для оркестрации всех микросервисов и зависимостей.

---

## 1. Базовая структура

- [ ] Создать docker-compose.yml в корне проекта
- [ ] Создать docker-compose.override.yml для разработки
- [ ] Создать docker-compose.prod.yml для продакшена
- [ ] Создать .env.example файл
- [ ] Документировать переменные окружения

---

## 2. Микросервисы

- [ ] Настроить сервис api-gateway
- [ ] Настроить identity-service
- [ ] Настроить restaurant-service
- [ ] Настроить menu-service
- [ ] Настроить cart-service
- [ ] Настроить order-service
- [ ] Настроить delivery-service
- [ ] Настроить payment-service
- [ ] Настроить notification-service
- [ ] Настроить review-service
- [ ] Настроить analytics-service

---

## 3. Базы данных

- [ ] Настроить PostgreSQL для Identity Service
- [ ] Настроить PostgreSQL для Restaurant Service
- [ ] Настроить PostgreSQL для Menu Service
- [ ] Настроить PostgreSQL для Cart Service
- [ ] Настроить PostgreSQL для Order Service
- [ ] Настроить PostgreSQL для Delivery Service (с PostGIS)
- [ ] Настроить PostgreSQL для Payment Service
- [ ] Настроить PostgreSQL для Notification Service
- [ ] Настроить PostgreSQL для Review Service
- [ ] Настроить PostgreSQL для Analytics Service
- [ ] Настроить инициализацию баз данных (init scripts)

---

## 4. Кэш и очереди

- [ ] Настроить Redis для кэширования
- [ ] Настроить RabbitMQ для message broker
- [ ] Настроить RabbitMQ Management UI
- [ ] Настроить очереди для каждого сервиса

---

## 5. Мониторинг и логирование

- [ ] Настроить Prometheus для метрик
- [ ] Настроить Grafana для визуализации
- [ ] Настроить Elasticsearch для логов (опционально)
- [ ] Настроить Kibana для анализа логов (опционально)
- [ ] Настроить Jaeger для distributed tracing (опционально)

---

## 6. Сети

- [ ] Настроить Docker networks
- [ ] Настроить изоляцию сетей
- [ ] Настроить внутреннюю коммуникацию между сервисами

---

## 7. Volumes

- [ ] Настроить volumes для баз данных
- [ ] Настроить volumes для логов
- [ ] Настроить volumes для конфигураций

---

## 8. Health Checks

- [ ] Настроить health checks для всех сервисов
- [ ] Настроить health checks для баз данных
- [ ] Настроить health checks для Redis
- [ ] Настроить health checks для RabbitMQ

---

## 9. Зависимости

- [ ] Настроить depends_on для всех сервисов
- [ ] Настроить порядок запуска
- [ ] Настроить wait-for скрипты для ожидания готовности зависимостей

---

## 10. Переменные окружения

- [ ] Создать .env файл с примерами
- [ ] Настроить переменные для всех сервисов
- [ ] Настроить секреты (для продакшена использовать secrets)
- [ ] Документировать все переменные

---

## 11. Оптимизация

- [ ] Настроить resource limits для контейнеров
- [ ] Настроить restart policies
- [ ] Настроить logging drivers
- [ ] Оптимизировать размеры образов

---

## 12. Документация

- [ ] Создать README для Docker Compose
- [ ] Документировать команды запуска
- [ ] Документировать структуру
- [ ] Создать troubleshooting guide

---

## 13. Тестирование

- [ ] Протестировать запуск всех сервисов
- [ ] Протестировать подключение к базам данных
- [ ] Протестировать коммуникацию между сервисами
- [ ] Протестировать health checks
- [ ] Протестировать перезапуск сервисов

---

## Приоритеты

**Высокий:** Базовая структура, Микросервисы, Базы данных, Redis, RabbitMQ
**Средний:** Мониторинг, Health Checks, Сети
**Низкий:** Расширенный мониторинг, Оптимизация


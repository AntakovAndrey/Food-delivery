# TODO: Identity Service

## Общее описание
Сервис аутентификации и авторизации. Управление пользователями, ролями, JWT токенами.

---

## 1. Настройка проекта

- [ ] Создать проект ASP.NET Core WebAPI
- [ ] Настроить структуру папок (Domain, Application, Infrastructure, API)
- [ ] Добавить необходимые NuGet пакеты:
  - [ ] Microsoft.EntityFrameworkCore
  - [ ] Npgsql.EntityFrameworkCore.PostgreSQL
  - [ ] Microsoft.AspNetCore.Authentication.JwtBearer
  - [ ] BCrypt.Net-Next (или Argon2)
  - [ ] FluentValidation
  - [ ] AutoMapper
  - [ ] Serilog
  - [ ] Swashbuckle.AspNetCore
- [ ] Настроить appsettings.json
- [ ] Создать Dockerfile
- [ ] Настроить docker-compose для сервиса

---

## 2. Domain Layer

- [ ] Создать сущности:
  - [ ] User (Id, Name, Email, PasswordHash, EmailVerified, CreatedAt, UpdatedAt)
  - [ ] Role (Id, Name, Permissions)
  - [ ] UserRole (связь многие-ко-многим)
  - [ ] RefreshToken (Id, UserId, Token, ExpiresAt, IsRevoked)
  - [ ] Address (Id, UserId, Street, City, PostalCode, Country, IsDefault)
- [ ] Создать Value Objects:
  - [ ] Email
  - [ ] Password
- [ ] Создать Domain Events:
  - [ ] UserRegisteredEvent
  - [ ] UserEmailVerifiedEvent
  - [ ] PasswordChangedEvent
- [ ] Создать исключения:
  - [ ] UserNotFoundException
  - [ ] InvalidCredentialsException
  - [ ] EmailAlreadyExistsException
  - [ ] InvalidTokenException

---

## 3. Infrastructure Layer

- [ ] Настроить DbContext (ApplicationDbContext)
- [ ] Создать миграции Entity Framework
- [ ] Настроить репозитории:
  - [ ] IUserRepository
  - [ ] IRoleRepository
  - [ ] IRefreshTokenRepository
  - [ ] IAddressRepository
- [ ] Реализовать репозитории
- [ ] Настроить JWT генерацию токенов
- [ ] Создать сервис для хеширования паролей (IPasswordHasher)
- [ ] Реализовать EmailService (интеграция с SMTP или SendGrid)
- [ ] Настроить Redis для кэширования (опционально)

---

## 4. Application Layer

- [ ] Создать DTOs:
  - [ ] RegisterRequestDto
  - [ ] LoginRequestDto
  - [ ] AuthResponseDto
  - [ ] UserProfileDto
  - [ ] UpdateProfileDto
  - [ ] ChangePasswordDto
  - [ ] RefreshTokenRequestDto
- [ ] Создать валидаторы (FluentValidation):
  - [ ] RegisterRequestValidator
  - [ ] LoginRequestValidator
  - [ ] UpdateProfileValidator
  - [ ] ChangePasswordValidator
- [ ] Создать интерфейсы сервисов:
  - [ ] IAuthService
  - [ ] IUserService
  - [ ] ITokenService
- [ ] Реализовать сервисы:
  - [ ] AuthService:
    - [ ] RegisterAsync
    - [ ] LoginAsync
    - [ ] RefreshTokenAsync
    - [ ] LogoutAsync
  - [ ] UserService:
    - [ ] GetProfileAsync
    - [ ] UpdateProfileAsync
    - [ ] ChangePasswordAsync
    - [ ] VerifyEmailAsync
    - [ ] ForgotPasswordAsync
    - [ ] ResetPasswordAsync
  - [ ] TokenService:
    - [ ] GenerateAccessToken
    - [ ] GenerateRefreshToken
    - [ ] ValidateToken
- [ ] Настроить AutoMapper профили

---

## 5. API Layer

- [ ] Создать контроллеры:
  - [ ] AuthController:
    - [ ] POST /api/identity/register
    - [ ] POST /api/identity/login
    - [ ] POST /api/identity/refresh-token
    - [ ] POST /api/identity/logout
    - [ ] POST /api/identity/verify-email
    - [ ] POST /api/identity/forgot-password
    - [ ] POST /api/identity/reset-password
  - [ ] UserController:
    - [ ] GET /api/identity/profile
    - [ ] PUT /api/identity/profile
    - [ ] POST /api/identity/change-password
    - [ ] GET /api/identity/addresses
    - [ ] POST /api/identity/addresses
    - [ ] PUT /api/identity/addresses/{id}
    - [ ] DELETE /api/identity/addresses/{id}
- [ ] Настроить Swagger с JWT авторизацией
- [ ] Добавить обработку ошибок (Global Exception Handler)
- [ ] Настроить CORS
- [ ] Добавить логирование запросов

---

## 6. Безопасность

- [ ] Настроить JWT параметры (секретный ключ, время жизни токенов)
- [ ] Реализовать хеширование паролей (BCrypt/Argon2)
- [ ] Добавить rate limiting для endpoints аутентификации
- [ ] Реализовать защиту от brute force атак
- [ ] Настроить HTTPS
- [ ] Добавить валидацию входных данных
- [ ] Реализовать проверку сложности пароля
- [ ] Добавить защиту от SQL injection (использование параметризованных запросов)

---

## 7. Интеграции

- [ ] Интеграция с Email сервисом для верификации
- [ ] Интеграция с OAuth провайдерами (Google, Facebook) - опционально
- [ ] Настройка отправки событий в Message Broker (UserRegistered, UserEmailVerified и т.д.)
- [ ] Интеграция с Notification Service для отправки уведомлений

---

## 8. Тестирование

- [ ] Unit тесты для Domain логики
- [ ] Unit тесты для Application сервисов
- [ ] Integration тесты для API endpoints
- [ ] Тесты безопасности (валидация токенов, защита от атак)
- [ ] Настроить покрытие кода тестами

---

## 9. Документация

- [ ] Настроить Swagger документацию
- [ ] Добавить XML комментарии к API методам
- [ ] Создать примеры запросов/ответов
- [ ] Документировать модели данных

---

## 10. Мониторинг и логирование

- [ ] Настроить Serilog
- [ ] Добавить health checks endpoint
- [ ] Настроить метрики (Prometheus)
- [ ] Добавить логирование важных событий (регистрация, вход, смена пароля)

---

## 11. Миграции и развертывание

- [ ] Создать скрипты миграций
- [ ] Настроить seed данные (роли по умолчанию)
- [ ] Протестировать миграции
- [ ] Настроить CI/CD pipeline
- [ ] Подготовить инструкции по развертыванию

---

## Приоритеты

**Высокий приоритет:**
- Настройка проекта
- Domain Layer
- Infrastructure Layer (DbContext, репозитории)
- Application Layer (AuthService, UserService)
- API Layer (AuthController, UserController)
- Безопасность (JWT, хеширование паролей)

**Средний приоритет:**
- Интеграции
- Тестирование
- Документация

**Низкий приоритет:**
- OAuth интеграция
- Расширенные функции (2FA, биометрия)


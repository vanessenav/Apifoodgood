

# **Food Delivery API**



---

## **Введение или краткое описание**

Food Delivery API — это веб-сервис, разработанный на платформе ASP.NET Core, который позволяет управлять заказами и доставкой здорового домашнего питания. Сервис предоставляет RESTful API для создания, чтения, обновления и удаления заказов, а также для управления пользователями, блюдами и доставками. Проект предназначен для демонстрации базовых возможностей работы с API и может быть использован как основа для создания полноценного сервиса доставки еды.

---

## **Необходимые условия для использования продукта**

Для запуска и использования проекта вам потребуется:

1. **Операционная система**: Windows, macOS или Linux.
2. **.NET SDK**: Установленная версия .NET SDK (рекомендуется версия 6.0 или выше).
3. **База данных**: SQL Server или другая база данных, поддерживаемая Entity Framework Core.
4. **Инструменты разработки**: Visual Studio, Visual Studio Code или любой другой редактор кода.
5. **Базовые знания**:
   - Основы работы с Git и GitHub.
   - Понимание работы с API и HTTP-запросами.
   - Знание C# и ASP.NET Core будет полезным, но не обязательным.

---

## **Как установить программу**

Чтобы установить и запустить проект, выполните следующие шаги:

### 1. **Клонируйте репозиторий**

```bash
git clone https://github.com/ваш-репозиторий/food-delivery-api.git
cd food-delivery-api
```

### 2. **Установите .NET SDK**

Если у вас ещё не установлен .NET SDK, скачайте и установите его с официального сайта: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

### 3. **Настройте базу данных**

1. Создайте базу данных в SQL Server или другой поддерживаемой базе данных.
2. Добавьте строку подключения в файл `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;TrustServerCertificate=True;"
     }
   }
   ```

   Если вы используете аутентификацию Windows:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=your_database;Integrated Security=True;TrustServerCertificate=True;"
     }
   }
   ```

3. Выполните миграцию для создания таблиц в базе данных:

   ```bash
   dotnet ef database update
   ```

### 4. **Запустите проект**

```bash
dotnet run
```

По умолчанию API будет доступно по адресу: `http://localhost:5000` или `https://localhost:5001`.

---

## **Порядок использования**

После установки и запуска проекта вы можете использовать API для управления заказами, пользователями, блюдами и доставками. Вот примеры основных операций:

### 1. **Получение всех заказов**

```http
GET /api/orders
```

### 2. **Создание нового заказа**

```http
POST /api/orders
Content-Type: application/json

{
    "userId": 1,
    "mealId": 2,
    "quantity": 1,
    "deliveryAddress": "ул. Примерная, 123"
}
```

### 3. **Обновление заказа**

```http
PUT /api/orders/1
Content-Type: application/json

{
    "quantity": 2,
    "deliveryAddress": "ул. Новая, 456"
}
```

### 4. **Удаление заказа**

```http
DELETE /api/orders/1
```

### 5. **Получение всех блюд**

```http
GET /api/meals
```

### 6. **Добавление нового блюда**

```http
POST /api/meals
Content-Type: application/json

{
    "name": "Салат Цезарь",
    "description": "Свежий салат с курицей и пармезаном",
    "price": 500
}
```

### 7. **Получение всех пользователей**

```http
GET /api/users
```

### 8. **Создание нового пользователя**

```http
POST /api/users
Content-Type: application/json

{
    "firstName": "Иван",
    "lastName": "Иванов",
    "email": "ivan@example.com"
}
```

---

## **Дополнительные возможности**

### 1. **Сортировка заказов**

Вы можете сортировать заказы по дате создания или стоимости. Например:

```http
GET /api/orders?sortStrategy=1
```

- `sortStrategy=1`: Сортировка по возрастанию.
- `sortStrategy=-1`: Сортировка по убыванию.

### 2. **Поиск заказов по пользователю**

```http
GET /api/orders/user/1
```

### 3. **Получение количества заказов по блюду**

```http
GET /api/orders/count-by-meal?mealId=2
```

---


---


## **Статус проекта**

![GitHub](https://img.shields.io/badge/status-active-brightgreen)
![GitHub](https://img.shields.io/badge/license-MIT-blue)

---

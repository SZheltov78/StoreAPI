# StoreAPI
ТЗ
Склад реализует овощи. Напишите web api для автоматизации заказов оптовых покупателей.
Каждый покупатель получает уникальный токен для работы с api.
Покупатель может получать список продуктов, цены, остатки на сладе. Может создавать, редактировать, отменять, получать список своих заказов.

Решение
Решение разделено на 3 проекта: StoreAPI (ASP.NET Core), DataAccessLayer (Class Library), BusinessLayer (Class Library).

DataAccessLayer содержит контекст и сущности БД.
BusinessLayer содержит сервисы для получения, создания, изменения данных. Используются DTO. Валидация моделей находится в слое бизнес-логики (FluentValidation).
Для идентификации написан специальный middleware. Реквест должен содержать в заголовке - "Authorization: Bearer {token}". В контроллерах доступ ограничивается при помощи атрибута авторизации.
Для тестирования используется Swagger.

Протестировать: http://sergzh-001-site1.itempurl.com/
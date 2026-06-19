# TP4 - TRANI

Aplicación **.NET MAUI Blazor Hybrid** que consume la [FakeStore API](https://fakestoreapi.com), una API REST pública de prueba que simula un e-commerce con productos, categorías, etc.

## HttpClient

En `MauiProgram.cs` se registra el `HttpClient` con su `BaseAddress` apuntando a `https://fakestoreapi.com/`, junto con `ProductService` como servicio inyectable mediante el contenedor de Dependency Injection de .NET. El `ProductService` recibe el `HttpClient` por constructor y expone un método para cada operación CRUD, devolviendo tanto el objeto deserializado como el código de estado HTTP real de la respuesta.

## Páginas y Rutas

| Ruta | Componente | Métodos HTTP |
|------|-----------|-------------|
| `/products` | Products.razor | GET /products |
| `/createproduct` | CreateProduct.razor | POST /products |
| `/editproduct/{id}` | EditProduct.razor | GET /products/{id}, PUT /products/{id} |
| `/deleteproduct/{id}` | DeleteProduct.razor | GET /products/{id}, DELETE /products/{id} |

## Endpoints consumidos

| Método | Endpoint | Uso |
|--------|----------|-----|
| GET | /products | Listar todos los productos |
| GET | /products/{id} | Obtener un producto por ID |
| POST | /products | Crear un nuevo producto |
| PUT | /products/{id} | Actualizar un producto existente |
| DELETE | /products/{id} | Eliminar un producto |

## Código de respuesta HTTP visible en la app

Cada página muestra en pantalla el código de respuesta real devuelto por la API (por ejemplo `200 OK`, `201 Created`) inmediatamente después de ejecutar la petición. Esto se logra utilizando `HttpClient.GetAsync`, `PostAsJsonAsync`, `PutAsJsonAsync` y `DeleteAsync` en lugar de los métodos de extensión que ocultan la respuesta HTTP, permitiendo leer `response.StatusCode` directamente.

## Sobre la FakeStore API

Es una API de pruebas. Los métodos POST, PUT y DELETE responden con los códigos de estado HTTP esperados (200 OK, 201 Created), pero **no persisten los cambios reales** en su base de datos. Al hacer GET luego de una operación de escritura no se verán reflejados los cambios. Sin embargo, en la aplicación se puede verificar que cada petición obtiene la respuesta HTTP correcta, mostrada directamente en la interfaz.

## Dependencias

- .NET MAUI con Blazor Hybrid (.NET 9)
- `System.Net.Http.Json` — para serialización/deserialización JSON
- HTML básico para la interfaz de usuario
# Guía para probar la API de IoonSistema

La siguiente guía describe los pasos necesarios para probar la API de **IoonSistema**. Cada uno de los endpoints ha sido detallado con los métodos HTTP y ejemplos de datos para asegurar que la API funcione correctamente en diferentes escenarios.

### Requisitos previos

Antes de comenzar con las pruebas, asegúrese de contar con los siguientes requisitos:

1. **Base de datos**: Debe tener configurada la base de datos que está incluida en el repositorio, llamada **"BaseDatos.Sql"**. Esta base de datos es compatible con **SQL Server** y debe estar correctamente instalada y conectada.

2. **.NET Core 7**: La API requiere .NET Core 7 para funcionar. Asegúrese de tenerlo instalado en su entorno de desarrollo.

3. **Ejecución de la API**: Verifique que la aplicación esté en ejecución en Visual Studio o en el entorno de desarrollo correspondiente. La API debe estar escuchando en una URL como `https://localhost:5001`.

4. **Swagger habilitado**: La API debe tener Swagger habilitado para probar los endpoints a través de una interfaz web. Swagger es accesible normalmente en `https://localhost:5001/swagger`.

---

## 1. Probar el endpoint de **Comercio (Commerce)**

### Endpoint: `GET /api/commerce`

Este endpoint devuelve todos los comercios registrados en la base de datos.

- **Método HTTP**: `GET`
- **URL**: `https://localhost:7151/swagger/index.html`

**Pasos para probarlo**:
1. Abra un navegador web y vaya a `https://localhost:7151/swagger/index.html`.
2. Busque el endpoint `GET /api/commerce` en la interfaz de Swagger.
3. Haga clic en "Try it out".
4. Haga clic en "Execute".
5. Si todo está configurado correctamente, debería recibir una respuesta en formato JSON con la lista de los comercios.

---

### Endpoint: `POST /api/commerce`

Este endpoint permite agregar un nuevo comercio a la base de datos.

- **Método HTTP**: `POST`
- **URL**: `https://localhost:5001/api/commerce`

**Pasos para probarlo**:
1. En la interfaz de Swagger, busque el endpoint `POST /api/commerce`.
2. Haga clic en "Try it out".
3. En el campo "Request body", ingrese los siguientes datos JSON para agregar un nuevo comercio:

    ```json
    {
      "CommerceId": "48BBA54E-6AB0-4E80-803E-39D8E98FAC53",
      "CommerceName": "IOON",
      "Address": "Managua | Virtual",
      "RUC": "1234567890",
      "State": "48BBA54E-6CB0-4E80-803E-39D8E98FAC83"
    }
    ```

---

## 2. Probar el endpoint de **Usuarios (Users)**

### Endpoint: `GET /api/users`

Este endpoint devuelve todos los usuarios registrados en la base de datos.

- **Método HTTP**: `GET`
- **URL**: `https://localhost:7151/swagger/index.html`

**Pasos para probarlo**:
1. Abra un navegador web y vaya a `https://localhost:7151/swagger/index.html`.
2. Busque el endpoint `GET /api/user` en la interfaz de Swagger.
3. Haga clic en "Try it out".
4. Haga clic en "Execute".
5. Si todo está configurado correctamente, debería recibir una respuesta en formato JSON con la lista de los usuarios.

---

### Endpoint: `POST /api/user`

Este endpoint permite agregar un nuevo usuario a la base de datos.

- **Método HTTP**: `POST`
- **URL**: `https://localhost:7151/swagger/index.html`

**Pasos para probarlo**:
1. En la interfaz de Swagger, busque el endpoint `POST /api/user`.
2. Haga clic en "Try it out".
3. En el campo "Request body", ingrese los siguientes datos JSON para agregar un nuevo usuario:

    ```json
    {
      "userId": "3fa85f68-5717-4562-b3fc-2c963f66afb6",
      "username": "Juan",
      "password": "1122MM",
      "role": "admin",
      "commerceId": "3FA85F64-5717-4562-B3FC-2C963F66AFA6",
      "state": "BAD80CC4-07DF-446D-94FA-93445188BEE3"
    }
    ```
 ##   Esto aplica para los demás elementos, sales, sale detail, state etc..
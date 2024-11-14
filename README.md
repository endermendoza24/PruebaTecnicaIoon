# Guía para probar la API de IoonSistema

La siguiente guía describe los pasos necesarios para probar la API de **IoonSistema**. Cada uno de los endpoints ha sido detallado con los métodos HTTP y ejemplos de datos para asegurar que la API funcione correctamente en diferentes escenarios.

### Requisitos previos

Antes de comenzar con las pruebas, asegúrese de que:

1. **La API esté en ejecución**: Verifique que la aplicación esté en ejecución en Visual Studio o el entorno de desarrollo correspondiente. La API debe estar escuchando en una URL como `https://localhost:5001`.

2. **Swagger esté habilitado**: La API debe tener Swagger habilitado para poder probar los endpoints a través de una interfaz web. Swagger es accesible normalmente en `https://localhost:5001/swagger`.

---

## 1. Probar el endpoint de **Comercio (Commerce)**

### Endpoint: `GET /api/commerce`

Este endpoint devuelve todos los comercios registrados en la base de datos.

- **Método HTTP**: `GET`
- **URL**: `https://localhost:5001/api/commerce`

**Pasos para probarlo**:
1. Abra un navegador web y vaya a `https://localhost:5001/swagger`.
2. Busque el endpoint `GET /api/commerce` en la interfaz de Swagger.
3. Haga clic en "Try it out".
4. Haga clic en "Execute".
5. Si todo está configurado correctamente, debería recibir una respuesta en formato JSON con la lista de los comercios.

---

### Endpoint: `GET /api/commerce/{id}`

Este endpoint obtiene los datos de un comercio específico a través de su `CommerceId`.

- **Método HTTP**: `GET`
- **URL**: `https://localhost:5001/api/commerce/{id}`

**Pasos para probarlo**:
1. En la interfaz de Swagger, busque el endpoint `GET /api/commerce/{id}`.
2. Haga clic en "Try it out".
3. En el campo `{id}`, ingrese un `CommerceId` válido, por ejemplo: `3FA85F64-5717-4562-B3FC-2C963F66AFA6`.
4. Haga clic en "Execute".
5. Si el comercio existe, recibirá los datos del comercio en formato JSON.

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
  "CommerceId": "48BBA54E-6CB0-4E80-803E-39D8E98FAC83", // este se genera automaticamente
  "CommerceName": "IOON",
  "Address": "Managua | Virtual",
  "RUC": "1234567890",
  "State": "48BBA54E-6CB0-4E80-803E-39D8E98FAC83"
}

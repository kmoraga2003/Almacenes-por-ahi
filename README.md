# Almacenes-por-ahi

Aplicación móvil simple en .NET MAUI para la evaluación de Programación .NET de **Almacenes Por Ahí**. La app funciona completamente local, sin Firebase, sin APIs externas y sin base de datos; toda la información se gestiona con `ObservableCollection` siguiendo un enfoque MVVM sencillo.

## Estructura del proyecto

- `AlmacenesPorAhi.slnx`: solución principal del repositorio.
- `AlmacenesPorAhi.App/AlmacenesPorAhi.App.csproj`: proyecto .NET MAUI (Android) con la interfaz móvil.
- `AlmacenesPorAhi.App/App.xaml`: recursos visuales compartidos, colores y estilos básicos.
- `AlmacenesPorAhi.App/App.xaml.cs`: inicia la app y abre la pantalla de login.
- `AlmacenesPorAhi.App/MauiProgram.cs`: registra `AppDataService` para compartir los datos en memoria.
- `AlmacenesPorAhi.App/Platforms/Android/*`: archivos mínimos de arranque para Android.
- `AlmacenesPorAhi.App/Views/LoginPage.xaml(.cs)`: login con validación simple usando credenciales quemadas en código.
- `AlmacenesPorAhi.App/Views/MainMenuPage.xaml(.cs)`: menú principal con navegación a inventario, ventas y devoluciones.
- `AlmacenesPorAhi.App/Views/InventoryPage.xaml(.cs)`: CRUD de productos con MVVM.
- `AlmacenesPorAhi.App/Views/SalesPage.xaml(.cs)`: registro de ventas con descuento automático de stock.
- `AlmacenesPorAhi.App/Views/ReturnsPage.xaml(.cs)`: módulo principal de devoluciones con historial y actualización de stock.
- `AlmacenesPorAhi.Core/Helpers/ObservableObject.cs`: base para `INotifyPropertyChanged`.
- `AlmacenesPorAhi.Core/Helpers/RelayCommand.cs`: implementación simple de `ICommand`.
- `AlmacenesPorAhi.Core/Models/Product.cs`: modelo de producto con nombre, precio y stock.
- `AlmacenesPorAhi.Core/Models/ReturnRecord.cs`: modelo para guardar el historial de devoluciones.
- `AlmacenesPorAhi.Core/Services/AppDataService.cs`: servicio en memoria con listas `ObservableCollection` y reglas de negocio.
- `AlmacenesPorAhi.Core/ViewModels/InventoryViewModel.cs`: lógica MVVM del inventario.
- `AlmacenesPorAhi.Core/ViewModels/SalesViewModel.cs`: lógica sencilla para registrar ventas.
- `AlmacenesPorAhi.Core/ViewModels/ReturnsViewModel.cs`: lógica MVVM para registrar devoluciones.
- `AlmacenesPorAhi.Tests/*`: pruebas unitarias para CRUD, ventas, devoluciones y actualización de stock.

## Funcionalidades incluidas

1. **Login**
   - Usuario: `empleado`
   - Contraseña: `1234`

2. **Menú principal**
   - Inventario
   - Ventas
   - Devoluciones

3. **Inventario**
   - Listado de productos
   - Agregar productos
   - Editar productos al seleccionarlos
   - Eliminar productos

4. **Ventas**
   - Selección de producto
   - Registro de cantidad vendida
   - Descuento automático de stock

5. **Devoluciones**
   - Selección de producto
   - Cantidad devuelta
   - Motivo de devolución
   - Confirmación del registro
   - Historial de devoluciones
   - Aumento automático del stock

## Pruebas incluidas

Se cubren los casos solicitados:

- Agregar producto
- Editar producto
- Eliminar producto
- Registrar venta
- Registrar devolución
- Actualizar stock

## Comandos útiles

```bash
dotnet test /home/runner/work/Almacenes-por-ahi/Almacenes-por-ahi/AlmacenesPorAhi.Tests/AlmacenesPorAhi.Tests.csproj
```

> Nota: en este entorno no está instalado el workload de .NET MAUI/Android, por lo que la lógica se valida mediante pruebas unitarias sobre `AlmacenesPorAhi.Core`. El proyecto MAUI quedó estructurado para abrirse y completarse en Visual Studio con el workload correspondiente.

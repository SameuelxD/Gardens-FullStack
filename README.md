### Gardens-FullStack

## Deploy BackEnd API en .NET en IIS.

#1 Activar los servicios IIS en Windows.
Ir al panel de control y buscar Programas en la seccion Programas y caracteristicas buscar "Activar o desactivar las caracteristicas de Windows"
despues buscamos Internet Information Services y ahi activamos todo de las ventanas menos de Servidor FTP lo dejamos sin activar el resto todo lo activamos
, aceptamos todo para guardar los cambios

#2 Usando Visual Studio 2022 Community para la "Publicacion".
Abrimos el proyecto en este programa y abrimos como tal su solucion o aplicacion en este caso API , que es la webapi de nuestro proyecto
al abrir si vamos a hacer el deploy para su produccion en Program.cs buscamos el apartado de la Configuracion HTTP peticiones pipeline y cambiamos "IsDevelopment" 
por "IsProduction" para hacer correctamente su Publicacion y finalmente en API/Properties buscamos el archivo "launchSettings.json" y cambiamos en Profiles "Development" por "Production"
, solo es necesario ahi.

#3 Hacemos la publicacion.
Dando click derecho en el proyecto API en Visual Studio 2022 configuramos toda la publicacion necesaria para que sirva , y al aceptar este creara unos archivos 
y esos los pasamos a inetput/wwwroot en una carpeta nueva.

#4 Administrador de Internet Information Services (IIS).
Despues creamos un sitio para que este cree a su vez un grupo  de aplicacion en donde se guardara nuestra conexion , hay que recalcar que para esto tenemos que tener instalado 
.NET8 Hosting Bundle 
http://localhost:81/swagger/index.html

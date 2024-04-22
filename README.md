### Gardens-FullStack

## Deploy BackEnd API en .NET en IIS Localmente.

# 1 Activar los servicios IIS en Windows.
Ir al panel de control y buscar Programas en la seccion Programas y caracteristicas buscar "Activar o desactivar las caracteristicas de Windows"
despues buscamos Internet Information Services y ahi activamos todo de las ventanas menos de Servidor FTP lo dejamos sin activar el resto todo lo activamos
, aceptamos todo para guardar los cambios

# 2 Usando Visual Studio 2022 Community para la "Publicacion".
Abrimos el proyecto en este programa y abrimos como tal su solucion o aplicacion en este caso API , que es la webapi de nuestro proyecto
al abrir si vamos a hacer el deploy para su produccion en Program.cs buscamos el apartado de la Configuracion HTTP peticiones pipeline y cambiamos "IsDevelopment" 
por "IsProduction" para hacer correctamente su Publicacion y finalmente en API/Properties buscamos el archivo "launchSettings.json" y cambiamos en Profiles "Development" por "Production"
, solo es necesario ahi.

# 3 Hacemos la publicacion.
Dando click derecho en el proyecto API en Visual Studio 2022 configuramos toda la publicacion necesaria para que sirva , y al aceptar este creara unos archivos 
y esos los pasamos a inetput/wwwroot en una carpeta nueva.

# 4 Administrador de Internet Information Services (IIS).
Despues creamos un sitio para que este cree a su vez un grupo  de aplicacion en donde se guardara nuestra conexion , hay que recalcar que para esto tenemos que tener instalado 
.NET8 Hosting Bundle 
http://localhost:81/swagger/index.html

## ¿Que es un Hosting?
Es un alojamiento estandar que nos permite subir una aplicacion a internet , hay diferentes tipos de hosting , en este caso para .NET toca usar un hosting propio para .NET.

## ¿Ques un Servidor? 
Es mas complejo tambien podemos subir aplicaciones a internet pero a diferencia del Hosting el servidor requiere ciertas configuraciones mas avanzadas por parte del usaurio para 
que asi este pueda alojar con caracteristicas de la aplicacion o servicio que queramos subir a internet.
# Servidor Fisico
# Servidor VPS

## Deploy BackEnd API en .NET en Hosting IIS Publico. Servidor FTP/FTPS 

# 1 Creamos cuenta en el Hosting de SOMEE.COM
Creamos cuenta y elegimos la opcion gratuita en este caso con la informacion nombre del dominio,titulo,etc.

# 2 Hacemos la publicacion del proyecto en Visual Studio 2022.
Hacemos la publicacion del proyecto a un Servidor FTP/FTPS 


genmigrationadd
genmigrationupdate
*Migraciones Migrations/Data/Persistence
dotnet ef migrations add InitialCreate -p Persistence -s ProductionApi -o Data/Migrations

dotnet ef database update -p Persistence -s API
dotnet build

genwatchrun
*Swagger UI
dotnet watch run -p API


dotnet ef dbcontext scaffold "server=localhost;user=root;password=123456;database=jardineria" Pomelo.EntityFrameworkCore.MySql -s API -p Domain 
--context GardensContext --context-dir Data --output-dir Entities


genpaquetes4capas
1.Creacion Proyecto 4 Capas,Crear Solucion Principal y agregar Soluciones ,
para cada implementacion API,Application,Domain,Persistence,,
Agregar referencias entre implementaciones y Finalmente descargar los,
paquetes a cada implementacion correspondiente si necesita.,
-dotnet new sln,dotnet sln add API,dotnet sln list;,
-dotnet new webapi -o API,dotnet new classlib -o Application;,
-dotnet add reference ../Application;

genconexionbd
genconexionjwt
2.Conexion Base de Datos y Conexion JWT,appsettings.json-appsettings.Development.json,
/API. 

gendbcontext
3.Crear ArchivoDbContext/Data/Persistence.

geninyeccion1
4.Agregar la primera inyeccion de ArchivoDbContext al Contenedor,
de Dependencias Program/API.

genbaseentity
generefreshtoken
generol
geneuser
geneuserrol
5.Generar Entities con Atributos,Definir RefreshToken,Rol,User,UserRol Entities/Domain.,

gencardunouno
gencardunomuchos
gencardmuchosmuchos
genrefnavegacion
gencollectnavegacion
genlistnavegacion
6.Establecer Relaciones o Cardinalidad entre Entidades Entities/Domain.

7.Definir DbSet,Definir para RefreshToken,Rol,User,UserRol en ArchivoContext/Data/Persistence.

genentityconfiguration
genhaskeyconfiguration
gentotableconfiguration
genstringpropertyconfiguration
genintpropertyconfiguration
gendatetimepropertyconfiguration
gendoublepropertyconfiguration
genuniqueconfiguration
genhasone-withoneconfiguration
genhasone-withmanyconfiguration
genhasmany-withmanyconfiguration
genclavescompuestas
gencrefreshtoken
gencrol
gencuser
8.Crear las configuraciones para cada Entidad,Definir para RefreshToken,Rol,User y Servicio en
EntityConfiguration/Configuration/Persistence.

genentitydto
genaddroledto
gendatauserdto
genlogindto
genregisterdto
9.Definir Dtos para mostrar valores de la Data,Definir AddRoleDto,DataUserDto,LoginDto,RegisterDto EntityDto/Dtos/API.

genmappingprofiles
10.Definir MappingProfiles para mapear y relacionar los Dtos con cada
Entidad MappingProfiles/Profiles/API.

genapplicationserviceextension
genaddjwtextensions
geninyeccion2
11.Definir Metodos de Extension e inyectar por segunda vez al
Contenedor de Dependencias ApplicationServiceExtension/Extensions/API 
, Program/API.

genigenericrepository
geniuser
genientityrepository
12.Definir Interfaces para cada Entidad,Definir IRefreshToken,IRol,IUser,Definir IGenericRepository 
IGenericRepository,IEntityRepository/Interfaces/Domain.

gengenericrepository
genuserrepository
genentityrepository
13.Definir Repositorios para cada Interface/Entidad,
Definir RefreshTokeRepository,RolRepository,UserRepository, Definir GenericRepository 
GenericRepository,EntityRepository/Repositories/Application.

genunitofwork
geniunitofwork
14.Definir IUnitOfWork y UnitOfWork IUnitOfWork/Interfaces/Domain , 
UnitOfWork/UnitOfWork/Application. ,Definir User,Rol,RefreshToken como Interfaces y Repositorios

genapplicationservices
geninyeccion3
15.Agregar Metodo de Extension,Agrega la UnitOfWork al Scope de EF
ApplicationService/Extensions/API.

genbasecontroller
genusercontroller
genentitycontroller
16.Generar Controladores,Definir UserController,Definir BaseController 
EntityController,BaseController/Controllers/API.

genpager
genparams
genjwthelpers
genauthorization
17,Generar Helpers ,Pager,Params,Jwt y Authorization ,Metodos de Paginacion y JWT Pager,Params/Helpers/API.

geniuserservice
genuserservice
18.Generar Servicios, Generar IUserService,UserService/Services/API.

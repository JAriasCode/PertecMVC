# PertecMVC
MVC test project for Pertec Global Services

Video tutorial: https://youtu.be/kn0AiA1mpFs

Instrucciones:
Para funcionar el proyecto requiere una base de datos SQL Server (adjunta), realizada de forma database first.

1 - Restaurar la base de datos adjunta (PERTECDB.bak) una instancia SQLSERVER 2019.

2 - Abrir la solucion del proyecto en Visual Studio.

3 - Cambiar el string de conexion "default" en el archivo appsettings.json, 
	Colocar la instancia, base de datos y credenciales correctas de SQL ejemplo:

	"Data Source=localhost; Initial Catalog=PERTECDB; user=jarias;Password=jarias; Trusted_Connection=False;Integrated Security=False;"

	Donde "localhost" es la instancia SQL, "PERTECDB" la base de datos, "jarias" el usuario SQL, "jarias" el password del usuario.

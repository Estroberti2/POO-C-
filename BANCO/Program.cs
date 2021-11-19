/*
 * Creado por SharpDevelop.
 * Usuario: yonat
 * Fecha: 10/11/2020
 * Hora: 23:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
namespace BANCO
{
	class Program
	{
		public static void Main(string[] args)
		{
			Banco banco = new Banco("Galicia");
	
			menu(ref banco);

			Console.ReadKey(true);
		}
		
		//Funciones
		public static void menu(ref Banco banco){
			//MENU AGREGAR CUENTA
			Console.WriteLine("\n -------------------BIENVENIDO-------------------"+
			                  "\n "+
			                  "\n             ELIJE LA OPCION DESEADA"+
							  "\n              1- AGREGAR CUENTA"+
							  "\n              2- ELIMINAR CUENTA"+
							  "\n              3- LISTAR "+
							  "\n              4- DEPOSITAR "+
							  "\n              5- EXTRACCION"+
							  "\n              6- EXISTE CLIENTE"+
							  "\n              7- SALIR"+
							  "\n "+
							  "\n -------------------------------------------------"+
							  "\n ");
			Console.Write("OPCIOPN N° : ");
			string opcion = Console.ReadLine();
			 
			switch (opcion) {
				case "1":
					Console.Clear();
					agregarCuenta(ref banco);
					break;
				case "2":
					Console.Clear();
					eliminar(ref banco);
					break;
				case "3":
					Console.Clear();
					listar(ref banco);
					break;
				case "4":
					Console.Clear();
					extraccion(ref banco);
					break;
				case "5":
					Console.Clear();
					depositar(ref banco);
					break;
				case "6":
					Console.Clear();
					existeCliente(ref banco);
					break;
				case "7":
					Console.Clear();
					Salir(ref banco);
					break;
				default:
					Console.Clear();
					Console.WriteLine("!!!!!!!!!!!!!!!  OPCION ERRONEA   !!!!!!!!!!!!!!!!");
					menu(ref banco);
					break;
			}
		}
		
		public static void Otra_Operacion(ref Banco banco){
			//PREGUNTAR SI DESEA SALIR
			Console.WriteLine("\n -------------------------------------------------"+
			                  "\n -      DESEA REALIZAR OTRA OPERACION?           -"+
			                  "\n -------------------------------------------------"+
			                  "\n ->SI "+
			                  "\n ->NO");
			Console.Write("--:");
			string opcion = Console.ReadLine();
			if ( opcion == "SI" || opcion == "Si" || opcion == "sI" || opcion == "si" || opcion == "S" || opcion == "s" ){
				Console.Clear();
				menu(ref banco);
			}
			if ( opcion == "NO" || opcion == "No" || opcion == "nO" || opcion == "no" || opcion == "N" || opcion == "n" ){
				Console.Clear();
				Salir(ref banco);
			}
			Console.Clear();
			Console.WriteLine("!!!!!!!!!!!!!!!  OPCION ERRONEA   !!!!!!!!!!!!!!!!");
			Otra_Operacion(ref banco);
		}
		
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 1   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		
		public static void agregarCuenta(ref Banco banco){
			//MENU AGREGAR CUENTA
			Console.WriteLine("\n------------------------------------------------"+
			                  "\n                AGREGAR CUENTA                 "+
			                  "\n------------------------------------------------"+
							  "\n              1- NUEVO"+
							  "\n              2- EXISTENTE"+
							  "\n              3- VOLVER"+
							  "\n------------------------------------------------"+
							  "\n ");
			Console.Write("OPCIOPN N° : ");
			string opcion = Console.ReadLine();
			switch (opcion) {
				case "1":
					Console.Clear();
					nuevoCliente(ref banco);
					break;
				case "2":
					Console.Clear();
					existente(ref banco);
					break;
				case "3":
					Console.Clear();
					menu(ref banco);
					break;
					default:
					Console.Clear();
					Console.WriteLine("!!!!!!!!!!!!!!!  OPCION ERRONEA   !!!!!!!!!!!!!!!!");
					agregarCuenta(ref banco);
					break;
			}
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 1/1   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void nuevoCliente(ref Banco banco){
			//CREAR CLIENTE Y CUENTA
			bool existe;
			double saldo;
			int dni, telefono;
			string nombre, apellido, direccion, mail;
			
			Console.WriteLine("\n -------------------------------------------------"+
			                  "\n -                NUEVA CUENTA                   -"+
			                  "\n -------------------------------------------------");
			int contador = 3;
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
			                      "\n -------------------------------------------------", contador);
				try {
					Console.Write("->\nINGRESE DNI: ");
					dni = int.Parse(Console.ReadLine());
					existe = banco.existeCliente(dni);
					
					if(existe==false){
						Console.Write("->INGRESE NOMBRE: ");
						nombre = Console.ReadLine();
						
						Console.Write("->INGRESE APELLIDO: ");
						apellido = Console.ReadLine();
							
						
						Console.Write("->INGRESE DIRECCION: ");
						direccion = Console.ReadLine();
					
						Console.Write("->INGRESE TELEFONO: ");
						telefono = int.Parse(Console.ReadLine());
					
						Console.Write("->INGRESE MAIL: ");
						mail = Console.ReadLine();
						
						Console.Write("->INGRESE SALDO A DEPOSITAR: ");
						saldo = double.Parse(Console.ReadLine());
					
						Cliente nuevo = new Cliente(nombre, apellido, dni, direccion, telefono, mail);
					
						Cuenta nueva = new Cuenta(nombre, apellido, dni, saldo);
						
						banco.agregarCli(nuevo);
						banco.altaCuenta(nueva);
						contador = -1;
						Console.Write("\n ---------------------------------------------------"+
						              "\n !!!!       CLIENTE CREADO EXITOSAMENTE         !!!!"+
						              "\n ---------------------------------------------------");
					
					}
					else{
						Console.Clear();
						Console.Write("\n ---------------------------------------------------"+
						              "\n !!!!     LA CLIENTE INGRESADO ES INVALIDO      !!!!"+
						              "\n ---------------------------------------------------");
						contador--;
					}
					
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
			
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 1/2   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void existente(ref Banco banco){
			//AGREGAR OTRA CUENTA A UN CLIENTE
			int contador = 3;
			Console.WriteLine("\n -------------------------------------------------"+
			                  "\n -                  EXISTENTE                    -"+
			                  "\n -------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
			                      "\n -------------------------------------------------", contador);
				try {
					Console.Write(" INGRESE EL DNI DEL CLIENTE : ");
					int dni = Convert.ToInt32(Console.ReadLine());
					
					if(banco.existeCliente(dni)==true){
						banco.agregarCuentaClienteExistente(Convert.ToInt32(dni));
						Console.WriteLine("\n -------------------------------------------------"+
						                  "\n -           CUENTA AGREGADA CON EXITO           -"+
						                  "\n -------------------------------------------------");
						contador = -1;
						
					}
					else{//si no encuentra nada notifica esto
						Console.Clear();
						Console.Write("\n ---------------------------------------------------"+
						              "\n !!!!     LA CLIENTE INGRESADO ES INVALIDO      !!!!"+
						              "\n ---------------------------------------------------");
						contador--;
					}
					
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
		}
		
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 2   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		
		public static void eliminar(ref Banco banco){
			//ELIMINAR CUENTA O CLIENTE
			int contador = 3;
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -                ELIMINAR CUENTA                -"+
			                  "\n -------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
			                      "\n -------------------------------------------------", contador);
			
				try {
					
					// pedimos el numero de cuenta
					Console.Write("->INGRESE NUMERO DE CUENTA: ");
					string cuenta = Console.ReadLine();
					
					if(banco.existeCuenta(cuenta)){
						banco.bajaCuenta(cuenta);
						contador = -1;
					
					}
					else{//si no encuentra nada notifica esto
						Console.Clear();
						Console.Write("\n ---------------------------------------------------"+
						              "\n !!!!      LA CUENTA INGRESADA ES INVALIDA      !!!!"+
						              "\n ---------------------------------------------------");
						contador--;
					}
					
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
		}
		
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		
		public static void listar(ref Banco banco){
			//LISTAR CUENTA O CLIENTE
			Console.WriteLine("\n------------------------------------------------"+
			                  "\n                   LISTAR                      "+
			                  "\n------------------------------------------------"+
							  "\n       1- CLIENTES"+
							  "\n       2- CUENTAS"+
							  "\n       3- LISTAR CLIENTES CON VARIAS CUENTAS    "+
							  "\n       4- VER IESIMO CLIENTE"+
							  "\n       5- VER JESIMA CUENTA"+
							  "\n       6- VOLVER"+
							  "\n------------------------------------------------"+
							  "\n ");
			Console.Write("OPCIOPN N° : ");
			string opcion = Console.ReadLine();
			switch (opcion) {
				case "1":
					Console.Clear();
					listarClientes(ref banco);
					break;
				case "2":
					Console.Clear();
					listarCuentas(ref banco);
					break;
				case "3":
					Console.Clear();
					listarClientesVariasCuentas(ref banco);
					break;
				case "4":
					Console.Clear();
					consultaIesimoCliente(ref banco);
					break;
				case "5":
					Console.Clear();
					consultaJesimaCuenta(ref banco);
					break;
				case "6":
					Console.Clear();
					menu(ref banco);
					break;
				default:
					Console.Clear();
					Console.WriteLine("!!!!!!!!!!!!!!!  OPCION ERRONEA   !!!!!!!!!!!!!!!!");
					listar(ref banco);
					break;
			}
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3/1   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void listarClientes(ref Banco banco){
			//LISTA TODOS LOS CLIENTES
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -         ESTA ES LA LISTA DE CLIENTE           -"+
			                  "\n -------------------------------------------------");
			banco.listarClientes();
			Otra_Operacion(ref banco);
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3/2   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void listarCuentas(ref Banco banco){
			//LISTA TODAD LAS CUENTAS
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -          ESTA ES LA LISTA DE CUENTAS          -"+
			                  "\n -------------------------------------------------");
			banco.listarCuentas();
			Otra_Operacion(ref banco);
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3/3   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void listarClientesVariasCuentas(ref Banco banco){
			//LISTA TODAD LAS CUENTAS
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -  SE LISTARA LOS CLIENTES CON 2 O MAS CUENTAS  -"+
			                  "\n -------------------------------------------------");

			banco.ListarClienteVariasCuentas();
			
			Otra_Operacion(ref banco);
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3/4   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void consultaIesimoCliente(ref Banco banco){
			
			int contador = 3;
			Console.WriteLine("\n --------------------------------------------------- "+
			                  "\n -                 IESIMO CLIENTE                  -"+
			                  "\n ---------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
				                      "\n -------------------------------------------------", contador);
				try {
					Console.Write("->INGRESE LA POSICION DEL CLIENTE:  ");
					int i = int.Parse(Console.ReadLine());
					if(banco.ListaCliente.Count>0){
						banco.verCliente(i);
						contador = -1;
					}
					else{
						Console.WriteLine("\n -EN ESTOS MOMENTOS NO EXISTEN CLIENTES REGISTRADOS-"+
				                  		  "\n ---------------------------------------------------");
						contador = -1;
					}
						
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
		}
		
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 3/5   ------------------------------------------------------------------------------------*/
		/*-------------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void consultaJesimaCuenta(ref Banco banco){
			int contador = 3;
			Console.WriteLine("\n --------------------------------------------------- "+
			                  "\n -                  JESIMA CUENTA                  -"+
			                  "\n ---------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
				                  "\n -------------------------------------------------", contador);
				
				try {
					Console.Write("->INGRESE LA POSICION DE LA CUENTA:  ");
					int j = int.Parse(Console.ReadLine());
					if(banco.ListaCuenta.Count>0){
						banco.verCliente(j);
						contador = -1;
					}
					else{
						Console.WriteLine("\n -EN ESTOS MOMENTOS NO EXISTEN CUENTAS REGISTRADAS -"+
				                  		  "\n ---------------------------------------------------");
						contador = -1;
					}
						
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			
			Otra_Operacion(ref banco);
		}
			
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 4   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		
		public static void depositar(ref Banco banco){
			
			int contador = 3;
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -                   DEPOSITAR                   -"+
			                  "\n -------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
				                  "\n -------------------------------------------------", contador);
				try {
					
					Console.Write("->INGRESE NUMERO DE CUENTA: ");
					string cuenta = Console.ReadLine();
				
				if(banco.existeCuenta(cuenta)){
			
					Console.Write("->CUANTO VA A DEPOSITAR? : ");
					double deposito = Convert.ToDouble(Console.ReadLine());
					banco.depositar(cuenta, deposito);
					
					
					Console.WriteLine("\n ------------------------------------------------- "+
				                	  "\n -          SALDO ACTUALIZADO CON EXITO          -"+
				               		  "\n -------------------------------------------------");
				}
				else{
						Console.Clear();
						Console.Write("\n ---------------------------------------------------"+
						              "\n !!!!      LA CUENTA INGRESADA ES INVALIDA      !!!!"+
						              "\n ---------------------------------------------------");
						contador--;
					}
			
			} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
									 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
					
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
					
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
			
		}
		
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 5   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void extraccion(ref Banco banco){
			
			int contador = 3;
			Console.WriteLine("\n ------------------------------------------------- "+
			                  "\n -                   EXTRAER                     -"+
			                  "\n -------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
				                  "\n -------------------------------------------------", contador);
			
				try {
					
					Console.Write("->INGRESE NUMERO DE CUENTA: ");
					string cuenta = Console.ReadLine();
					
					if(banco.existeCuenta(cuenta)){
						
						Console.Write("->CUANTO VA A EXTRAER? : ");
						double extraccion = Convert.ToDouble(Console.ReadLine());
						
						banco.extraer(cuenta, extraccion);
					}
					else{
							Console.Clear();
							Console.Write("\n ---------------------------------------------------"+
							              "\n !!!!      LA CUENTA INGRESADA ES INVALIDA      !!!!"+
							              "\n ---------------------------------------------------");
							contador--;
						}
				
				} catch (FormatException) {
						Console.Clear();
						Console.WriteLine("\n ---------------------------------------------------"+
										 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
						                 "\n ---------------------------------------------------");
						contador--;
						
						
				}catch (OverflowException) {
						Console.Clear();
						Console.WriteLine("\n ---------------------------------------------------"+
						                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
						                 "\n ---------------------------------------------------");
						contador--;
						
				}
			}
			if(contador==0){
				Console.Clear();
				Console.WriteLine("\n -------------------------------------------------"+
				                  "\n -         HAS USADO TODOS TUS INTENTOS          -"+
				                  "\n -------------------------------------------------");
			}
			Otra_Operacion(ref banco);
		}
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 6   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		
		public static void existeCliente(ref Banco banco){
			
			int dni, telefono;
			string nombre, apellido, direccion, mail;
			int contador = 3;
			Console.WriteLine("\n -------------------------------------------------"+
			                  "\n -               EXISTE CLIENTE                  -"+
			                  "\n -------------------------------------------------");
			while(contador>0){
				Console.WriteLine("\n - quedan {0} intentos                           -"+
			                      "\n -------------------------------------------------", contador);
				try {
					Console.Write("->\nINGRESE DNI: ");
					dni = int.Parse(Console.ReadLine());
					
					Console.Write("->INGRESE NOMBRE: ");
					nombre = Console.ReadLine();
							
					Console.Write("->INGRESE APELLIDO: ");
					apellido = Console.ReadLine();
								
					Console.Write("->INGRESE DIRECCION: ");
					direccion = Console.ReadLine();
						
					Console.Write("->INGRESE TELEFONO: ");
					telefono = int.Parse(Console.ReadLine());
						
					Console.Write("->INGRESE MAIL: ");
					mail = Console.ReadLine();
						
					Cliente nuevo = new Cliente(nombre, apellido, dni, direccion, telefono, mail);
					
					if(banco.existesCliente(nuevo)){
						Console.WriteLine("\n -------------------------------------------------"+
				                		  "\n -               EL CLIENTE EXISTE               -"+
				               			   "\n -------------------------------------------------");
					}
					else{
						Console.Clear();
						Console.Write("\n ---------------------------------------------------"+
							              "\n !!!!     EL CLIENTE INGRESADO ES INVALIDO      !!!!"+
							              "\n ---------------------------------------------------");
							contador--;
					}
						
				} catch (FormatException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
										 "\n!!!!!!!!!!!!       FORMATO INVALIDO     !!!!!!!!!!!!"+
						                 "\n ---------------------------------------------------");
					contador--;
						
						
				}catch (OverflowException) {
					Console.Clear();
					Console.WriteLine("\n ---------------------------------------------------"+
					                  "\n!!!!!!!    VALOR INGRESADO FUERA DEL RANGO   !!!!!!!"+
					                 "\n ---------------------------------------------------");
					contador--;
				}
			}
			Otra_Operacion(ref banco);
		}
		
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		/*----------------------------------------------  OPCION 7   ------------------------------------------------------------------------------------*/
		/*-----------------------------------------------------------------------------------------------------------------------------------------------*/
		
		public static void Salir(ref Banco banco){
			//PREGUNTAR SI DESEA SALIR
			Console.WriteLine("\n -------------------------------------------------"+
			                  "\n -            ESTA SEGURO? -SI| NO               -"+
			                  "\n -------------------------------------------------");
			Console.Write("--:");
			string opcion = Console.ReadLine();
			if ( opcion == "SI" || opcion == "Si" || opcion == "sI" || opcion == "si" || opcion == "S" || opcion == "s" ){
				Environment.Exit(1);
			}
			else if ( opcion == "NO" || opcion == "No" || opcion == "nO" || opcion == "no" || opcion == "N" || opcion == "n" ){
				Console.Clear();
				menu(ref banco);
			}
			Console.Clear();
			Console.WriteLine("!!!!!!!!!!!!!!!  OPCION ERRONEA   !!!!!!!!!!!!!!!!");
			Salir(ref banco);
		}
		
	}
}
/*
 * Creado por SharpDevelop.
 * Usuario: yonat
 * Fecha: 10/11/2020
 * Hora: 23:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace BANCO
{

	public class Banco
	{
		private string nombre;
		private ArrayList listaCliente;
		private ArrayList listaCuenta;
		
		public Banco(string nombre)
		{
			this.nombre = nombre;
			listaCliente = new ArrayList();
			listaCuenta = new ArrayList();
		}
		
		//set y get para poder modificar el nombre
		public string NombreBanco{
			set{
				nombre = value;
			}get{
				return nombre;
			}
		}
		public ArrayList ListaCliente{
			set{
				listaCliente = value;
			}get{
				return listaCliente;
			}
		}
		public ArrayList ListaCuenta{
			set{
				listaCuenta = value;
			}get{
				return listaCuenta;
			}
		}
		
		//METODOS CLIENTES
		
		public void agregarCli(Cliente cli){//agrega clientes (sirve)
			
			listaCliente.Add(cli);
		}
		
		public void eliminarCliente(int dni){//elimina un cliente (sirve)
			int x = 0;
			int z = 0;
			foreach (Cliente cli in listaCliente){
				 if(cli.Dni==dni){
					z = x;
				}
				x++;
			}
			listaCliente.RemoveAt(z);
			Console.WriteLine("!!     CLIENTE ELIMINADO CORRECTAMENTE    !!");
		}
		
		public bool existeCliente(int dni){//vemos si existe cliente (sirve)
			bool existe = false;
			foreach (Cliente cli in listaCliente){
				if (cli.Dni==dni){
				existe = true;
				}
			}
			return existe;
			
		}
		
		public bool existesCliente(Cliente cli){
			bool existe = false;
			foreach(Cliente c in ListaCliente){
				if(cli.Nombre==c.Nombre && cli.Apellido==c.Apellido && cli.Dni==c.Dni && cli.Direccion==c.Direccion && cli.Telefono==c.Telefono && cli.Mail==c.Mail){
					existe = true;
				}
			}

			return existe;
		}
		
		public void verCliente(int i){//con este vemos el iesimo cliente (sirve)
			int x = 0 ;
			foreach (Cliente cli in listaCliente){
				if (x==i-1){
					cli.imprimirCliente();
				}
				x++;
			}
			
		}
		
		public void listarClientes(){//lista todos los clientes (sirve)
			if(listaCliente.Count>0){
				foreach(Cliente cli in listaCliente){
					cli.imprimirCliente();
				}
			}
			else if(listaCliente.Count==0){
				Console.WriteLine("!!!!!    NO SE ENCONTRARON CLIENTES    !!!!!");
			}
		}

		public void cantidadClientes(){//devuelve la cantidad total de clientes que hay (sirve)
			Console.WriteLine(listaCliente.Count);
		}
		
		
		
		// METODOS CUENTA
		
		public void altaCuenta(Cuenta unaC){//agrega cuentas (sirve)
			
			listaCuenta.Add(unaC);
		}
		
		public bool existeCuenta(string numCuenta){//vemos si existe cuenta (sirve)
			bool existe = false;
			foreach (Cuenta cli in listaCuenta){
				if (cli.NumCuenta==numCuenta){
				existe = true;
				}
			}
			return existe;
			
			
		}
		
		public void verCuenta(int j){//con este vemos la jesima cuenta (sirve)
			int x = 0 ;
			foreach (Cuenta cli in listaCuenta){
				if (x==j){
					cli.imprimirCuenta();
				}
				x++;
			}
			
		}
		
		public void ListarClienteVariasCuentas(){
			int cuenta = 0;
			int dni = 0;
			foreach(Cliente c in listaCliente){
				dni = c.Dni;
				foreach(Cuenta cu in listaCuenta){
					if(c.Dni==cu.DniCuenta){
						cuenta++;
					}
				}
				if(cuenta>=2){
					foreach(Cliente k in listaCliente){
						Console.WriteLine(k.Nombre+" "+ k.Apellido);
						foreach(Cuenta cu in listaCuenta){
							if(dni==cu.DniCuenta){
								Console.WriteLine("\n -NumCuenta: "+ cu.NumCuenta + 
			                  					 "\n -Saldo: "+ cu.Saldo);
							}
						}
					}
				}
				cuenta=0;
			}
		}
		
		public void consultarUnCliente(int dni){
			
			foreach(Cliente cli in listaCliente){
				
				if (dni == cli.Dni) {
					cli.imprimirCliente();
					
					foreach (Cuenta cue in listaCuenta) {
						if (dni == cue.DniCuenta) {
							Console.WriteLine("\n" +
			                  "\n -Numero de Cuenta: "+ cue.NumCuenta +
						      "\n -Saldo: "+ cue.Saldo);
						}
					}
				}
			}
		}
		
		public void listarCuentas(){//lista todos las cuentas (sirve)
			
			if(listaCuenta.Count>0){
				foreach(Cuenta cli in listaCuenta){
					cli.imprimirCuenta();
				}
			}
			else if(listaCuenta.Count==0){
				Console.WriteLine("!!!!!    NO SE ENCONTRARON CUENTAS   !!!!!");
			}
		}

		public void cantidadCuentas(){//devuelve un int con la cantidad total de cuentas que hay (sirve)
			Console.WriteLine(listaCuenta.Count);
		}
		
		public void agregarCuentaClienteExistente(int Dni){//agrega una cuenta a un cliente existente
			
			string nombre = "";
			string apellido = "";
			int dni = 0;
			foreach (Cliente cli in listaCliente){
				if (cli.Dni==Dni){
					nombre = cli.Nombre;
					apellido = cli.Apellido;
					dni = cli.Dni;
					Cuenta nuevo = new Cuenta(nombre,apellido, dni);
					altaCuenta(nuevo);
				}
			}
			
			
		}
		
		public void bajaCuenta(string numCuenta){//elimina una cuenta con el numero de cuenta
			int pos = 0;
			int count = 0;
			int dni = 0;
			foreach(Cuenta c in listaCuenta){
				if(c.NumCuenta==numCuenta){
					pos = count;
					dni = c.DniCuenta;
				}
				count++;
			}
			int cuentas = 0;
			foreach(Cuenta c in listaCuenta){
				if(c.DniCuenta==dni){
					cuentas++;
				}
			}
			if(cuentas>=2){
				eliminarCuenta(pos);
			
				Console.WriteLine("\n ------------------------------------------------- "+
						  	      "\n -          CUENTA ELIMINADA CON EXITO           -"+
						  	      "\n -------------------------------------------------");
			}
			if(cuentas==1){
				eliminarCuenta(pos);
				eliminarCliente(dni);
			}
		}
		
		
		public void eliminarCuenta(int x){// elimina una cuenta (sirve)
			listaCuenta.RemoveAt(x);
			Console.WriteLine("!!       CUENTA ELIMINADA CON EXITO       !!");
		}
		
		
		public void depositar(string numCuenta, double saldo){// modifica el saldo de una cuenta dicha
			foreach(Cuenta c in ListaCuenta){
				if(c.NumCuenta==numCuenta){
					c.Saldo = saldo;
				}
			}
		}
		
		public void extraer(string numCuenta, double extraer){// extrae el saldo de una cuenta dicha y si es menor lo rechaza
			int y = 0;
			foreach(Cuenta c in ListaCuenta){
				
				if(numCuenta == c.NumCuenta){
					
					if(c.Saldo < extraer){
						
						throw new ManejoException("\n ------------------------------------------------- "+
			                			  "\n -              SALDO INSUFICIENTE               -"+
			               				  "\n -------------------------------------------------");
					}
					else if(c.Saldo > extraer){
						c.Saldo = c.Saldo - extraer;
						Console.WriteLine("\n ------------------------------------------------- "+
			                	 		  "\n -        EXTRACCION REALIZADA CON EXITO         -"+
			               				  "\n -------------------------------------------------");
					}
				}
				y++;
			}
		}

		
	}
}

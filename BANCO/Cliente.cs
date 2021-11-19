/*
 * Creado por SharpDevelop.
 * Usuario: yonat
 * Fecha: 10/11/2020
 * Hora: 23:59
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace BANCO
{
	public class Cliente
	{
		private string nombre;
		private string apellido;
		private int dni;
		private string direccion;
		private int telefono;
		private string mail;
		
		public Cliente(string nombre, string apellido, int dni, string direccion, int telefono, string mail){
			
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.direccion = direccion;
			this.telefono = telefono;
			this.mail = mail;
		}
		
		
		
		// set y get de cada atributo para poder modificarlo
		public string Nombre{
			set{
				nombre = value;
			}get{
				return nombre;
			}
		}
		
		public string Apellido{
			set{
				apellido = value;
			}get{
				return apellido;
			}
		}
		
		public int Dni{
			set{
				dni = value;
			}get{
				return dni;
			}
		}
		
		public string Direccion{
			set{
				direccion = value;
			}get{
				return direccion;
			}
		}
		
		public int Telefono{
			set{
				telefono = value;
			}get{
				return telefono;
			}
		}
		
		public string Mail{
			set{
				mail = value;
			}get{
				return mail;
			}
		}
		
		public void imprimirCliente(){
			
			Console.WriteLine("\n" +
			                  "\n -Nombre: "+ nombre +
			                  "\n -Apellido: "+ apellido + 
			                  "\n -DNI: "+ dni + 
			                  "\n -Dir: "+ direccion + 
			                  "\n -Tel: "+ telefono +
						      "\n -Mail: "+ Mail);
		}
	}
}

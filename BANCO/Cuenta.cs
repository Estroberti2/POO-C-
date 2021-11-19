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
using System.IO;

namespace BANCO
{
	public class Cuenta
	{
		private string nroCuenta;
		private string nombre;
		private string apellido;
		private int dni;
		private double saldo;
		
		
		public Cuenta(string nombre, string apellido, int dni)
		{
			
			nroCuenta = Ramdon();
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			saldo = 0;	
			
		}
		
		public Cuenta(string nombre, string apellido, int dni, double saldo)
		{
			
			nroCuenta = Ramdon();
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.saldo = saldo;	
			
		}
		
		
		// set y get de cada atributo para poder modificarlo
		public string NumCuenta{
			set{
				nroCuenta = value;
			}get{
				return nroCuenta;
			}
		}
		
		public string NomCuenta{
			set{
				nombre = value;
			}get{
				return nombre;
			}
		}
		
		public string ApeCuenta{
			set{
				apellido = value;
			}get{
				return apellido;
			}
		}
		
		public int DniCuenta{
			set{
				dni = value;
			}get{
				return dni;
			}
		}
		
		public double Saldo{
			set{
				saldo = value;
			}get{
				return saldo;
			}
		}
		
		public void imprimirCuenta(){
			Console.WriteLine("\n" +
			                  "\n -Numero de Cuenta: "+ nroCuenta +
			                  "\n -Nombre: "+ nombre +
			                  "\n -Apellido: "+ apellido + 
			                  "\n -DNI: "+ dni + 
						      "\n -Saldo: "+ saldo);
		}
		
				
		public string Ramdon(){//genera un string con valores al azar
			string path = Path.GetRandomFileName();
    		path = path.Replace(".", ""); // elimina puntos y espacion
    		return path.Substring(0, 8);  // devuelve los primeros 8 caracteres del string
		}
	}
}

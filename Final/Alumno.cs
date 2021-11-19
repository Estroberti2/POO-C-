/*
 * Creado por SharpDevelop.
 * Usuario: almma
 * Fecha: 10/8/2021
 * Hora: 14:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Final
{
	/// <summary>
	/// Description of Alumno.
	/// </summary>
	public class Alumno
	{
		private string nombre;
		private int dni, cantHerm;

		public Alumno(string n, int doc, int h )
		{
			nombre = n;
			dni = doc;
			cantHerm= h;
		}
		public string Nombre
		{
			set{
				nombre=value;
			}
			get{
				return nombre;
			}
		}		
		public int Dni
		{
			set{
				dni=value;
			}
			get{
				return dni;
			}
		}		
		public int CantHerm
		{
			set{
				cantHerm=value;
			}
			get{
				return cantHerm;
			}
		}		
	}
}

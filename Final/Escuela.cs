/*
 * Creado por SharpDevelop.
 * Usuario: almma
 * Fecha: 10/8/2021
 * Hora: 14:10
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;

namespace Final
{
	/// <summary>
	/// Description of Escuela.
	/// </summary>
	public class Escuela
	{
		protected ArrayList alumnos;
		private string nombre;

		public Escuela (string nom) {

			alumnos= new ArrayList();
			nombre = nom;
		}

		public void inscribirAlu (Alumno a){
			alumnos.Add(a);  
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
	}
}

/*
 * Creado por SharpDevelop.
 * Usuario: almma
 * Fecha: 16/6/2021
 * Hora: 13:19
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Vivero
{
	/// <summary>
	/// Description of Especie.
	/// </summary>
	public class Especie
	{
		private string nombreespecie;
        private string tipoplanta;   /*interior, exterior*/
        
		public Especie(string nomEspecie, string tipoPlanta)
		{
			nombreespecie = nomEspecie;
			tipoplanta = tipoPlanta;
		}
		public string especiePlanta
		{
			set{
				nombreespecie=value;
			} 
			get{
				return nombreespecie;
			}
		}
		
		public string tipoPlanta
		{
			set{
				tipoplanta=value;
			} 
			get{
				return tipoplanta;
			}
		}
	}
}

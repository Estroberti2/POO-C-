/*
 * Creado por SharpDevelop.
 * Usuario: yonat
 * Fecha: 11/11/2020
 * Hora: 00:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace BANCO
{
	public class ManejoException:Exception
	{
		public string mensaje;
		
		public ManejoException(string mensaje)
		{
			this.mensaje = mensaje;
		}
	}
}

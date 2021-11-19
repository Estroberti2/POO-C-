
using System;

namespace Consultorio_medico
{
	public class NoHayTurnosException : Exception
	{
		public NoHayTurnosException()
		{
			Console.WriteLine(" HORARIOS NO DISPONIBLES, LLAMAR PROXIMO DIA DE ATENCIÓN");
		}
	}
}
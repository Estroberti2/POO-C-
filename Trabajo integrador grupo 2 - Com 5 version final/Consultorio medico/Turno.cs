
using System;

namespace Consultorio_medico
{
	/// <summary>
	/// Description of Turno.
	/// </summary>
	public class Turno
	{
		private string nombrePac,hora;
		private int dnipac;
		public Turno(string hora,string nombrePac,int dni)
		{
			this.nombrePac=nombrePac;
			this.hora=hora;
			this.dnipac=dni;
		}
		public Turno()
		{
			
		}
		public Turno(string nombrePac,int dni)
		{
			this.nombrePac=nombrePac;
			this.dnipac=dni;
		}
		
		public string NombrePac{
			set{nombrePac=value;}
			get{return nombrePac;}
		}
		
		public string Hora{
			set{hora=value;}
			get{return hora;}
		}
		
		public int Dnipac{
			set{dnipac=value;}
			get{return dnipac;}
		}
	}
}

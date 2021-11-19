/*
 * Creado por SharpDevelop.
 * Usuario: almma
 * Fecha: 10/8/2021
 * Hora: 14:10
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Final
{
	/// <summary>
	/// Description of EscuelaPrivada.
	/// </summary>
	public class EscuelaPrivada:Escuela
	{
		private float cuotaMensual, matricula;

		public EscuelaPrivada (float prec, float mat, string nom): base (nom) 
		{
			cuotaMensual = prec;
			matricula=mat;

		}
		public void recaudacionAnual(){
			double recaudacionCuota = 0;
			double recaudacionMatricula = 0;
			foreach(Alumno a in alumnos){
				double recaudadoA;
				if(a.CantHerm >= 2){
					recaudadoA = (cuotaMensual - (cuotaMensual * 0.2)) * 11;
					recaudacionMatricula += (matricula - (matricula * 0.2));
					recaudacionCuota += recaudadoA;
				}
				if(a.CantHerm < 2 && a.CantHerm >= 0){
					recaudacionMatricula += matricula;
					recaudadoA = cuotaMensual * 11;
					recaudacionCuota += recaudadoA;
				}
			}
			double total = recaudacionMatricula + recaudacionCuota;
			Console.WriteLine("El todal recaudado por matriculas es {0}\n"+
			                  "El total recaudado en cuotas es {1}\n"+
			                  "Dando un total de {2}", recaudacionMatricula, recaudacionCuota, total);
		}
		public float CuotaMensual
		{
			set{
				cuotaMensual=value;
			}
			get{
				return cuotaMensual;
			}
		}		
		public float Matricula
		{
			set{
				matricula=value;
			}
			get{
				return matricula;
			}
		}		
	}
}


using System;
using System.Collections;

namespace Consultorio_medico
{
	/// <summary>
	/// Description of Médico.
	/// </summary>
	public class Médico
	{
		private string nommed,apemed;
		private int dnimed;
		private ArrayList pacientes;
		private Turno turnos;
		private Turno[] turnosdias;
		public Médico(string nommed,string apemed,int dni)
		{
			this.nommed=nommed;
			this.apemed=apemed;
			this.dnimed=dni;
			pacientes=new ArrayList();
			turnosdias=new Turno[9];
			for(int p=0;p<9;p++){ //Se inicializa el arreglo de turnos
				Turno turnosinciales= new Turno(" ",0);
					turnosdias[p]=turnosinciales;
			}
			(turnosdias[0]).Hora="8:00";
			(turnosdias[1]).Hora="8:30";
			(turnosdias[2]).Hora="9:00";
			(turnosdias[3]).Hora="9:30";
			(turnosdias[4]).Hora="10:00";
			(turnosdias[5]).Hora="10:30";
			(turnosdias[6]).Hora="11:00";
			(turnosdias[7]).Hora="11:30";
			(turnosdias[8]).Hora="12:00";
		}
		
		public string Nommed{
			set{nommed=value;}
			get{return nommed;}
		}
		
		public string Apemed{
			set{apemed=value;}
			get{return apemed;}
		}
		
		public int Dnimed{
			set{dnimed=value;}
			get{return dnimed;}
		}
		
		public ArrayList Pacientes{
			set{pacientes=value;}
			get{return pacientes;}
		}
		
		public Turno Turnos{
			set{turnos=value;}
			get{return turnos;}
		}
		
		public Turno[] Turnosdias{
			set{turnosdias=value;}
			get{return turnosdias;}
		}
		
		public void agregarPac(Paciente pac){
			pacientes.Add(pac);
		}
		
		public void eliminarPac(Paciente pac){
			pacientes.Remove(pac);
		}
		
		public int totalPac(){
			return pacientes.Count;
		}
			
		public Paciente verPac(int i){
			return(Paciente) pacientes[i];
			
		}
		
		public ArrayList todosPac(){
			return pacientes;
		}
		
		public char esPaciente(Paciente pac){
			
			ArrayList listpac=new ArrayList();
			char res='F';
			listpac= pacientes;
			foreach(Paciente p in listpac) // Recorremos la lista de pacientes
			{
				if(p.Dnipac== pac.Dnipac) // Si el DNI que recibe esta en la lista el valor de la variable "res" cambia
				{
					res='V';
					break;
				}
			}
			return res;
		}
		public void darTurno(string unaHora,string nombrePac,int dni){
			turnos=new Turno();
			turnos.Hora=unaHora;
			turnos.NombrePac=nombrePac;
			turnos.Dnipac=dni;
			switch (unaHora) {
					case "8:00":turnosdias[0]=turnos;
								break;
					case "8:30":turnosdias[1]=turnos;
								break;
					case "9:00":turnosdias[2]=turnos;
								break;
					case "9:30":turnosdias[3]=turnos;
								break;
					case "10:00":turnosdias[4]=turnos;
								break;
					case "10:30":turnosdias[5]=turnos;
								break;
					case "11:00":turnosdias[6]=turnos;
								break;
					case "11:30":turnosdias[7]=turnos;
								break;
					case "12:00":turnosdias[8]=turnos;
								break;
					default: Console.WriteLine("Turno fuera de horario o formato incorrecto de horario");
							break;
			}
		}
		public void cancelarTurno(string unaHora){
			foreach (Turno t in turnosdias) {
				if(t.Hora==unaHora){ // Si el horario que recibe coincide con alguno de los turnos, ese mismo se cancelara
					t.NombrePac=" "; // Se borrara el nombre del paciente...
					t.Dnipac=0; // ... y su DNI de la lista de turnos
				}
			}
		}
		public int totalTurnosOcupados(){
			int canturnos=0;
			foreach (Turno t in turnosdias) 
			{
				if(t.NombrePac!=" "){ // Se contaran la cantidad de turnos que no esten ocupados
					canturnos++;
				}
			}
			return canturnos;
		}
		public Turno verTurno(int j){
			return(Turno) turnosdias[j];
			
		}
		public Turno[] listaDeTurnos(){
			return turnosdias;
		}
	}
}

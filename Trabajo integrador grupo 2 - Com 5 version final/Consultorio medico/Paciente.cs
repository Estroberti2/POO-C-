
using System;
using System.Collections;

namespace Consultorio_medico
{
	/// <summary>
	/// Description of Paciente.
	/// </summary>
	public class Paciente
	{
		private string nompac,apepac,obrasocial;
		private int dnipac,numafiliado;
		private ArrayList diagnosticos;
		public Paciente(string nompac,string apepac,string obrasocial,int dni,int numafiliado)
		{
			this.nompac=nompac;
			this.apepac=apepac;
			this.obrasocial=obrasocial;
			this.dnipac=dni;
			this.numafiliado=numafiliado;
			diagnosticos=new ArrayList();
		}
		public Paciente(int dni){
			this.dnipac=dni;
		}
		public string Nompac{
			set{nompac=value;}
			get{return nompac;}
		}
		public string Apepac{
			set{apepac=value;}
			get{return apepac;}
		}
		public string Obrasocial{
			set{obrasocial=value;}
			get{return obrasocial;}
		}
		public int Dnipac{
			set{dnipac=value;}
			get{return dnipac;}
		}
		
		public int Numafiliado{
			set{numafiliado=value;}
			get{return numafiliado;}
		}
		
		public ArrayList Diagnosticos{
			set{diagnosticos=value;}
			get{return diagnosticos;}
		}
		public void agregarDiag(string diag){
			diagnosticos.Add(diag);
			
		}
		public void eliminarDiag(string diag){//borra el ultimo diagnostico que coincide con el parametro
			diagnosticos.Reverse();
			diagnosticos.Remove(diag);
			diagnosticos.Reverse();
		}
		
		public int cantdiag(){
			return diagnosticos.Count;
		}
		
		public ArrayList verListaDiag(){
			return diagnosticos;
		}
		
		public string verUltimoDiag(){
			return(string) diagnosticos[diagnosticos.Count-1];
		}
	}
}

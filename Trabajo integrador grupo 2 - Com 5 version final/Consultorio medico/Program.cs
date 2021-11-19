using System;
using System.Collections;

namespace Consultorio_medico
{
	class Program
	{
		
		public static string menu(){
			Console.WriteLine("Seleccione la opcion deseada: ");
			Console.WriteLine("1- Dar un turno");
			Console.WriteLine("2- Actualizar diagnostico de un paciente");
			Console.WriteLine("3- Cancelar un turno");
			Console.WriteLine("4- Ver listado de los turnos dados");
			Console.WriteLine("5- Atender a un paciente");
			Console.WriteLine("6- Ver listado de obras sociales de los pacientes");
			Console.WriteLine("7- Listado de pacientes");
			Console.WriteLine("8- Ver último diagnostico de un paciente");
			Console.WriteLine("9- Salir");
			string opcion=Console.ReadLine();
			return opcion;
			
		}
		//**********************************************************************************
		public static void DarTurno(ref Médico m1){
			
			bool formato=true;
			try{
				for(int i=0;i<9;i++){  // Recorremos cada turno disponible, del 1 al 8
					if(m1.totalTurnosOcupados()==9){ // Si todos los 9 turnos ya estan ocupados....
						throw new NoHayTurnosException(); // ... saltara la excepción
					}
				}
			}
			catch(NoHayTurnosException){return;} // y retornara el mensaje ingresado en la excepcion definida, lo que terminara el programa
			
			Console.Write("Ingrese el horario del turno:  ");
			string horario=Console.ReadLine();
			for(int i=0;i<9;i++) 
			{
				if(((m1.Turnosdias[i]).Hora==horario)&&((m1.Turnosdias[i]).NombrePac==" ")){ // Si el horario que se ingreso coincide con los horarios disponibles, y no esta ocupado por ningun paciente se permitira dar el turno
					Console.Write("Ingrese el nombre del paciente:  ");
					string nombre=Console.ReadLine();
					Console.Write("Ingrese el DNI del paciente:  ");
					int DNI=int.Parse(Console.ReadLine());
					for (int j=0;j<9; j++) {
						if((m1.Turnosdias[j]).Dnipac==DNI){
							Console.WriteLine("ERROR,YA SE LE ASIGNO UN TURNO A ESTE NÚMERO DE DNI");
							return;
							
						}
					}
					
					m1.darTurno(horario,nombre,DNI); 
					formato=false;
					break;
					   
					
					
				}
				if(((m1.Turnosdias[i]).Hora==horario)&&((m1.Turnosdias[i]).NombrePac!=" ")){ // Si el horario que se ingreso coincide con un horario ya ocupado por un paciente no se puede dar el turno
					Console.WriteLine("Este turno esta ocupado o ya se atendió.Consulte la lista de turnos para ver si hay turnos disponibles.");
					formato=false;
				}
				
			}
			if (formato) //  Si el horario que se ingreso no es valido el bool "formato" permanecera "true" y se cumplira esta condición
				Console.WriteLine("Entrada incorrecta");
		}
		
		//**********************************************************************************
		public static void ActualizarDiagnostico(ref Médico m1){
			Console.WriteLine("Ingrese el DNI del paciente para actualizar su diagnostico");
			try {
				int dni=int.Parse(Console.ReadLine());
				bool espaciente=false;
				foreach (Paciente p in m1.Pacientes) // Repasamos cada paciente ingresado
				{
					if(p.Dnipac==dni) // Si el DNI ingresado coincide con uno que ya esta en la lista de pacientes se podra actualizar el diagnostico
					{
						Console.WriteLine("Ingrese el nuevo diagnostico");
						p.agregarDiag(Console.ReadLine());
						espaciente=true;
					}
				}
				if(!espaciente) // Si el DNI ingresado no coincide con uno que ya esta en la lista de pacientes no se podra actualizar el diagnostico
					Console.WriteLine("No se encontro el paciente");
				else Console.WriteLine("Diagnostico agregado con exito"); 
			}
			catch (FormatException) 
			{
				Console.WriteLine("Entrada incorrecta");
			}
		}
		//**********************************************************************************
		public static void CancelarUnTurno(ref Médico m1){
			Console.Write("Ingrese la hora del turno a cancelar(formato hh:mm): ");
			string opc=Console.ReadLine();
			bool turnoexiste=false;
			for(int i=0;i<9;i++) // Recorremos todos los turnos
			{
				if((m1.Turnosdias[i]).Hora==opc) // Si el horario que se ingreso esta en la lista de turnos se cancelará
				{
					if(m1.Turnosdias[i].NombrePac!="ATENDIDO"){
					m1.cancelarTurno(opc);
					turnoexiste=true;
					}
					else{
						Console.WriteLine("IMPOSIBLE CANCELAR,ESTE TURNO YA SE ATENDIÓ");
						turnoexiste=true;
					}
				}
			}
			if(!turnoexiste) // Si el horario que se ingreso no esta en la lista de turnos no se cancelará nada
				Console.WriteLine("Entrada incorrecta");
		}
		//*************************************************************************************
		
		public static void ListadoDeTurnosDados(ref Médico m1){
			Console.WriteLine("************TURNOS DEL DIA**************"); // Formamos el cuadro con sus campos
			Console.WriteLine("{0,10}{1,10}{2,12}","Turno","   Nombre","  DNI   ");
			foreach (Turno t in m1.listaDeTurnos()) // Recorremos cada turno de la lista
			{	
				Console.WriteLine("{0,10}{1,10}{2,12}",t.Hora,t.NombrePac,t.Dnipac); // Imprimimos la lista de todos los turnos
			}
			Console.WriteLine("****************************************");
		}
		
		//*************************************************************************************
		public static void AtenderPaciente(ref Médico m1){
			Console.WriteLine("Ingrese la hora del turno a atender(formato hh:mm,de 8:00 a 12:00 cada 30 minutos)");
			string opc=Console.ReadLine();
			bool turnoexiste=false;
			int dni=0;
			string nombre;
			for(int i=0;i<9;i++){
				if(((m1.Turnosdias[i]).Hora==opc)&&((m1.Turnosdias[i]).NombrePac!=" ")&&(((m1.Turnosdias[i]).NombrePac!="ATENDIDO")))// Si el horario ingresado esta en la lista de turnos y tiene asignado ya un paciente entonces podra ser atendido
				{
					turnoexiste=true;
					dni=m1.Turnosdias[i].Dnipac;
					nombre=m1.Turnosdias[i].NombrePac;
					Paciente pp;
					char espaciente=m1.esPaciente(pp=new Paciente(dni)); // 	Se identifica el paciente que necesita ser atendido por medio del dni
					m1.Turnosdias[i].Dnipac=0; // Se elimina el dni del paciente en la lista de turnos...
					m1.Turnosdias[i].NombrePac="ATENDIDO"; // ... y se indica que el paciente fue atendido
					
					if(espaciente=='V')  //Si se encuentra el dni del paciente en la lista pacientes se procede al diagnostico
					{                         
						Console.WriteLine("El paciente pertenece a la lista");
						Console.WriteLine("Ingrese el diagnostico");
						foreach(Paciente p in m1.Pacientes)
						{
							if(p.Dnipac==dni){
								p.agregarDiag(Console.ReadLine());	
							}
						}
					}
					else //Si no se encuentra el dni del paciente se lo agrega a la lista de pacientes
					{                                       
						
						
						
						
						Console.WriteLine("Paciente nuevo,hay que agregarlo a la lista");
						int numafiliado;
						Console.WriteLine("Ingrese apellido");
						string ape=Console.ReadLine();
						Console.WriteLine("Ingrese obra social");
						string social=Console.ReadLine();
						Console.WriteLine("Ingrese numero afiliado a obra social");
						try{numafiliado=int.Parse(Console.ReadLine());} // Si el numero de afiliado no es de tipo entero o excede la cantidad de numeros no sera valido
						
						catch(FormatException)
						{
							Console.WriteLine("Entrada de número de afiliado errónea");
							break;
						}
						catch(OverflowException)
						{
							Console.WriteLine("Formato de Nº de afiliado erróneo.Excede la cantidad de números.");
							break;
						}
						Paciente nuevo=new Paciente(nombre,ape,social,dni,numafiliado);
						// Despues de agregar el nuevo paciente ahora si se podra ingresar el diagnostico
						Console.WriteLine("Ahora ingrese el diagnostico");
						nuevo.agregarDiag(Console.ReadLine());
						m1.agregarPac(nuevo);
						Console.WriteLine("Paciente agregado con exito");
					
					}
				}
				if(((m1.Turnosdias[i]).Hora==opc)&&((m1.Turnosdias[i]).NombrePac==" ")) 
					// Si el horario ingresado esta en la lista de turnos pero no hay ningun paciente ocupando ese turno no se atendera a nadie
				{
					Console.WriteLine("Turno libre");
					turnoexiste=true;
				}
			}
			if(!turnoexiste) // Si el horario es incorrecto el programa se reiniciara
				Console.WriteLine("ERROR: Horario fuera de rango,formato incorrecto o turno ya atendido");
		}
		
		//*************************************************************************************
		
		public static void ListadodeObrasSociales( ref Médico m1 )  {
			Console.WriteLine("*************Lista de obras sociales de los pacientes***********");
			ArrayList diagno=new ArrayList();
			foreach(Paciente s in m1.Pacientes){
				if (diagno.IndexOf(s.Obrasocial)==-1) // Buscamos la obra social en la lista de pacientes...
				{
					diagno.Add(s.Obrasocial); // ... y la agregamos a una nueva lista
				}
			}
			diagno.Sort(); // Ordenamos la lista en orden alfabetico...
			foreach (string s in diagno) 
			{
				Console.WriteLine("- "+s.ToUpper()); // ... y la imprimimos
			}
			Console.WriteLine("****************************************************************");
		}
		
		//*************************************************************************************
		public static void ListadoDePacientes(ref Médico m1){
			Console.WriteLine("*****************************LISTADO DE PACIENTES************************************************");
			Console.WriteLine("{0,15}{1,10}{2,12}{3,15}{4,10}","NOMBRE","APELLIDO","DNI","OBRASOCIAL","  Nº AFILIADO"); // Formamos el cuadro de pacientes con sus campos
			foreach (Paciente p in m1.todosPac()) 
			{
				Console.WriteLine("{0,15}{1,10}{2,12}{3,15}{4,10}",p.Nompac,p.Apepac,p.Dnipac,p.Obrasocial,p.Numafiliado); // Imprimimos la lista de pacientes
			}
			Console.WriteLine("*************************************************************************************************");
		}
		
		//*************************************************************************************
		public static void Ultimodiagnostico(ref Médico m1){	
		Console.WriteLine("Ingrese DNI del paciente a consultar");
		int opc;
		bool nofigura=false;
		try
		{
			opc=int.Parse(Console.ReadLine());
			foreach (Paciente p in m1.Pacientes) // Recorremos cada paciente
			{		
					if(p.Dnipac==opc) // Seleccionamos el DNI del paciente correspondiente
					{
					if(p.Diagnosticos.Count!=0){
						Console.WriteLine("");
						Console.WriteLine("ULTIMO DIÁGNOSTICO: ");
						Console.WriteLine("- "+p.Diagnosticos[(p.Diagnosticos.Count)-1]); // Imprimimos lo ultimo con lo que se diagnostico al paciente
						nofigura=true;
					}
						else {Console.WriteLine("De momento este paciente no tiene ningún diagnóstico");
						nofigura=true;}
					}	
				}
			if(!nofigura) // Si el DNI no esta en la lista de pacientes entonces no es un paciente del medico
				Console.WriteLine("Este DNI no figura en los registros");
			
		        } // Si el dni no es de tipo entero o excede la cantidad de numeros no sera valido
			catch(FormatException)
			{
				Console.WriteLine("Formato de DNI erroneo");
			}
			catch(OverflowException)
			{
				Console.WriteLine("Formato de DNI erroneo.Excede la cantidad de números.");
			}
		}
		//*****************************************************************************************
		public static void Main(string[] args)
		{
			string resp;
			// Creamos al médico
			Médico m1= new Médico("Jose Luis","Diaz",501111222);
			
			//Instanciamos algunos pacientes
			Paciente p1=new Paciente("Mario","Lopez","OSDE",777888,111111);
			Paciente p2=new Paciente("Lucia","Reyes","Galeno",999222,222222);
			Paciente p3=new Paciente("Leonardo","Guzman","Swiss Medical",555666,33333);
			Paciente p4=new Paciente("Soledad","Martinez","IOMA",111222,44444);
			Paciente p5=new Paciente("Pedro","Ramos","OSDE",333666,555555);
			Paciente p6=new Paciente("Maria","Rojas","Htal italiano",222444,666666);
			Paciente p7=new Paciente("Sebastian","Linares","Apres",888777,777777);
			
			//Agreganmos los pacientes al medico
			m1.agregarPac(p1);
			m1.agregarPac(p2);
			m1.agregarPac(p3);
			m1.agregarPac(p4);
			m1.agregarPac(p5);
			m1.agregarPac(p6);
			m1.agregarPac(p7);
			
			//Le damos los turnos a los 7 pacientes ingresados
			m1.darTurno("8:00","Pedro",333666);
			m1.darTurno("8:30","Maria",222444);
			m1.darTurno("9:00","Soledad",111222);
			m1.darTurno("10:00","Lucas",222333);
			m1.darTurno("10:30","Leonardo",555666);
			m1.darTurno("11:00","Mario",777888);
			m1.darTurno("11:30","Lara",111999);
			//Agregando algunos diagnosticos para algunos pacientes
			p1.agregarDiag("Gripe");
			p1.agregarDiag("Mejora levemente");
			p1.agregarDiag("Recuperado totalmente");
			p2.agregarDiag("Gastroenteritis");
			p2.agregarDiag("Recuperada");
			p3.agregarDiag("Cefalea");
			p3.agregarDiag("Continua con el cuadro,nueva medicación");
			
			// Iniciamos la ejecución de datos
			Console.WriteLine("**************************************************************");
			Console.Write("---- ");
			Console.Write("Bienvenido al programa de gestión consultorio médico");
			Console.WriteLine(" ----");
			Console.WriteLine("**************************************************************");
			Console.WriteLine("");
			do{
				string a=menu(); // Asignamos con la variable "a" el valor que se retorno en el metodo "menu"
				switch (a) // Llamamos a los datos de la opcion que se eligio
				{ 
						case "1":	Console.Clear(); // Cada vez que se pida los datos de la opcion elegida se limpiara la consola... 
						ListadoDeTurnosDados(ref m1); // ... y se mostrara un listado de todos los turnos en algunas opciones para poder ingresar los datos de forma mas sencilla
						DarTurno(ref m1);
						break;
						case "2":	Console.Clear();
						ListadoDePacientes(ref m1);
						ActualizarDiagnostico(ref m1);
						break;
						case "3":	Console.Clear();
						ListadoDeTurnosDados(ref m1);
						CancelarUnTurno(ref m1);
						break;
						case "4":	Console.Clear();
						ListadoDeTurnosDados(ref m1);
						break;
						case "5":	Console.Clear();
						ListadoDeTurnosDados(ref m1);
						AtenderPaciente(ref m1);
						break;
						case "6": Console.Clear();
						ListadodeObrasSociales(ref m1);
						break;
						case "7": Console.Clear();
						ListadoDePacientes(ref m1);
						break;
						case "8":Console.Clear();
						ListadoDePacientes(ref m1);
						Ultimodiagnostico(ref m1);
						break;
						case "9":	Console.Clear();
						Console.WriteLine("Hasta pronto");
						resp="n";
						continue;
						default:	Console.WriteLine("Opción errónea");
						break;
				}
				Console.WriteLine("========================================");
				Console.WriteLine("¿Quiere hacer otra operación?s/n"); // Cada vez que se termine de mostrar los datos de cada opcion se repite todo el programa de vuelta hasta que la condicion sea falsa
				resp=Console.ReadLine();
				Console.Clear();
			}
			while(resp=="s"); // Si la condicion es diferente de "s" el programa termina
			
			Console.Write("Presione una tecla para salir . . . ");
			Console.ReadKey(true);
		}
	}
}




	
















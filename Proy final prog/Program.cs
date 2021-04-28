using System;

namespace Proy_final_prog
{
    class Program
    { 
        private double monto,interes,ingreso,plazo,cuota,cdeuda,capital,balance,interes_tabla;
        private int pago=1,cont;
        private DateTime fecha = DateTime.Now;

        public void entradas()
        {
            Console.WriteLine("SERVICO DE PRESTACIONES BANCO POPULAR");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Digite su ingreso mensual");
            ingreso = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("SERVICO DE PRESTACIONES BANCO POPULAR");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Digite el monto que desea solicitar");
            monto = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("SERVICO DE PRESTACIONES BANCO POPULAR");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Digite la tasa de interes anual");
            interes = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("SERVICO DE PRESTACIONES BANCO POPULAR");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Digite el plazo (en meses) del pago");
            plazo = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
        }  
        public void formula()
        {
            cuota = interes/1200 + 1;
            cuota = (double)Math.Pow(cuota, plazo);
            cuota -= 1;
            cuota = (interes/1200) / cuota;
            cuota = interes/1200 + cuota;
            cuota = monto * cuota;

            cdeuda = cuota*100/ingreso;
        }
        public void tablas()
        {
            if (cdeuda<80)
            {
                Console.WriteLine("Monto del prestamo:        RD$ {0}",monto);
                Console.WriteLine("Tasa de porcentaje anual:  {0}%",interes);
                Console.WriteLine("Plazo:                     {0} Meses",plazo);
                Console.WriteLine("Valor de cuota:            RD$ {0}",cuota.ToString("0.00"));
                Console.WriteLine("");
                Console.WriteLine("Capacidad de endeudamiento: {0}% de sus ingresos mensuales",cdeuda.ToString("0.00"));
                Console.WriteLine("");
                 
                 
                Console.Write("Pago");
                Console.Write("\t\t Cuota");
                Console.Write("\t\tCapital ");
                Console.Write("\tInterés");              
                Console.Write("\t\tBalance ");
                Console.Write("\t  Fecha de Pago");
                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                
                balance=monto;
                for (cont=1; cont <= plazo; cont++)
                {
                    interes_tabla = balance * interes/1200;
                    capital = cuota - interes_tabla;
                    balance -= capital;

                    Console.Write("{0}\t    ", pago);

                    Console.Write("\t{0}\t", Math.Round(cuota, 2));
                        
                    Console.Write(" \t{0}\t", Math.Round(capital, 2));
                
                    Console.Write("\t{0}\t", Math.Round(interes_tabla, 2));
                    
                    if (balance >= 1)
                    {
                        Console.Write(" \t{0}    ", Math.Round(balance, 2));
                    }
                    else
                    {
                        Console.Write(" \t{0} \t   ", balance = 0);
                    }

                    fecha = fecha.AddDays(30);
                    Console.Write("\t {0}", fecha.ToString("dd-MMM-yyyy"));

                    pago += 1;
                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Su prestamo no fue aprobado");
                Console.WriteLine("No gana lo suficiente para cumplir la cuota");
            }
        }     
        static void Main(string[] args)
        {
            Program proy = new Program();
            proy.entradas();
            proy.formula();
            proy.tablas();
            Console.ReadKey();

        }
    }
}

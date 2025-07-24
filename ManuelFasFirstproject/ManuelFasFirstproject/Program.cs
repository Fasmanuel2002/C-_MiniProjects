using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManuelFasFirstproject.classes;

namespace ManuelFasFirstproject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float apuesta = 100.0f;
            Horse horse1 = new Horse();
            horse1.Name = "Javi";
            horse1.VelocidadBase = 20;

            Horse horse2 = new Horse();
            horse2.Name = "Noelia";
            horse2.VelocidadBase = 14;

            Horse horse3 = new Horse();
            horse3.Name = "Debora";
            horse3.VelocidadBase = 17;

            Horse horse4 = new Horse();
            horse4.Name = "Ernesto";
            horse4.VelocidadBase = 12;

            Horse horse5 = new Horse();
            horse5.Name = "Henar";
            horse5.VelocidadBase = 13;

            Horse horse6 = new Horse();
            horse6.Name = "Ruben";
            horse6.VelocidadBase = 15;

            var horses = new List<Horse> { horse1, horse2, horse3,
                horse4, horse5, horse6 };



            for (int i = 0; i < horses.Count; i++)
            {
                Console.WriteLine($"Caballo {i + 1}: {horses[i].Name}");
            }
                
            
            Console.WriteLine("Por Quien Apuestas: ");
            String UsuarioChoice = Console.ReadLine();
            Carrera carrera = new Carrera();

            carrera.caballos.AddRange(horses);


            var resultado = carrera.Simular();
            foreach(var horse in resultado)
            {
                Console.WriteLine(horse);

   
            }
            
            Console.WriteLine(string.Join("\n", carrera.Simular()));
            Console.WriteLine("Es el ganador: " + resultado[0].Name);


            if(UsuarioChoice == resultado[0].Name)
            {
                Console.WriteLine("Has Ganado");
            }else
            {
                Console.WriteLine("Has perdido");
            }
        }
    }
}
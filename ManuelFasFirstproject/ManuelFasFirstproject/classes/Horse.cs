using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManuelFasFirstproject.classes
{
    public class Horse
    {
       
        public String Name { get; set; }
        public int VelocidadBase { get; set; }
        public int DistanciaRecorrida { get; set; }


        public void Avanzar(Random rnd) {
            Random rand = new Random();
            DistanciaRecorrida += rnd.Next(1, VelocidadBase + 1);
            
        }

        public override string ToString()
        {
            return $"{Name} (distancia: {DistanciaRecorrida})";
        }
    }

    


}

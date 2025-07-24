using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManuelFasFirstproject.classes;

internal class Carrera
{
    
    public List<Horse> caballos = new List<Horse>();
    public int DistanciaMeta = 100;



    public List<Horse> Simular()
    {
        var rnd = new Random();
        while (!caballos.Any(horse=> horse.DistanciaRecorrida >= DistanciaMeta))
        {
            foreach(Horse horse in caballos)
            {
                horse.Avanzar(rnd);
            }
        }

        return caballos.OrderByDescending(c => c.DistanciaRecorrida).ToList();

    }
}
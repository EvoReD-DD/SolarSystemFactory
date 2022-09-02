using System.Collections.Generic;

interface IPlaneterySystem
{
    List<IPlaneteryObject> PlaneteryObjects { get; set; }

    public void GeneratePlanetSystem(double mass);
}
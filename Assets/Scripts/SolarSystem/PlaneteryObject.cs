using UnityEngine;

public class PlaneteryObject : MonoBehaviour, IPlaneteryObject
{
    public PlaneteryObject(double mass, float speed, float rotationSpeed, float offsetSin, float offsetCos)
    {
        this.mass = mass;
        this.speed = speed;
        this.rotationSpeed = rotationSpeed;
        this.offsetSin = offsetSin;
        this.offsetCos = offsetCos;
        SizeCalculation(mass);
    }

    public Transform target { get; set; }
    public Vector3 scale { get; set; }
    public float speed { get; set; }
    public float rotationSpeed { get; set; }
    public float offsetSin { get; set; }
    public float offsetCos { get; set; }
    public float distance { get; set; }
    public float currentAng { get; set; }
    public double mass { get; set; }

    public void SizeCalculation(double massCompare)
    {
        switch (massCompare)
        {
            case <= MassClass.MercurianMin:
                double minAsteroidan = MassClass.AsteroidanRadiusMin;
                double maxAsteroidan = MassClass.AsteroidanRadiusMax;
                var randomAsteroidan = new System.Random();
                var resultAsteroidanSize =
                    (float) (randomAsteroidan.NextDouble() * (maxAsteroidan - minAsteroidan) + minAsteroidan);
                scale = new Vector3(resultAsteroidanSize, resultAsteroidanSize, resultAsteroidanSize);
                break;
            case <= MassClass.SubterranMin:
                double minMercurian = MassClass.MercurianRadiusMin;
                double maxMercurian = MassClass.MercurianRadiusMax;
                var randSizeMercurian = new System.Random();
                var resultMercurian =
                    (float) (randSizeMercurian.NextDouble() * (maxMercurian - minMercurian) + minMercurian);
                scale = new Vector3(resultMercurian, resultMercurian, resultMercurian);
                break;
            case <= MassClass.TerranMin:
                double min = MassClass.SubterranRadiusMin;
                double max = MassClass.SubterranRadiusMax;
                var rand = new System.Random();
                var result = (float) (rand.NextDouble() * (max - min) + min);
                scale = new Vector3(result, result, result);
                break;
            case <= MassClass.SuperterranMin:
                double minTerran = MassClass.TerranRadiusMin;
                double maxTerran = MassClass.TerranRadiusMax;
                var randTerran = new System.Random();
                var resultTerran = (float) (randTerran.NextDouble() * (maxTerran - minTerran) + minTerran);
                scale = new Vector3(resultTerran, resultTerran, resultTerran);
                break;
            case <= MassClass.NeptunianMin:
                double minSuperterran = MassClass.SuperterranRadiusMin;
                double maxSuperterran = MassClass.SuperterranRadiusMax;
                var randSuperterran = new System.Random();
                var resultSuperterran =
                    (float) (randSuperterran.NextDouble() * (maxSuperterran - minSuperterran) + minSuperterran);
                scale = new Vector3(resultSuperterran, resultSuperterran, resultSuperterran);
                break;
            case <= MassClass.JovianMin:
                double minNeptunian = MassClass.NeptunianRadiusMin;
                double maxNeptunian = MassClass.NeptunianRadiusMax;
                var randNeptunian = new System.Random();
                var resultNeptunian =
                    (float) (randNeptunian.NextDouble() * (maxNeptunian - minNeptunian) + minNeptunian);
                scale = new Vector3(resultNeptunian, resultNeptunian, resultNeptunian);
                break;
            case <= MassClass.JovianMax:
                double minJovian = MassClass.JovianRadiusMin;
                double maxJovian = MassClass.JovianRadiusMax;
                var randJovian = new System.Random();
                var resultJovian = (float) (randJovian.NextDouble() * (maxJovian - minJovian) + minJovian);
                scale = new Vector3(resultJovian, resultJovian, resultJovian);
                break;
        }
    }
}
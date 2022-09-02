using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneterySystem : MonoBehaviour, IPlaneterySystem
{
    public List<IPlaneteryObject> PlaneteryObjects { get; set; }
    public List<PlaneteryObject> PlaneteryObjectsSystem { get; set; }

    private Vector3 centerPoint = new Vector3(0, 0, 0);

    private bool IsCreated = false;
    private bool Once = false;

    private void Update()
    {
        if (IsCreated)
        {
            if (!Once)
            {
                GetDistance();
            }

            PlanetMovement();
        }
    }

    private void Initial()
    {
        PlaneteryObjects = new List<IPlaneteryObject>();
        PlaneteryObjectsSystem = new List<PlaneteryObject>();
    }

    public void GeneratePlanetSystem(double totalMass)
    {
        Initial();
        double currentMassSystem = 0;
        int minPlanetCount = 6;
        for (int i = 0; i < minPlanetCount; i++)
        {
            if (currentMassSystem < totalMass)
            {
                var mass = CreateRandomPlanets();
                Debug.Log("Mass " + mass);
                InstantiatePlanets(i);

                currentMassSystem += mass;
                if (currentMassSystem < totalMass)
                {
                    minPlanetCount++;
                }
            }
        }

        IsCreated = true;
    }

    private double CreateRandomPlanets()
    {
        double mass = Random.Range(0, 5000);
        float randomRotationSpeed = Random.Range(0, 0.5f);
        float randomSpeed = Random.Range(0, 0.5f);
        PlaneteryObject planeteryObject = new PlaneteryObject(mass, randomSpeed, randomRotationSpeed, 1, 1);
        PlaneteryObjects.Add(planeteryObject);
        return mass;
    }

    private void InstantiatePlanets(int i)
    {
        for (int j = 0; j < PlaneteryObjects.Count; j++)
        {
            if (i == j)
            {
                PlaneteryObject planet =
                    Instantiate(Resources.Load("Planet"),
                            new Vector3(j * PlaneteryObjects[j].scale.x,
                                j * PlaneteryObjects[j].scale.y,
                                j * PlaneteryObjects[j].scale.z), Quaternion.identity)
                        .GetComponent<PlaneteryObject>();
                planet.mass = PlaneteryObjects[j].mass;
                planet.offsetCos = PlaneteryObjects[j].offsetCos;
                planet.offsetSin = PlaneteryObjects[j].offsetSin;
                planet.currentAng = PlaneteryObjects[j].currentAng;
                planet.speed = PlaneteryObjects[j].speed;
                planet.rotationSpeed = PlaneteryObjects[j].rotationSpeed;
                planet.target = planet.transform;
                planet.target.localScale = PlaneteryObjects[j].scale;
                PlaneteryObjectsSystem.Add(planet);
            }
        }
    }

    private void PlanetMovement()
    {
        for (int j = 0; j < PlaneteryObjectsSystem.Count; j++)
        {
            PlaneteryObjectsSystem[j].target.position = GetPositon(centerPoint,
                PlaneteryObjectsSystem[j].distance,
                PlaneteryObjectsSystem[j].currentAng,
                PlaneteryObjectsSystem[j].offsetSin, PlaneteryObjectsSystem[j].offsetCos);
            PlaneteryObjectsSystem[j].target
                .Rotate(Vector3.up * PlaneteryObjectsSystem[j].rotationSpeed);
            PlaneteryObjectsSystem[j].currentAng += PlaneteryObjectsSystem[j].speed * Time.deltaTime;
        }

        Once = true;
    }

    private Vector3 GetPositon(Vector3 around, float dist, float angle, float sin, float cos)
    {
        around.x += Mathf.Sin(angle) * dist * sin;
        around.z += Mathf.Cos(angle) * dist * cos;
        return around;
    }

    private void GetDistance()
    {
        for (int j = 0; j < PlaneteryObjectsSystem.Count; j++)
        {
            PlaneteryObjectsSystem[j].distance =
                (PlaneteryObjectsSystem[j].target.position - centerPoint).magnitude;
        }
    }
}
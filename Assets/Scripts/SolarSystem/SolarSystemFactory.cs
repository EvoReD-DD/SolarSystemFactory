using UnityEngine;

public class SolarSystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    [SerializeField] private double _massInput;
    private PlaneterySystem planeterySystem;

    public void Create(double totalMass)
    {
        planeterySystem = this.GetComponent<PlaneterySystem>();
        planeterySystem.GeneratePlanetSystem(totalMass);
    }

    private void Start()
    {
        Create(_massInput);
    }
}
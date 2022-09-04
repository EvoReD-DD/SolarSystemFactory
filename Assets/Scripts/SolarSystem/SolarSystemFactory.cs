using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SolarSystemFactory : MonoBehaviour, IPlaneterySystemFactory
{
    [SerializeField] private TMP_InputField _massInput;
    [SerializeField] private Button _clear;
    private PlaneterySystem planeterySystem;

    private void Start()
    {
        _clear.interactable = false;
    }

    public void Create(double totalMass)
    {
        planeterySystem = this.GetComponent<PlaneterySystem>();
        planeterySystem.GeneratePlanetSystem(totalMass);
        _clear.interactable = true;
    }

    public void ClearCall()
    {
        planeterySystem.Clear();
        _clear.interactable = false;
    }

    public void CreateCall()
    {
        double value = double.Parse(_massInput.text, System.Globalization.CultureInfo.InvariantCulture);
        Create(value);
    }
}
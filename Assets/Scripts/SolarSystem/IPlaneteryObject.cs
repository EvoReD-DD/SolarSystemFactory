using UnityEngine;

public interface IPlaneteryObject
{
    public Transform target { get; set; }
    public Vector3 scale { get; set; }
    public float speed { get; set; }
    public float rotationSpeed { get; set; }
    public float offsetSin { get; set; }
    public float offsetCos { get; set; }
    public float distance { get; set; }
    public float currentAng { get; set; }
    double mass { get; set; }

    void SizeCalculation(double massCompare);
}
using UnityEngine;

[CreateAssetMenu(fileName = "noiseSettings", menuName = "Data/NoiseSettings")]
public class NoiseSettings : ScriptableObject {
    public float octaves;
    public float noiseZoom;
    public Vector2Int offset;
    public Vector2Int worldOffset;
    public float persistance;
    public float redistributionModifier;
    public float exponent;
}
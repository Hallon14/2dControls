using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject
{
    public float topSpeed;
    public float acceleration;
    public float decceleration;
    public float jumpForce;
    public float stamina;

}

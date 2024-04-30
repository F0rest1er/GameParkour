using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public Vector3 Teleport_Point;
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Teleport_Point;
    }
}

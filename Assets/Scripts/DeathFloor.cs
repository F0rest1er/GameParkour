using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public Vector3 Teleport_Point;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); // �������� Rigidbody � �������
        CapsuleCollider cc = collision.gameObject.GetComponent<CapsuleCollider>(); // �������� CapsuleCollider � �������

        if (rb != null && cc != null) // ��������� ������� Rigidbody � CapsuleCollider
        {
            rb.velocity = Vector3.zero; // �������� �������� �������
            rb.angularVelocity = Vector3.zero; // �������� ������� �������� �������

            Vector3 newPos = new Vector3(Teleport_Point.x, Teleport_Point.y + cc.height / 2, Teleport_Point.z); // ��������� ������ CapsuleCollider
            collision.gameObject.transform.position = newPos; // ���������� ������ �� ����� �������
        }
    }
}

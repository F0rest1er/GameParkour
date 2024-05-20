using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    public Vector3 Teleport_Point;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); // Получаем Rigidbody у объекта
        CapsuleCollider cc = collision.gameObject.GetComponent<CapsuleCollider>(); // Получаем CapsuleCollider у объекта

        if (rb != null && cc != null) // Проверяем наличие Rigidbody и CapsuleCollider
        {
            rb.velocity = Vector3.zero; // Обнуляем скорость объекта
            rb.angularVelocity = Vector3.zero; // Обнуляем угловую скорость объекта

            Vector3 newPos = new Vector3(Teleport_Point.x, Teleport_Point.y + cc.height / 2, Teleport_Point.z); // Учитываем высоту CapsuleCollider
            collision.gameObject.transform.position = newPos; // Перемещаем объект на новую позицию
        }
    }
}

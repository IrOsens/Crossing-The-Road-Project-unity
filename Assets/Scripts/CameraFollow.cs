using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 15, -4);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogError("Player belum diassign ke kamera!");
            return;
        }

        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        Quaternion targetRotation = Quaternion.Euler(60f, 0f, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
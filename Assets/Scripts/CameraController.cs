using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minValue, maxValue;

    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        //define min max x, y, z

        Vector3 playerPos = player.position + offset;
        //kiem tra vi tri co ra khoi rang buoc hay khong?
        //gioi han boi cac gia tri min max
        Vector3 boundPos = new Vector3(
            Mathf.Clamp(playerPos.x, minValue.x, maxValue.x),
            Mathf.Clamp(playerPos.y, minValue.y, maxValue.y),
            Mathf.Clamp(playerPos.z, minValue.z, maxValue.z)
            );

        Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPos;
    }
}

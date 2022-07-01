using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed;

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // transform.rotation = Quaternion.Lerp(transform.rotation, player.rotation, smoothSpeed);
        Debug.Log(player.rotation);
        // transform.LookAt(player);

    }
}

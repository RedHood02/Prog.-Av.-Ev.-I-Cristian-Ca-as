using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] StudioEventEmitter backGroundMusic;

    private void Update()
    {
        Vector3 newPos = new(playerTransform.position.x + 6, transform.position.y);
        transform.position = newPos;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offset;
    public Transform Player;
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = (Player.position - this.transform.position).normalized;
        Vector3 desiredPos = Player.transform.position + Offset;
        Vector3 smoothPos = Vector3.Lerp(this.transform.position, desiredPos, smoothing * Time.deltaTime);
        this.transform.position = smoothPos;
    }
}

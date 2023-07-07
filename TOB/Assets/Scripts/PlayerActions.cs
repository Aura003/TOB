using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed;
    public event Action<Vector2> Movement;
    private Vector2 InputVector;


    // Start is called before the first frame update
    void Start()
    {
        joystick.Movement += Move;
    }

    private void Move(Vector2 obj)
    {
        InputVector = obj;
        Movement?.Invoke(InputVector);
    }
    private void OnDestroy()
    {
        joystick.Movement -= Move;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.LogError(InputVector);
        this.transform.position +=  moveSpeed * Time.deltaTime * new Vector3(-InputVector.x, 0, -InputVector.y);
    }
}

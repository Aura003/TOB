using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed;
    public float rotationSpeed;
    public event Action<Vector2> Movement;
    private Vector2 InputVector;

    public Button JumpBTN;
    public Animator playerAnim;
    private float smoothVelocity;

    private void Awake()
    {
        JumpBTN.onClick.AddListener(Jump);
    }
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
        JumpBTN.onClick.RemoveListener(Jump);
    }

    private void Jump()
    {
        playerAnim.SetTrigger("canJump");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerMovement = new Vector3(InputVector.x, 0, InputVector.y);
        //this.transform.position +=  moveSpeed * Time.deltaTime * playerMovement;
        //Debug.LogError(playerMovement.magnitude);

        Vector3 movementDirection = playerMovement.normalized;
        float targetAngle = Mathf.Atan2(movementDirection.x, 0f) * Mathf.Rad2Deg; //second parameter to be movementDirection.z if you want full 360 rotation
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, rotationSpeed);
        if (movementDirection.magnitude > 0)
        {
            this.transform.position += movementDirection * moveSpeed * Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        playerAnim.SetFloat("movement", movementDirection.magnitude);
    }
}

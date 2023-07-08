using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed;
    public event Action<Vector2> Movement;
    private Vector2 InputVector;

    public Button JumpBTN;
    public Animator playerAnim;

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
        Vector3 playerMovement = new Vector3(-InputVector.x, 0, -InputVector.y);
        this.transform.position +=  moveSpeed * Time.deltaTime * playerMovement;
        //Debug.LogError(playerMovement.magnitude);
        playerAnim.SetFloat("movement", playerMovement.magnitude);
    }
}

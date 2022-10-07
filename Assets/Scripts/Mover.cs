using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{

    [SerializeField] float xValue = 0f;
    [SerializeField] float yValue = 0f;
    [SerializeField] float zValue = 0f;

    [SerializeField] float speedValue = 1f;

    private PlayerController playerController;

    void Awake()
    {
        playerController = new PlayerController();
        playerController.Move.MoveInput.started += OnMove;
        playerController.Move.MoveInput.canceled += OnMove;
        playerController.Move.MoveInput.performed += OnMove;
    }

    void OnEnable()
    {
        playerController.Enable();
    }

    void OnDisable()
    {
        playerController.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void OnMove(InputAction.CallbackContext context) 
    {
        Vector2 horizontalInput = context.ReadValue<Vector2>();
        xValue = horizontalInput.x * speedValue;
        zValue = horizontalInput.y * speedValue;
    }

    void PrintInstruction() 
    {
        Debug.Log("Use WASD to control player");
    }

    void MovePlayer() 
    {
        transform.Translate(xValue * Time.deltaTime, yValue, zValue * Time.deltaTime);
    }

}

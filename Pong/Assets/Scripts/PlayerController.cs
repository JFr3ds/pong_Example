using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isPlayerOne;
    [SerializeField] private PaddleMovement paddle;

    private void Awake()
    {
        paddle = GetComponent<PaddleMovement>();
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            paddle.MovePaddle((int)Input.GetAxisRaw("Vertical"));
        }
        else
        { 
            paddle.MovePaddle((int)Input.GetAxisRaw("Vertical2"));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetcMove : MonoBehaviour
{
    [SerializeField] private string _msj;
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log(_msj);
        }
    }
}

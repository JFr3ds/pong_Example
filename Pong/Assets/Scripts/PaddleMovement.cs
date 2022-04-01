using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    Vector2 direccionDeMovimiento;
    public float velref;
    public float velocidadDeMovimiento {get; private set;}
    public float offset;
    public bool isIzq;

    private void Start()
    {
        velocidadDeMovimiento = velref;
        SetPlayer();
    }

    public void MovePaddle(int moveDirY)
    {
        offset = transform.localScale.y / 2f;
        direccionDeMovimiento.y = moveDirY;
        if (transform.position.y + offset >= GameManager.Instance.PointInWorld(GameManager.Instance.DesirePositions()[1]).y && moveDirY > 0)
        {
            direccionDeMovimiento.y = 0;
        }

        if (transform.position.y - offset <= GameManager.Instance.PointInWorld(GameManager.Instance.DesirePositions()[0]).y && moveDirY < 0)
        {
            direccionDeMovimiento.y = 0;
        }

        transform.Translate(direccionDeMovimiento * velocidadDeMovimiento * Time.deltaTime);
    }

    void SetPlayer()
    {
        if (isIzq)
        {
            transform.position = new Vector3(GameManager.Instance.GetValue(ValueToReturn.MinX) + GameManager.Instance.offsetPlayerToMargen, 0, GameManager.Instance.m_disFromCamera);
        }
        else 
        { 
            transform.position = new Vector3(GameManager.Instance.GetValue(ValueToReturn.MaxX) - GameManager.Instance.offsetPlayerToMargen, 0, GameManager.Instance.m_disFromCamera);
        }
    }
}
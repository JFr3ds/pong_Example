using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direccionDeMovimiento;
    public float velocidadDeMovimiento;
    public float offset;

    private void Update()
    {
        offset = transform.localScale.y / 2f;

        direccionDeMovimiento.y = Input.GetAxisRaw("Vertical");
        if (transform.position.y + offset >= GameManager.Instance.PointInWorld(GameManager.Instance.DesirePositions()[1]).y && Input.GetAxisRaw("Vertical") > 0) 
        {
            direccionDeMovimiento.y = 0;
        }

        if (transform.position.y - offset <= GameManager.Instance.PointInWorld(GameManager.Instance.DesirePositions()[0]).y && Input.GetAxisRaw("Vertical") < 0)
        {
            direccionDeMovimiento.y = 0;
        }

        transform.Translate(direccionDeMovimiento * velocidadDeMovimiento * Time.deltaTime);
    }
}

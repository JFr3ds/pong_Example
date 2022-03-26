using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float m_speedBall;
    [SerializeField] private Vector2 m_ballDirection;
    [SerializeField] private float expectedTime;
    
    float timeElapsed;


    private void Start()
    {
        /*
        float distanceX = transform.position.x - gameManager.PointInWorld(gameManager.GetScreenSize()).x;
        Debug.Log(distanceX);
        expectedTime = distanceX / m_speedBall;
        expectedTime = Mathf.Abs(expectedTime);
        */
    }

    private void Update()
    {
        /*
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= expectedTime)
        {
            return;
        }
        */


        if (transform.position.x > GameManager.Instance.PointInWorld(GameManager.Instance.GetScreenSize()).x && m_ballDirection.x > 0)
        {
            m_ballDirection.x *= -1;
        }

        if (transform.position.x < GameManager.Instance.PointInWorld(Vector3.zero).x && m_ballDirection.x < 0)
        {
            m_ballDirection.x *= -1;
        }

        if (transform.position.y > GameManager.Instance.PointInWorld(GameManager.Instance.GetScreenSize()).y && m_ballDirection.y > 0)
        {
            m_ballDirection.y *= -1;
        }

        if (transform.position.y <  GameManager.Instance.PointInWorld(Vector3.zero).y && m_ballDirection.y < 0)
        {
            m_ballDirection.y *= -1;
        }
        transform.Translate(m_ballDirection * m_speedBall * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_ballDirection.x *= -1;
        }
    }
}

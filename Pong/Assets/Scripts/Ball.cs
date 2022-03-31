using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speedRef;
    public float m_speedBall { get; private set; }
    [SerializeField] private Vector2 m_ballDirection;
    [SerializeField] private float expectedTime;
    
    float timeElapsed;

    private void Start()
    {
        m_speedBall = speedRef;
    }

    private void Update()
    {
        if (transform.position.x > GameManager.Instance.PointInWorld(GameManager.Instance.GetScreenSize()).x && m_ballDirection.x > 0)
        {
            GameManager.Instance.UpdateScore(1);
            gameObject.SetActive(false);
        }

        if (transform.position.x < GameManager.Instance.PointInWorld(Vector3.zero).x && m_ballDirection.x < 0)
        {
            GameManager.Instance.UpdateScore(2);
            gameObject.SetActive(false);
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

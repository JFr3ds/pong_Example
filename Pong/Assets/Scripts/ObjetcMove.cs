using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetcMove : MonoBehaviour
{
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private float m_disFromCamera;
    [SerializeField] private float m_sphereRadius;
    [SerializeField] private GameObject m_ball;
    [SerializeField] private float m_speedBall;
    private Vector2 m_ballDirection;

    private void OnDrawGizmos()
    {
        Vector3 screenReference = new Vector3(Screen.width, Screen.height, m_disFromCamera);
        Vector3[] desirePositions = {
            new Vector3(0,0,m_disFromCamera),
            new Vector3(0,screenReference.y, m_disFromCamera),
            screenReference,
            new Vector3(screenReference.x, 0, m_disFromCamera)
        };

        for (int i = 0; i < desirePositions.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_mainCamera.ScreenToWorldPoint(desirePositions[i]), m_sphereRadius);
            Gizmos.color = Color.green;
            if (i > 0)
            {
                Gizmos.DrawLine(m_mainCamera.ScreenToWorldPoint (desirePositions[i]), m_mainCamera.ScreenToWorldPoint(desirePositions[i - 1]));
            }
            else
            {
                Gizmos.DrawLine(m_mainCamera.ScreenToWorldPoint(desirePositions[i]), m_mainCamera.ScreenToWorldPoint(desirePositions[desirePositions.Length-1]));
            }
        }
    }
}

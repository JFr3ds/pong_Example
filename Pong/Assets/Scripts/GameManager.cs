using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private float m_disFromCamera;
    [SerializeField] private float m_sphereRadius;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

    }

    public Vector3 GetScreenSize()
    {
        Vector3 screenSize = new Vector3(Screen.width, Screen.height, m_disFromCamera);
        return screenSize;
    }

    public Vector3[] DesirePositions()
    {
        Vector3[] desirePositions = {
            new Vector3(0,0,m_disFromCamera),
            new Vector3(0,GetScreenSize().y, m_disFromCamera),
            GetScreenSize(),
            new Vector3(GetScreenSize().x, 0, m_disFromCamera)
        };
        return desirePositions;
    }

    public Vector3 PointInWorld(Vector3 vectorIn)
    {
        Vector3 vectorOut = m_mainCamera.ScreenToWorldPoint(vectorIn);
        return vectorOut;
    }

    /*
    private void OnDrawGizmos()
    {
        for (int i = 0; i < DesirePositions().Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(PointInWorld(DesirePositions()[i]), m_sphereRadius);
            Gizmos.color = Color.green;
            if (i > 0)
            {
                Gizmos.DrawLine(PointInWorld(DesirePositions()[i]), PointInWorld(DesirePositions()[i - 1]));
            }
            else
            {
                Gizmos.DrawLine(PointInWorld(DesirePositions()[i]), PointInWorld(DesirePositions()[DesirePositions().Length - 1]));
            }
        }
    }
    */
}

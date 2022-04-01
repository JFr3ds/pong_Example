using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Camera m_mainCamera;
    public float m_disFromCamera;
    [SerializeField] private float m_sphereRadius;
    public float offsetPlayerToMargen;

    private int m_scorePlayerOne;
    private int m_scorePlayerTwo;
    [SerializeField] UIController m_uiController;

    [SerializeField] Ball m_ball;
    [SerializeField] Vector3 m_ballStartPosition;

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

    public void StartRound()
    {
        m_ball.transform.position = m_ballStartPosition;
        m_ball.OnInitializeBall();
    }

    public void UpdateScore(int indexPlayer)
    {
        if (indexPlayer == 1)
        {
            m_scorePlayerOne++;
        }
        else if (indexPlayer == 2)
        {
            m_scorePlayerTwo++;
        }
        m_uiController.UpdateScoreUi(m_scorePlayerOne, m_scorePlayerTwo);
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
            GetScreenSize(),
        };
        return desirePositions;
    }

    public Vector3 PointInWorld(Vector3 vectorIn)
    {
        Vector3 vectorOut = m_mainCamera.ScreenToWorldPoint(vectorIn);
        return vectorOut;
    }

    public float GetValue(ValueToReturn val)
    {
        float myVal = 0;
        switch (val)
        {
            case ValueToReturn.MinX:
                myVal = PointInWorld(DesirePositions()[0]).x;
                break;
            case ValueToReturn.MaxX:
                myVal = PointInWorld(DesirePositions()[1]).x;
                break;
            case ValueToReturn.MinY:
                myVal = PointInWorld(DesirePositions()[0]).y;
                break;
            case ValueToReturn.MaxY:
                myVal = PointInWorld(DesirePositions()[1]).y;
                break;
        }
        return myVal;
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

public enum ValueToReturn
{ 
    MinX,
    MaxX,
    MinY,
    MaxY
}

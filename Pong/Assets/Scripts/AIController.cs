using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Ball m_ball;
    public float m_SpeedBall;

    private void Start()
    {
        m_SpeedBall = m_ball.m_speedBall;
    }
}

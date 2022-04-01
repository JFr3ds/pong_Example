using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController: MonoBehaviour
{
    [SerializeField] Text m_scorePlayerOne;
    [SerializeField] Text m_scorePlayerTwo;

    public void UpdateScoreUi(int playerOneScore, int playerTwoScore)
    {
        m_scorePlayerOne.text = $"{playerOneScore}";
        m_scorePlayerTwo.text = $"{playerTwoScore}";
    }

    public void SetScreen(ContentType actualScrren)
    {
        switch (actualScrren)
        {
            case ContentType.Menu:

                break;
            case ContentType.InGame:

                break;
            case ContentType.FinishScreen:

                break;
        }
    }
}

public enum ContentType
{
    Menu,
    InGame,
    FinishScreen
}

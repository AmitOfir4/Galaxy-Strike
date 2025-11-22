using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text scoreBoardText;

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreBoardText.text = score.ToString();
    }
}

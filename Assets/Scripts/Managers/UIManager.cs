using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalScoreText;

    public void UpdateScoreText(int score)
    {
        _scoreText.text = $"Score: {score}";
        _finalScoreText.text = $"Score: {score}";
    }
}

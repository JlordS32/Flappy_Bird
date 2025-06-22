using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void UpdateScoreText(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
}

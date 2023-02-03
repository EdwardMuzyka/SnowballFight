using TMPro;
using UnityEngine;

namespace SnowballFight
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText = null;
        [SerializeField] private ScoringSystem _scoringSystem = null;

        private void Update()
        {
            ScoreText();
        }

        private void ScoreText()
        {
            _scoreText.text = "Score:" + " " + _scoringSystem.CurrentScore.ToString();
        }
    }
}
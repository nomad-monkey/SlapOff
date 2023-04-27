using TMPro;
using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private SlapManager _slapManager;

    // Start is called before the first frame update
    void Start()
    {
        _slapManager = SlapManager.Instance;
        _slapManager.OnSlapEvent.AddListener(UpdateScoreText);
    }

    private void UpdateScoreText()
    {
        var sliderValue = _slapManager.SliderValue;
        var rightHandValue = _slapManager.RightHandValue;
        var leftHandValue = _slapManager.LeftHandValue;
        var score = _slapManager.Score;
        
        scoreText.text = "Slider value: " + sliderValue + "<br>" +
                         "Right hand value: " + rightHandValue + "<br>" +
                         "Left hand value: " + leftHandValue + "<br>" +
                         "Score: " + score;
    }

}

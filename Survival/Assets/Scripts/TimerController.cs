using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Color defaultColor = Color.white;
    public Color alertColor = Color.red;
    private float elapsedTime = 0f;
    private bool isAlert = false;

    void Update()
    {
        elapsedTime += Time.unscaledDeltaTime;
        timerText.text = "Time: " + elapsedTime.ToString("F2");

        if ((int)elapsedTime % 8 == 0 && !isAlert)
        {
            timerText.color = alertColor;
            isAlert = true;
        }
        else if ((int)elapsedTime % 8 != 0 && isAlert)
        {
            timerText.color = defaultColor;
            isAlert = false;
        }
    }
}

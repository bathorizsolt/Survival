using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    public float speedIncreaseInterval = 8f;
    public float speedIncreaseAmount = 0.1f;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.unscaledDeltaTime;

        if (elapsedTime >= speedIncreaseInterval)
        {
            Time.timeScale += speedIncreaseAmount;
            elapsedTime = 0f;
        }
    }
}

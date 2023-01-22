using UnityEngine;
using UnityEngine.UI;

public class TimerAndScore : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public Text timerText;
    public int score = 0;
    public Text scoreText;
    private bool timeUp = false;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + (int)timeLeft;

        if (timeLeft < 0)
        {
            timeUp = true;
            TimeUp();
        }
        if (!timeUp)
        {
            //Reset time
            Time.timeScale = 1;
            
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        Destroy(hit.transform.gameObject);
                        score++;
                        scoreText.text = score + " frogs was ate.";

                        Debug.Log("You ate: " + score + "Frogs");
                    }
                }
            }
        }
    }
    void TimeUp()
    {
        Time.timeScale = 0;
        timerText.text = "Time's up!";
        // disable player's input script
        this.enabled = false;
    }
}
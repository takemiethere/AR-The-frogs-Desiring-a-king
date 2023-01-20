using UnityEngine;
using UnityEngine.UI;

public class TimerAndScore : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public Text timerText;
    public int score = 0;
    public Text scoreText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + (int)timeLeft;

        if (timeLeft < 0)
        {
            Time.timeScale = 0;
            timerText.text = "Time's up!";
        }


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
                    scoreText.text = "Score: " + score;

                    Debug.Log("Score: " + score);
                }
            }
        }

    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }
    }*/
}
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class InfoUI : MonoBehaviour
{

    public Text text;
    public Text texts;
    public Text score;
    public Text endGame;
    public Text timer;
    public int timerC = 60;
    public bool endGamebool = false;
    public int bugCollected = 0;
    public GameObject addone;
    
    RectTransform rt;
    Vector2 startPos;

    void Start()
    {
        rt = GetComponent<RectTransform>();
        startPos = rt.anchoredPosition;
        StartCoroutine(Timer());
    }

    void Update()
    {
        text.text = Planet.Score.ToString("0.#") + "m (distance)";
        texts.text = (126f/Planet.Score).ToString() + "m/s (speed)";

        rt.anchoredPosition = Vector2.Lerp(Vector2.zero, startPos, Planet.Size);


        ENDGAME();
        
    }

    public void ENDGAME()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); 
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1.0)
            {
                Time.timeScale = 0.0f;
                endGame.text = "PAUSE <SPACE>";
            }

            else
            {
                Time.timeScale = 1.0f;
                endGame.text = "";
            }

            if(endGamebool)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void addScore()
    {
        if(bugCollected >= 20)
        {
            Time.timeScale = 0.0f;
            endGamebool = true;
            endGame.text = "WINNER! press SPACE to Restart";
            //WON GAME & RESTART
            return;
        }
        bugCollected += 1;
        StartCoroutine(addonemore());
        score.text = bugCollected + "/20 (bugs collected)";
    }

    IEnumerator Timer()
    {
        if (timerC > 0)
        {
            
            timerC -= 1;
            timer.text = timerC.ToString();
            yield return new WaitForSeconds(1f);
        }
        else
        {
            endGamebool = true;
            Time.timeScale = 0.0f;
            endGame.text = "LOST! press SPACE";
        }
        StartCoroutine(Timer());
    }

    IEnumerator addonemore()
    {
        addone.SetActive(true);
        yield return new WaitForSeconds(1f);
        addone.SetActive(false);
    }

}

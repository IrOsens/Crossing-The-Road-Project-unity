using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PengaturanSkor : MonoBehaviour
{
    public GameObject PreasureTrigger;
    public GameObject Barrier;
    public GameObject Bullet;
    public int Skor = 0;
    public float Times = 80;
    public Text TextSkor;
    public Text CountdownTime;
    public Text WinningText;
    private bool isPaused = false;
    private int LevelID = 1;
    public int Health = 3;
    public Text HealthText;
    public Transform SpawnPoint;
    public GameObject Player;


    void Start()
    {
        Time.timeScale = 1;
        UpdateSkor();
        UpdateHealth();
    }

    public void TambahSkor(int Poin)
    {
        Skor += Poin;
        UpdateSkor();
    }

    void UpdateSkor()
    {
        if (TextSkor != null)
        {
            TextSkor.text = "Skor: " + Skor;
        }
    }

    public void Tertabrak()
    {
        PauseTime();
        LosingPopup(2f);
    }

    public void WinningPopup()
    {
        if (LevelID == 1 && Skor >= 30 && Times > 0)
        {
            WinningText.text = "WIN";
            Skor = 0;
            LevelID += 1;

            PauseTime();
            StartCoroutine(RemoveText(WinningText, 3f));
            StartCoroutine(RemoveText(TextSkor, 0.1f));
            StartCoroutine(PindahKeLevelBerikutnya(2f));
        }
    }

    public void LosingPopup(float countdownTime)
    {
        WinningText.text = "LOSE";
        StartCoroutine(RemoveText(WinningText, 3f));
        StartCoroutine(RestartLevel(countdownTime));
    }

    IEnumerator RestartLevel(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator RemoveText(Text textObject, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        textObject.text = "";
    }

    void Update()
    {
        if (Times <= 0)
        {
            LosingPopup(3f);
        }

        if (!isPaused)
        {
            if (CountdownTime != null)
            {
                Times -= Time.deltaTime;
                int Mundur = Mathf.RoundToInt(Times);

                if (Mundur > 0)
                {
                    int menit = Mundur / 60;
                    int detik = Mundur % 60;

                    int puluhanMenit = menit / 10;
                    int satuanMenit = menit % 10;
                    int puluhanDetik = detik / 10;
                    int satuanDetik = detik % 10;

                    StopWatch(satuanDetik, puluhanDetik, satuanMenit, puluhanMenit);
                }
            }
        }
    }

    void StopWatch(int satuanDetik, int puluhanDetik, int satuanMenit, int puluhanMenit)
    {
        if (CountdownTime != null)
        {
            CountdownTime.text = puluhanMenit.ToString() + satuanMenit.ToString() + ":" + puluhanDetik.ToString() + satuanDetik.ToString();
        }
    }

    public void PauseTime()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
    public void TambahHealth(int jumlah)
    {
        Health += jumlah;
        UpdateHealth();
    }

    public void KurangiHealth(int jumlah)
    {
        Health -= jumlah;
        UpdateHealth();

        if (Health > 0)
        {
            Player.transform.position = SpawnPoint.position;
        }
        else
        {
            Tertabrak();
        }
    }

    void UpdateHealth()
    {
        if (HealthText != null)
        {
            HealthText.text = "Health: " + Health;
        }
    }
    IEnumerator PindahKeLevelBerikutnya(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
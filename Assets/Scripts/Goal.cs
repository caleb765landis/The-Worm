using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public TextMeshProUGUI imageCanvasGroup;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    
    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            if (other.gameObject.GetComponent<WormController>().hasObjective)
            {
                // print("hello");
                m_IsPlayerAtExit = true;
            }
        }
    }

    void Update ()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel (false);
        }
    }

    void EndLevel (bool doRestart)
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.text = "You brought your neighbor some sugar!";


        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}

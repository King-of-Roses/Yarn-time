using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private bool isPaused = false;

    private EventInstance bgmInstance;

    void Update()
    {
        // �����ո���л���ͣ/����״̬
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);  // ������ͣ����
        Time.timeScale = 0f;          // ��ͣ��Ϸ
        AudioManager.instance.PauseAudio();
        isPaused = true;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;         // �ָ���Ϸ
        AudioManager.instance.ResumeAudio();
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

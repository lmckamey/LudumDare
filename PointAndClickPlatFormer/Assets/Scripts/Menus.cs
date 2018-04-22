using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] string m_currentScene;
    [SerializeField] string m_nextScene;

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(m_currentScene);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(m_nextScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

}

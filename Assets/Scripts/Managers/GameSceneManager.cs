using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameSceneManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;

        if (AudioManager.Instance)
        {
            AudioManager.Instance.PauseMusicBG();
            AudioManager.Instance.ResetMusicBG();
        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
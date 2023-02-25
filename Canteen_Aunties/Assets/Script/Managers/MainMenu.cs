using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
    }

    public void ScoreBoard()
    {
        Debug.Log("Scoreboard");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void TodayMenu()
    {
        Debug.Log("Today Menu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void Exit()
    {
        //Application.Quit();
        SceneManager.LoadScene("LandingScene");
        AzureServicesForUnity.Shared.TableStorageClient.Instance.CurrentUser = null;
    }

    public void MoveToFront(GameObject buttonGameObject)
    {
        buttonGameObject.transform.SetAsLastSibling();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string StartGameSceneName;

	public void StartGame() {     
		SceneManager.LoadScene(StartGameSceneName);
    }

    public void QuitGame() {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMaster : MonoBehaviour
{
    public void OnRestartScene()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}

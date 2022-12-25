using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Next() =>
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}

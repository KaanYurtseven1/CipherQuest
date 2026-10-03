using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    const int StartSceneIndex = 0; //Start scene index'i sabit olarak tanimlayalim
    //Kullanici butona basarsa kod calissin
    //public --> bu method baska bir yerden de cagrilabilir, ornek: Unity Button
    //unity'nin Button On Click() event'ine bu methodu ekleyebiliriz
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Mevcut scene'in index'ini alalim
        int nextSceneIndex = currentSceneIndex + 1; //Bir sonraki scene'in index'ini hesaplayalim
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = StartSceneIndex; //Eger bir sonraki scene yoksa, Start scene'e donelim
        }
        SceneManager.LoadScene(nextSceneIndex); //Bir sonraki scene'i yukleyelim

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(StartSceneIndex); //Start scene'i yukleyelim
    }

    public void QuitGame()
    {
#if UNITY_EDITOR //conditional compilation directive, sadece Unity Editor'de calisir
        UnityEditor.EditorApplication.isPlaying = false; //Unity Editor'de oyunu durdur
#else
            Application.Quit(); //Build'da oyunu kapat
#endif
    }
}

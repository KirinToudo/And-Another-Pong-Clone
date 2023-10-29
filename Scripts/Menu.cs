using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;	
using System.Collections;

public class LevelManager : MonoBehaviour
{

    private static LevelManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(string name)
    {
        //Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
        //Brick.breakableCount = 0;
    }

    public void EndGame()
    {
        
        Application.Quit();
    }


 
    public void LoadNextLevel()

    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }



}

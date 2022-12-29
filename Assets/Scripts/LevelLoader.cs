using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    /* void OnTriggerEnter2D(Collider2D other)
    {
         if (other.gameObject.name == "Player")
        {
            //Ensures only contact with player object will cause next scene to laod
            LoadNextLevel();
            
        }
        
    } */
    void Update()
    {
    
    }

    public void LoadNextLevel()
    {
        // Load next scene in line after a delay (you can get no delay by deleting the Coroutine, 
        // or specific scene by just specifying the index of scene found in build settings)
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void LoadWinLevel()
    {
        SceneManager.LoadScene("Scene Win");
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        // Starts animation with trigger "Start"
        transition.SetTrigger("Start");
        // Waits 1 second
        yield return new WaitForSeconds(transitionTime);
        // Loads scene with Index parsed through function
        SceneManager.LoadScene(levelIndex);

    }
}

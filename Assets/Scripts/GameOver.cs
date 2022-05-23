using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverPanel;
    private GameObject player;
    AudioSource myAudio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        myAudio = GetComponent<AudioSource>();
        if (player == null)
        {
            Debug.Log("Show panel");
            gameOverPanel.SetActive(true);
            myAudio.mute = true;  //to mute
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

}

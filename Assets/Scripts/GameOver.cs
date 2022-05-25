using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverPanel;
    private GameObject player;
    public GameObject leaderboardPanel;
    AudioSource myAudio;
    [SerializeField] private PlayFabManager pfm;

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

    public void Leaderboard()
    {
        leaderboardPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        pfm.GetLeaderboard();
    }

    public void Back()
    {
        gameOverPanel.SetActive(true);
        leaderboardPanel.SetActive(false);
        pfm.GetLeaderboard();
    }

    private void Awake()
    {

        // Try and get the component if it is attached to the same object as this
        if (!pfm) pfm = GetComponent<PlayFabManager>();
        // Or try and find it anywhere in the scene
        if (!pfm) pfm = FindObjectOfType<PlayFabManager>();

        // Or simply create and attach it to the same object as this one
        if (!pfm) pfm = gameObject.AddComponent<PlayFabManager>();
    }
}

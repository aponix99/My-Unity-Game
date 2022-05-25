using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private float score;
    private GameObject player;
    [SerializeField] private PlayFabManager pfm;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null)
         {
            if(player==null)
                    {
                        Debug.Log("GameOver");
                        pfm.SendLeaderboard((int)score);
                    }
            else
            {
                score += 1 * Time.deltaTime;
                scoreText.text = ((int)score).ToString();
            }
         
        }
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
    bool GameOver()
    {
        return GameObject.FindGameObjectsWithTag("Player") == null;
    }
}

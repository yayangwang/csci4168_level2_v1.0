using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelMgr: MonoBehaviour
{
    private static GameLevelMgr _instance;

    public static GameLevelMgr Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameLevelMgr>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("GameLevelMgr");
                    _instance = singletonObject.AddComponent<GameLevelMgr>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);  
        }
    }
    public Transform enemy;
    public GameObject gameOverPanel;
    public Transform player;
    public Transform bornPoint;
    public CameraMove mainCamera;

    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        player.transform.position = bornPoint.position;
    }
    public void EnemyAppear()
    {
        enemy.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        mainCamera.GameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private int currentLevel = 1;

    [SerializeField]
    private int currentBlockNumber;

    [Range(0.1f, 10.0f)] [SerializeField]
    private float gameSpeed = 1.0f;

    [SerializeField]
    private int currentScore;

    [SerializeField]
    private int pointsPerBlock;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(this.currentLevel);
        this.currentScore = 0;
        this.pointsPerBlock = 2;
        GetGameSpeed();

        scoreText.SetText(this.currentScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void LoadLevel(int levelNumber) {
        var levelPath = $"{Application.dataPath}/Levels/{levelNumber}.json";
        if(File.Exists(levelPath)) {
            string levelData = File.ReadAllText(levelPath);
            this.GenerateBlocks(levelData);
        }else {
            Debug.Log("Livelli completati");
        }
    }
    private void GenerateBlocks(string levelData) {
        Level level = JsonUtility.FromJson<Level>(levelData);

        this.currentBlockNumber = level.blocks.Length;

        foreach (BlockOptions block in level.blocks) {
            var newBlock = Instantiate(blockPrefab, new Vector3(block.position.x, block.position.y, 0), Quaternion.identity);
            newBlock.GetComponent<SpriteRenderer>().color = block.color;
            newBlock.transform.parent = GameObject.Find("Blocks").transform;
        }
    }

    public void OnBlockDestroyed() {
        this.currentBlockNumber--;

        if(this.currentBlockNumber == 0) {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel() {
        this.currentLevel += 1;
        this.LoadLevel(this.currentLevel);
    }

    private void GetGameSpeed() {
        Time.timeScale = gameSpeed;
    } 

    public void AddPointsToScore() {
        currentScore += this.pointsPerBlock;
        scoreText.SetText(this.currentScore.ToString());
    }
}

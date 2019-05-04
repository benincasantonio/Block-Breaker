using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GenerateBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        string levelData = File.ReadAllText($"{Application.dataPath}/Levels/1.json");
        Level level = JsonUtility.FromJson<Level>(levelData);

        foreach (BlockOptions block in level.blocks) {
            var newBlock = Instantiate(blockPrefab, new Vector3(block.position.x, block.position.y, 0), Quaternion.identity);
            newBlock.GetComponent<SpriteRenderer>().color = block.color;
            newBlock.transform.parent = gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

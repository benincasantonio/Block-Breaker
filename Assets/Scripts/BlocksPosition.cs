using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BlocksPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Level level = new Level();
        level.levelNumber = 2;
        List<BlockOptions> blockList = new List<BlockOptions>();

        for(int i = 0; i < transform.childCount; i++) {
            Transform block = transform.GetChild(i);
            Vector2 position = block.position;
            BlockOptions blockOptions = new BlockOptions();
            blockOptions.position = new Vector2(position.x, position.y);
            blockOptions.color = block.GetComponent<SpriteRenderer>().color;
            blockList.Add(blockOptions);
        }
        level.blocks = blockList.ToArray();

        var json = JsonUtility.ToJson(level, true);
        string path = $"{Application.dataPath}/Levels/{level.levelNumber}.json";
        File.WriteAllText(path, json);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

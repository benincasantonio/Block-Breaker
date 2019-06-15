using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    private AudioClip breakSound;

    LevelManager level;

    [SerializeField]
    GameObject blockVFX;

    void Start() {
        level = FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, new Vector3(transform.position.x, transform.position.y, 0));
        level.OnBlockDestroyed();
        if (transform.tag == "Breakable") { 
            level.AddPointsToScore();
            TriggerBlockVFX();
            Destroy(gameObject);
        }
    }

    void TriggerBlockVFX() {
        GameObject VFX = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(VFX, blockVFX.GetComponent<ParticleSystem>().main.duration);
    }
}

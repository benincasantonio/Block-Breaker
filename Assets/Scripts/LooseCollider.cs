using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour {
    
	private void OnTriggerEnter2D(Collider2D collider) {
        SceneManager.LoadScene("Win Screen", LoadSceneMode.Single);
    }
}

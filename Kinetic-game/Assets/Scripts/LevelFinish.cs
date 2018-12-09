using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour {

    public int sceneNumber;
    public ParticleSystem particles;

	void Start () {
        particles = GetComponent<ParticleSystem>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            particles.Play();
            StartCoroutine(WaitForLevelEnd());
        }
    }

    private IEnumerator WaitForLevelEnd()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNumber);
    }

}

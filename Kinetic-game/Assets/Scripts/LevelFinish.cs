using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour {

    public int sceneNumber;
    public ParticleSystem particles;
    public GameObject levelEndDoor;
    private Animator doorAnimator;

    void Start () {

        if (levelEndDoor.GetComponent<Animator>() != null)
        {
            doorAnimator = levelEndDoor.GetComponent<Animator>();
        }
        particles = GetComponent<ParticleSystem>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open");
            }
            //particles.Play();
            StartCoroutine(WaitForLevelEnd());
        }
    }

    private IEnumerator WaitForLevelEnd()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneNumber);
    }

}

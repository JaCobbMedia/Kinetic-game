using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private PlayerStatus playerStatus;
    private float maxHealth;
    private float currentHealth;
    public Image healthBar;

	void Start () {

        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        if(playerStatus != null)
        {
            maxHealth = playerStatus.health;
            currentHealth = playerStatus.health;
            UpdateHealthBar();
        }
	}

    private void Update()
    {
        currentHealth = playerStatus.health;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        float ratio = currentHealth / maxHealth;

        if (ratio < 0)
            ratio = 0;

        healthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffectCanvas : MonoBehaviour {

    public GameObject damageEffectCanvas;

    private PlayerStatus playerStatus;
    private Animator damageEffectAnimator;

    private void OnEnable()
    {
        if (damageEffectCanvas.GetComponent<Animator>() != null)
        {
            damageEffectAnimator = damageEffectCanvas.GetComponent<Animator>();
        }
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        playerStatus.EventHealthDeduction += ShowEffect;

    }

    private void OnDisable()
    {
        playerStatus.EventHealthDeduction -= ShowEffect;
    }

    private void ShowEffect(float damage)
    {
        if (playerStatus.health + damage > 0)
        {
            if (damage / playerStatus.maxHealth > 0.4f) damageEffectAnimator.SetTrigger("Effect2");
            else if (damage / playerStatus.maxHealth > 0.075f) damageEffectAnimator.SetTrigger("Effect1");
            else damageEffectAnimator.SetTrigger("Effect0");
        }
    }
}

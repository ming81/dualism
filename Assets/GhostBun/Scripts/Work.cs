﻿using EmeraldAI;
using System.Collections;
using UnityEngine;

public class Work : MonoBehaviour
{
    [SerializeField] private int _emoteAnimationIndex;

    private EmeraldAIEventsManager _eventSystem;

    public float turnOffTrigetTime = 10f;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Worker on point: " + _emoteAnimationIndex);
        if (other.CompareTag("NPC"))
        {
            //Debug.Log("Worker on point: " + _emoteAnimationIndex);
            _eventSystem = other.GetComponent<EmeraldAIEventsManager>();

            // Останавливаем движение NPC до окончания анимации
            StartCoroutine(Working(other.GetComponent<AnimationsArray>().AnimationsLength[_emoteAnimationIndex]));
        }
        else if (other.CompareTag("Player"))
        {
            //Debug.Log("Worker on point: " + _emoteAnimationIndex);
            _eventSystem = other.GetComponent<EmeraldAIEventsManager>();

            // Останавливаем движение NPC до окончания анимации
            StartCoroutine(Working(other.GetComponent<AnimationsArray>().AnimationsLength[_emoteAnimationIndex]));
        }

    }

    private IEnumerator Working(float delay)
    {
        _eventSystem.StopMovement();
        _eventSystem.PlayEmoteAnimation(_emoteAnimationIndex);
        yield return new WaitForSeconds(delay);
        _eventSystem.ResumeMovement();
        StartCoroutine(TurnOffCollider(turnOffTrigetTime));
    }


    private IEnumerator TurnOffCollider(float delay)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(delay);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}

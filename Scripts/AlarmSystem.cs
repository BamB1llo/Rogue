using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem: MonoBehaviour
{
    private Coroutine _increaseSound;
    private Coroutine _reduceSound;
    private AudioSource _audioSource;
    private float _finalVolueMaximum = 1;
    private float _finalVolumeMinimum = 0;
    private float _duration = 0.1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _audioSource.Play();
            _increaseSound = StartCoroutine(ChangeVolume(_finalVolueMaximum, _duration));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(_increaseSound);
            _audioSource.Stop();

            _reduceSound = StartCoroutine(ChangeVolume(_finalVolumeMinimum, _duration));
            _audioSource.Play();
        }
    }

    private IEnumerator ChangeVolume(float finalValue, float duration)
    {
        while (_audioSource.volume != finalValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, finalValue, duration * Time.deltaTime);

            yield return null;
        }
    }
}

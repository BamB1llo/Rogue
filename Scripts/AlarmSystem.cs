using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSystem : MonoBehaviour
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
            if (_reduceSound != null)
            {
                StopCoroutine(_reduceSound);
                _audioSource.Stop();
            }

            _increaseSound = StartCoroutine(ChangeVolume(_finalVolueMaximum, _duration));
            _audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            if(_increaseSound != null) 
            {
                StopCoroutine(_increaseSound);
                _audioSource.Stop();
            }

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

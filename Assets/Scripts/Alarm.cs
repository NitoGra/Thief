using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
	private bool _isAlarmOn = false;
	private AudioSource _audio;
	private float _volumeDecreases = 0.8f;
	private float _volumeIncreases = 0.8f;
	private float _startVolume = 0.002f;
	private float _delay = 0.001f;
	private float _sirenOn = 1;
	private float _sirenOff = 0;
	private Coroutine _coroutine;

	public void Start()
	{
		_audio = GetComponent<AudioSource>();
		_audio.Stop();
	}

	public void TurnOffSiren()
	{
		_isAlarmOn = false;
		_coroutine = StartCoroutine(SoundChange(_delay, _sirenOff));
	}

	public void TurnOnSiren()
	{
		_audio.Play();
		_audio.volume = _startVolume;
		_isAlarmOn = true;
		_coroutine = StartCoroutine(SoundChange(_delay, _sirenOn));
	}

	private IEnumerator SoundChange(float delay, float targetVolume)
	{
		var wait = new WaitForSeconds(delay);
		bool isContinue = true;

		while (isContinue)
		{
			if (_audio.volume == targetVolume)
			{
				StopCoroutine(_coroutine);
				break;
			}

			if (_isAlarmOn)
				_audio.volume += _volumeIncreases * Time.deltaTime;
			else
				_audio.volume -= _volumeDecreases * Time.deltaTime;

			yield return wait;
		}

		yield return wait;
	}
}
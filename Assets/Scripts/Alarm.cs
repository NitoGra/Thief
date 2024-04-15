using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
	private bool _isAlarmOn = false;
	private AudioSource _audio;
	private float _volumeDecreases = 0.8f;
	private float _volumeIncreases = 0.8f;
	private float _startVolume = 0.002f;
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
		_coroutine = StartCoroutine(SoundChange(_sirenOff));
	}

	public void TurnOnSiren()
	{
		_audio.Play();
		_audio.volume = _startVolume;
		_isAlarmOn = true;
		_coroutine = StartCoroutine(SoundChange(_sirenOn));
	}

	private IEnumerator SoundChange(float targetVolume)
	{
		bool isContinue = true;

		while (isContinue)
		{
			_audio.volume = Mathf.MoveTowards(_audio.volume, targetVolume, Time.deltaTime);

			if (_audio.volume == targetVolume)
			{
				StopCoroutine(_coroutine);
				break;
			}

			yield return null;
		}

		//yield return null;
	}
}
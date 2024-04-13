using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
	[SerializeField] private Alarm alarm;

	public void Start()
	{
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		//alarm.EnemyAlarm();
	}
}
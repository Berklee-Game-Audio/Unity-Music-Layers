using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicSnapshotSwitch : MonoBehaviour {

	public AudioMixerSnapshot mySnapshot;
	public float fadeTime = 3.0f;
	public float delayTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		Debug.Log("OnTriggerEnter");
		if(delayTime < 0.05f)
        {
			mySnapshot.TransitionTo(fadeTime);
		} else
        {
			StartCoroutine(startDelayedTransition());
			
		}




	}

	IEnumerator startDelayedTransition()
	{
		//Print the time of when the function is first called.
		Debug.Log("Delayed snapshot switch starting in: " + delayTime + " seconds.  The current time is: " + Time.time);

		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(delayTime);

		//After we have waited 5 seconds print the time again.
		Debug.Log("Beginning delayed snapshot at: " + Time.time);

		mySnapshot.TransitionTo(fadeTime);
	}

}

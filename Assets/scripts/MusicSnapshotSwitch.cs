using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicSnapshotSwitch : MonoBehaviour {

	public float fadeDuration = 3.0f;
	public float delayTime = 0.0f;
	public float targetVolume = 80.0f;
	public AudioMixer audioMixer;
	private string exposedParameter = "masterVolume";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		Debug.Log("MusicSnapshotSwitch OnTriggerEnter: " + audioMixer.name + " fade to " + targetVolume + " over " + fadeDuration + " seconds.");
		if(delayTime < 0.05f)
        {
			StartCoroutine(FadeMixerGroup.StartFade (audioMixer, exposedParameter, fadeDuration, targetVolume));
			//mySnapshot.TransitionTo(fadeTime);
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

		StartCoroutine(FadeMixerGroup.StartFade(audioMixer, exposedParameter, fadeDuration, targetVolume));
	}

}

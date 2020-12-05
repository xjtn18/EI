using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoChannelsException: System.Exception {}


public class AudioManager {

	private static AudioSource[] channels;
	private static AudioClip[] sounds;
	private static string soundDirName = "Sounds/";


	// Start is called before the first frame update
	static AudioManager() {
		GameObject mainAudio = GameObject.Find("MainAudio");
		channels = mainAudio.GetComponents<AudioSource>();
		
		// set channel 0 for game music
		//PlaySoundOn("hapi_tomi", 0, 0.05f, true); // music
		PlaySoundOn("outdoor_ambience", 1, 0.2f, true);
		PlaySoundOn("major_theme", 1, 0.2f, true);

	}


	private static AudioSource GetFreeChannel(){
		foreach (AudioSource c in channels){
			if (! c.isPlaying){
				return c;
			}
		}
		Debug.Log("No available channel; can't play sound.");
		throw new NoChannelsException();
	}


	public static void PlaySound(string soundName, float volume = 0.5f, bool loop = false){
		// takes the name of the sound (no file extension) and plays it on any free channel
		AudioSource channel; try {channel = GetFreeChannel();} catch {return;}
		channel.clip = Resources.Load<AudioClip>(soundDirName + soundName);
		channel.volume = volume; channel.loop = loop;
		channel.Play();
	}


	public static void PlaySoundOn(string soundName, int cIndex, float volume = 0.5f, bool loop = false){
		// takes the name of the sound (no file extension) and plays it on specified channel
		AudioSource channel = channels[cIndex];
		channel.clip = Resources.Load<AudioClip>(soundDirName + soundName);
		channel.volume = volume; channel.loop = loop;
		channel.Play();
	}


	public static void PlayRandom(string[] soundNames){
		// plays a random sound given a list of sound names
		AudioSource channel; try {channel = GetFreeChannel();} catch {return;}
		int idx = Random.Range(0, soundNames.Length - 1);
		PlaySound(soundNames[idx]);
	}


	public static void StopSound(int cIndex){
		channels[cIndex].Stop();
	}

}



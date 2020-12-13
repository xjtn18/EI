using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NoChannelsException: System.Exception {}


public class AudioManager {

	private static AudioSource[] channels;
	public static string soundDirName = "Sounds/";
	

	public static void start(){
		GameObject mainAudio = GameObject.Find("MainAudio");
		channels = mainAudio.GetComponents<AudioSource>();
		
		// set channel 0 for game music
		PlaySoundOn("outdoor_ambience", 0, 0.2f, true);
		PlaySoundOn("wind", 1, 0.2f, true);
		startBattleMusic();
	}


	public static AudioClip GetSound(string soundName){
		return Resources.Load<AudioClip>(soundDirName + soundName);
	}


	private static void startBattleMusic(){
		GameObject battleMusic = GameObject.Find("BattleMusic");
		AudioSource musicChannel = battleMusic.GetComponent<AudioSource>();
		if ( ! musicChannel.isPlaying){
			musicChannel.clip = Resources.Load<AudioClip>(soundDirName + "major_theme");
			musicChannel.volume = 0.1f;
			musicChannel.loop = true;
			musicChannel.Play();
		}
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


	public static void PlayRandom(string soundPrefix, int numSounds, float volume = 0.5f){
		// plays a random sound given a list of sound names
		AudioSource channel; try {channel = GetFreeChannel();} catch {return;}
		int idx = Random.Range(1, numSounds);
		PlaySound(soundPrefix + idx, volume);
	}


	public static void StopSound(int cIndex){
		channels[cIndex].Stop();
	}

	public static void closeMusicFilter(){
		GameObject battleMusic = GameObject.Find("BattleMusic");
		battleMusic.GetComponent<AudioLowPassFilter>().cutoffFrequency = 2000;
	}

	public static void openMusicFilter(){
		GameObject battleMusic = GameObject.Find("BattleMusic");
		battleMusic.GetComponent<AudioLowPassFilter>().cutoffFrequency = 22000;
	}	
}



using System;
using Uniject;
using UnityEngine;

namespace Uniject.Impl {
    public class UnityAudioSource : TestableComponent, IAudioSource {
    	private AudioSource source;

    	public UnityAudioSource(IGameObject obj) : base(obj) {
            this.source = obj.GetComponent<AudioSource>();
            if (this.source == null) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have an AudioSource but none was found");
            }
            source.rolloffMode = AudioRolloffMode.Linear;
    	}

        public void loopSound(AudioClip clip) {
            source.loop = true;
            source.clip = clip;
            source.Play();
        }

        public void playOneShot(AudioClip clip) {
            source.PlayOneShot(clip);
        }

    	public void Play ()
    	{
    		source.Play();
    	}

        public bool isPlaying {
            get { return source.isPlaying; }
        }
    }
}

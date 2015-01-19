using System;
using UnityEngine;

namespace Uniject.Impl {
    public class UnityAudioListener : TestableComponent, IAudioListener {

        public UnityAudioListener(IGameObject parent) : base(parent) {
            AudioListener listener = parent.GetComponent<AudioListener>();
            if (null == listener) {
				throw new NullReferenceException("Object " + parent.Name  + " expected to have an AudioListener but none was found");
            }
        }

        public void noOp() {
        }
    }
}


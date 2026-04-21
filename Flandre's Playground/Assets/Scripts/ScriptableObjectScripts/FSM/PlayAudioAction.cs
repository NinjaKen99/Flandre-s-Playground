using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/PlayAudio")]
public class PlayAudioAction : Action
{
    public AudioClip audioClip;
    public override void Act(StateController controller)
    {
        FlanStateController m = (FlanStateController)controller;
        m.gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}

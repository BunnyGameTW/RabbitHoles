using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
// A behaviour that is attached to a playable
public class RabbitFallAnimation : PlayableBehaviour
{

    public PlayableDirector playableDir;
    public Animator ani;
    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {

    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {

    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        // 遍历playableDir中的TimeLine中所有的Track
        foreach (PlayableBinding item in playableDir.playableAsset.outputs)
        {
            // 所有track的名字
            Debug.Log(item.streamName);
            //if (item.streamName == "Animation Track1")
            //{
            //    // 绑定一个对象，绑定到该Track
            //    playableDir.SetGenericBinding(item.sourceObject, playableDir.gameObject);
            //}
        }
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {

       
    }
}

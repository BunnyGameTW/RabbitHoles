using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class Rabbit : PlayableAsset
{
    public ExposedReference<PlayableDirector> playableDir;

    public ExposedReference<Animator> ani;

    // 继承PlayableAsset后默认创建的工厂方法
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {

        // 继承PlayableBehaviour C# Script的类对象
        RabbitFallAnimation npb = new RabbitFallAnimation();

        // graph.GetResolver()：Returns the table used by the graph to resolve ExposedReferences.
        npb.playableDir = playableDir.Resolve(graph.GetResolver());

        npb.ani = ani.Resolve(graph.GetResolver());

        // 自定以的返回结果需要使用ScriptPlayable<T>来闯将对象
        return ScriptPlayable<RabbitFallAnimation>.Create(graph, npb);

        // 默认返回的是由graph创建的Playable对象
        //return Playable.Create(graph);
    }

}

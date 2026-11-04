using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.Splines;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Movement", story: "[Car] moving in [spline] at a [speed]", category: "Action", id: "c8dd251a35794f8010e7ea02e9ed9b88")]
public partial class MovementAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Car;
    [SerializeReference] public BlackboardVariable<SplineContainer> Spline;
    [SerializeReference] public BlackboardVariable<float> Speed;
    public float progress = 0f;
    protected override Status OnStart()
    {
        //Speed.Value = Random.Range(8.0f, 10.0f);
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        progress += (Speed / Spline.Value.CalculateLength()) * Time.deltaTime;
        progress %= 1f;
        Car.Value.transform.position = Spline.Value.EvaluatePosition(progress);
        //if (Car.Value.transform.position.x >= 80f)
        //{
        //    return Status.Success;
        //}
        return Status.Success;

    }

    protected override void OnEnd()
    {
    }
}


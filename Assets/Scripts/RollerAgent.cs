using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class RollerAgent : Agent
{
    public Transform Target;
    public float speed = 10;
    Rigidbody rBody;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    //进入新一轮训练时调用
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < 0)
        {
            //如果智能体掉下去，则重置位置+重置速度
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3(0, 0.5f, 0);
        }
        //将目标球重生至一个新的随机位置
        //Target.localPosition = new Vector3(UnityEngine.Random.value * 50 - 25, 1f, UnityEngine.Random.value * 50 - 25);
    }

    //收集观察结果
    public override void CollectObservations(VectorSensor sensor)
    {
        //观察目标球和智能体的位置
        sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(this.transform.localPosition);
        //观察智能体的速度
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.z);
        //在这里因为目标球是不会动的，智能体也不会在y轴上又运动，所以没有必要观察这些值的变化。
        //sensor.AddObservation(rBody.velocity.y);
    }

    //处理接受的动作，并根据当前动作评估奖励信号值    
    public override void OnActionReceived(ActionBuffers actions)
    {
        //------ 动作处理
        // 接受两个动作数值
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];
        rBody.AddForce(controlSignal * speed);

        //------ 奖励信号
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);
        // 到达目标球
        if (distanceToTarget < 1.42f)
        {
            //奖励值+1.0f
            SetReward(1.0f);
            EndEpisode();
        }

        // 掉落场景外
        if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    //手动操控智能体，用于手动调试智能体或启发模仿学习。
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");

    }
}
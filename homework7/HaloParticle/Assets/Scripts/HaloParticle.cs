using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloParticle : MonoBehaviour
{
    public float radius, angle, time;
    public HaloParticle(float radius_, float angle_, float time_)
    {
        radius = radius_; // 粒子的分布半径
        angle = angle_; // 粒子的和水平轴成的角度，本实验中单位均为弧度
        time = time_; // 时间，主要用于关联后期粒子的来回周期性运动
    }
}
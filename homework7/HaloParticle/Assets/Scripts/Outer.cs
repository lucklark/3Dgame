using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outer : MonoBehaviour
{
    public ParticleSystem ps; // 粒子系统对象
    private ParticleSystem.Particle[] particle_arr; // 存储粒子的仓库
    private int resolution = 3000;
    private HaloParticle[] hp; // 存储每一个粒子信息的数组
    // 外环的粒子总体分布半径要大一些
    private float min_radius = 2.5F;
    private float max_radius = 5F;
    private float pingPong = 0.01F; // 粒子在来回运动的时候的游离范围

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
        particle_arr = new ParticleSystem.Particle[resolution];
        hp = new HaloParticle[resolution];
        ps.Emit(resolution);
        ps.GetParticles(particle_arr);
        // 初始化各个粒子的位置
        for (int i = 0; i < resolution; i++)
        {
            // 使得粒子集中在平均半径处
            float shiftMinRadius = Random.Range(1, (min_radius + max_radius) / (2 * min_radius));
            float shiftMaxRadius = Random.Range((min_radius + max_radius) / (2 * max_radius), 1);
            float radius = Random.Range(min_radius * shiftMinRadius, max_radius * shiftMaxRadius);
            // 粒子的角度为[0, 2π], 按照平面直角坐标系的参数方程进行设定
            float angle = Random.Range(0, 2 * Mathf.PI);
            float time = Random.Range(0.0f, 360.0f);
            hp[i] = new HaloParticle(radius, angle, time);
            particle_arr[i].position = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
        ps.SetParticles(particle_arr, particle_arr.Length);
    }

    void Update()
    {
        for (int i = 0; i < resolution; i++)
        {
            // 使粒子旋转
            hp[i].angle -= Random.Range(0, 1F / 360);
            particle_arr[i].position = new Vector3(hp[i].radius * Mathf.Cos(hp[i].angle), hp[i].radius * Mathf.Sin(hp[i].angle), 0);
            // 调整上下浮动
            hp[i].time += Time.deltaTime;
            hp[i].radius += Mathf.PingPong(hp[i].time / min_radius / max_radius, pingPong) - pingPong / 2.0f;
        }
        ps.SetParticles(particle_arr, particle_arr.Length);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawPointCloud();
    }

    ParticleSystem.Particle[] allParticles;         // 所有粒子的集合
    void DrawPointCloud()
    {
        var main = GetComponent<ParticleSystem>().main;
        {
            main.startSpeed = 0.0f;                           // 设置粒子的初始速度为0
            main.startLifetime = 1000.0f;

            var pointCount = 100;
            allParticles = new ParticleSystem.Particle[pointCount];
            main.maxParticles = pointCount;
            GetComponent<ParticleSystem>().Emit(pointCount);
            GetComponent<ParticleSystem>().GetParticles(allParticles);
            for (int i = 0; i < pointCount; i++)
            {
                allParticles[i].position = new Vector3(0.1f * i, 0.2f * i, 0.3f * i);    // 设置每个点的位置
                allParticles[i].startColor = Color.yellow;    // 设置每个点的rgb
                allParticles[i].startSize = 0.2f;
            }

            GetComponent<ParticleSystem>().SetParticles(allParticles, pointCount);      // 将点云载入粒子系统
        }
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class fibbonacci : MonoBehaviour
{
    [Range(1, 1000)]
    public int N = 100;

    [Range(0.01f, 1f)]
    public float pointsize = 0.15f;
    Vector3[] vertices;
    [SerializeField]
    public int fibb = 2;

    public int offset = 0;
    
    public int spiral = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateVertices();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void GenerateVertices()
    {
        vertices = new Vector3[N];
        float goldenRatio = (1f + Mathf.Sqrt(5f)) / 2f;
        float angleIncrement = Mathf.PI * 2f * (1f - 1f / goldenRatio);

        for (int i = 0; i < N; i++)
        {
            float t = (i + 0.5f) / N; 
            float phi = Mathf.Acos(1f - 2f * t);
            float theta = angleIncrement * i;

            float x = Mathf.Sin(phi) * Mathf.Cos(theta);
            float y = Mathf.Sin(phi) * Mathf.Sin(theta);
            float z = Mathf.Cos(phi);

            vertices[i] = new Vector3(x, y, z);
        }
    }

    void OnValidate()
    {
        fibb = Mathf.Clamp(fibb, 1, N);
        List<float> fibSequence = sequence(N);
        fibb = Mathf.RoundToInt(fibb); // ensure it's an int
        if (fibSequence.Count > 0)
        {
            fibb = (int)fibSequence.OrderBy(x => Mathf.Abs(x - fibb)).First();
        }
        GenerateVertices();
    }

    void OnDrawGizmos()
    {
        if (vertices == null || vertices.Length == 0 || vertices[0] == null) return;
        Vector3 prev = vertices[0] + transform.position;

        float k = 0;
        
        foreach (var v in vertices)
        {
            Gizmos.color = Color.red;
            if ((k + offset*spiral)% (float)fibb == 0 || k == 0){
                Gizmos.color = Color.white;
            }
            Vector3 p = transform.position + v;
            Gizmos.DrawSphere(p, pointsize);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(prev, p);
            prev = p;
            k ++;
        }
    }

    List<float> sequence(float N){
        
        List<float> sequence = new List<float> {1, 1};

        while (sequence.Last() < N){
            sequence.Add(sequence.Last() + sequence[sequence.Count - 2]);
        }

        return sequence;
    }
}


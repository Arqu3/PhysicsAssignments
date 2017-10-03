using PhysicsAssignments;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    [SerializeField] private Planet m_source1; //Earth 
    [SerializeField] private Planet m_source2; //Moon

    private float m_dist;

    private readonly float g = 9.82f;

    void Start()
    {
        m_source1.SetMass(20f);
        m_source2.SetMass(1f);
    }
}

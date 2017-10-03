using PhysicsAssignments;
using UnityEngine;

public class Planet : MonoBehaviour {

    private Vector3 m_startVelo;

    private Body m_body;
    
    private bool m_gravity = false;

    void Start () {
        m_body = new Body(transform.position, Vector3.zero, Vector3.zero);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += m_body.Velocity * Time.fixedDeltaTime;
        m_body.Velocity *= 0.9f;
    }

    public void SetMass(float m)
    {
        m_body.Mass = m;
    }

    public float GetMass()
    {
        return m_body.Mass;
    }

    public void AddForce(Vector3 f)
    {
        m_body.Velocity += f / m_body.Mass * Time.deltaTime;
    }
}

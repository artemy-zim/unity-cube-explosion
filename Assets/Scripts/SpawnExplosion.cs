using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpawnExplosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;

    public void DoExplosion()
    {
        GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius, _upwardsModifier);
    }
}

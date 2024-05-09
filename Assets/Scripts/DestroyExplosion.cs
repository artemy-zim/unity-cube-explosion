using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DestroyExplosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;

    private void OnDestroy()
    {
        GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius, _upwardsModifier);
    }
}

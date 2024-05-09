using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Renderer))]
public class Cube : MonoBehaviour, IClickable, ISpawnable
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private float _splitChance;

    public void OnClick()
    {
        if (CanSplit())
            _spawner.TrySpawn(this);

        Destroy(gameObject);
    }

    public void OnSpawn()
    {
        int scaleReducer = 2;

        transform.localScale /= scaleReducer;
        GetComponent<Renderer>().material.color = Random.ColorHSV();

        _explosion.DoExplosion();
    }

    private bool CanSplit()
    {
        float maxPercentage = 101f;
        int chanceReducer = 2;

        if(Random.Range(0, maxPercentage) <= _splitChance)
        {
            _splitChance /= chanceReducer;
            return true;
        }

        return false;
    }
}

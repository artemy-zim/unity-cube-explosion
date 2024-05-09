using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Min(0)] private int _minAmount;
    [SerializeField, Min(0)] private int _maxAmountExclusive;

    private void OnValidate()
    {
        if (_minAmount > _maxAmountExclusive - 1)
            _minAmount = _maxAmountExclusive - 1;
    }

    public void TrySpawn(Cube cube)
    {
        for (int i = 0; i < Random.Range(_minAmount, _maxAmountExclusive); i++)
        {
            ISpawnable newCube = Instantiate(cube);
            newCube.OnSpawn();
        }
    }
}

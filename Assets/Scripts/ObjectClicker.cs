using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            HandleObjectClick();
    }

    private void HandleObjectClick()
    {
        Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.transform.TryGetComponent(out IClickable clickable))
                clickable.OnClick();
        }
    }
}

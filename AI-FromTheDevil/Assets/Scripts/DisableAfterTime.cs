using UnityEngine;
//script was made by mercy (IvanVasilyev)
public class DisableAfterTime : MonoBehaviour
{
    [SerializeField] private float delay = 3.0f;

    private void OnEnable()
    {
        Invoke(nameof(DisableSelf), delay);
    }

    private void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}

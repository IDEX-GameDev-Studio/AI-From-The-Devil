using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [Tooltip("Unique sequential index for this checkpoint (e.g., 0 for Checkpoint 1, 1 for Checkpoint 2)")]
    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[3D Trigger] Something entered: {other.gameObject.name} (Tag: {other.tag})");

        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.SaveCheckpoint(checkpointIndex, other.transform.position);
        }
    }
}

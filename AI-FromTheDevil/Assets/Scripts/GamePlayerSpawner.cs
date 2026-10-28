using TMPro;
using UnityEngine;

public class GamePlayerSpawner : MonoBehaviour
{
    public static GamePlayerSpawner Instance;

    [Header("References")]
    public Transform playerTransform;
    public TextMeshProUGUI checkpointUI;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CheckpointData data = CheckpointManager.Instance.LoadGame();
        ApplySpawnPosition(data);
        RefreshUI(data.currentCheckpointIndex);
    }

    private void ApplySpawnPosition(CheckpointData data)
    {
        if (data.currentCheckpointIndex != -1)
        {
            Vector3 spawnPosition = new Vector3(data.posX, data.posY, data.posZ);
            
            CharacterController cc = playerTransform.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            playerTransform.position = spawnPosition;

            if (cc != null) cc.enabled = true;

            Debug.Log($"Player spawned at checkpoint {data.currentCheckpointIndex}: {spawnPosition}");
        }
        else
        {
            Debug.Log("No active checkpoint found. Spawning at default scene position.");
        }
    }

    public void RefreshUI(int checkpointIndex)
    {
        if (checkpointUI != null)
        {
            if (checkpointIndex != -1)
            {
                checkpointUI.text = $"Current Checkpoint: {checkpointIndex + 1}";
            }
            else
            {
                checkpointUI.text = "Current Checkpoint: None";
            }
        }
    }
}
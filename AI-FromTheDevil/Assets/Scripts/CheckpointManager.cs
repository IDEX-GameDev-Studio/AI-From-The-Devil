using System.IO;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private string saveFilePath;
    private CheckpointData currentData = new CheckpointData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            saveFilePath = Path.Combine(Application.persistentDataPath, "checkpointData.json");
            LoadGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveCheckpoint(int checkpointIndex, Vector3 spawnPosition)
    {
        if (checkpointIndex > currentData.currentCheckpointIndex)
        {
            currentData.currentCheckpointIndex = checkpointIndex;
            currentData.posX = spawnPosition.x;
            currentData.posY = spawnPosition.y;
            currentData.posZ = spawnPosition.z;

            string json = JsonUtility.ToJson(currentData, true);
            File.WriteAllText(saveFilePath, json);
            Debug.Log($"Checkpoint {checkpointIndex} saved successfully at {spawnPosition}.");

            if (GamePlayerSpawner.Instance != null)
            {
                GamePlayerSpawner.Instance.RefreshUI(checkpointIndex);
            }
        }
    }

    public CheckpointData LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            currentData = JsonUtility.FromJson<CheckpointData>(json);
            Debug.Log($"Loaded checkpoint index: {currentData.currentCheckpointIndex}");
        }
        else
        {
            currentData = new CheckpointData();
            Debug.Log("No save file found. Starting fresh.");
        }
        return currentData;
    }

    public void ResetProgress()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
        currentData = new CheckpointData();
        Debug.Log("Checkpoint progress reset.");
    }
}
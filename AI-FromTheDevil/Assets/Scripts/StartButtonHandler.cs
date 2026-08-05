using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//script written by mercydev (Ivan Vasilyev)
public class StartButtonHandler : MonoBehaviour
{
    public UnityEvent onStartGame;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        
        if (button != null)
        {
            button.onClick.AddListener(TriggerStartGame);
        }
    }

    private void TriggerStartGame()
    {
        onStartGame?.Invoke();
    }
}

using UnityEngine.Events; // 1
using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent;
    [SerializeField]
    private UnityEvent response;

    private void OnEnable() => gameEvent.Register(gameEventListener: this);
    
    private void OnDisable() => gameEvent.Deregister(gameEventListener: this);

    public void RaiseEvent() => response.Invoke();
}
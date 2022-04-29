using UnityEngine;

public interface IPooledObject
{
    public void OnObjectSpawn(); //this interface allows the object pooler to call this method on every script that inherits it
}

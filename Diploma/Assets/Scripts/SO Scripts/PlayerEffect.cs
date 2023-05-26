using UnityEngine;

public abstract class PlayerEffect : ScriptableObject
{
    public abstract void Execute(Component sender, object data);
}

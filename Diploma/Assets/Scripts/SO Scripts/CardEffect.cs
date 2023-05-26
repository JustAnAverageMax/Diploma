using UnityEngine;
public abstract class CardEffect : ScriptableObject
{
    public abstract void Execute(Component sender, object data);
}

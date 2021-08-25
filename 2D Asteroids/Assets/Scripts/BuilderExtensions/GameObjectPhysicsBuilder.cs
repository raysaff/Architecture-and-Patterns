using UnityEngine;

internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
{
    public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }

    public GameObjectPhysicsBuilder CircleCollider2D()
    {
        GetOrAddComponent<CircleCollider2D>();
        return this;
    }

    public GameObjectPhysicsBuilder RigidBody2D()
    {
        var component = GetOrAddComponent<Rigidbody2D>();
        component.gravityScale = 0;
        component.freezeRotation = true;
        return this;
    }


    private T GetOrAddComponent<T>() where T : Component
    {
        var result = _gameObject.GetComponent<T>();
        if (!result)
        {
            result = _gameObject.AddComponent<T>();
        }
        return result;
    }
}

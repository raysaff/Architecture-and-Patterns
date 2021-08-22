using UnityEngine;
using UnityEngine.AI;

public static partial class BuilderExtensions
{
    public static GameObject SetName(this GameObject gameObject, string name)
    {
        gameObject.name = name;
        return gameObject;
    }
    public static GameObject SetTag(this GameObject gameObject, string tag)
    {
        gameObject.tag = tag;
        return gameObject;
    }

    public static GameObject AddCircleCollider2D(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<CircleCollider2D>();
        return gameObject;
    }

    public static GameObject AddSphereCollider(this GameObject gameObject)
    {
        gameObject.GetOrAddComponent<SphereCollider>();
        return gameObject;
    }

    public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
    {
        var component = gameObject.GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return gameObject;
    }

    public static GameObject AddAudioSource(this GameObject gameObject, AudioClip clip)
    {
        var component = gameObject.GetOrAddComponent<AudioSource>();
        component.loop = true;
        component.clip = clip;
        return gameObject;
    }

    public static GameObject AddRigidBody(this GameObject gameObject)
    {
        var component = gameObject.GetOrAddComponent<Rigidbody>();
        component.useGravity = false;
        return gameObject;
    }

    public static GameObject AddTrailRenderer(this GameObject gameObject)
    {
        var componentInChildren = gameObject.GetComponentInChildren<TrailRenderer>();
        if (componentInChildren)
        {
            return gameObject;
        }
        var lineRendererGameObject = new GameObject("TrailRenderer");
        var lineRenderer = lineRendererGameObject.AddComponent<TrailRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.time = 0.2f;
        lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
        lineRendererGameObject.transform.SetParent(gameObject.transform);
        return gameObject;
    }

    
    private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        var result = gameObject.GetComponent<T>();
        if (!result)
        {
            result = gameObject.AddComponent<T>();
        }
        return result;
    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.BuilderExtensions
{
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

        public static GameObject AddRigidBody2D(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.simulated = true;
            component.gravityScale = 0;
            component.freezeRotation = true;
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

        public static GameObject SetAudioClip(this GameObject gameObject, AudioClip clip)
        {
            var component = gameObject.GetOrAddComponent<AudioSource>();
            component.clip = clip;
            component.PlayOneShot(clip);
            return gameObject;

        }

        public static T DeepCopy<T>(this T self) where T : class
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Type must be iserializable");
            }

            if (ReferenceEquals(self, null))
            {
                return default;
            }

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
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

        public static string NumberToAbbreviate(this long number, int startNumber = 5)
        {
            if (number < 0) throw new ArgumentOutOfRangeException(nameof(number), "insert a positive number");

            string[] Postfixes = new[]
            {
                string.Empty, "K", "M", "B", "T", "aa", "bb"
            };

            startNumber = Mathf.Clamp(startNumber, 4, int.MaxValue);
            int rank = 0;

            long prompt = number;

            while (prompt >= 1000L)
            {
                prompt /= 1000L;
                rank++;
            }

            long categoryNumber = 1;
            long categoryPrompt = prompt;

            while (categoryPrompt >= 10L)
            {
                categoryPrompt /= 10L;
                categoryNumber++;
            }

            if (rank * 3 + categoryNumber < startNumber)
                return number.ToString();
        

            float subgroupRatio = number / Mathf.Pow(1000.0f, rank) - 0.001f;

            if (subgroupRatio > 0.0f)
                return $"{subgroupRatio:#.#}{Postfixes[rank]}";
        

            return $"{prompt:0}{Postfixes[rank]}";
        }
    }
}

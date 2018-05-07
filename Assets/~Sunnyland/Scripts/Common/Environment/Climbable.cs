using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Climbable : MonoBehaviour
    {
        public Vector2 offset;
        public Vector2 zoneCenter;
        public Vector2 zoneSize;
        [Header("Debug")]
        public Color zoneColour = Color.cyan;
        public Color lineColour = Color.white;

        private Bounds zone;
        private Bounds box;
        private BoxCollider2D col;
        public Vector2 size, top, bottom;

        // Use this for initialization
        void Start()
        {
            RecalculateBounds();
        }

        // Update is called once per frame
        void OnDrawGizmos()
        {
            if (Application.isEditor)
            {
                RecalculateBounds();

                Gizmos.color = zoneColour;
                Gizmos.DrawCube(zone.center, zone.size);

                Gizmos.color = lineColour;
                Gizmos.DrawLine(top, bottom);
            }
        }

        void RecalculateBounds()
        {
            col = GetComponent<BoxCollider2D>();
            box = col.bounds;
            size = box.size;

            zone = new Bounds(box.center + (Vector3)zoneCenter, box.size + (Vector3)zoneSize);
            Vector2 position = transform.position;
            top = position + new Vector2(offset.x, 0);
            bottom = position + new Vector2(offset.x, -size.y + offset.y);
        } 

        public float GetX()
        {
            return zone.center.x;
        }
        public bool isAtTop(Vector3 point)
        {
            return point.y > zone.max.y;
        }
        public bool isAtBottom(Vector3 point)
        {
            return point.y < zone.min.y;
        }
    }
}


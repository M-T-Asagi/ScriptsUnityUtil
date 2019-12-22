using UnityEngine;

namespace AsagiHandyScripts
{
    public static class GetEndPointsOfScreen
    {
        public struct ScreenEndPoints
        {
            public Vector3 topLeft;
            public Vector3 topRight;
            public Vector3 bottomLeft;
            public Vector3 bottomRight;

            public ScreenEndPoints(Vector3 tl, Vector3 tr, Vector3 bl, Vector3 br)
            {
                topLeft = tl;
                topRight = tr;
                bottomLeft = bl;
                bottomRight = br;
            }
        }

        public static ScreenEndPoints GetPoints(Camera eye)
        {
            Vector3 UPSIDE_DOWN;
            UPSIDE_DOWN.x = 1;
            UPSIDE_DOWN.y = -1;
            UPSIDE_DOWN.z = 1;

            ScreenEndPoints points;
            points.bottomLeft = eye.ScreenToWorldPoint(new Vector3(0, 0, eye.nearClipPlane));
            points.topLeft = eye.ScreenToWorldPoint(new Vector3(0, Screen.height, eye.nearClipPlane));
            points.topRight = eye.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, eye.nearClipPlane));
            points.bottomRight = eye.ScreenToWorldPoint(new Vector3(Screen.width, 0, eye.nearClipPlane));
            return points;
        }
    }
}
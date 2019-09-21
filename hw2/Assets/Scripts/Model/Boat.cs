using UnityEngine;
namespace MySpace
{
    public class Boat
    {
        public readonly Move mScript;
        public readonly Vector3 selfSide;
        public readonly Vector3 otherSide;
        public readonly Vector3[] RightSides;
        public readonly Vector3[] LeftSides;
        public CharacterController[] passengers = new CharacterController[2];
        public GameObject _Boat { get; set; }
        public Location location { get; set; }

        public Boat()
        {
            selfSide = new Vector3(2, -2, 0);
            otherSide = new Vector3(-2, -2, 0);
            location = Location.right;

            RightSides = new Vector3[]
            {
               new Vector3(2.5f,-1f,0),
               new Vector3(1.5f,-1f,0)
            };
            LeftSides = new Vector3[]
            {
                new Vector3(-1.5f,-1f,0),
                new Vector3(-2.5f, -1f, 0)
            };
            _Boat = Object.Instantiate(Resources.Load("Prefab/Boat", typeof(GameObject)), selfSide, Quaternion.Euler(0, 0, 180f), null) as GameObject;
            _Boat.name = "boat";
            mScript = _Boat.AddComponent(typeof(Move)) as Move;
            _Boat.AddComponent(typeof(UserGUI));
        }
    }
}

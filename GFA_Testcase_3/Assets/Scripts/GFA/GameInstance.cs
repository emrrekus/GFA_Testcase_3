using UnityEngine;

namespace GFA
{
    [CreateAssetMenu (menuName = "GameInstance")]
    public class GameInstance : ScriptableObject
    {
        public float Time { get; private set; }
        public GameObject Player { get; set; }

        public void AddTime(float time)
        {
            Time += time;
        }

        public void Reset()
        {
            Time = 0;
        }
    }
    
}

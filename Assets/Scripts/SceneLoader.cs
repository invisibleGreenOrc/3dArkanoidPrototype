using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
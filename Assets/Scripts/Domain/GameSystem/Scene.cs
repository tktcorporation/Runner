using System.Collections;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class Scene
    {
        //static UnityEngine.AsyncOperation WaitForLoadScene(ScenesMap sceneName)
        //{
        //    return SceneManager.LoadSceneAsync(sceneName.Value);
        //}

        static IEnumerator LoadSceneAsync(ScenesMap sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName.Value);
        }
        static void LoadScene(ScenesMap sceneName)
        {
            SceneManager.LoadScene(sceneName.Value);
        }
        static IEnumerator WaitForUnload(ScenesMap sceneName)
        {
            yield return SceneManager.UnloadSceneAsync(sceneName.Value);
        }
        public static Scene BuildWithLoadSceneAsync(ScenesMap sceneName)
        {
            LoadSceneAsync(sceneName);
            return new Scene(sceneName);
        }
        public static Scene BuildWithLoadScene(ScenesMap sceneName)
        {
            LoadScene(sceneName);
            return new Scene(sceneName);
        }

        public ScenesMap scene { get; private set; }

        Scene(ScenesMap sceneName)
        {
            scene = sceneName;
        }

        public void WaitForUnload()
        {
            WaitForUnload(scene);
        }

        public class ScenesMap
        {
            private ScenesMap(string value) { Value = value; }

            public string Value { get; private set; }

            public static ScenesMap Main { get { return new ScenesMap("MainScene"); } }
            public static ScenesMap Title { get { return new ScenesMap("TitleScene"); } }
        }
    }
}

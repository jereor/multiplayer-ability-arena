using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Editor
{
    [InitializeOnLoad]
    public static class BootstrapSceneOpener
    {
        private const string BootstrapSceneName = "Bootstrap";

        [UsedImplicitly]
        static BootstrapSceneOpener() { }

        [MenuItem("Tools/Open Bootstrap Scene #&b")] // Shift+Alt+B shortcut
        public static void OpenBootstrapScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                string scenePath = FindScenePath(BootstrapSceneName);

                if (scenePath != null)
                {
                    EditorSceneManager.OpenScene(scenePath);
                    Debug.Log($"[BootstrapSceneOpener] Opened: {scenePath}");
                }
                else
                {
                    EditorUtility.DisplayDialog(
                        "Scene Not Found",
                        $"Could not find a scene named '{BootstrapSceneName}' in the project.\n\nMake sure it exists and is named exactly '{BootstrapSceneName}.unity'.",
                        "OK"
                    );
                }
            }
        }

        private static string FindScenePath(string sceneName)
        {
            string[] guids = AssetDatabase.FindAssets($"t:Scene {sceneName}");

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                string fileName = System.IO.Path.GetFileNameWithoutExtension(path);

                // Exact name match (case-insensitive)
                if (string.Equals(fileName, sceneName, System.StringComparison.OrdinalIgnoreCase))
                    return path;
            }

            return null;
        }
    }
}
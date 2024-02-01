using StdNounou.Core;
using UnityEngine.SceneManagement;

public class Gamerules : PersistentSingleton<Gamerules>
{
    public static float Gravity { get; private set; } = -9.81f;

    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }

    protected override void OnSceneUnloaded(Scene scene)
    {
    }
}
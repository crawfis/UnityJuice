using UnityEngine;

namespace CrawfisSoftware.Juice
{
    public static class JuicePlayer
    {
        public static void InstantiateAndPlayJuice(GameObject target, JuiceScriptableAbstract juiceTemplate, float juiceTimeScale, MonoBehaviour context)
        {
            var juice = InstantiateJuice(target, juiceTemplate, juiceTimeScale);
            PlayJuice(juice, context);
        }

        public static JuiceScriptableAbstract InstantiateJuice(GameObject target, JuiceScriptableAbstract juiceTemplate, float juiceTimeScale)
        {
            var juice = ScriptableObject.Instantiate<JuiceScriptableAbstract>(juiceTemplate);
            juice._target = target;

            juice._juiceTimeScale = juiceTimeScale;
            return juice;
        }

        public static void PlayJuice(JuiceScriptableAbstract juice, MonoBehaviour context)
        {
            if (juice != null) context.StartCoroutine(juice.Play(context));
        }
    }
}
using UnityEngine;

namespace CrawfisSoftware.Juice
{
    public static class JuicePlayer
    {
        public static void InstantiateAndPlayJuice(GameObject target, JuiceAbstract juiceTemplate, float juiceTimeScale, MonoBehaviour context)
        {
            var juice = InstantiateJuice(target, juiceTemplate, juiceTimeScale);
            PlayJuice(juice, context);
        }

        public static JuiceAbstract InstantiateJuice(GameObject target, JuiceAbstract juiceTemplate, float juiceTimeScale)
        {
            var juice = ScriptableObject.Instantiate<JuiceAbstract>(juiceTemplate);
            juice._target = target;

            juice._juiceTimeScale = juiceTimeScale;
            return juice;
        }

        public static void PlayJuice(JuiceAbstract juice, MonoBehaviour context)
        {
            if (juice != null) context.StartCoroutine(juice.Play(context));
        }
    }
}
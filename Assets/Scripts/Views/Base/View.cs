using ScriptableObjects.Answers.Base;
using UnityEngine;

namespace Views.Base
{
    public abstract class View : MonoBehaviour
    {
        public abstract void Render(IContainQuestionData data);
    }
}

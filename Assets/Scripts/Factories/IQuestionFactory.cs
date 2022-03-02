using Models;
using UnityEngine;
using Views.Base;

namespace Factories
{
    interface IQuestionFactory
    {
        View CreateQuestionView(Question question, Transform parent);
    }
}

using System;
using System.Linq;

namespace QuestionStore.Core
{
    public static class Extensoes
    {
        public static bool EhVazia(this string value)
        {
            return string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);
        }

        public static string ObtenhaGuid(this Guid guid)
        {
            var id = guid.ToString().ToCharArray().Take(32);
            return string.Concat(id);
        }
    }
}

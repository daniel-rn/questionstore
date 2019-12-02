using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Core
{
    public static class Extensoes
    {
        public static bool EhVazia(this string value)
        {
            return string.IsNullOrEmpty(value) && string.IsNullOrWhiteSpace(value);
        }
    }
}

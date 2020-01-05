using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace QuestionStore.Core.Data
{
    internal static class ExtensoesBd
    {
        public static void Commit(this DbCommand fbCommand)
        {
            fbCommand.Transaction.Commit();
        }

        public static void AddParametersToCommand(this DbCommand fbCommand, params string[] parametros)
        {
            foreach (var param in parametros)
            {
                fbCommand.Parameters.Add(new FbParameter
                {
                    ParameterName = param
                });
            }

            fbCommand.Prepare();
        }

        public static void AddValuesToParameters(this DbCommand fbCommand, IList<object> Valores)
        {
            if (fbCommand.Parameters.Count <= decimal.Zero)
                throw new Exception("Não foram adicionados parametros");

            foreach (var value in Valores)
            {
                fbCommand.Parameters[Valores.IndexOf(value)].Value = value;
            }
        }
    }

}

using FirebirdSql.Data.FirebirdClient;
using QuestionStore.Core.Properties;
using System;
using System.Data.Common;

namespace ControleFamiliar.Mapeadores
{
    [Obsolete("Outra conexao ficou melhor")]
    public static class Connection_obsoleta
    {
        public static FbConnection FbCnn { get; private set; }

        public static FbTransaction FbTxx { get; private set; }

        public static FbCommandBuilder FbCmm { get; } = new FbCommandBuilder();

        public static bool Active(bool bActive)
        {
            if (bActive)
            {
                FbCnn = new FbConnection(ObtenhaConfiguracoesBanco());
                FbCnn.Open();
                return true;
            }
            FbCnn.Close();
            return false;
        }

        private static string ObtenhaConfiguracoesBanco()
        {
           return Resources.ConnectionString;
        }

        public static FbTransaction ObtenhaFbTransaction()
        {
            Active(true);
            FbTxx = FbCnn.BeginTransaction();
            return FbTxx;
        }

        public static DbCommand ObtenhaComando(string sql)
        {
            return new FbCommand(sql, FbCnn);
        }

        public static DbCommand ObtenhaComando()
        {
            var cmd = new FbCommand
            {
                Connection = FbCnn,
                Transaction = FbTxx
            };

            return cmd;
        }

        public static void Close()
        {
            Active(false);
        }
    }
}

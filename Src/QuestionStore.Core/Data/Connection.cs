using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data.Common;

namespace ControleFamiliar.Mapeadores
{
    public static class Connection
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
            var configuracoesBanco = "initial catalog = C:\\Work\\Bases\\QUESTION.FB3; data source = localhost; user id = SYSDBA; password = masterkey; pooling = True; port number = 3053";
            return configuracoesBanco;
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

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
            var configuracoesBanco = "User=SYSDBA;Password=masterkey";
            configuracoesBanco += ";Database = C:\\WorkNascimento\\Bases\\QUESTION.FB3";
            configuracoesBanco += ";Port=3053;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;";
            configuracoesBanco += "Connection timeout=7;Pooling=True;Packet Size=8192;Server Type=0";
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

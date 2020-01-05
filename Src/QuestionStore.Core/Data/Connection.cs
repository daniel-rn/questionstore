using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;
using System.Linq;

namespace QuestionStore.Core.Data
{
    public sealed class Connection : IConnection, IDisposable
    {
        private readonly FbConnection _fbCnn;
        private FbTransaction FbTxx;

        private Connection(IConfiguration configuracoes)
        {
            var connectionString = configuracoes.GetConnectionString("ConnectionString");

            _fbCnn = new FbConnection(connectionString);
            _fbCnn.Open();
        }

        public FbTransaction ObtenhaFbTransaction()
        {
            FbTxx = _fbCnn.BeginTransaction();
            return FbTxx;
        }

        public DbCommand ObtenhaComando()
        {
            var cmd = new FbCommand
            {
                Connection = _fbCnn,
                Transaction = FbTxx ?? _fbCnn.BeginTransaction()
            };

            return cmd;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            _fbCnn.Close();
            _fbCnn.Dispose();
        }

        public static class Factory
        {
            public static Connection Crie(IConfiguration configuration)
            {
                return new Connection(configuration);
            }
        }
    }

}

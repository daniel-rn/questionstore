using System;
using System.Data.Common;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using QuestionStore.Core.Properties;

namespace QuestionStore.Core.Data
{
    public class Connection2 : IConnection, IDisposable
    {
        private readonly FbConnection _fbCnn;

        public FbTransaction FbTxx { get; private set; }

        public Connection2(IConfiguration configuracoes)
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
            };

            return cmd;
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            _fbCnn.Dispose();
            _fbCnn.Close();
        }
    }

    public interface IConnection { }
}

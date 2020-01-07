using QuestionStore.Core.Service;
using System.Collections.Generic;

namespace QuestionStore.Core.Mapping
{
    public interface IMapper
    {
        void Insert(Command command);

        //bool Delete(Command command);
    }
}

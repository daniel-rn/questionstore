using System;

namespace QuestionStore.Domain
{
    public abstract class Entity
    {
        protected Entity()
        {
            Guid = Guid.NewGuid();
        }

        protected Guid Guid { get; set; }
    }
}

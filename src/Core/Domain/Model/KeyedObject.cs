using Tarantino.Core.Commons.Model;

namespace SikhResearchInstitute.Core.Domain.Model
{
    public abstract class KeyedObject : PersistentObject
    {
        public virtual string Key { get; set; }
    }
}

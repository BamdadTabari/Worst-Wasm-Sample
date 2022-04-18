using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects
{
    public interface IBaseEntity
    {
    }
    public abstract class BaseEntity<T> : IBaseEntity
    {
        public T Id { get; set; }
    }

    // this is defualt for id 
    //you see default id type is long
    // but if need to have diffrent type
    // just depend yor entity directly to ----> BaseEntity<T>
    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}

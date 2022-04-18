using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Dto
{
    public interface IBaseDto
    {
    }
    public abstract class BaseDto<T> : IBaseDto
    {
        public T Id { get; set; }
    }
    public abstract class BaseDto : BaseDto<int>
    {
    }
}

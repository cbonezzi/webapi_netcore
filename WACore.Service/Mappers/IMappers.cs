using System;
using System.Collections.Generic;
using System.Text;

namespace WACore.Service.Mappers
{
    public interface IMappers<TFrom, TTo>
    {
        TTo Map(TFrom from);
    }
}

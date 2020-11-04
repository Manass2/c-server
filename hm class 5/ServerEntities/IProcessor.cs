using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities
{
    public interface IProcessor
    {
        Response Process(Request request);
    }
}

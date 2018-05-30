using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTemplate.Helpers
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}

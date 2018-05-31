using System;

namespace MobileTemplate.Helpers
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}

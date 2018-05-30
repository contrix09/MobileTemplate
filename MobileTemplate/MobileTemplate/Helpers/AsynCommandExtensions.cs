using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileTemplate.Helpers
{
    public static class AsynCommandExtensions
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}

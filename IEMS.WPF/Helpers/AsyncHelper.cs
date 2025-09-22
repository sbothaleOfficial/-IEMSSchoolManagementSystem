using System;
using System.Threading.Tasks;
using System.Windows;

namespace IEMS.WPF.Helpers
{
    public static class AsyncHelper
    {
        /// <summary>
        /// Safely executes an async operation in a fire-and-forget manner with proper exception handling
        /// Use this for async event handlers that cannot be converted to async Task
        /// </summary>
        /// <param name="asyncAction">The async operation to execute</param>
        /// <param name="errorTitle">Title for error dialog (optional)</param>
        public static async void SafeFireAndForget(Func<Task> asyncAction, string errorTitle = "Error")
        {
            try
            {
                await asyncAction();
            }
            catch (Exception ex)
            {
                // Log the error and show user-friendly message
                var errorMessage = $"An error occurred: {ex.Message}";

                // Include inner exception details for debugging
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetails: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                // TODO: Add proper logging framework here
                System.Diagnostics.Debug.WriteLine($"AsyncHelper Error: {ex}");
            }
        }

        /// <summary>
        /// Safely executes an async operation with a return value
        /// Use this for async operations that need to return a result
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="asyncFunc">The async function to execute</param>
        /// <param name="defaultValue">Default value to return on error</param>
        /// <param name="errorTitle">Title for error dialog (optional)</param>
        /// <returns>Result of the async operation or default value on error</returns>
        public static async Task<T> SafeExecuteAsync<T>(Func<Task<T>> asyncFunc, T defaultValue = default(T), string errorTitle = "Error")
        {
            try
            {
                return await asyncFunc();
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred: {ex.Message}";

                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetails: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, errorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                System.Diagnostics.Debug.WriteLine($"AsyncHelper Error: {ex}");

                return defaultValue;
            }
        }
    }
}
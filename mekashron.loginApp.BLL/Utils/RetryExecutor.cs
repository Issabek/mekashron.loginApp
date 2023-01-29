namespace mekashron.loginApp.BLL.Utils;
public class RetryExecutor
{

    public RetryExecutor()
    {
    }
    public void Retry(Action action, int maxRetries, int interval)
    {
        Retry<object>(() =>
        {
            action();
            return null;
        }, maxRetries, interval);
    }

    public T Retry<T>(Func<T> logic, int maxRetries, int interval)
    {
        int attempts = 0;
        T retval = default(T);
        do
        {
            try
            {
                attempts++;
                retval = logic();
                break;
            }
            catch (Exception ex)
            {
                if (attempts == maxRetries)
                {
                    break;
                }
                else
                {
                    Task.Delay(TimeSpan.FromSeconds(interval)).GetAwaiter().GetResult();
                }
            }
        }
        while (attempts < maxRetries);
        return retval;
    }
}

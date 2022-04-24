namespace Bdv.Redis
{
    public class RedisException : Exception
    {
        public RedisException(string message)
            : base(message)
        {

        }
    }
}

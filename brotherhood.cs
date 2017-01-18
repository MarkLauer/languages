using System;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        int n = 20;
        Token token = new Token();
        token.data = "data";
        token.recipient = n;
        ThreadRunner runner = new ThreadRunner();
        runner.Run(token, n);
    }
}

public class ThreadRunner
{
    private Token token;

    public void Run(Token token, int n)
    {
        this.token = token;
        for (int i = 1; i <= n; i++)
        {
            Thread thread = new Thread(Func); 
            thread.Start(i);
        }
        
    }

    private void Func(object data)
    {
        lock (token)
        {
            int threadNum = (int)data;
            Console.WriteLine("thread #{0}", threadNum);
            if (token.recipient == threadNum) {
                Console.WriteLine("{0} received", token.data);
            }
        }
    }
}

public class Token
{
    public string data;
    public int recipient;
}

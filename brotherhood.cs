using System;
using System.Threading;

public class Brotherhood
{
    public static void Main()
    {
        int N = 20;
        Token token = new Token("some data", N);
        for (int i = 1; i <= N; i++)
        {
            token.setCurrent(i);
            Thread newThread = new Thread(Brotherhood.Func);
            newThread.Start(token);
        }
    }

    public static void Func(object data)
    {
        Token token = (Token) data;
        if (token.getRecipient() == token.getCurrent())
        {
            Console.WriteLine("arrived at thread #" + token.getCurrent());
        }
    }
}

public class Token
{
    private string data;
    private int recipient;
    private int current;

    public Token(string data, int recipient)
    {
        this.data = data;
        this.recipient = recipient;
    }

    public void setCurrent(int i) { current = i; }

    public string getData() { return data; }

    public int getRecipient() { return recipient; }

    public int getCurrent() { return current; }
}

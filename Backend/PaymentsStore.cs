using System.Threading.Channels;
using System.Collections.Concurrent;

namespace Backend;

public static class PaymentsStore
{
    public static readonly Channel<Payment> Pending = Channel.CreateUnbounded<Payment>();

    public static ConcurrentStack<Payment> Default = new();
    public static ConcurrentStack<Payment> Fallback = new();
}

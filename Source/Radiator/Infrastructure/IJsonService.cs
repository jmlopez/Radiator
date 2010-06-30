using System;

namespace Radiator.Infrastructure
{
    public interface IJsonService
    {
        string Serialize<T>(T input);
        T Deserialize<T>(string input);
        object Deserialize(string input, Type targetType);
    }
}
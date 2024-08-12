namespace DependencyInjectionSample
{
    public interface IGuidSingleton : IGuidGenerator { }
    public interface IGuidScoped : IGuidGenerator { }
    public interface IGuidTransient : IGuidGenerator { }

    public interface IGuidGenerator
    {
        Guid Value { get; }
    }

    public class GuidGenerator : IGuidSingleton, IGuidScoped, IGuidTransient
    {
        public Guid Value { get; private set; } = Guid.NewGuid();
    }
}


using Access.domain.Commands;

namespace Access.domain.Interfaces
{
    public interface ICommandHandler
    {
        RegisterResponse Handle(RegisterRequest command);
    }
}
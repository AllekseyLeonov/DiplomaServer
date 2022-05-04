using Core;

namespace Application.Interfaces.Services;

public interface ICodeService
{
    public bool IsCodeValid(Code code);
}
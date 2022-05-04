using Application.Interfaces.Services;
using Application.Utils;
using Core;

namespace Application.Services;

public class CodeService : ICodeService
{
    public bool IsCodeValid(Code code)
    {
        string codeToCheck = CodeHelper.GetFormattedCode(code);

        return true;
    }
}
using Application.Interfaces.Services;
using Application.Utils;
using Core;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Application.Services;

public class CodeService : ICodeService
{
    public bool IsCodeValid(Code code)
    {
        string codeToCheck = CodeHelper.GetFormattedCode(code);

        var result = (bool) CSharpScript.EvaluateAsync(codeToCheck).Result;

        return result;
    }
}
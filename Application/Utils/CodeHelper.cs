using Core;

namespace Application.Utils;

public static class CodeHelper
{
    public static string GetFormattedCode(Code code)
    {
        var codeWithInputs = code.StaticPart
            .Replace("<inner>", code.UsersInnerPart)
            .Replace("<outer>", code.UsersOuterPart);
        codeWithInputs += code.Tests;

        return codeWithInputs;
    }
}
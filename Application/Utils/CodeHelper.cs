using Core;

namespace Application.Utils;

public static class CodeHelper
{
    public static string GetFormattedCode(Code code, string innerCode, string outerCode)
    {
        var codeWithInputs = code.StaticPart
            .Replace("<inner>", "\n" + innerCode)
            .Replace("<outer>", "\n" + outerCode);
        codeWithInputs += "return ";
        codeWithInputs += code.Tests;
        codeWithInputs += ";";

        return codeWithInputs;
    }
}
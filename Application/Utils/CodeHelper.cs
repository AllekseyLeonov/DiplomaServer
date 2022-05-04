using Core;

namespace Application.Utils;

public static class CodeHelper
{
    public static string GetFormattedCode(Code code)
    {
        var codeWithInputs = code.StaticPart
            .Replace("<inner>", code.UsersInnerPart)
            .Replace("<outer>", code.UsersOuterPart);
        var testsResult = "bool result = " + code.Tests[0];
        
        for (int i = 1; i < code.Tests.Count; i++)
        {
            testsResult += "&& " + code.Tests[i];
        }

        testsResult += ";";

        return codeWithInputs + testsResult + "return result;";
    }
}
using Core;

namespace Application.Utils;

public static class CodeHelper
{
    public static string GetFormattedCode(Code code)
    {
        return code.StaticPart
            .Replace("<inner>", code.UsersInnerPart)
            .Replace("<outer>", code.UsersOuterPart);
    }
}
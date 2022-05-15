using System.Diagnostics;
using Application.Interfaces.Services;
using Application.Utils;
using Core;

namespace Application.Services;

public class CodeService : ICodeService
{
    public bool IsCodeValid(Code code)
    {
        string codeToCheck = CodeHelper.GetFormattedCode(code);

        var processInfo = new ProcessStartInfo("docker", $"run -it --rm check-code {codeToCheck}")
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };

        int exitCode;
        using (var process = new Process())
        {
            process.StartInfo = processInfo;
            process.OutputDataReceived += (_, e) => Console.WriteLine(e.Data);
            process.ErrorDataReceived += (_, e) => Console.WriteLine(e.Data);

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit(5000);
            if (!process.HasExited)
            {
                process.Kill();
            }

            exitCode = process.ExitCode;
            process.Close();
        }

        return exitCode == 1;
    }
}
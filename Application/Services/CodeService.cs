using System.Diagnostics;
using Application.Interfaces.Services;
using Application.Models.CheckCode;
using Application.Utils;
using Persistence.Interfaces;

namespace Application.Services;

public class CodeService : ICodeService
{
    private readonly ICodeRepository _repository;
    
    public CodeService(ICodeRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<CheckCodeResult> IsCodeValid(CheckCodeRequest request)
    {
        var result = new CheckCodeResult();

        var code = await _repository.GetCodeByPracticeId(request.PracticeId);
        string codeToCheck = CodeHelper.GetFormattedCode(code, request.InnerCode, request.OuterCode);

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
            
            process.OutputDataReceived += (_, e) =>
            {
                if (e.Data is null) return;
                if (!e.Data.StartsWith("Result") && ! e.Data.StartsWith("Error")) return;
                
                result.Messages.Add(e.Data);
                Console.WriteLine(e.Data);
            };
            process.ErrorDataReceived += (_, e) =>
            {
                if (e.Data is null) return;
                if (!e.Data.StartsWith("Result") && ! e.Data.StartsWith("Error")) return;
                
                result.Messages.Add(e.Data);
                Console.WriteLine(e.Data);
            };

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

        result.IsValid = exitCode == 1;

        return result;
    }
}
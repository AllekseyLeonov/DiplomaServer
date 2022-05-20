using Application.Models;
using Application.Models.CheckCode;
using Core;

namespace Application.Interfaces.Services;

public interface ICodeService
{
    public Task<CheckCodeResult> IsCodeValid(CheckCodeRequest request);
}
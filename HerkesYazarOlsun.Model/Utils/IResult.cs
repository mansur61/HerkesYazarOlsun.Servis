
namespace HerkesYazarOlsun.Model.Utils;
public interface IResult
{
    MessageResultState State { get; }
    string Message { get; }
}


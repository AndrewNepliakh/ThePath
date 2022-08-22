using System.Threading.Tasks;
using Managers;

public interface ILevel
{
    Task Init(LevelsArguments args);
    void Dispose();
}
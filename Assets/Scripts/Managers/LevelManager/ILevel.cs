using System.Threading.Tasks;
using Managers;

public interface ILevel
{
    void Init(LevelsArguments args);
    void Dispose();
}
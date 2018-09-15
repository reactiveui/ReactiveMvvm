using System.Threading.Tasks;

namespace ReactiveMvvm.Services
{
    public interface ISender
    {
        Task Send(string title, string message, int section, bool bug);
    }
}

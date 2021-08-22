using System.Threading.Tasks;
using System.Windows.Input;

namespace OneView_MappingSet_MVVM.UI.ViewModel.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        void RaiseCanExecuteChanged();
    }

    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
        void RaiseCanExecuteChanged();
    }
}

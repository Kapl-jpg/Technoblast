using Directors;
using Zenject;

public class WriteInFileInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var writeInFile = new WriteInFile();
        Container.Bind<WriteInFile>().FromInstance(writeInFile).AsSingle().NonLazy();
    }
}
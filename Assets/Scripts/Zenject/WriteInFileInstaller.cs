using Directors;
using Zenject;

public class WriteInFileInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var writeInFile = new DataFile();
        Container.Bind<DataFile>().FromInstance(writeInFile).AsSingle().NonLazy();
    }
}
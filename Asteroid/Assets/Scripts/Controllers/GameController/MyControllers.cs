using System.Collections.Generic;

public class MyControllers : IInit, IExecute, ILateExecutes
{
    private readonly List<IInit> _initializationControllers;
    private readonly List<IExecute> _executeControllers;
    private readonly List<ILateExecutes> _lateControllers;

    internal MyControllers()
    {
        _initializationControllers = new List<IInit>();
        _executeControllers = new List<IExecute>();
        _lateControllers = new List<ILateExecutes>();
    }

    internal MyControllers Add(IControllers controller)
    {
        if (controller is IInit initController)
            _initializationControllers.Add(initController);

        if (controller is ILateExecutes lateExecuteController)
            _lateControllers.Add(lateExecuteController);

        if (controller is IExecute executeController)
            _executeControllers.Add(executeController);

        return this;
    }
    public void Initialization()
    {
        for (int i = 0; i < _initializationControllers.Count; i++)
            _initializationControllers[i].Initialization();
    }

    public void Execute(float deltaTime)
    {
        for (int i = 0; i < _executeControllers.Count; i++)
        {
            _executeControllers[i].Execute(deltaTime);
        }
    }

    public void LateExecute(float deltaTime)
    {
        for (int i = 0; i < _lateControllers.Count; i++)
            _lateControllers[i].LateExecute(deltaTime);
    }
}

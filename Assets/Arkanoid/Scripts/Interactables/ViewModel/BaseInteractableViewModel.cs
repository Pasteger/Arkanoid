using UniRx;
using UnityEngine;

public abstract class BaseInteractableViewModel : IInteractableViewModel
{
    public InteractableType Type { get; set; }
    public Vector3 Position { get; set; }
    public Subject<IInteractableModel> OnSetModel { get; } = new Subject<IInteractableModel>();
    public Subject<bool> OnActivate { get; } = new Subject<bool>();

    protected IInteractableModel Model { get; private set; }


    protected readonly CompositeDisposable Disposables = new CompositeDisposable();

    protected BaseInteractableViewModel()
    {
    }

    protected BaseInteractableViewModel(BaseInteractableViewModel referenceViewModel)
    {
        Type = referenceViewModel.Type;
        Position = referenceViewModel.Position;
    }

    public virtual void SetModel(IInteractableModel model)
    {
        Model = model;

        Type = Model.Type;
        Position = model.Position;

        OnSetModel.OnNext(model);
    }

    public virtual void Update(Rigidbody rigidbody)
    {
    }

    public virtual void Collide(Collision other)
    {
    }

    public void Dispose() => Disposables.Dispose();
}
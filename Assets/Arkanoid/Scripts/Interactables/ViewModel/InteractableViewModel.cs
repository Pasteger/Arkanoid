using UniRx;
using UnityEngine;

public class InteractableViewModel : IInteractableViewModel
{
    public InteractableType Type { get; set; }
    public Vector3 Position { get; set; }
    public Subject<IInteractableModel> OnSetModel { get; } = new Subject<IInteractableModel>();

    protected IInteractableModel Model { get; private set; }


    protected readonly CompositeDisposable Disposables = new CompositeDisposable();

    protected InteractableViewModel()
    {
    }

    protected InteractableViewModel(InteractableViewModel referenceViewModel)
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
using UniRx;
using UnityEngine;

public class InteractableViewModel : IInteractableViewModel
{
    public InteractableType Type { get; set; }
    public Vector3 Position { get; set; }
    
    protected IInteractableModel Model { get; private set; }
    

    protected readonly CompositeDisposable Disposable = new CompositeDisposable();

    public void SetModel(IInteractableModel model)
    {
        Model = model;

        Type = Model.Type;
        Position = model.Position;
    }

    public void Update(Rigidbody2D rigidbody, BoxCollider2D boxCollider, Transform transform)
    {
    }
    
    public void Dispose() => Disposable.Dispose();
    
}

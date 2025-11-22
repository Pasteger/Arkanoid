using UniRx;
using UnityEngine;

public abstract class InteractableView : MonoBehaviour, IInteractableView
{
    public IInteractableViewModel ViewModel { get; private set; } = null!;

    protected readonly CompositeDisposable Disposables = new CompositeDisposable();

    protected Rigidbody InteractableRigidbody = null!;

    public void SetViewModel(IInteractableViewModel viewModel)
    {
        ViewModel = viewModel;
        Disposables.Add(ViewModel);

        Subscribe();
    }

    public void Activate(bool isActive, Vector3 position = new Vector3())
    {
        gameObject.SetActive(isActive);
        transform.position = position;
    }

    protected abstract void Init(IInteractableModel model);
    protected virtual void Subscribe() => ViewModel.OnSetModel.Subscribe(Init).AddTo(Disposables);

    protected virtual void Awake() => InteractableRigidbody = GetComponent<Rigidbody>();

    protected virtual void FixedUpdate() => ViewModel.Update(InteractableRigidbody);

    protected virtual void OnCollisionEnter(Collision other) => ViewModel.Collide(other);

    protected void OnDestroy() => Dispose();

    public void Dispose() => Disposables.Dispose();
}
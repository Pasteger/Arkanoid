using MiniIT.INTERACTABLES.MODEL;
using MiniIT.INTERACTABLES.VIEWMODEL;
using UniRx;
using UnityEngine;

namespace MiniIT.INTERACTABLES.VIEW
{
    public abstract class BaseInteractableView : MonoBehaviour, IInteractableView
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
        protected virtual void Subscribe()
        {
            ViewModel.OnSetModel.Subscribe(Init).AddTo(Disposables);
            ViewModel.OnActivate.Subscribe(isActive => Activate(isActive)).AddTo(Disposables);
        }

        protected virtual void Awake() => InteractableRigidbody = GetComponent<Rigidbody>();

        protected virtual void FixedUpdate() => ViewModel.Update(InteractableRigidbody);

        protected virtual void OnCollisionEnter(Collision other) => ViewModel.Collide(other);

        protected void OnDestroy() => Dispose();

        public void Dispose() => Disposables.Dispose();
    }
}
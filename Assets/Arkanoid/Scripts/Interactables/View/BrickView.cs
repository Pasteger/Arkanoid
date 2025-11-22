using UniRx;
using UnityEngine;

public class BrickView : InteractableView
{
    [SerializeField] private BrickDestructionEffect brickDestructionEffect = null!;

    private readonly ReactiveProperty<Color> color = new ReactiveProperty<Color>();
    private bool isUnbreakable = false;

    private Renderer brickRenderer;

    protected override void Awake()
    {
        base.Awake();
        brickRenderer = GetComponent<Renderer>();
        color.Subscribe(c => brickRenderer.material.color = c);
    }

    protected override void Init(IInteractableModel model)
    {
        BrickModel brickModel = (BrickModel)model;

        transform.position = brickModel.Position;
        color.Value = brickModel.IsUnbreakable ? brickModel.UnbreakableColor : brickModel.Color;
        isUnbreakable = brickModel.IsUnbreakable;
    }

    protected override void Subscribe()
    {
        base.Subscribe();

        BrickViewModel brickViewModel = (BrickViewModel)ViewModel;

        brickViewModel.OnDestroy.Subscribe(_ => Destruction()).AddTo(Disposables);
    }

    private void Destruction()
    {
        Instantiate(brickDestructionEffect, transform.position, Quaternion.identity);
        Activate(false);
    }
}
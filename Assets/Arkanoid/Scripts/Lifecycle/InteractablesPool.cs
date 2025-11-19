using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class InteractablesPool : IDisposable
{
    private readonly InteractablesFactory interactablesFactory;
    private readonly Dictionary<InteractableType, Queue<IInteractableView>> pools;
    private readonly Dictionary<InteractableType, HashSet<IInteractableView>> activePools;

    [Inject]
    public InteractablesPool(InteractablesFactory factory)
    {
        interactablesFactory = factory;
        pools = new Dictionary<InteractableType, Queue<IInteractableView>>();
        activePools = new Dictionary<InteractableType, HashSet<IInteractableView>>();
    }

    public async UniTask<IInteractableView> Get(InteractableType interactableType, Vector3 position)
    {
        pools.TryGetValue(interactableType, out Queue<IInteractableView> queue);

        IInteractableView view = queue == null || queue.Count <= 0
            ? await interactablesFactory.Create(interactableType)
            : queue.Dequeue();

        view.Activate(true, position);

        if (!activePools.TryGetValue(interactableType, out HashSet<IInteractableView> activeHashSet))
        {
            activeHashSet = new HashSet<IInteractableView>();
            activePools[interactableType] = activeHashSet;
        }

        activeHashSet.Add(view);

        return view;
    }

    public void Release(IInteractableView view)
    {
        view.Activate(false);
        InteractableType type = view.ViewModel.Type;

        activePools.TryGetValue(type, out HashSet<IInteractableView> activeHashSet);
        activeHashSet?.Remove(view);

        if (!pools.TryGetValue(type, out Queue<IInteractableView> queue))
        {
            queue = new Queue<IInteractableView>();
            pools[type] = queue;
        }

        queue.Enqueue(view);
    }

    public void ReleaseAll()
    {
        foreach (IInteractableView interactable in activePools.Values.SelectMany(set => set))
        {
            Release(interactable);
        }
    }

    public void Clear()
    {
        foreach (HashSet<IInteractableView> set in activePools.Values)
        {
            foreach (IInteractableView view in set)
            {
                view.Dispose();
            }

            set.Clear();
        }

        foreach (Queue<IInteractableView> queue in pools.Values)
        {
            queue.Clear();
        }

        pools.Clear();
        activePools.Clear();
    }

    public void Dispose() => Clear();
}
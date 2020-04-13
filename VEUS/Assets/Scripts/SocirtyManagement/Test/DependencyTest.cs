using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyTest : MonoBehaviour
{
    DependentIndex i1;
    ConditionableIndex i2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Empezamos");
        Index.ErrorMarginInAnIndexChange = 0;
        i1 = new DependentIndex("Índice Dependiente", "Índice Influido", 0.5f);
        i2 = new ConditionableIndex("Índice Independiente", "Índice que influye", 0.5f);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Dependencia aditiva");
        i1.AddDependency(new AdditionDependency(i2, 50));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Bajamos al influyente");
        i2.ChangeIndexValue(Index.CHANGE.DROP);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Subimos al influyente pero eliminamos la dependencia. 2 veces para buscar el error");
        i2.ChangeIndexValue(Index.CHANGE.INCREASE);
        i1.RemoveDependency(i2);
        i1.RemoveDependency(i2);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Subimos un poco al influyente y añadimos dependencia de adición inversa");
        i2.ChangeIndexValue(Index.CHANGE.LOW_INCREASE);
        i1.AddDependency(new ReverseAdditionDependency(i2, 50));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Ahora la dependencia es reducción inversa");
        i1.RemoveDependency(i2);
        i1.AddDependency(new ReverseSubstractionDependency(i2, 50));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Ahora la dependencia es reducción sin más");
        i1.RemoveDependency(i2);
        i1.AddDependency(new SubstractionDependency(i2, 50));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Añadimos otra dependencia para buscar el error, borramos dependencia y añadimos una de misma tendencia");
        i1.AddDependency(new SameTendencyDependency(i2, 50));
        i1.RemoveDependency(i2);
        i1.AddDependency(new SameTendencyDependency(i2, 50));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Bajamos al influyente");
        i2.ChangeIndexValue(Index.CHANGE.DROP);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Añadimos otro influyente");
        Index i3 = new ConditionableIndex("Otro Índice Independiente", "Índice que también influye", 0.5f);
        i1.AddDependency(new SubstractionDependency(i3, 25));
        Debug.Log(i1);
        Debug.Log(i2);
        Debug.Log(i3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

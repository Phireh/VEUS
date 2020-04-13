using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionTest : MonoBehaviour
{
    public class ObjectForTesting
    {
        public enum STATE { ONE, TWO }
        string id;
        STATE state;
        public STATE GetState() => this.state;
        public void SetState(STATE state) => this.state = state;
        public ObjectForTesting(string id) { this.id = id; state = STATE.ONE; }
        public override string ToString() => id + " -> " + state;
    }

    // Start is called before the first frame update
    void Start()
    {
        ConditionableIndex i1 = new ConditionableIndex("Índice1", "Índice condicionable", 0.5f);
        DependentIndex i2 = new DependentIndex("Índice2", "Índice dependiente", 0.5f);

        Debug.LogWarning("I1 tiene una dependencia con I2 del tipo misma tendencia\nHay 1 condición: si I1 es máximo I2 se desplomará");
        i2.AddDependency(new SameTendencyDependency(i1, 25));
        ConditionController.AddCondition(new IndexToIndexStateCondition(
            i2,                 // Índice condicionante
            i1,                 // Índice Condicionado
            Index.STATE.MAX,    // Estado objetivo del índice condicionante
            Index.CHANGE.DROP   // Cambio sobre el índice condicionado
            ));
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Disminuimos un poco I1");
        i1.ChangeIndexValue(Index.CHANGE.LOW_DROP);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Maximizamos I1");
        i1.ChangeIndexValue(Index.CHANGE.MAXIMIZE);
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Aplicamos las condiciones");
        Debug.Log("Número de condiciones aplicadas: " + ConditionController.ApplyAllConditions());
        Debug.Log(i1);
        Debug.Log(i2);

        Debug.LogWarning("Creamos dos objetos de testeo O1 y O2 que empiezan en el estado ONE");
        ObjectForTesting o1 = new ObjectForTesting("O1");
        ObjectForTesting o2 = new ObjectForTesting("O2");
        Debug.Log(o1);
        Debug.Log(o2);

        Debug.LogWarning("Añadimos una condición: Si O1 está en estado TWO, O2 pasa a estado TWO");
        ConditionController.AddCondition(new AttributeToAtributeValueCondition<ObjectForTesting.STATE, ObjectForTesting.STATE>(
            o1.GetState,                    // El método que permite comprobar el valor del atributo de interés
            o2.SetState,                    // El método que permite cambiar el valor del atributo objetivo
            ObjectForTesting.STATE.TWO,     // El valor que debe tomar el atributo de interés
            ObjectForTesting.STATE.TWO      // El valor que tomará el atributo objetivo
            ));
        Debug.Log("Número de condiciones aplicadas: " + ConditionController.ApplyAllConditions());

        Debug.LogWarning("Cambiamos el estado de O1 a TWO");
        o1.SetState(ObjectForTesting.STATE.TWO);
        Debug.Log(o1);
        Debug.Log(o2);

        Debug.LogWarning("Aplicamos las condiciones");
        Debug.Log("Número de condiciones aplicadas: " + ConditionController.ApplyAllConditions());
        Debug.Log(o1);
        Debug.Log(o2);

        Debug.LogWarning("Creamos un nuevo índice I3 y un nuevo objeto O3\nNuevas condiciones: Si O1 está en estado TWO -> O3 pasa a estado TWO," +
            "Si O3 está en estado TWO -> O2 pasa a estado ONE, Si O2 está en estado ONE -> I1 baja a mínimos, Si I2 baja a mínimos O1 pasa a estado ONE");
        ConditionableIndex i3 = new ConditionableIndex("Índice3", "Índice condicionable", 0.5f);
        ObjectForTesting o3 = new ObjectForTesting("O3");
        ConditionController.AddCondition(new AttributeToAtributeValueCondition<ObjectForTesting.STATE, ObjectForTesting.STATE>(
            o1.GetState, o3.SetState, ObjectForTesting.STATE.TWO, ObjectForTesting.STATE.TWO));
        ConditionController.AddCondition(new AttributeToAtributeValueCondition<ObjectForTesting.STATE, ObjectForTesting.STATE>(
            o3.GetState, o2.SetState, ObjectForTesting.STATE.TWO, ObjectForTesting.STATE.ONE));
        Debug.Log(i3);
        Debug.Log(o1);
        Debug.Log(o2);
        Debug.Log(o3);
        Debug.Log(i1);
        Debug.Log(i2);
    }

}

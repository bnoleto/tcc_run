using Classes;
using Enums;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Movimentacao)), CanEditMultipleObjects]
public class MovimentacaoEditor : Editor
{
    public SerializedProperty estiloProp, verticalProp, alcanceProp;

    void OnEnable()
    {
        estiloProp = serializedObject.FindProperty("ModosDeCombate.EstiloCombate");
        verticalProp = serializedObject.FindProperty("ModosDeCombate.VelocidadeRotacaoVertical");
        alcanceProp = serializedObject.FindProperty("ModosDeCombate.Alcance");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(estiloProp);

        EstiloCombate estilo = (EstiloCombate)estiloProp.intValue;

        switch (estilo)
        {
            case EstiloCombate.Padrao:
                break;
            case EstiloCombate.Circular:
                EditorGUILayout.Slider(verticalProp, 5, 30, new GUIContent("Velocidade Vertical"));
                EditorGUILayout.PropertyField(alcanceProp, new GUIContent("Alcance"));
                break;
            case EstiloCombate.Guiado:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}

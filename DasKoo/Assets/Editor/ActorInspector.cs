using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Actor))]
public class ActorInspector : Editor
{
    Actor actor;
    SerializedProperty actor_motor;
    //everytime u see the inspector
    //useful for initalizing 
    void OnEnable()
    {
        actor = (Actor)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        //EditorGUILayout.BeginVertical();
        //EditorGUILayout.LabelField("Aerial Jump Velocity" + actor.actorStats.aerialJumpVelocity);

        //string input
        //actor.actorName = EditorGUILayout.TextArea(actor.actorName);
        //actor.actorStats.moveSpeed = EditorGUILayout.FloatField("Move Speed", actor.actorStats.moveSpeed);
        //actor.actorStats.moveAccel = EditorGUILayout.FloatField("Move Acceleration", actor.actorStats.moveAccel);
        //actor.actorStats.groundedJumpVelocity = EditorGUILayout.FloatField("Grounded Jump Velocity", actor.actorStats.groundedJumpVelocity);
        //actor.actorStats.aerialJumpVelocity = EditorGUILayout.FloatField("Aerial Jump Velocity", actor.actorStats.aerialJumpVelocity);

        //PropertyDrawer drawer;
        actor_motor = serializedObject.FindProperty("_motor");
        //EditorGUI.BeginChangeCheck();
        //EditorGUILayout.PropertyField(actor_motor, true);
        //if (EditorGUI.EndChangeCheck())
        //    serializedObject.ApplyModifiedProperties();
        //EditorGUILayout.EndVertical();

        //actor.motor.groundOffsetVector = EditorGUILayout.Vector3Field("Ground Offset Vector", actor.motor.groundOffsetVector);
        //actor.motor.groundOffsetVector = EditorGUILayout.PropertyField(actor_motor);
        //actor.motor.groundCheckers = EditorGUILayout.
        serializedObject.ApplyModifiedProperties();
    }


}

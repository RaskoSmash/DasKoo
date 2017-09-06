//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;


//[CustomEditor(typeof(Actor))]
//[CanEditMultipleObjects]
//public class ActorInspector : Editor
//{
//    Actor actor;
//    //SerializedProperty actor_motor;
//    //SerializedProperty actor_stats;
//    //everytime u see the inspector
//    //useful for initalizing 
//    void OnEnable()
//    {
//        actor = (Actor)target;
//        //actor_motor = serializedObject.FindProperty("_motor");
//        //actor_stats = serializedObject.FindProperty("actorStats");
//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        //base.OnInspectorGUI();
//        //EditorGUILayout.BeginVertical();

//        actor.actorStats.moveSpeed = EditorGUILayout.FloatField("Move", actor.actorStats.moveSpeed);
//        //SerializedObject _actor = new SerializedObject(actor);
//        //_actor.Update();
//        ActorStats ts = actor.actorStats;
//        if (GUI.changed)
//        {
//            actor.actorStats = ts;
//            EditorUtility.SetDirty(actor);
//            Debug.Log("Editor has set a new value" + actor.actorStats.moveSpeed);
//        }

//        serializedObject.ApplyModifiedProperties();
//        //EditorGUILayout.EndVertical();
//    }


//}

//old code
/*
 
     //EditorGUILayout.LabelField("Aerial Jump Velocity" + actor.actorStats.aerialJumpVelocity);

        //string input
        //actor.actorName = EditorGUILayout.TextArea(actor.actorName);
        //actor.actorStats.moveSpeed = EditorGUILayout.FloatField("Move Speed", actor.actorStats.moveSpeed);
        //actor.actorStats.moveAccel = EditorGUILayout.FloatField("Move Acceleration", actor.actorStats.moveAccel);
        //actor.actorStats.groundedJumpVelocity = EditorGUILayout.FloatField("Grounded Jump Velocity", actor.actorStats.groundedJumpVelocity);
        //actor.actorStats.aerialJumpVelocity = EditorGUILayout.FloatField("Aerial Jump Velocity", actor.actorStats.aerialJumpVelocity);

        //PropertyDrawer drawer;
        //EditorGUILayout.PropertyField(actor_motor, true);

        //    serializedObject.ApplyModifiedProperties();
        //serializedObject.ApplyModifiedProperties();
        //EditorGUILayout.EndVertical();

        //actor.motor.groundOffsetVector = EditorGUILayout.Vector3Field("Ground Offset Vector", actor.motor.groundOffsetVector);
        //actor.motor.groundOffsetVector = EditorGUILayout.PropertyField(actor_motor);
        //actor.motor.groundCheckers = EditorGUILayout.
*/

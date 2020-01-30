﻿using UnityEditor;
using UnityEngine;
using System.Reflection;
using Innoactive.Hub.Training.SceneObjects;
using Innoactive.Hub.Training.SceneObjects.Properties;

namespace Innoactive.Hub.Training.Editors.SceneObjects
{
    /// <summary>
    /// This class adds names to newly added entities.
    /// </summary>
    [CustomEditor(typeof(TrainingSceneObject))]
    public class SceneObjectEditor : Editor
    {
        private void OnEnable()
        {
            ISceneObject sceneObject = target as ISceneObject;
            FieldInfo fieldInfoObj = sceneObject.GetType().GetField("uniqueName", BindingFlags.NonPublic | BindingFlags.Instance);
            string uniqueName = fieldInfoObj.GetValue(sceneObject) as string;

            if (string.IsNullOrEmpty(uniqueName))
            {
                sceneObject.SetSuitableName();
            }
        }

        [MenuItem ("CONTEXT/TrainingSceneObject/Remove Training Properties", false)]
        private static void RemoveTrainingProperties()
        {
            Component[] trainingProperties = Selection.activeGameObject.GetComponents(typeof(TrainingSceneObjectProperty));
            ISceneObject sceneObject = Selection.activeGameObject.GetComponent(typeof(ISceneObject)) as ISceneObject;

            foreach (Component trainingProperty in trainingProperties)
            {
                sceneObject.RemoveTrainingProperty(trainingProperty, true);
            }
        }

        [MenuItem("CONTEXT/TrainingSceneObject/Remove Training Properties", true)]
        private static bool ValidateRemoveTrainingProperties()
        {
            return Selection.activeGameObject.GetComponents(typeof(TrainingSceneObjectProperty)) != null;
        }
    }
}


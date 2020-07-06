using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Innoactive.Creator.Core;
using Innoactive.Creator.Core.Properties;
using Innoactive.Creator.Core.RestrictiveEnvironment;
using Innoactive.Creator.Core.SceneObjects;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Innoactive.CreatorEditor.UI.Drawers
{
    [DefaultTrainingDrawer(typeof(LockableObjectsCollection))]
    internal class LockableObjectsDrawer : DataOwnerDrawer
    {
        public override Rect Draw(Rect rect, object currentValue, Action<object> changeValueCallback, GUIContent label)
        {
            LockableObjectsCollection lockableObjects = (LockableObjectsCollection) currentValue;

            Rect nextPosition = new Rect(rect.x, rect.y, rect.width, EditorDrawingHelper.HeaderLineHeight);
            nextPosition.y += 10;

            GUI.Label(nextPosition,"Automatically unlocked objects in this step");

            IEnumerable<ISceneObject> distinctObjects = lockableObjects.ToAutomaticallyUnlock.Select(propertyData => propertyData.Property.SceneObject).Distinct();

            foreach (ISceneObject lockableObject in distinctObjects)
            {
                nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing;
                EditorGUILayout.BeginHorizontal();

                EditorGUI.ObjectField(nextPosition, (TrainingSceneObject)lockableObject, typeof(TrainingSceneObject), true);

                foreach (ISceneObjectProperty sceneObjectProperty in lockableObject.Properties.Where(property => property is LockableProperty))
                {
                    nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing;
                    Rect objectPosition = nextPosition;
                    objectPosition.x += EditorDrawingHelper.IndentationWidth * 2f;
                    objectPosition.width -= EditorDrawingHelper.IndentationWidth * 2f;

                    // if property is

                    EditorGUI.Toggle(nextPosition, false);
                    EditorGUI.ObjectField(objectPosition, sceneObjectProperty.SceneObject.GameObject, typeof(LockableProperty), true);
                }

                EditorGUILayout.EndHorizontal();
            }

            nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing * 2;

            GUI.Label(nextPosition,"Additional objects to lock/unlock during this step");

            distinctObjects = lockableObjects.ToManuallyUnlock.Select(propertyData => propertyData.Property.SceneObject).Distinct();

            foreach (ISceneObject lockableObject in distinctObjects)
            {
                nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing;
                EditorGUILayout.BeginHorizontal();

                EditorGUI.ObjectField(nextPosition, (TrainingSceneObject)lockableObject, typeof(TrainingSceneObject), true);

                foreach (ISceneObjectProperty sceneObjectProperty in lockableObject.Properties.Where(property => property is LockableProperty))
                {
                    nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing;
                    Rect objectPosition = nextPosition;
                    objectPosition.x += EditorDrawingHelper.IndentationWidth * 2f;
                    objectPosition.width -= EditorDrawingHelper.IndentationWidth * 2f;

                    EditorGUI.Toggle(nextPosition, false);
                    EditorGUI.ObjectField(objectPosition, sceneObjectProperty.SceneObject.GameObject, typeof(LockableProperty), true);
                }

                EditorGUILayout.EndHorizontal();
            }



            nextPosition.y += EditorDrawingHelper.SingleLineHeight + EditorDrawingHelper.VerticalSpacing * 2;

            TrainingSceneObject newObjectToManuallyLock = (TrainingSceneObject) EditorGUI.ObjectField(nextPosition, null, typeof(TrainingSceneObject), true);

            if (newObjectToManuallyLock != null)
            {
                foreach (ISceneObjectProperty objectProperty in newObjectToManuallyLock.Properties)
                {
                    if (objectProperty is LockableProperty)
                    {
                        LockablePropertyData data = new LockablePropertyData((LockableProperty)objectProperty);
                        lockableObjects.ToManuallyUnlock.Add(data);
                    }
                }
            }

            return rect;
        }
    }
}

using System.Collections.Generic;
using System.Runtime.Serialization;
using Innoactive.Creator.Core.Behaviors;
using Innoactive.Creator.Core.RestrictiveEnvironment;
using Innoactive.Creator.Core.SceneObjects;

namespace Innoactive.Creator.Core
{
    [DataContract(IsReference = true)]
    public class LockableObjectsCollection
    {
        public string Text = "LockableCollection";

        private List<TrainingSceneObject> sceneObjects;

        public LockableObjectsCollection(Step.EntityData entityData)
        {
            ToUnlock = LockableHandling.GetLockablePropertiesFrom(entityData);
            ToManuallyUnlock = entityData.ToUnlock;

            sceneObjects = new List<TrainingSceneObject>();
        }

        public IEnumerable<LockablePropertyData> ToUnlock { get; set; }

        public IEnumerable<LockablePropertyReference> ToManuallyUnlock { get; set; }

        public void UpdateSceneObjects()
        {
            foreach (LockablePropertyData lockablePropertyData in ToUnlock)
            {

            }
        }
    }
}

namespace Innoactive.CreatorEditor.UI.Drawers.Metadata
{
    /// <summary>
    /// Metadata to make <see cref="Innoactive.Creator.Core.Attributes.ReorderableListOfAttribute"/> reorderable.
    /// </summary>
    public class ReorderableElementMetadata
    {
        /// <summary>
        /// Determines, whether the entity in the list must be moved up.
        /// </summary>
        public bool MoveUp { get; set; }

        /// <summary>
        /// Determines, whether the entity in the list must be moved down.
        /// </summary>
        public bool MoveDown { get; set; }
    }
}

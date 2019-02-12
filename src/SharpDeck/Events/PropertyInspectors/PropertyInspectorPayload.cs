﻿namespace SharpDeck.Events.PropertyInspectors
{
    /// <summary>
    /// Provides an optional payload which can be used in association with <see cref="PropertyInspectorMethodAttribute"/> to expose a method to the property inspector.
    /// </summary>
    public class PropertyInspectorPayload
    {
        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        public string Event { get; set; }
    }
}
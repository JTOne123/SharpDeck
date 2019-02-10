﻿namespace SharpDeck
{
    using Newtonsoft.Json.Linq;
    using SharpDeck.Events;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides a handler for an event received from an Elgato Stream Deck for an instance of an action.
    /// </summary>
    public class StreamDeckActionReceiver : IStreamDeckActionReceiver, IDisposable
    {
        /// <summary>
        /// Occurs when the user presses a key.
        /// </summary>
        public event EventHandler<ActionEventArgs<KeyPayload>> KeyDown;

        /// <summary>
        /// Occurs when the user releases a key.
        /// </summary>
        public event EventHandler<ActionEventArgs<KeyPayload>> KeyUp;

        /// <summary>
        /// Occurs when the property inspector sends a message to the plugin.
        /// </summary>
        public event EventHandler<ActionEventArgs<JObject>> SendToPlugin;

        /// <summary>
        /// Occurs when the user changes the title or title parameters.
        /// </summary>
        public event EventHandler<ActionEventArgs<TitlePayload>> TitleParametersDidChange;

        /// <summary>
        /// Occurs when an instance of an action appears.
        /// </summary>
        public event EventHandler<ActionEventArgs<ActionPayload>> WillAppear;

        /// <summary>
        /// Occurs when an instance of an action disappears.
        /// </summary>
        public event EventHandler<ActionEventArgs<ActionPayload>> WillDisappear;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing) {}

        /// <summary>
        /// Raises the event, based on the <paramref name="event"/>, using the specified <paramref name="args"/>.
        /// </summary>
        /// <param name="event">The event name.</param>
        /// <param name="args">The message as arguments.</param>
        internal virtual Task RaiseEventAsync(string @event, JObject args)
        {
            switch (@event)
            {
                case "keyDown":
                    return this.OnKeyDown(args.ToObject<ActionEventArgs<KeyPayload>>());

                case "keyUp":
                    return this.OnKeyUp(args.ToObject<ActionEventArgs<KeyPayload>>());

                case "sendToPlugin":
                    return this.OnSendToPlugin(args.ToObject<ActionEventArgs<JObject>>());

                case "titleParametersDidChange":
                    return this.OnTitleParametersDidChange(args.ToObject<ActionEventArgs<TitlePayload>>());

                case "willAppear":
                    return this.OnWillAppear(args.ToObject<ActionEventArgs<ActionPayload>>());

                case "willDisappear":
                    return this.OnWillDisappear(args.ToObject<ActionEventArgs<ActionPayload>>());
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when the user presses a key.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{KeyPayload}" /> instance containing the event data.</param>
        protected virtual Task OnKeyDown(ActionEventArgs<KeyPayload> args)
        {
            this.KeyDown?.Invoke(this, args);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when the user releases a key.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{KeyPayload}" /> instance containing the event data.</param>
        protected virtual Task OnKeyUp(ActionEventArgs<KeyPayload> args)
        {
            this.KeyUp?.Invoke(this, args);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when the property inspector sends a message to the plugin.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{JObject}"/> instance containing the event data.</param>
        protected virtual Task OnSendToPlugin(ActionEventArgs<JObject> args)
        {
            this.SendToPlugin?.Invoke(this, args);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when the user changes the title or title parameters.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{TitlePayload}" /> instance containing the event data.</param>
        protected virtual Task OnTitleParametersDidChange(ActionEventArgs<TitlePayload> args)
        {
            this.TitleParametersDidChange?.Invoke(this, args);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when an instance of an action appears.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{ActionPayload}" /> instance containing the event data.</param>
        protected virtual Task OnWillAppear(ActionEventArgs<ActionPayload> args)
        {
            this.WillAppear?.Invoke(this, args);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Occurs when an instance of an action disappears.
        /// </summary>
        /// <param name="args">The <see cref="ActionEventArgs{ActionPayload}" /> instance containing the event data.</param>
        protected virtual Task OnWillDisappear(ActionEventArgs<ActionPayload> args)
        {
            this.WillDisappear?.Invoke(this, args);
            return Task.CompletedTask;
        }
    }
}

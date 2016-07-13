using System;

namespace Wpf.Common.Events {
    using Prism.Events;

    /// <summary>
    /// This resolver allows an event to be passed to an object, without actually allowing the 
    /// event aggregator to leak into the object because this class wraps and hides the event aggregator.
    /// When passed into a constructor, it declares intent, that the class will be using this event,
    /// rather than just the entire event aggregator and any events it has.
    /// </summary>
    /// <typeparam name="T">EventBase derived type</typeparam>
    public class EventResolver<T> : IEventResolver<T> where T : EventBase, new() {

        readonly IEventAggregator _eventAggregator;

        public EventResolver(IEventAggregator eventAggregator) {
            if (eventAggregator == null) {
                throw new ArgumentNullException(nameof(eventAggregator));
            }

            _eventAggregator = eventAggregator;
        }

        public T Resolve() {
            return _eventAggregator.GetEvent<T>();
        }
    }
}

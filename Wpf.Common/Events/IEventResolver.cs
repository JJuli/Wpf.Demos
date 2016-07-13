namespace Wpf.Common.Events {
    using Prism.Events;

    public interface IEventResolver<out T> where T : EventBase, new() {

        T Resolve();

    }
}

namespace Wpf.Common.Infrastructure {
    using System;

    public class RepositoryResult<T> {

        public Exception Error { get; }

        public T Package { get; }

        public RepositoryResult(T package, Exception error) {
            this.Package = package;
            this.Error = error;
        }

    }
}

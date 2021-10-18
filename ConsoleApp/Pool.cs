using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    public sealed class Pool : IDisposable
    {
        private readonly LinkedList<Thread> _workers;
        private readonly LinkedList<Action> _tasks = new LinkedList<Action>();
        private bool _disallowAdd;
        private bool _disposed;

        public Pool(int poolSize)
        {
            _workers = new LinkedList<Thread>();
            for (var i = 0; i < poolSize; ++i)
            {
                var worker = new Thread(Worker) { Name = string.Concat("Worker ", i) };
                worker.Start();
                _workers.AddLast(worker);
            }
        }

        public void Dispose()
        {
            var waitForThreads = false;
            lock (_tasks)
            {
                if (!_disposed)
                {
                    GC.SuppressFinalize(this);

                    _disallowAdd = true; 
                    while (_tasks.Count > 0)
                    {
                        Monitor.Wait(_tasks);
                    }

                    _disposed = true;
                    Monitor.PulseAll(_tasks); 
                    waitForThreads = true;
                }
            }
            if (waitForThreads)
            {
                foreach (var worker in _workers)
                {
                    worker.Join();
                }
            }
        }

        public void QueueTask(Action task)
        {
            lock (_tasks)
            {
                if (_disallowAdd) { throw new InvalidOperationException("This Pool instance is in the process of being disposed, can't add anymore"); }
                if (_disposed) { throw new ObjectDisposedException("This Pool instance has already been disposed"); }
                _tasks.AddLast(task);
                Monitor.PulseAll(_tasks); 
            }
        }

        private void Worker()
        {
            Action task = null;
            while (true) 
            {
                lock (_tasks) 
                {
                    while (true) 
                    {
                        if (_disposed)
                        {
                            return;
                        }
                        if (null != _workers.First && object.ReferenceEquals(Thread.CurrentThread, _workers.First.Value) && _tasks.Count > 0) 
                        {
                            task = _tasks.First.Value;
                            _tasks.RemoveFirst();
                            _workers.RemoveFirst();
                            Monitor.PulseAll(_tasks); 
                            break; 
                        }
                        Monitor.Wait(_tasks); 
                    }
                }

                task(); 
                lock (_tasks)
                {
                    _workers.AddLast(Thread.CurrentThread);
                }
                task = null;
            }
        }


    }
}
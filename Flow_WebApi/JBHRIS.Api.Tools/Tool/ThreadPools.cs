using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JBHRIS.Api.Tools.Tool
{
    /// <summary>
    /// 
    /// </summary>
    public class ThreadPools : IDisposable
    {
        private List<Thread> _workerThreads = new List<Thread>();

        private bool _stop_flag = false;
        private bool _cancel_flag = false;

        private TimeSpan _maxWorkerThreadTimeout = TimeSpan.FromMilliseconds(1000000);
        private int _maxWorkerThreadCount = 0;
        private ThreadPriority _workerThreadPriority = ThreadPriority.Normal;

        private Queue<WorkItem> _workitems = new Queue<WorkItem>();
        private ManualResetEvent enqueueNotify = new ManualResetEvent(false);
        //private AutoResetEvent enqueueNotify = new AutoResetEvent(false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="threads"></param>
        /// <param name="priority"></param>
        public ThreadPools(int threads, ThreadPriority priority)
        {
            this._maxWorkerThreadCount = threads;
            this._workerThreadPriority = priority;
        }

        private void CreateWorkerThread()
        {
            Thread worker = new Thread(new ThreadStart(this.DoWorkerThread));
            worker.Priority = this._workerThreadPriority;
            lock (this._workerThreads)
            {
                this._workerThreads.Add(worker);
            }
            worker.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public bool QueueUserWorkItem(WaitCallback callback)
        {
            return this.QueueUserWorkItem(callback, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool QueueUserWorkItem(WaitCallback callback, object state)
        {
            if (this._stop_flag == true)
            {
                return false;
            }

            WorkItem wi = new WorkItem();
            wi.callback = callback;
            wi.state = state;

            if (this._workitems.Count > 0 && this._workerThreads.Count < this._maxWorkerThreadCount)
            {
                this.CreateWorkerThread();
            }
            else
            {
                wi.Execute();
            }

            this._workitems.Enqueue(wi);
            this.enqueueNotify.Set();
            this.enqueueNotify.Reset();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndPool()
        {
            this.EndPool(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public void CancelPool()
        {
            this.EndPool(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancelQueueItem"></param>
        public void EndPool(bool cancelQueueItem)
        {
            if (this._workerThreads.Count == 0) return;

            this._stop_flag = true;
            this._cancel_flag = cancelQueueItem;
            this.enqueueNotify.Set();

            //do
            //{
            //    Thread worker = this._workerThreads[0];
            //    worker.Join();
            //    this._workerThreads.Remove(worker);
            //} while (this._workerThreads.Count > 0);

            while (this._workerThreads.Count > 0)
            {
                Thread worker = this._workerThreads[0];
                //曾有發生null 的可能 所以先判斷 20140218 by 阿明
                if (worker != null)
                {
                    worker.Join();
                    this._workerThreads.Remove(worker);
                }
            }
        }

        private void DoWorkerThread()
        {
            while (true)
            {
                while (this._workitems.Count > 0)
                {
                    WorkItem item = null;
                    lock (this._workitems)
                    {
                        if (this._workitems.Count > 0)
                        {
                            item = this._workitems.Dequeue();
                        }
                    }
                    if (item == null) 
                    { 
                        continue; 
                    }

                    try
                    {
                        item.Execute();
                    }
                    catch (Exception)
                    {
                        //
                        //  ToDo: exception handler
                        //
                    }

                    if (this._cancel_flag == true)
                    {
                        break;
                    }
                }

                if (this._stop_flag == true || this._cancel_flag == true)
                {
                    break;
                }
                if (this.enqueueNotify.WaitOne(this._maxWorkerThreadTimeout, true) == true)
                {
                    continue;
                }
                break;
            }

            lock (this._workerThreads)
            {
                if (this._workerThreads.Contains(Thread.CurrentThread))
                {
                    this._workerThreads.Remove(Thread.CurrentThread);
                }
            }
        }

        private class WorkItem
        {
            public WaitCallback callback;
            public object state;

            public void Execute()
            {
                this.callback(this.state);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.EndPool(false);
        }
    }
}

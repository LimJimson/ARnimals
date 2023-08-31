using System;
using System.Collections.Generic;

namespace Plugins.HG.PermissionManager
{
    // Requests one permission after another, waiting for either Granted or Denied callback first
    internal class PermissionRequestQueue
    {
        private readonly Action<string, Action<string>, Action<string>> _requestPermissionDelegate;
        private bool _requestInProgress = false;
        private readonly List<PermissionRequest> _queue = new List<PermissionRequest>();

        private class PermissionRequest
        {
            public string PermissionName;
            public Action<string> OnPermissionGranted;
            public Action<string> OnPermissionDenied;
        }

        // expects a delegate where first argument is the permission name,
        // second is the OnPermissionGranted callback
        // third is the OnPermissionDenied callback
        public PermissionRequestQueue(Action<string, Action<string>, Action<string>> requestPermissionDelegate)
        {
            _requestPermissionDelegate = requestPermissionDelegate;
        }


        public void Add(string permissionName, Action<string> onPermissionGranted, Action<string> onPermissionDenied)
        {
            var request = new PermissionRequest
            {
                PermissionName = permissionName,
                OnPermissionGranted = onPermissionGranted,
                OnPermissionDenied = onPermissionDenied
            };

            AddToQueue(request);
            ProcessQueue();
        }

        private void ProcessQueue()
        {
            if (_requestInProgress) return;
            if (_queue.Count == 0) return;

            _requestInProgress = true;
            
            var request = _queue[0];
            _queue.RemoveAt(0);
            
            _requestPermissionDelegate.Invoke(request.PermissionName,
                request.OnPermissionGranted + OnRequestFinished,
                request.OnPermissionDenied + OnRequestFinished);

        }

        private void OnRequestFinished(string permissionName)
        {
            _requestInProgress = false;
            ProcessQueue();
        }

        private void AddToQueue(PermissionRequest request)
        {
            _queue.Add(request);
        }
    }
}
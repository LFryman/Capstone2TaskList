using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTaskList
{
    class Task
    {
        #region fields
        private string _name;
        private string _description;
        private DateTime _dueDate;
        private bool _completed;

        #endregion

        #region properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        public bool Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }

        #endregion

        #region Constructor

        public Task()
        {

        }

        public Task(string TeamMemberName, string TaskDescription, DateTime DueDate, bool Completed = false)
        {
            _name = TeamMemberName;
            _description = TaskDescription;
            _dueDate = DueDate;
            _completed = Completed;
        }
        #endregion

    }
}


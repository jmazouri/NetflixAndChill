using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace NetflixAndChill
{
    public class SessionManager
    {
        private readonly List<Session> _sessions = new List<Session>();

        public ReadOnlyCollection<Session> Sessions
        {
            get { return _sessions.AsReadOnly(); }
        }

        public bool SessionIdExists(string sessionId)
        {
            return _sessions.Any(d => d.SessionID == sessionId);
        }

        public void AddSession(Session session)
        {
            if (!SessionIdExists(session.SessionID))
            {
                _sessions.Add(session);
            }
            else
            {
                throw new DuplicateNameException("Session already exists: "+session.SessionID);
            }
        }

        public void ClearSession(string id)
        {
            _sessions.RemoveAll(d => d.SessionID == id);
        }
    }
}

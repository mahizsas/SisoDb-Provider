using System;
using System.Collections.Generic;
using SisoDb.EnsureThat;
using SisoDb.Structures;
using SisoDb.Structures.Schemas;

namespace SisoDb
{
    public class SessionEvents : ISessionEvents
    {
        protected readonly List<Action<ISession, IStructureSchema, IStructure, object>> OnInsertedHandlers;
        protected readonly List<Action<ISession, IStructureSchema, IStructure, object>> OnUpdatedHandlers;
        protected readonly List<Action<ISession, IStructureSchema, IStructureId>> OnDeletedHandlers;
        protected readonly List<Action<ISession, IStructureSchema, IQuery>> OnDeletedByQueryHandlers;

        public Action<ISession, IStructureSchema, IStructure, object> OnInserted 
        { 
            set 
            {
                Ensure.That(value, "OnInserted").IsNotNull();
                RegisterNewOnInsertedHandler(value);
            }
        }
        public Action<ISession, IStructureSchema, IStructure, object> OnUpdated
        {
            set
            {
                Ensure.That(value, "OnUpdated").IsNotNull();
                RegisterNewOnUpdatedHandler(value);
            }
        }

        public Action<ISession, IStructureSchema, IStructureId> OnDeleted
        {
            set
            {
                Ensure.That(value, "OnDeleted").IsNotNull();
                RegisterNewOnDeletedHandler(value);
            }
        }

        public Action<ISession, IStructureSchema, IQuery> OnDeletedByQuery
        {
            set
            {
                Ensure.That(value, "OnDeleted").IsNotNull();
                RegisterNewOnDeletedByQueryHandler(value);
            }
        }

        public SessionEvents()
        {
            OnInsertedHandlers = new List<Action<ISession, IStructureSchema, IStructure, object>>();
            OnUpdatedHandlers = new List<Action<ISession, IStructureSchema, IStructure, object>>();
            OnDeletedHandlers = new List<Action<ISession, IStructureSchema, IStructureId>>();
            OnDeletedByQueryHandlers = new List<Action<ISession, IStructureSchema, IQuery>>();
        }

        protected virtual void RegisterNewOnInsertedHandler(Action<ISession, IStructureSchema, IStructure, object> handler)
        {
            OnInsertedHandlers.Add(handler);
        }

        protected virtual void RegisterNewOnUpdatedHandler(Action<ISession, IStructureSchema, IStructure, object> handler)
        {
            OnUpdatedHandlers.Add(handler);
        }

        protected virtual void RegisterNewOnDeletedHandler(Action<ISession, IStructureSchema, IStructureId> handler)
        {
            OnDeletedHandlers.Add(handler);
        }

        protected virtual void RegisterNewOnDeletedByQueryHandler(Action<ISession, IStructureSchema, IQuery> handler)
        {
            OnDeletedByQueryHandlers.Add(handler);
        }

        public virtual void NotifyOnInserted(ISession session, IStructureSchema schema, IStructure structure, object item)
        {
            foreach (var handler in OnInsertedHandlers)
                handler.Invoke(session, schema, structure, item);
        }

        public virtual void NotifyOnInserted(ISession session, IStructureSchema schema, IStructure[] structures, object[] items)
        {
            for (var i = 0; i < structures.Length; i++)
                NotifyOnInserted(session, schema, structures[i], items[i]);
        }

        public virtual void NotifyOnUpdated(ISession session, IStructureSchema schema, IStructure structure, object item)
        {
            foreach (var handler in OnUpdatedHandlers)
                handler.Invoke(session, schema, structure, item);
        }

        public virtual void NotifyOnUpdated(ISession session, IStructureSchema schema, IStructure[] structures, object[] items)
        {
            for (var i = 0; i < structures.Length; i++)
                NotifyOnUpdated(session, schema, structures[i], items[i]);
        }

        public virtual void NotifyOnDeleted(ISession session, IStructureSchema schema, IStructureId id)
        {
            foreach (var handler in OnDeletedHandlers)
                handler.Invoke(session, schema, id);
        }

        public virtual void NotifyOnDeleted(ISession session, IStructureSchema schema, IStructureId[] ids)
        {
            foreach (var id in ids)
                NotifyOnDeleted(session, schema, id);
        }

        public virtual void NotifyOnDeleted(ISession session, IStructureSchema schema, IQuery query)
        {
            foreach (var handler in OnDeletedByQueryHandlers)
                handler.Invoke(session, schema, query);
        }
    }
}
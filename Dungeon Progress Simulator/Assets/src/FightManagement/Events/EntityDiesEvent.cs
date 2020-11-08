using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EntityDiesEvent : Event
{
    public EntityDiesEvent(int targetId, int sourceId) : base(targetId,sourceId)
    {

    }
}


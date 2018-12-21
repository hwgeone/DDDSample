using LabFlow.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LabFlow.Application.EventSourcedNormalizers
{
    public class TigerHistory
    {
        public static IList<TigerHistoryData> HistoryData { get; set; }

        public static IList<TigerHistoryData> ToJavaScriptTigerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<TigerHistoryData>();
            TigerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<TigerHistoryData>();
            var last = new TigerHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new TigerHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void TigerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new TigerHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "TigerRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Name = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}

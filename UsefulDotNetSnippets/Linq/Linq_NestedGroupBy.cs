using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambdaDemo.Linq
{
    public static class Linq_NestedGroupBy
    {
        public class Event
        {
            public Event(int eventId, string eventName, string eventSource)
            {
                EventId = eventId;
                EventName = eventName;
                Source = eventSource;
            }
            public int EventId;
            public string EventName;
            public string Source;
        }

        public class Rule
        {
            public Rule(int ruleId, string ruleName, string source)
            {
                RuleId = ruleId;
                RuleName = ruleName;
                Source = source;
            }

            public int RuleId;
            public string RuleName;
            public string Source;
        }

        public class Action
        {
            public Action(int ruleId, int actionId, string actionName)
            {
                RuleId = ruleId;
                ActionId = actionId;
                ActionName = actionName;
            }

            public int RuleId;
            public int ActionId;
            public string ActionName;
        }

        public class ActionElement
        { 
            public string ActionName;
            public int ActionId;
        }
        public class RuleElement
        {
            public string RuleName;
            public int RuleId;
            public ActionElement[] ActionElements;
        }

        public class ProcessingItem
        {
            public string EventName;
            public int EventId;
            public string EventSource;

            public RuleElement RuleElement;
        }

        public static void Demo()
        {
            var events = new List<Event>() {
                new Event(1, "Inflow from barbara city", "Sewage"),
                new Event(2, "Inflow from via vice town", "Sewage"),
                new Event(3, "Hazardous waste from trel-tek industry", "Sewage"),
                new Event(4, "The industrial exhaust from trel-tek", "Air"),
                new Event(5, "Crammery work by-product", "Air"),
                new Event(6, "Surprise storms at charles hempton town", "Rain"),
                new Event(7, "Vapoured rain water from land rover survey shore", "Rain"),
                new Event(8, "Draught time rain at rearkey city", "Air"),
            };

            var rules = new List<Rule>()
            {
                new Rule(1,"Filter Sewage Water", "Sewage"),
                new Rule(2,"Hydrate Sewage Water", "Sewage"),
                new Rule(3,"Mineralize Sewage Water", "Sewage"),
                new Rule(4,"Suck the exhaust air", "Air"),
                new Rule(5,"Filter the air", "Air"),
                new Rule(6,"Release the air into sysem", "Air"),
                new Rule(7,"Harvest the rain water", "Rain"),
                new Rule(8,"Filter the rain water", "Rain"),
                new Rule(9,"Treat the rain water with minerals and little alkaline", "Rain"),
                new Rule(10,"Irrigate the filtered rain water into dam", "Rain"),
            };

            var actions = new List<Action>()
            {
                new Action(1,1,"Pump the water"),
                new Action(1,2,"Treat with chlorine while the water is pumped"),
                new Action(2,3,"Add some pure water"),
                new Action(3,4,"Treat with phosphorus"),
                new Action(3,5,"Treat with sulfur"),
                new Action(3,6,"Treat with calcium"),
                new Action(4,7,"Turn on the blow-field-tec vaccuum"),
                new Action(4,8,"Direct the flow to suck surrounding air"),
                new Action(5,9,"Heat the air"),
                new Action(5,10,"Activate filters"),
                new Action(5,11,"Activate nano particle emitter and let it run"),
                new Action(6,12,"Release the air into system"),
                new Action(6,13,"Turn off the vaccuum"),
                new Action(7,14,"Turn on water rotors to pump in the rain water"),
                new Action(7,15,"Turn off water rotors after x minutes"),
                new Action(8,16,"Filter the water with process-a"),
                new Action(8,17,"Filter the water with process-b"),
                new Action(9,18,"Treat with sulfur"),
                new Action(9,19,"Treat with calcium"),
                new Action(9,20,"Add some sugar"),
                new Action(10,21,"Pump out the water from reverse hedging hydro rotor"),
                new Action(10,22,"Turn on the heater to dry out the internal chambers"),
            };

            var result =
                events
                    .Join(rules, r => r.Source, e => e.Source, (e, r) => new { Event = e, Rule = r })
                    .Join(actions, re => re.Rule.RuleId, a => a.RuleId, (re, a) => new { re.Event, re.Rule, Action = a })
                    .GroupBy(list => list.Event, list => new { list.Rule, list.Action })
                    .SelectMany(evtGrp => evtGrp.GroupBy(item => item.Rule, grpRle => new { grpRle.Action }),
                                        (e, r) => new { Event = e.Key, Rule = r })
                    .Select(grpEvent =>
                     {
                         return new ProcessingItem()
                         {
                             EventId = grpEvent.Event.EventId,
                             EventName = grpEvent.Event.EventName,
                             EventSource = grpEvent.Event.Source,
                             RuleElement = new RuleElement()
                             {
                                 RuleId = grpEvent.Rule.Key.RuleId,
                                 RuleName = grpEvent.Rule.Key.RuleName,
                                 ActionElements = grpEvent.Rule.Select(item =>
                                                       {
                                                           return new ActionElement()
                                                           {
                                                               ActionId = item.Action.ActionId,
                                                               ActionName = item.Action.ActionName,
                                                           };
                                                       }).ToArray()
                             }
                         };
                     })
                    .ToList();

        }
    }
}

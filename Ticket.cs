using System;

namespace midterm
{
    public abstract class Ticket
    {
        public int ticketID { get; set; }
        public string summary { get; set; }

        public string status {get; set;}

        public string priority {get; set;}

        public string submitter {get; set;}

        public string assigned {get; set;}

        public string watching {get; set;}

        public virtual string Display()
        {
            return ($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}");
        }

    }

    public class Bug: Ticket {
        public string severity { get; set; }
        public override string Display()
        {
            return ($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}, {severity}");
        }

    }

        public class Enhancement: Ticket {
        
        //Software, Cost, Reason, Estimate
        public string software {get; set;}
        public decimal cost {get; set;}
        public string reason {get; set;}

        public string estimate {get; set;}
        public override string Display()
        {
            return ($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}, {software}, {cost}, {reason}, {estimate}");
        }

    }

        public class Task: Ticket {
        
        //ProjectName, DueDate
        public string projectName {get; set;}
        public string dueDate {get; set;}
        public override string Display()
        {
            return ($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}, {projectName}, {dueDate}");
        }

    }

}
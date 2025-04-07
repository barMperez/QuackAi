#region Using

using HomeTask.Models;

#endregion

namespace HomeTask.Services
{
    internal class CategoryService
    {
        #region Constants

        private static readonly Dictionary<CategoryType, HashSet<string>> KeywordsByCategoryType = new()
        {
            { CategoryType.Bug, new HashSet<string>
            {
                "error", "bug", "issue", "problem", "technical", "glitch", "malfunction", "failure", "crash", "defect", "fault", "anomaly", "exception", "bug report", "bug fix", "bug tracking", "bug bounty", "bug database", "bug management", "bug analysis", "bug resolution", "missing"
            }
            },
            {
                CategoryType.Payment, new HashSet<string>
                {
                    "billing", "charge", "payment", "invoice", "money", "refund", "transaction", "credit card", "debit card", "bank account", "payment method", "payment issue", "payment problem", "payment error", "payment failure", "payment dispute", "payment confirmation", "payment receipt", "payment processing", "payment gateway", "payment processor", "payment service provider"
                }
            },
            {
                CategoryType.General, new HashSet<string>
                {
                    "question", "info", "inquiry", "help", "support", "assistance", "request", "query", "clarification", "details", "information", "knowledge", "understanding", "explanation", "advice", "guidance", "direction", "instruction", "recommendation", "suggestion", "feature"
                }
            },
            {
                CategoryType.Feedback, new HashSet<string>
                {
                    "feedback", "suggestion", "improve", "like", "dislike", "comment", "review", "opinion", "response", "reaction", "evaluation", "assessment", "critique", "testimony", "endorsement", "recommendation", "appraisal", "analysis", "report", "survey"
                }
            }
        };

        #endregion

        #region Methods

        #region GetTicketsBefore

        public string GetTicketsBefore(List<Ticket> tickets, DateTime maxCreationTime)
        {
            try
            {
                var result = string.Join("\n", tickets.Where(ticket => ticket.CreatedAt < maxCreationTime).Select(ticket=> $"{ticket.TicketId} - {ticket.CreatedAt}"));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred getting tickets before {maxCreationTime}.", ex);
            }
        }

        #endregion

        #region CategorizeTickets

        public string CategorizeTickets(List<Ticket> tickets)
        {
            try
            {
                var categorizedTickets = new Dictionary<CategoryType, int>();

                foreach (var ticket in tickets)
                {
                    var category = CategorizeTicket(ticket);
                    if (category != null)
                    {
                        if (!categorizedTickets.ContainsKey(category.Value))
                        {
                            categorizedTickets[category.Value] = 0;
                        }
                        categorizedTickets[category.Value]++;
                    }
                }

                var result = string.Join("\n", categorizedTickets.Select(category => $"{category.Key}: {category.Value}"));

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred categorizing tickets.", ex);
            }
        }

        #endregion

        #region CategorizeTicket

        private CategoryType? CategorizeTicket(Ticket ticket)
        {
            foreach (var category in KeywordsByCategoryType)
            {
                foreach (var keyword in category.Value)
                {
                    if (ticket.Description != null && ticket.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        ticket.Subject != null && ticket.Subject.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        return category.Key;
                    }
                }
            }

            return null;
        }

        #endregion

        #endregion
    }
}
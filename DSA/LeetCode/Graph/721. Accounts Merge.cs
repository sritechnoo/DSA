using System;
using System.Collections.Generic;
using System.Text;

namespace DSA.LeetCode.Graph._721AccountsMerge
{
    /*Given a list of accounts where each element accounts[i] is a list of strings, where the first element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account.

   Now, we would like to merge these accounts. Two accounts definitely belong to the same person if there is some common email to both accounts. Note that even if two accounts have the same name, they may belong to different people as people could have the same name. A person can have any number of accounts initially, but all of their accounts definitely have the same name.

   After merging the accounts, return the accounts in the following format: the first element of each account is the name, and the rest of the elements are emails in sorted order. The accounts themselves can be returned in any order.



   Example 1:

   Input: accounts = [
        ["John","johnsmith@mail.com","john_newyork@mail.com"],
        ["John","johnsmith@mail.com","john00@mail.com"],
        ["Mary","mary@mail.com"],
        ["John","johnnybravo@mail.com"]
    ]
   Output: [
        ["John","john00@mail.com","john_newyork@mail.com","johnsmith@mail.com"],
        ["Mary","mary@mail.com"],
        ["John","johnnybravo@mail.com"]
    ]
   Explanation:
   The first and second John's are the same person as they have the common email "johnsmith@mail.com".
   The third John and Mary are different people as none of their email addresses are used by other accounts.
   We could return these lists in any order, for example the answer [['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'], 
   ['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.

   Example 2:

   Input: accounts = [
        ["Gabe","Gabe0@m.co","Gabe3@m.co","Gabe1@m.co"],
        ["Kevin","Kevin3@m.co","Kevin5@m.co","Kevin0@m.co"],
        ["Ethan","Ethan5@m.co","Ethan4@m.co","Ethan0@m.co"],
        ["Hanzo","Hanzo3@m.co","Hanzo1@m.co","Hanzo0@m.co"],
        ["Fern","Fern5@m.co","Fern1@m.co","Fern0@m.co"]
    ]
   Output: [
        ["Ethan","Ethan0@m.co","Ethan4@m.co","Ethan5@m.co"],
        ["Gabe","Gabe0@m.co","Gabe1@m.co","Gabe3@m.co"],
        ["Hanzo","Hanzo0@m.co","Hanzo1@m.co","Hanzo3@m.co"],
        ["Kevin","Kevin0@m.co","Kevin3@m.co","Kevin5@m.co"],
        ["Fern","Fern0@m.co","Fern1@m.co","Fern5@m.co"]
    ]
   */

    public class Solution
    {
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();
            foreach (IList<string> account in accounts)
            {
                int accountLength = account.Count;
                string accountName = account[0];

                string firstEmail = account[1];
                for (int i = 2; i < accountLength; i++)
                {
                    string currentEmail = account[i];

                    if (adjList.ContainsKey(firstEmail) == false) { adjList.Add(firstEmail, new List<string>()); };
                    adjList[firstEmail].Add(currentEmail);

                    if (adjList.ContainsKey(currentEmail) == false) { adjList.Add(currentEmail, new List<string>()); };
                    adjList[currentEmail].Add(firstEmail);
                }
            }

            HashSet<string> visited = new HashSet<string>();
            IList<IList<string>> mergedAccounts = new List<IList<string>>();
            foreach (IList<string> account in accounts)
            {
                var accountName = account[0];
                var accountFirstEmail = account[1];
                if (!visited.Contains(accountFirstEmail))
                {
                    SortedSet<string> connectedEmails = new SortedSet<string>();
                    DFS(adjList, accountFirstEmail, connectedEmails, visited);

                    IList<string> mergedAccount = new List<string> { accountName };
                    foreach (string connectedEmail in connectedEmails)
                    {
                        mergedAccount.Add(connectedEmail);
                    }
                    mergedAccounts.Add(mergedAccount);
                }
            }
            return mergedAccounts;
        }

        private static void DFS(Dictionary<string, List<string>> adjList, string uEmail, SortedSet<string> connectedEmails, HashSet<string> visited)
        {
            if (visited.Contains(uEmail)) { return; }

            connectedEmails.Add(uEmail);
            visited.Add(uEmail);

            if (adjList.ContainsKey(uEmail))
            {
                foreach (string vEmail in adjList[uEmail])
                {
                    DFS(adjList, vEmail, connectedEmails, visited);
                }
            }
        }
    }
}

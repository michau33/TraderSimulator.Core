using System;
using Assets.Scripts.DialogueSystem;
using Assets.Scripts.Xml;

namespace BrokerSimulatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlDataProvider = new XmlDataProvider();
            var provider = new DialogueProvider(xmlDataProvider);
            
            DialogueTree newTree = new DialogueTree();
            newTree = provider.FetchTreeFromXml("Mock path");

            foreach (var treeNode in newTree.DialogueNodes)
            {
                Console.WriteLine(treeNode.Content);
            }
        }
    }
}

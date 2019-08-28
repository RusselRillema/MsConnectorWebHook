using ConnectorWebHook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using ConnectorWebHook.BLL;

namespace WebHookBuilder
{
    public partial class Form1 : Form
    {
        MessageCard _connectorPayload;
        WebHookDelivery _webHookDelivery;
        readonly string _webHookUrl = "https://outlook.office.com/webhook/8304f5e1-4c5f-48cf-8ce8-915d2d624e77@01f087f8-8805-4349-bd70-b39649b5fbfd/IncomingWebhook/6bd4fe0ade0041179aa43ad73ae3aded/a48ad334-5523-44f5-a605-9d78dc9c5705";

        public Form1()
        {
            InitializeComponent();
            _webHookDelivery = new WebHookDelivery(_webHookUrl);
            _connectorPayload = SetupConnector();
            propertyGrid1.SelectedObject = _connectorPayload;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var result = _webHookDelivery.SendWebHookPayload(_connectorPayload);
            MessageBox.Show(result);
        }

        public MessageCard SetupConnector()
        {
            MessageCard payload = new MessageCard();

            payload.type = "MessageCard";
            payload.context = "http://schema.org/extensions";
            payload.themeColor = "0076D7";
            payload.summary = "Russel Rillema started running Margins Daily Calculator";
            Section section = new Section()
            {
                activityTitle = "Russel Rillema started running Margins Daily Calculator",
                activitySubtitle = "On McCloud",
                activityImage = "https://teamsnodesample.azurewebsites.net/static/img/image5.png",
                markdown = true
            };
            Fact assignee = new Fact()
            {
                name = "Assigned to",
                value = "Unassigned"
            };
            Fact dueDate = new Fact()
            {
                name = "Due date",
                value = "Mon May 01 2017 17:07:18 GMT-0700 (Pacific Daylight Time)"
            };
            Fact status = new Fact()
            {
                name = "Status",
                value = "Not started"
            };
            section.facts.Add(assignee);
            section.facts.Add(dueDate);
            section.facts.Add(status);

            PotentialAction comment = new PotentialAction()
            {
                type = "ActionCard",
                name = "Add a comment",
                inputs = new List<Input>() { new TextInput() { id = "comment", isMultiline = false, title = "Add a comment here for this task" } },
                actions = new List<ConnectorWebHook.Models.Action>() { new ConnectorWebHook.Models.Action() { type = "HttpPOST", name = "Add comment", target = "http://..." } }
            };
            PotentialAction setDueDate = new PotentialAction()
            {
                type = "ActionCard",
                name = "Set due date",
                inputs = new List<Input>() { new DateInput() { id = "dueDate", title = "Enter a due date for this task" } },
                actions = new List<ConnectorWebHook.Models.Action>() { new ConnectorWebHook.Models.Action() { type = "HttpPOST", name = "Add comment", target = "http://..." } }
            };
            MultichoiceInput multichoiceInput = new MultichoiceInput() { id = "list", title = "Select a status", isMultiSelect = "false" };
            multichoiceInput.choices.Add(new MultichoiceInputChoice() { display = "In Progress", value = "1" });
            multichoiceInput.choices.Add(new MultichoiceInputChoice() { display = "Active", value = "2" });
            multichoiceInput.choices.Add(new MultichoiceInputChoice() { display = "Closed", value = "3" });
            PotentialAction changeStatus = new PotentialAction()
            {
                type = "ActionCard",
                name = "Change status",
                inputs = new List<Input>() { multichoiceInput },
                actions = new List<ConnectorWebHook.Models.Action>() { new ConnectorWebHook.Models.Action() { type = "HttpPOST", name = "Add comment", target = "http://..." } }
            };


            payload.sections.Add(section);
            payload.potentialAction.Add(comment);
            payload.potentialAction.Add(setDueDate);
            payload.potentialAction.Add(changeStatus);

            return payload;
        }
    }
}

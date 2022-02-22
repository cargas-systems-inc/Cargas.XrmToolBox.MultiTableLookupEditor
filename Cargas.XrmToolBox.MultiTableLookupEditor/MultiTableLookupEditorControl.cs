using Cargas.XrmToolBox.MultiTableLookupEditor.Classes;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Cargas.XrmToolBox.MultiTableLookupEditor
{
    public partial class MultiTableLookupEditorControl : PluginControlBase
    {
        private Settings pluginSettings;

        public MultiTableLookupEditorControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out pluginSettings))
            {
                pluginSettings = new Settings();
                LogWarning("Settings not found, creating new file");
            }
            else
            {
                LogInfo("Settings loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void cmbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbEntities_Leave(object sender, EventArgs e)
        {
            
        }


        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), pluginSettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (pluginSettings != null && detail != null)
            {
                pluginSettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        public void LoadEntities()
        {
            Enabled = false;
            WorkAsync(new WorkAsyncInfo("Retrieving Entities...",
                e =>
                {
                    e.Result = Service.Execute(new RetrieveAllEntitiesRequest() { EntityFilters = EntityFilters.Entity, RetrieveAsIfPublished = true });
                })
            {
                PostWorkCallBack = e =>
                {
                    var result = ((RetrieveAllEntitiesResponse)e.Result).EntityMetadata.
                        Select(m => new ObjectCollectionItem<EntityMetadata>(m.DisplayName.GetLocalOrDefaultText("N/A") + " (" + m.LogicalName + ")", m)).
                        OrderBy(r => r.DisplayName);

                    object[] items = result.Cast<object>().ToArray();

                    cmbEntities.LoadItems(items);
                    clbEntities.LoadItems(items);
                    Enabled = true;
                }
            });
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ExecuteMethod(CreateOrUpdateAttribute);
        }

        public void CreateOrUpdateAttribute()
        {
            if (!(cmbEntities.SelectedItem is ObjectCollectionItem<EntityMetadata>))
            {
                MessageBox.Show("You must select an entity to add this attribute to!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(txtSchemaName.Text?.Length > 0))
            {
                MessageBox.Show("Schema name cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(txtDisplayName.Text?.Length > 0))
            {
                MessageBox.Show("Display name cannot be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Enabled = false;

            WorkAsync(new WorkAsyncInfo("Creating Attribute...", e =>
            {
                // https://docs.microsoft.com/en-us/powerapps/developer/data-platform/webapi/multitable-lookup

                ObjectCollectionItem<EntityMetadata> sourceEntity = (ObjectCollectionItem<EntityMetadata>)cmbEntities.SelectedItem;

                List<OneToManyRelationshipMetadata> relationships = new List<OneToManyRelationshipMetadata>();

                foreach (object selectedObject in clbEntities.CheckedItems)
                {
                    if (selectedObject is ObjectCollectionItem<EntityMetadata> entity)
                    {
                        string schemaName = string.Format("{0}_{1}_{2}", txtSchemaName, sourceEntity.Value.LogicalName, entity.Value.LogicalName);
                        LogInfo("Adding relationship: '{0}'", schemaName);

                        relationships.Add(new OneToManyRelationshipMetadata
                        {
                            SchemaName = schemaName,
                            ReferencedEntity = entity.Value.LogicalName,
                            ReferencingEntity = sourceEntity.Value.LogicalName,
                        });
                    }
                }

                if (relationships.Count == 0)
                {
                    MessageBox.Show("At least one entity must be selected to create an attribute!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(string.Format("Relationships: {0}", relationships.Count), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Result = Service.Execute(new CreatePolymorphicLookupAttributeRequest
                {
                    OneToManyRelationships = relationships.ToArray(),
                    Lookup = new LookupAttributeMetadata()
                    {
                        Description = new Microsoft.Xrm.Sdk.Label(txtDescription.Text, 1033),
                        DisplayName = new Microsoft.Xrm.Sdk.Label(txtDisplayName.Text, 1033),
                        SchemaName = txtSchemaName.Text,
                    }
                });
            })
            {
                PostWorkCallBack = e =>
                {
                    LogInfo("CreateOrUpdateCallback");
                    CreatePolymorphicLookupAttributeResponse resp = (CreatePolymorphicLookupAttributeResponse)e.Result;
                    LogInfo(resp.AttributeId.ToString());
                    Enabled = true;
                }
            });
        }
    }
}
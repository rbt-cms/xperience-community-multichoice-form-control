using Kentico.Xperience.Admin.Base;

using XperienceCommunity.MultiChoiceFormControl;

[assembly: CMS.AssemblyDiscoverable]
[assembly: CMS.RegisterModule(typeof(MultiChoiceFormControlModule))]

// Adds a new application category 
[assembly: UICategory(MultiChoiceFormControlModule.CUSTOM_CATEGORY, "Custom", Icons.CustomElement, 100)]

namespace XperienceCommunity.MultiChoiceFormControl
{
    internal class MultiChoiceFormControlModule : AdminModule
    {
        public const string CUSTOM_CATEGORY = "xperienceCommunity.MultiChoice.Formcontorl";

        public MultiChoiceFormControlModule()
            : base("xperiencecommunity.multichoiceformcontrol")
        {
        }

        protected override void OnInit()
        {
            base.OnInit();

            // Makes the module accessible to the admin UI
            RegisterClientModule("xperiencecommunity", "multichoiceformcontrol");
        }
    }
}
